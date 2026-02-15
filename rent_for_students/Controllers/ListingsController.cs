using Microsoft.AspNetCore.Mvc;
using rent_for_students.Application.Commands;
using rent_for_students.Domain.Services;
using rent_for_students.Mapping;
using rent_for_students.ViewModels;

namespace rent_for_students.Controllers
{
    public class ListingsController : Controller
    {
        private readonly CommandDispatcher _dispatcher;
        private readonly HousingService _housingService;

        public ListingsController(CommandDispatcher dispatcher, HousingService housingService)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _housingService = housingService ?? throw new ArgumentNullException(nameof(housingService));
        }

        // GET: /Listings
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ListingFilterViewModel filter, CancellationToken ct)
        {
            // Базова валідація query-моделі
            if (!ModelState.IsValid)
            {
                // якщо query “кривий” — просто покажемо порожній список з дефолтами
                var fallbackVm = new ListingListViewModel { Filter = new ListingFilterViewModel() };
                return View(fallbackVm);
            }

            var criteria = ListingMapper.ToCriteria(filter);

            var cmd = new SearchListingsCommand(_housingService, criteria);
            var listings = await _dispatcher.DispatchAsync(cmd, ct);

            var vm = new ListingListViewModel
            {
                Filter = filter,
                Listings = listings
            };

            return View(vm);
        }

        // GET: /Listings/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id, CancellationToken ct)
        {
            if (id == Guid.Empty) return BadRequest();

            var cmd = new GetListingDetailsCommand(_housingService, id);
            var listing = await _dispatcher.DispatchAsync(cmd, ct);

            if (listing is null) return NotFound();

            return View(new ListingDetailsViewModel { Listing = listing });
        }

        // GET: /Listings/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ListingCreateViewModel());
        }

        // POST: /Listings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingCreateViewModel form, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            // додаткова “мʼяка” валідація (не обов’язково, але часто треба):
            if (form.MinPriceGreaterThanMax())
            {
                ModelState.AddModelError(string.Empty, "Некоректні значення ціни.");
                return View(form);
            }

            var entity = ListingMapper.ToEntity(form);

            var cmd = new CreateListingCommand(_housingService, entity);
            var createdId = await _dispatcher.DispatchAsync(cmd, ct);

            // Після створення — на Details
            return RedirectToAction(nameof(Details), new { id = createdId });
        }
    }

    // v0.3 helper extension (щоб не плодити зайві класи)
    internal static class ListingCreateVmExtensions
    {
        public static bool MinPriceGreaterThanMax(this ListingCreateViewModel vm)
        {
            // зараз у CreateVM немає Min/Max, лишив хук якщо захочеш додати
            return false;
        }
    }
}
