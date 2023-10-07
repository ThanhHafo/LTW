using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW.Models;
using System.Data.SqlClient;

namespace LTW.Controllers
{

    public class SachOnlineController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();


        // GET: SachOnline
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd; 
            return PartialView(listChuDe);
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }

        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Soluongban).Take(count).ToList();
        }

        private List<SACH> LaySachMoi(int count)
        { 
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }

    }
}