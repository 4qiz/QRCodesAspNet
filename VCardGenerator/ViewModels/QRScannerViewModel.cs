using System.ComponentModel.DataAnnotations;

namespace VCardGenerator.ViewModels
{
    public class QRScannerViewModel
    {
        [Required]
        public IFormFile QRCode { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
    }
}
