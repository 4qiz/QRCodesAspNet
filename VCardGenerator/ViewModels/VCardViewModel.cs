using System.ComponentModel.DataAnnotations;

namespace VCardGenerator.ViewModels
{
    public class VCardViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string SecondName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber{ get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email{ get; set; } = string.Empty;
        [Required]
        public string Company{ get; set; } = string.Empty;
        [Required]
        public string Job{ get; set; } = string.Empty;
        [Required]
        public string Street{ get; set; } = string.Empty;
        [Required]
        public string City{ get; set; } = string.Empty;
        [Required]
        public string Country{ get; set; } = string.Empty;
        [Required]
        public string WebSite{ get; set; } = string.Empty;
    }
}
