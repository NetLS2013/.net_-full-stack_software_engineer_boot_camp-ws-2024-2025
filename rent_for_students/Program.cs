using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_for_students.Application.Commands;
using rent_for_students.Application.Notifications;
using rent_for_students.Application.UseCases;
using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Flyweight;
using rent_for_students.Domain.Services;
using rent_for_students.Infrastructure.Data;
using rent_for_students.Infrastructure.Notifications;
using rent_for_students.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(cs);
});

builder.Services.AddScoped<IHousingRepository, EfHousingRepository>();
builder.Services.AddScoped<IRentalApplicationRepository, EfRentalApplicationRepository>();
builder.Services.AddScoped<IRentalApplicationProfileRepository, EfRentalApplicationProfileRepository>();
builder.Services.AddScoped<HousingService>();

builder.Services.AddScoped<INotificationService, LogNotificationService>();
builder.Services.AddScoped<IListingUseCaseMediator, ListingUseCaseMediator>();
builder.Services.AddScoped<IApplicationUseCaseMediator, ApplicationUseCaseMediator>();

builder.Services.AddScoped<CommandDispatcher>();

builder.Services.AddSingleton<RoomTypeFlyweightFactory>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

app.Run();
