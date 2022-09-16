using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wedduykhanh.Models;

namespace wedduykhanh.Controllers
{
    public class HomeController : Controller
    {

        Model1 db = new Model1();
        public ActionResult Index()
        {
            Model1 db = new Model1();
            List<SANPHAM> sanpham = db.SANPHAMs.ToList();
            return View(sanpham);
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        //[ChildActionOnly]
        public ActionResult loadCategory()
        {
            Model1 db = new Model1();
            List<LOAI_SP> listloai_sp = db.LOAI_SP.ToList();

            return PartialView(listloai_sp);
        }

        public ActionResult loadlistdanhmuc(int id_loaisanpham)
        {
            Model1 db = new Model1();
            List<SANPHAM> danhmucsanpham = (from d in db.SANPHAMs where d.MALOAI== id_loaisanpham select d ).ToList();

            return View(danhmucsanpham);
           
        }
       

    }
}