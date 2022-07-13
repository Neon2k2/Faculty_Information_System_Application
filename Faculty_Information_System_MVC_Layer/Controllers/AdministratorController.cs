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

    public class AdministratorController : Controller
    {

        

        public IActionResult Index()
        {
            IEnumerable<AdministratorVM> adminList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Administrators");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                adminList = JsonConvert.DeserializeObject<IEnumerable<AdministratorVM>>(data.Result);
            }
            return View(adminList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdministratorVM admin)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Administrators");
            var result = client.PostAsJsonAsync(uri, admin).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                /*throw*/
                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Administrators/" + id.ToString());
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                AdministratorVM admin = null;



                Uri uri = new("http://localhost:26686/api/administrators/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    admin = JsonConvert.DeserializeObject<AdministratorVM>(data.Result);
                    return View(admin);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }

        }




        [HttpPost]
        public IActionResult Edit(AdministratorVM admin)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri uri = new("http://localhost:26686/api/Administrators/" + admin.AdministratorId.ToString());
                var result = client.PutAsJsonAsync(uri, admin).Result;
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









        //Nagivation options

        //faculty

        

        

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

        [HttpGet]
        public IActionResult FacCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FacCreate(FacultyVM fac)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Faculties");
            var result = client.PostAsJsonAsync(uri, fac).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowFac");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }




        [HttpGet]
        public IActionResult FacEdit(int id)
        {
            using (HttpClient client = new ())
            {
                FacultyVM fac = null;



                Uri uri = new("http://localhost:26686/api/Faculties/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    fac = JsonConvert.DeserializeObject<FacultyVM>(data.Result);
                    return View(fac);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }

        }




        [HttpPost]
        public IActionResult FacEdit(FacultyVM fac)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri uri = new("http://localhost:26686/api/Faculties/" + fac.FacultyId.ToString());
                var result = client.PutAsJsonAsync(uri, fac).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowFac");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }

        public IActionResult FacDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Faculties/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowFac");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        //courses

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

        public IActionResult CourCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CourCreate(CourseVM cour)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Courses");
            var result = client.PostAsJsonAsync(uri, cour).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourse");
            }
            else
            {
                ModelState.AddModelError("Course Already Exists", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CourEdit(int id)
        {
            using (HttpClient client = new())
            {
                CourseVM cour = null;



                Uri uri = new("http://localhost:26686/api/Courses/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    cour = JsonConvert.DeserializeObject<CourseVM>(data.Result);
                    return View(cour);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }

        }


        [HttpPost]
        public IActionResult CourEdit(CourseVM cour)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Courses/" + cour.CourseId.ToString());
                var result = client.PutAsJsonAsync(uri, cour).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowCourse");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }

        public IActionResult CourDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Courses/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourse");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }


        //coursesTaught

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

        public IActionResult CourTautcreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CourTautcreate(CourseTaughtVM courTaut)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/CourseTaughts");
            var result = client.PostAsJsonAsync(uri, courTaut).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourTaught");
            }
            else
            {
                /*throw*/
                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CourTautedit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                CourseTaughtVM courSub = null;



                Uri uri = new("http://localhost:26686/api/CourseTaughts/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    courSub = JsonConvert.DeserializeObject<CourseTaughtVM>(data.Result);
                    return View(courSub);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }

        }




        [HttpPost]
        public IActionResult CourTautedit(CourseTaughtVM courTaut)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri uri = new("http://localhost:26686/api/CourseTaughts/" + courTaut.CoureseTaughtId.ToString());
                var result = client.PutAsJsonAsync(uri, courTaut).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowCourTaught");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }

        }

        public IActionResult CourTautDelete(int id)
        {
            HttpClient client = new HttpClient();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/CourseTaughts/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourTaught");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }


        //Users


        public IActionResult showUser()
        {
            IEnumerable<UserVM> userList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Users");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                userList = JsonConvert.DeserializeObject<IEnumerable<UserVM>>(data.Result);
            }
            return View(userList);
        }


        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserCreate(UserVM user)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Users");
            var result = client.PostAsJsonAsync(uri, user).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowUser");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        public IActionResult UserDelete(int id)
        {
            HttpClient client = new ();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Users/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowUser");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                UserVM user = null;



                Uri uri = new("http://localhost:26686/api/Users/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserVM>(data.Result);
                    return View(user);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }

        



        [HttpPost]
        public IActionResult UserEdit(UserVM user)
        {
            using (HttpClient client = new ())
            {

                Uri uri = new("http://localhost:26686/api/Users/" + user.UserId.ToString());
                var result = client.PutAsJsonAsync(uri, user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowUser");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }


        //Degree

        public IActionResult DegreeDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Degrees/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDegree");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");
        }

        public IActionResult ShowDegree()
        {
            IEnumerable<DegreeVM> degList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Degrees");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                degList = JsonConvert.DeserializeObject<IEnumerable<DegreeVM>>(data.Result);
            }
            return View(degList);
        }



        public IActionResult DegreeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DegreeCreate(DegreeVM deg)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Degrees");
            var result = client.PostAsJsonAsync(uri, deg).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDegree");
            }
            else
            {
                ModelState.AddModelError("Degree Already Exists", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult DegreeEdit(int id)
        {
            using (HttpClient client = new())
            {
                DegreeVM deg = null;



                Uri uri = new("http://localhost:26686/api/Degrees/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    deg = JsonConvert.DeserializeObject<DegreeVM>(data.Result);
                    return View(deg);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }

        }


        [HttpPost]
        public IActionResult DegreeEdit(DegreeVM deg)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Degrees/" + deg.DegreeId.ToString());
                var result = client.PutAsJsonAsync(uri, deg).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowDegree");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }



        //Department

        public IActionResult DeptDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Departments/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDept");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

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



        public IActionResult DeptCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeptCreate(DepartmentVM dept)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Departments");
            var result = client.PostAsJsonAsync(uri, dept).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDept");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeptEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                DepartmentVM dept = null;



                Uri uri = new("http://localhost:26686/api/Departments/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    dept = JsonConvert.DeserializeObject<DepartmentVM>(data.Result);
                    return View(dept);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }





        [HttpPost]
        public IActionResult DeptEdit(DepartmentVM dept)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Departments/" + dept.DepartmentId.ToString());
                var result = client.PutAsJsonAsync(uri, dept).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowDept");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }



        //Desginatiion

        public IActionResult DesigDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Designations/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDesig");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        public IActionResult ShowDesig()
        {
            IEnumerable<DesignationVM> DesigList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/Designations");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                DesigList = JsonConvert.DeserializeObject<IEnumerable<DesignationVM>>(data.Result);
            }
            return View(DesigList);
        }



        public IActionResult DesigCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DesigCreate(DesignationVM desig)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Designations");
            var result = client.PostAsJsonAsync(uri, desig).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowDesig");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult DesigEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                DesignationVM desig = null;



                Uri uri = new("http://localhost:26686/api/Designations/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    desig = JsonConvert.DeserializeObject<DesignationVM>(data.Result);
                    return View(desig);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }



        [HttpPost]
        public IActionResult DesigEdit(DesignationVM desig)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Designations/" + desig.DesignationId.ToString());
                var result = client.PutAsJsonAsync(uri, desig).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowDesig");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }


        // Grants

        public IActionResult GrantDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Grants/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowGrant");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

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



        public IActionResult GrantCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GrantCreate(GrantVM grant)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Grants");
            var result = client.PostAsJsonAsync(uri, grant).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowGrant");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult GrantEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                GrantVM grant = null;



                Uri uri = new("http://localhost:26686/api/Grants/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    grant = JsonConvert.DeserializeObject<GrantVM>(data.Result);
                    return View(grant);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }



        [HttpPost]
        public IActionResult GrantEdit(GrantVM grant)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Grants/" + grant.GrantId.ToString());
                var result = client.PutAsJsonAsync(uri, grant).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowGrant");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }



        public IActionResult SubjectDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Subjects/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowSubject");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

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



        public IActionResult SubjectCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubjectCreate(SubjectVM sub)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Subjects");
            var result = client.PostAsJsonAsync(uri, sub).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowSubject");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SubjectEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                SubjectVM sub = null;



                Uri uri = new("http://localhost:26686/api/Subjects/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    sub = JsonConvert.DeserializeObject<SubjectVM>(data.Result);
                    return View(sub);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }



        [HttpPost]
        public IActionResult SubjectEdit(SubjectVM sub)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Subjects/" + sub.SubjectID.ToString());
                var result = client.PutAsJsonAsync(uri, sub).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowSubject");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }


        //Course and Subject relational table

        public IActionResult CourSubDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/CourseSubjects/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourSub");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        public IActionResult ShowCourSub()
        {
            IEnumerable<CourseSubjectVM> CourSubList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/CourseSubjects");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                CourSubList = JsonConvert.DeserializeObject<IEnumerable<CourseSubjectVM>>(data.Result);
            }
            return View(CourSubList);
        }



        public IActionResult CourSubCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CourSubCreate(CourseSubjectVM courSub)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/CourseSubjects");
            var result = client.PostAsJsonAsync(uri, courSub).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCourSub");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CourSubEdit(int id)
        {
            using (HttpClient client = new ())
            {
                CourseSubjectVM courSub = null;



                Uri uri = new("http://localhost:26686/api/CourseSubjects/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    courSub = JsonConvert.DeserializeObject<CourseSubjectVM>(data.Result);
                    return View(courSub);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }





        [HttpPost]
        public IActionResult CourSubEdit(CourseSubjectVM courSub)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/CourseSubjects/" + courSub.CourseSubjectId.ToString());
                var result = client.PutAsJsonAsync(uri, courSub).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowCourSub");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }



        //Publications

        public IActionResult PublishDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/Publications/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowPublish");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

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



        public IActionResult PublishCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PublishCreate(PublicationVM publish)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/Publications");
            var result = client.PostAsJsonAsync(uri, publish).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowPublish");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PublishEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                PublicationVM publish = null;



                Uri uri = new("http://localhost:26686/api/Publications/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    publish = JsonConvert.DeserializeObject<PublicationVM>(data.Result);
                    return View(publish);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }





        [HttpPost]
        public IActionResult PublishEdit(PublicationVM publish)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/Publications/" + publish.PublicationId.ToString());
                var result = client.PutAsJsonAsync(uri, publish).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowPublish");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }



        //wORKHISTORY


        public IActionResult WorkDelete(int id)
        {
            HttpClient client = new();


            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Uri uri = new("http://localhost:26686/api/WorkHistories/" + id.ToString());
            var result = client.DeleteAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowWork");
            }
            else
            {
                TempData["message"] = result.ReasonPhrase;
            }
            return RedirectToAction("index");

        }

        public IActionResult ShowWork()
        {
            IEnumerable<WorkHistoryVM> WorkList = null;
            HttpClient client = new();
            string token = Request.Cookies["jwttoken"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Uri uri = new("http://localhost:26686/api/WorkHistories");


            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                WorkList = JsonConvert.DeserializeObject<IEnumerable<WorkHistoryVM>>(data.Result);
            }
            return View(WorkList);
        }



        public IActionResult WorkCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WorkCreate(WorkHistoryVM work)
        {
            HttpClient client = new();
            Uri uri = new("http://localhost:26686/api/WorkHistories");
            var result = client.PostAsJsonAsync(uri, work).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowWork");
            }
            else
            {

                ModelState.AddModelError("", result.ReasonPhrase);
            }
            return View();
        }

        [HttpGet]
        public IActionResult WorkEdit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                WorkHistoryVM work = null;



                Uri uri = new("http://localhost:26686/api/WorkHistories/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    work = JsonConvert.DeserializeObject<WorkHistoryVM>(data.Result);
                    return View(work);
                }
                else
                {
                    TempData["message"] = result.ReasonPhrase;
                }
                return RedirectToAction("index");
            }


        }





        [HttpPost]
        public IActionResult WorkEdit(WorkHistoryVM work)
        {
            using (HttpClient client = new())
            {

                Uri uri = new("http://localhost:26686/api/WorkHistories/" + work.WorkHistoryId.ToString());
                var result = client.PutAsJsonAsync(uri, work).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowWork");
                }
                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }

    }
}
