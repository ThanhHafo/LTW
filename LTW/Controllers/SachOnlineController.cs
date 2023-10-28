using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW.Models;
using PagedList;
using PagedList.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }

        // GET: SachOnline
        public ActionResult Index(int ? page)
        {
            int iSize = 6;
            int iPageNum = (page ?? 1);
            var listSachMoi = LaySachMoi(20);
            return View(listSachMoi.ToPagedList(iPageNum, iSize));
        }

        public ActionResult NavPartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }

        public ActionResult SachTheoChuDe(int iMaCD, int ? page)
        {
            ViewBag.MaCD = iMaCD;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaCD == iMaCD select s;
            return View(sach.ToPagedList(iPageNum,iSize));
        }

        public ActionResult SachTheoNhaXuatBan(int iMaXB, int? page)
        {
            ViewBag.MaXB = iMaXB;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaNXB == iMaXB select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }
    }
}