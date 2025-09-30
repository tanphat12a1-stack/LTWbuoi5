using LTWeb05_Bai02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb05_Bai02.Controllers
{
    public class HomeController : Controller
    {
        DuLieu csdl = new DuLieu();
        public ActionResult HienThiNhanVien()
        {
            List<Employee> ds = csdl.dsNV;
            return View(ds);
        }

        public ActionResult HienThiPhongBan()
        {
            List<Department> ds = csdl.dsPB;
            return View(ds);
        }

        public ActionResult ChiTietPhongBan(int id)
        {
            var pb = csdl.dsPB.FirstOrDefault(x => x.MaPg == id);
            if (pb == null) return HttpNotFound();

            int soNV = csdl.dsNV.Count(x => x.MaPg == id);
            ViewBag.SoNV = soNV;

            return View(pb);
        }

        public ActionResult NhanVienTheoPhong(int id)
        {
            var pb = csdl.dsPB.FirstOrDefault(x => x.MaPg == id);
            if (pb == null) return HttpNotFound();

            var ds = csdl.dsNV.Where(x => x.MaPg == id).ToList();
            ViewBag.TenPg = pb.TenPg;

            return View(ds);
        }
    }
}