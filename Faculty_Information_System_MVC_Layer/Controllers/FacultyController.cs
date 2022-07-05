using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Faculty_Information_System_MVC_Layer.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;


namespace Faculty_Information_System_MVC_Layer.Controllers
{
    public class FacultyController : Controller
    {
       /*public IActionResult Searchfac(IFormCollection admin)
       {
           HttpClient client = new();
           IEnumerable<AdministratorVM> adminList = null;
           string adminName = admin["txtFacultyName"];

           Uri uri = new ("http://localhost:26686/api/Administrators/" + adminName);
           var result = client.GetAsync(uri).Result;
           if (result.IsSuccessStatusCode)
           {
               Task<string> data = result.Content.ReadAsStringAsync();
               adminList = JsonConvert.DeserializeObject<IEnumerable<AdministratorVM>>(data.Result);
           }
           return View("Index", adminList);
       }*/

        


        

        public IActionResult Delete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Faculties/" + id.ToString());
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

        public IActionResult Index()
        {
            IEnumerable<FacultyVM> facultyList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Faculties");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                facultyList = JsonConvert.DeserializeObject<IEnumerable<FacultyVM>>(data.Result);
            }
            return View(facultyList);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FacultyVM fac)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Faculties");
            var result = client.PostAsJsonAsync(uri, fac).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new();
            FacultyVM admin = null;

            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Faculties/" + id);
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                admin = JsonConvert.DeserializeObject<FacultyVM>(data.Result);
                return View(admin);
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Edit(FacultyVM fac)
        {
            HttpClient client = new();

            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Faculties/" + fac.FacultyId.ToString());
            var result = client.PutAsJsonAsync(uri, fac).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();

        }



    }
}
