using Microsoft.AspNetCore.Mvc;
using WebCafePoly.Models;
using System.Linq;

namespace WebCafePoly.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly PolyCafeContext _context;

        public DangNhapController(PolyCafeContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("MaNhanVien") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Login(string email, string matkhau)
        {
            var nv = _context.NhanViens.FirstOrDefault(x =>
                x.Email == email &&
                x.MatKhau == matkhau &&
                x.TrangThai == true);

            if (nv == null)
            {
                ViewBag.Loi = "Sai email hoặc mật khẩu";
                return View();
            }
            // Lưu thông tin đăng nhập
            HttpContext.Session.SetString("MaNhanVien", nv.MaNhanVien);
            HttpContext.Session.SetString("HoTen", nv.HoTen);
            HttpContext.Session.SetString("VaiTro", nv.VaiTro.ToString());

            // Chuyển về trang chủ
            return RedirectToAction("Index", "Home");
            //return View();

        }
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
