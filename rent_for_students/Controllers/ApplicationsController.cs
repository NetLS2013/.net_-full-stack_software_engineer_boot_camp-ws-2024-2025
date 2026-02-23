using Microsoft.AspNetCore.Mvc;
using rent_for_students.Application.Common;
using rent_for_students.Application.Commands;
using rent_for_students.Application.UseCases;
using rent_for_students.Domain.Entities;
using rent_for_students.ViewModels;

namespace rent_for_students.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly CommandDispatcher _dispatcher;
        private readonly IListingUseCaseMediator _listingMediator;
        private readonly IApplicationUseCaseMediator _applicationMediator;

        public ApplicationsController(
            CommandDispatcher dispatcher,
            IListingUseCaseMediator listingMediator,
            IApplicationUseCaseMediator applicationMediator)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _listingMediator = listingMediator ?? throw new ArgumentNullException(nameof(listingMediator));
            _applicationMediator = applicationMediator ?? throw new ArgumentNullException(nameof(applicationMediator));
        }

        [HttpGet]
        public async Task<IActionResult> Apply(Guid listingId, CancellationToken ct)
        {
            if (listingId == Guid.Empty) return BadRequest();

            var detailsCmd = new GetListingDetailsCommand(_listingMediator, listingId);
            var detailsResult = await _dispatcher.DispatchAsync(detailsCmd, ct);
            if (!detailsResult.IsSuccess || detailsResult.Value is null || !detailsResult.Value.IsActive)
            {
                return NotFound();
            }

            ViewData["ListingTitle"] = detailsResult.Value.Title;
            return View(new RentalApplicationCreateViewModel { ListingId = listingId });
        }

        [HttpGet]
        public async Task<IActionResult> List(Guid listingId, CancellationToken ct)
        {
            if (listingId == Guid.Empty) return BadRequest();

            var detailsCmd = new GetListingDetailsCommand(_listingMediator, listingId);
            var detailsResult = await _dispatcher.DispatchAsync(detailsCmd, ct);
            if (!detailsResult.IsSuccess || detailsResult.Value is null)
            {
                return NotFound();
            }

            var cmd = new GetListingApplicationsCommand(_applicationMediator, listingId);
            var result = await _dispatcher.DispatchAsync(cmd, ct);
            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return View(new ListingApplicationsViewModel
            {
                ListingId = listingId,
                ListingTitle = detailsResult.Value.Title,
                Applications = result.Value ?? Array.Empty<RentalApplication>()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(RentalApplicationCreateViewModel model, CancellationToken ct)
        {
            await FillListingTitleAsync(model.ListingId, ct);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var applicant = new RentalApplication
            {
                ApplicantName = model.ApplicantName.Trim(),
                Phone = model.Phone.Trim(),
                Email = model.Email.Trim(),
                Message = string.IsNullOrWhiteSpace(model.Message) ? null : model.Message.Trim()
            };

            var cmd = new CreateRentalApplicationCommand(_applicationMediator, model.ListingId, applicant);
            var result = await _dispatcher.DispatchAsync(cmd, ct);
            if (!result.IsSuccess)
            {
                if (result.ErrorCode == ErrorCodes.ListingNotAvailable)
                {
                    return NotFound();
                }

                ModelState.AddModelError(string.Empty, result.Message ?? "Failed to submit application.");
                return View(model);
            }

            TempData["ListingMessage"] = "Application submitted. Status: Approved.";
            return RedirectToAction("Details", "Listings", new { id = model.ListingId });
        }

        private async Task FillListingTitleAsync(Guid listingId, CancellationToken ct)
        {
            if (listingId == Guid.Empty)
            {
                return;
            }

            var detailsCmd = new GetListingDetailsCommand(_listingMediator, listingId);
            var detailsResult = await _dispatcher.DispatchAsync(detailsCmd, ct);
            if (detailsResult.IsSuccess && detailsResult.Value is not null)
            {
                ViewData["ListingTitle"] = detailsResult.Value.Title;
            }
        }
    }
}
