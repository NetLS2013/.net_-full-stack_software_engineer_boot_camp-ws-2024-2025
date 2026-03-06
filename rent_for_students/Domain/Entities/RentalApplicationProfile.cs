using System.ComponentModel.DataAnnotations;

namespace rent_for_students.Domain.Entities
{
    // PROMPT v1.3: Prototype source for reusable rental application payloads.
    public class RentalApplicationProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string ProfileName { get; set; } = string.Empty;

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

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        // PROMPT v1.3: Explicit prototype contract (no ICloneable ambiguity).
        public RentalApplication CreateApplicationPrototype(Guid listingId)
        {
            return new RentalApplication
            {
                Id = Guid.NewGuid(),
                ListingId = listingId,
                ApplicantName = ApplicantName,
                Phone = Phone,
                Email = Email,
                Message = Message,
                CreatedAtUtc = DateTime.UtcNow
            };
        }
    }
}
