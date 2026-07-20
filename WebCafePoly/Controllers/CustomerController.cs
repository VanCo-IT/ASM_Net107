using Microsoft.AspNetCore.Mvc;
using WebCafePoly.Models;
namespace WebCafePoly.Controllers
{
    public class CustomerController : Controller
    {
        // Kiểm tra đăng nhập trước khi vào các trang Customer
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("MaKhachHang") == null)
            {
                context.Result = RedirectToAction("DangNhap", "GuestAccount");
            }

            base.OnActionExecuting(context);
        }

        // Trang chủ Customer
        public IActionResult Index()
        {
            ViewBag.HoTen = HttpContext.Session.GetString("HoTenKhachHang");
            return View();
        }
        private readonly PolyCafeContext _context;

        public CustomerController(PolyCafeContext context)
        {
            _context = context;
        }
        public IActionResult HoSoKhachHang()
        {
            string maKH = HttpContext.Session.GetString("MaKhachHang");

            var kh = _context.KhachHangs.FirstOrDefault(x => x.MaKhachHang == maKH);

            if (kh == null)
            {
                return RedirectToAction("DangNhap", "GuestAccount");
            }

            return View(kh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return View(khachHang);
            }

            var kh = _context.KhachHangs
                .FirstOrDefault(x => x.MaKhachHang == khachHang.MaKhachHang);

            if (kh == null)
            {
                return NotFound();
            }

            kh.HoTen = khachHang.HoTen;
            kh.Email = khachHang.Email;
            kh.SoDienThoai = khachHang.SoDienThoai;
            kh.DiaChi = khachHang.DiaChi;
            kh.MatKhau = khachHang.MatKhau;

            _context.SaveChanges();

            ViewBag.ThongBao = "Cập nhật thành công";

            return View(kh);
        }
    }
}
