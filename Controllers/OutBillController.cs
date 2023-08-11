using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HospitalManagementSysSprint_CoreMvc.Models;

namespace HospitalManagementSprint_CoreMvc.Controllers
{
    public class OutBillController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<OutBillVM> outbillList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/outbills");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                outbillList = JsonConvert.DeserializeObject<List<OutBillVM>>(data.Result);
            }
            return View(outbillList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(OutBillVM outbill)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outbills/");
                var result = client.PostAsJsonAsync(uri, outbill).Result;
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
            OutBillVM outbill = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outbills/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    outbill = JsonConvert.DeserializeObject<OutBillVM>(data.Result);

                }
                return View(outbill);
            }
        }
        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outbills/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }
        [HttpPost]

        public IActionResult Edit(OutBillVM outbill)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/outbills/" + outbill.BillId.ToString());
                var result = client.PutAsJsonAsync(uri, outbill).Result;
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

