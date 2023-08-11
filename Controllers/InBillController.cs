
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
    public class InBillController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<InBillVM> inbillList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/inbills");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                inbillList = JsonConvert.DeserializeObject<List<InBillVM>>(data.Result);
            }
            return View(inbillList);

        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(InBillVM inbill)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inbills/");
                var result = client.PostAsJsonAsync(uri, inbill).Result;
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
            InBillVM inbill = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inbills/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    inbill = JsonConvert.DeserializeObject<InBillVM>(data.Result);

                }
                return View(inbill);
            }
        }
        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inbills/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");

            }
        }
        [HttpPost]

        public IActionResult Edit(InBillVM inbill)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/inbills/" + inbill.BillId.ToString());
                var result = client.PutAsJsonAsync(uri, inbill).Result;
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

