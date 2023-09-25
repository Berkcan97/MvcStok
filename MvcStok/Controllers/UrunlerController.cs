using Microsoft.AspNetCore.Mvc;
using MvcStok.Entity;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        MvcDbStokContext db=new MvcDbStokContext();

        public IActionResult Index()
        {
            var degerler=db.Tblurunlers.ToList();
            return View(degerler);
        }

        public IActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniUrun(Tblurunler u1)
        {
            db.Tblurunlers.Add(u1);
            db.SaveChanges();
            return View();
        }
       
        
    }
}
