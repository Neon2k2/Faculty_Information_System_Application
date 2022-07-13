using Faculty_Information_System_MVC_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Faculty_Information_System_MVC_Layer.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }





        public IActionResult Login()
        {
/*            IEnumerable<RoleLookupVM> roleList = null;*/

/*
            HttpClient client = new HttpClient();
            Uri uri = new Uri("http://localhost:26686/api/RoleLookup");

            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                roleList = JsonConvert.DeserializeObject<List<RoleLookupVM>>(data.Result);
            }

            SelectList sl = new SelectList(roleList, "RoleLookupId", "Role");
            ViewBag.roleData = sl;*/
            return View();
        }



        [HttpPost]
        public IActionResult Login(UserVM login)
        {
            MyJwtToken jwttoken;

            using (HttpClient client = new HttpClient())
            {

                Uri uri = new Uri("https://localhost:44339/api/Users/" + login.UserName + "/" + login.Password);
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

                if (login.RoleLookupId == 1)
                {

                    return RedirectToAction("index", "administrator");
                }
                else if (login.RoleLookupId == 2)
                {
                    return RedirectToAction("index", "faculty");
                }

                else
                {
                    return RedirectToAction("index", "Student");
                }
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("username");
            return RedirectToAction("login");
        }
    }
}

