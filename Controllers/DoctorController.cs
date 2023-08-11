
using HospitalManagementSysSprint_CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HospitalManagementSprint_CoreMvc.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<DoctorVM> docList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/doctors");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                docList = JsonConvert.DeserializeObject<List<DoctorVM>>(data.Result);

            }
            return View(docList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DoctorVM doc)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/doctors/");
                var result = client.PostAsJsonAsync(uri, doc).Result;
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
            DoctorVM doc = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/doctors/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    doc = JsonConvert.DeserializeObject<DoctorVM>(data.Result);

                }
                return View(doc);
            }

        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/doctors/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }

        [HttpPost]

        public IActionResult Edit(DoctorVM doc)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/doctors/" + doc.DoctorId.ToString());
                var result = client.PutAsJsonAsync(uri, doc).Result;
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
