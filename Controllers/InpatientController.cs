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
    public class InpatientController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<InpatientVM> inpatList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/inpatients");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                inpatList = JsonConvert.DeserializeObject<List<InpatientVM>>(data.Result);
            }
            return View(inpatList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(InpatientVM inpat)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inpatients/");
                var result = client.PostAsJsonAsync(uri, inpat).Result;
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
            InpatientVM inpat = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inpatients/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    inpat = JsonConvert.DeserializeObject<InpatientVM>(data.Result);

                }
                return View(inpat);
            }

        }
        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inpatients/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(InpatientVM inpat)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inpatients/" + inpat.InPatientId.ToString());
                var result = client.PutAsJsonAsync(uri, inpat).Result;
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

        //public IActionResult Delete(int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        Uri uri = new Uri("https://localhost:44320/api/inpatients/" + id.ToString());
        //        var result = client.DeleteAsync(uri).Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("index");
        //        }
        //        return RedirectToAction("index");
        //    }
        //}
        public IActionResult AddPatient(int PatientId)
        {
            ViewBag.data = PatientId;

            return View();
        }

    }
}

