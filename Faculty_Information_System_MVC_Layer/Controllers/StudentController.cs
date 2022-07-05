using Faculty_Information_System_MVC_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Faculty_Information_System_MVC_Layer.Controllers
{
    public class Student : Controller
    {
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

        public IActionResult ShowFac()
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

        public IActionResult ShowCourse()
        {
            IEnumerable<CourseVM> courseList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Courses");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                courseList = JsonConvert.DeserializeObject<IEnumerable<CourseVM>>(data.Result);
            }
            return View(courseList);
        }

        public IActionResult showCourTaught()
        {
            IEnumerable<CourseTaughtVM> courTautList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/CourseTaughts");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                courTautList = JsonConvert.DeserializeObject<IEnumerable<CourseTaughtVM>>(data.Result);
            }
            return View(courTautList);
        }

        public IActionResult ShowDept()
        {
            IEnumerable<DepartmentVM> DeptList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Departments");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                DeptList = JsonConvert.DeserializeObject<IEnumerable<DepartmentVM>>(data.Result);
            }
            return View(DeptList);
        }

        public IActionResult ShowGrant()
        {
            IEnumerable<GrantVM> GrantList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Grants");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                GrantList = JsonConvert.DeserializeObject<IEnumerable<GrantVM>>(data.Result);
            }
            return View(GrantList);
        }

        public IActionResult ShowSubject()
        {
            IEnumerable<SubjectVM> SubjectList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Subjects");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                SubjectList = JsonConvert.DeserializeObject<IEnumerable<SubjectVM>>(data.Result);
            }
            return View(SubjectList);
        }

        public IActionResult ShowPublish()
        {
            IEnumerable<PublicationVM> PublishList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Publications");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                PublishList = JsonConvert.DeserializeObject<IEnumerable<PublicationVM>>(data.Result);
            }
            return View(PublishList);
        }

    }


}
