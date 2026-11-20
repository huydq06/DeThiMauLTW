using DuongQuangHuy_241230742.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DuongQuangHuy_241230742.Controllers
{
    public class HomeController : Controller

    {
        private readonly QlnhaSachContext _context;
        public HomeController(QlnhaSachContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dsSach = _context.Saches.Where(s=>s.Gia!=null && s.Gia>=100).ToList();
            return View();
        }

        public IActionResult LocSachTheoTheLoai(int maTl)
        {
            var theLoai = _context.TheLoais.Find(maTl);
            ViewBag.TenTheLoai = theLoai != null ? theLoai.TenTl : "Danh sách sách";
            var dsSach = _context.Saches.Where(s=> s.MaTl == maTl).ToList();
            return PartialView("_DanhSachSachPartial", dsSach);
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(Sach);
        }
    }
}
