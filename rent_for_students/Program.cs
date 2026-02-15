using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_for_students.Application.Commands;
using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Services;
using rent_for_students.Infrastructure.Data;
using rent_for_students.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC + базові security defaults для форм
builder.Services.AddControllersWithViews(options =>
{
    // Автоматична перевірка antiforgery для небезпечних HTTP методів (POST/PUT/DELETE)
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// DbContext (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(cs);
});

// DI: Repository + Receiver(Service) + Invoker(Dispatcher)
builder.Services.AddScoped<IHousingRepository, EfHousingRepository>();
builder.Services.AddScoped<HousingService>();
builder.Services.AddScoped<CommandDispatcher>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// (Поки що без auth, але порядок правильний)
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Авто-створення БД
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.Run();
