using Microsoft.AspNetCore.Mvc;
using MvcStok.Entity;


namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokContext db=new MvcDbStokContext();

        public IActionResult Index()
        {
            var degerler=db.Tblkategorilers.ToList();
            return View(degerler);
        }
        public IActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKategori(Tblkategoriler p1)
        {
           db.Tblkategorilers.Add(p1);
           db.SaveChanges();
           return View();
        }
        public IActionResult Sil(int id)
        {
            var kategori=db.Tblkategorilers.Find(id);
            db.Tblkategorilers.Remove(kategori);
            db.SaveChanges();
            return View();
        }
    }
}
