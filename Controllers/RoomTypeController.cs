using HospitalManagementSysSprint_CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HospitalManagementSysSprint_CoreMvc.Controllers
{
    public class RoomTypeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<RoomTypeVM> rtList = null;
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/roomtypes");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                rtList = JsonConvert.DeserializeObject<List<RoomTypeVM>>(data.Result);

            }
            return View(rtList);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomTypeVM rt)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/roomtypes/");
                var result = client.PostAsJsonAsync(uri, rt).Result;
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
            RoomTypeVM rt = null;
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/roomtypes/" + id);
                var result = client.GetAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> data = result.Content.ReadAsStringAsync();
                    rt = JsonConvert.DeserializeObject<RoomTypeVM>(data.Result);

                }
                return View(rt);
            }

        }
        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/roomtypes/" + id.ToString());
                var result = client.DeleteAsync(uri).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
        }

        [HttpPost]

        public IActionResult Edit(RoomTypeVM rt)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("https://localhost:44320/api/roomtypes/" + rt.RoomTypeId.ToString());
                var result = client.PutAsJsonAsync(uri, rt).Result;
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