using Microsoft.AspNetCore.Mvc;
using MvcStok.Entity;

namespace MvcStok.Controllers
{
    public class SatısController : Controller
    {
        MvcDbStokContext db=new MvcDbStokContext();
        public IActionResult Index()
        {
            var degerler=db.Tblsatislars.ToList();
            return View(degerler);
        }
    }
}
