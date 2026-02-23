using System.ComponentModel.DataAnnotations;

namespace rent_for_students.ViewModels
{
    public class RentalApplicationCreateViewModel
    {
        [Required]
        public Guid ListingId { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string ApplicantName { get; set; } = string.Empty;

        [Required]
        [StringLength(40)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Message { get; set; }
    }
}
