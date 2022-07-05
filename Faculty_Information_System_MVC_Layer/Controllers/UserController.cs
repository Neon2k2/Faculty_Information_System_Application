using Faculty_Information_System_MVC_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /*public IActionResult Search(IFormCollection admin)
        {
            HttpClient client = new();
            IEnumerable<AdministratorVM> adminList = null;
            string adminName = admin["txtAdminName"];

            Uri uri = new("http://localhost:26686/api/Administrators/" + adminName);
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                adminList = JsonConvert.DeserializeObject<IEnumerable<AdministratorVM>>(data.Result);
            }
            return View("Index", adminList);
        }*/

        public IActionResult UserDelete(int id)
        {
            HttpClient client = new HttpClient();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Users/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        
    }
}
