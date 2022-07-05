using Faculty_Information_System_MVC_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Faculty_Information_System_MVC_Layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }





        public IActionResult Login()
        {
            IEnumerable<RoleLookupVM> roleList = null;


            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:26686/api/RoleLookup");

            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                roleList = JsonConvert.DeserializeObject<List<RoleLookupVM>>(data.Result);
            }

            SelectList sl = new SelectList(roleList, "RoleLookupId", "Role");
            ViewBag.roleData = sl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVM login)
        {
            MyJwtToken jwttoken;

            using (HttpClient client = new HttpClient())
            {
                if (login.RoleLookupId == 1)
                {
                    Uri uri = new Uri("https://localhost:44339/api/administrator/" + login.UserName + "/" + login.Password);
                    var result = client.GetAsync(uri).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> data = result.Content.ReadAsStringAsync();
                        jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
                        Response.Cookies.Append("jwttoken", jwttoken.Token);
                        //HttpContext.Session.SetString("token", jwttoken.Token);
                        Response.Cookies.Append("username", login.UserName);
                        ViewBag.message = jwttoken.Token;
                    }
                    else
                    {
                        ViewBag.message = result.ReasonPhrase;
                    }
                    return RedirectToAction("index", "administrator");
                }
                else if (login.RoleLookupId == 2)
                {

                    Uri uri = new Uri("https://localhost:44339/api/faculty/" + login.UserName + "/" + login.Password);
                    var result = client.GetAsync(uri).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> data = result.Content.ReadAsStringAsync();
                        jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
                        Response.Cookies.Append("jwttoken", jwttoken.Token);
                        //HttpContext.Session.SetString("token", jwttoken.Token);
                        Response.Cookies.Append("username", login.UserName);
                        ViewBag.message = jwttoken.Token;
                    }
                    else
                    {
                        ViewBag.message = result.ReasonPhrase;
                    }
                    return RedirectToAction("index", "faculty");
                }

                else
                {
                    Uri uri = new Uri("https://localhost:44339/api/faculty/" /*+ login.UserName + "/" + login.Password*/);
                    var result = client.GetAsync(uri).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> data = result.Content.ReadAsStringAsync();
                        jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
                        Response.Cookies.Append("jwttoken", jwttoken.Token);
                        //HttpContext.Session.SetString("token", jwttoken.Token);
                        Response.Cookies.Append("username", login.UserName);
                        ViewBag.message = jwttoken.Token;
                    }
                    else
                    {
                        ViewBag.message = result.ReasonPhrase;
                    }
                    return RedirectToAction("index", "Student");
                }
            }
        }













        //public IActionResult Login()
        //{
        //    IEnumerable<RoleLookupVM> roleList = null;


        //    HttpClient client = new HttpClient();
        //    Uri uri = new Uri("http://localhost:60659/api/RoleLookup");

        //    var result = client.GetAsync(uri).Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        Task<string> data = result.Content.ReadAsStringAsync();
        //        roleList = JsonConvert.DeserializeObject<List<RoleLookupVM>>(data.Result);
        //    }

        //    SelectList sl = new SelectList(roleList, "RoleLookupId", "Role");
        //    ViewBag.roleData = sl;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(LoginVM login)
        //{
        //    MyJwtToken jwttoken;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        if (login.RoleLookupId == 1)
        //        {
        //            Uri uri = new Uri("https://localhost:44391/api/Artist/" + login.UserName + "/" + login.Password);
        //            var result = client.GetAsync(uri).Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                Task<string> data = result.Content.ReadAsStringAsync();
        //                jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
        //                Response.Cookies.Append("jwttoken", jwttoken.Token);
        //                //HttpContext.Session.SetString("token", jwttoken.Token);
        //                Response.Cookies.Append("username", login.UserName);
        //                ViewBag.message = jwttoken.Token;
        //            }
        //            else
        //            {
        //                ViewBag.message = result.ReasonPhrase;
        //            }
        //            return RedirectToAction("index", "gig");
        //        }
        //        else if (login.RoleLookupId == 2)
        //        {

        //            Uri uri = new Uri("https://localhost:44391/api/User/" + login.UserName + "/" + login.Password);
        //            var result = client.GetAsync(uri).Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                Task<string> data = result.Content.ReadAsStringAsync();
        //                jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
        //                Response.Cookies.Append("jwttoken", jwttoken.Token);
        //                //HttpContext.Session.SetString("token", jwttoken.Token);
        //                Response.Cookies.Append("username", login.UserName);
        //                ViewBag.message = jwttoken.Token;
        //            }
        //            else
        //            {
        //                ViewBag.message = result.ReasonPhrase;
        //            }
        //            return RedirectToAction("index", "user");
        //        }
        //        return View();
        //    }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}