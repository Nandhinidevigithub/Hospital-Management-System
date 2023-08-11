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
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<PatientVM> patList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/patients");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                patList = JsonConvert.DeserializeObject<List<PatientVM>>(data.Result);
            }
            return View(patList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientVM pat)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patients/");
                var result = client.PostAsJsonAsync(uri, pat).Result;
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
            PatientVM pat = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patients/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    pat = JsonConvert.DeserializeObject<PatientVM>(data.Result);

                }
                return View(pat);
            }

        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patients/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(PatientVM pat)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/patients/" + pat.PatientId.ToString());
                var result = client.PutAsJsonAsync(uri, pat).Result;
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



