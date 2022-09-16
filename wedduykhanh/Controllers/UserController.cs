using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wedduykhanh.Models;

namespace wedduykhanh.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModels model)
        {
            if (ModelState.IsValid)
            {
                UserManager manager = new UserManager();

                if (manager.checkUsername(model.Username) && manager.checkEmail(model.Email))
                {
                    KHACHHANG user = new KHACHHANG
                    {

                        TenKH = model.Username,
                        MK = Encrypt.MD5Hash(model.Pass),
                        Email = model.Email,
                        Ngaysinh = model.DateOfBirth,
                        SDT = model.PhoneNumber,
                        Diachi = model.Address
                    };
                    db.KHACHHANGs.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Index","Home");
                    
                }
                else
                {
                    ViewBag.Error = "tài khoản và gmail đã tồn tại";
                    return View();
                    
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModels user)
        {
            if (ModelState.IsValid)
            {
                //kiem tra tai khoan 

                UserManager manager = new UserManager();
                if (manager.checkLogin(user.Email, user.Pass))
                {
                    ViewBag.Success = "ok";
                    Session["user"] = user.Email;
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ViewBag.Error="Incorrect email or Pass";
                    return View();
                }
                
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("index", "Home");

        }
    }
}