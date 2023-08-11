using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using HospitalManagementSysSprint_CoreMvc.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;


namespace HospitalManagementSprint_CoreMvc.Controllers
{
    public class LabTestController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<LabTestVM> labList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/labtests");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                labList = JsonConvert.DeserializeObject<List<LabTestVM>>(data.Result);
            }
            return View(labList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(LabTestVM lab)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/labtests/");
                var result = client.PostAsJsonAsync(uri, lab).Result;
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
            LabTestVM lab = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/labtests/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    lab = JsonConvert.DeserializeObject<LabTestVM>(data.Result);

                }
                return View(lab);
            }

        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/labtests/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }

        [HttpPost]

        public IActionResult Edit(LabTestVM lab)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/labtests/" + lab.LabTestId.ToString());
                var result = client.PutAsJsonAsync(uri, lab).Result;
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
