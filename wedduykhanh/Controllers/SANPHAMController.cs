using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wedduykhanh.Models;
namespace wedduykhanh.Controllers
{
    public class SANPHAMController : Controller
    {
        // GET: SANPHAM
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Chitiet(String id)
        {
            Model1 db = new Model1();
            SANPHAM sanpham = db.SANPHAMs.FirstOrDefault(x => x.MASP == id);
            return View(sanpham);
            
        }


       

    }
}