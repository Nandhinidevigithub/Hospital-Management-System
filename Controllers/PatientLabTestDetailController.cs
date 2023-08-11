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
    public class PatientLabTestDetailController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<PatientLabTestDetailVM> plabList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/patientlabtestdetails");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                plabList = JsonConvert.DeserializeObject<List<PatientLabTestDetailVM>>(data.Result);
            }
            return View(plabList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientLabTestDetailVM plab)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patientlabtestdetails/");
                var result = client.PostAsJsonAsync(uri, plab).Result;
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
            PatientLabTestDetailVM plab = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patientlabtestdetails/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    plab = JsonConvert.DeserializeObject<PatientLabTestDetailVM>(data.Result);

                }
                return View(plab);
            }

        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patientlabtestdetails/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(PatientLabTestDetailVM plab)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patientlabtestdetails/" + plab.Id.ToString());
                var result = client.PutAsJsonAsync(uri, plab).Result;
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