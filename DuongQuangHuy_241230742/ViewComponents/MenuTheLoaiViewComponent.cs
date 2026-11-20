using DuongQuangHuy_241230742.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DuongQuangHuy_241230742.ViewComponents
{
    public class MenuTheLoaiViewComponent
    {
        public class MenuTheLoaiViewComponent: ViewComponents
        {
            private readonly QlnhaSachContext _context;
            public MenuTheLoaiViewComponent(QlnhaSachContext context)
            {
                _context = context;
            }
            public IViewComponentResult Invoke()
            {
                var dsTheLoai = _context.TheLoais.ToList();
                return View(dsTheLoai);
            }
        }
    }
}
