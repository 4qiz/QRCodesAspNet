
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using VCardGenerator.ViewModels;
using ZXing;
using ZXing.Windows.Compatibility;

namespace VCardGenerator.Controllers
{
    public class QRScannerController : Controller
    {
        // GET: QRScannerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(QRScannerViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var stream = new MemoryStream();
                await model.QRCode.CopyToAsync(stream);

                var bitmap = new Bitmap(stream);
                BitmapLuminanceSource source = new BitmapLuminanceSource(bitmap);
                var reader = new BarcodeReaderGeneric();
                var decodedValue = reader.Decode(source);
                model.Text = decodedValue.Text;
            }

            return View(model);
        }
    }
}
