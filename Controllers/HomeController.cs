using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            Dachi DojoDachi = new Dachi();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            
            return View(DojoDachi);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Dachi DojoDachi = GetDachiFromSession();
            DojoDachi.Feed();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return View("Index",DojoDachi);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Dachi DojoDachi = GetDachiFromSession();
            DojoDachi.Play();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return View("Index",DojoDachi);
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Dachi DojoDachi = GetDachiFromSession();
            DojoDachi.Work();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return View("Index",DojoDachi);
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Dachi DojoDachi = GetDachiFromSession();
            DojoDachi.Sleep();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return View("Index",DojoDachi);
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            Dachi DojoDachi = GetDachiFromSession();
            DojoDachi.Reset();
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return View("Index",DojoDachi);
        }

        [HttpGet]
        [Route("ajaxcall/{cmd}")]
        public JsonResult AjaxCall(string cmd)
        {
            Dachi DojoDachi = GetDachiFromSession();
            switch(cmd) {
                case "feed":  DojoDachi.Feed();   break;
                case "play":  DojoDachi.Play();   break;
                case "work":  DojoDachi.Work();   break;
                case "sleep":  DojoDachi.Sleep();   break;
                default: DojoDachi.Reset(); break;
            }
            HttpContext.Session.SetString("dachi", JsonConvert.SerializeObject(DojoDachi));
            return Json(DojoDachi);
        }

        private Dachi GetDachiFromSession() {
            Dachi DojoDachi = new Dachi();
            if(HttpContext.Session.GetString("dachi")!=null) {
                string dachiStr = HttpContext.Session.GetString("dachi");
                DojoDachi = JsonConvert.DeserializeObject<Dachi>(dachiStr);
            }
            return DojoDachi;
        }


        private object JavaScriptSerializer()
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
