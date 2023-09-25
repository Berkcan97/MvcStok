using Microsoft.AspNetCore.Mvc;
using MvcStok.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {

        MvcDbStokContext db=new MvcDbStokContext();

        public IActionResult Index()
        {
            var degerler=db.Tblmusterilers.ToList();
            return View(degerler);
        }
        public IActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniMusteri(Tblmusteriler m1)
        {
            db.Tblmusterilers.Add(m1);
            db.SaveChanges();
            return View();
        }
    }
}
