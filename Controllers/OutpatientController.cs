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
    public class OutpatientController : Controller
    {
        public IActionResult Index()
        {

            IEnumerable<OutpatientVM> ioutList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/outpatients");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                ioutList = JsonConvert.DeserializeObject<List<OutpatientVM>>(data.Result);
            }
            return View(ioutList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(OutpatientVM iout)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outpatients/");
                var result = client.PostAsJsonAsync(uri, iout).Result;
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
            OutpatientVM iout = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outpatients/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    iout = JsonConvert.DeserializeObject<OutpatientVM>(data.Result);

                }
                return View(iout);
            }
        }
        //public IActionResult Edit(OutpatientVM iout)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        Uri uri = new Uri("https://localhost:44320/api/outpatients/" + iout.OutPatientId.ToString());
        //        var result = client.PutAsJsonAsync(uri, iout).Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", result.ReasonPhrase);
        //        }
        //        return View();
        //    }

        //}
        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outpatients/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(OutpatientVM iout)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outpatients/" + iout.OutPatientId.ToString());
                var result = client.PutAsJsonAsync(uri, iout).Result;
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
