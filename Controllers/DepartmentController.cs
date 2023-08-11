using HospitalManagementSysSprint_CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HospitalManagementSysSprint_CoreMvc.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<DepartmentVM> deptList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/departments");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                deptList = JsonConvert.DeserializeObject<List<DepartmentVM>>(data.Result);
            }
            return View(deptList);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dept)
        { 
            using (HttpClient client = new HttpClient())
            {
               // string token = Request.Cookies["jwttoken"];
               // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Uri uri = new Uri("https://localhost:44320/api/departments/");
                var result = client.PostAsJsonAsync(uri, dept).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    ModelState.AddModelError("", result.ReasonPhrase);
                }
                return View();

            }
        }

        public IActionResult Edit(int id)
        {
            DepartmentVM dept = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/departments/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    dept = JsonConvert.DeserializeObject<DepartmentVM>(data.Result);

                }
                return View(dept);
            }

        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/departments/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(DepartmentVM dept)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/departments/" + dept.DepartmentId.ToString());
                var result = client.PutAsJsonAsync(uri, dept).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
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
