using Microsoft.AspNetCore.Mvc;
using QRCoder;
using VCardGenerator.ViewModels;

namespace VCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(VCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                string vCardData = $"""
                    BEGIN:VCARD
                    VERSION:2.1
                    N:{model.SecondName} {model.FirstName}
                    FN:{model.SecondName} {model.FirstName}
                    ORG:{model.Company}
                    TITLE:{model.Company}
                    TEL;HOME;VOICE:{model.PhoneNumber}
                    ADR;HOME:;;{model.Street};{model.City};;;{model.Country}
                    EMAIL:{model.Email}
                    END:VCARD
                    """;
                // Generate QR code
                using QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vCardData, QRCodeGenerator.ECCLevel.Q);

                using PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

                byte[] qrCodeImage = qrCode.GetGraphic(20);

                string qrCodeBase64 = Convert.ToBase64String(qrCodeImage);

                ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;
            }

            return View();
        }
    }
}
