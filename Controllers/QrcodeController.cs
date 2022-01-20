using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class QrcodeController : Controller
    {
        // GET: Qrcode
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index( string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generatekod = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrkod = generatekod.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap picture=qrkod.GetGraphic(10))
                {
                    picture.Save(ms,ImageFormat.Png);
                    ViewBag.qrcodeimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}