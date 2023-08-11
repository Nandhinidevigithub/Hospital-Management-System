using HospitalManagementSysSprint_CoreMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HospitalManagementSysSprint_CoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            IEnumerable<RoleVM> roleList = null;

            // HttpClientHandler clientHandler = new HttpClientHandler();
             // clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/Roles");
            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                roleList = JsonConvert.DeserializeObject<List<RoleVM>>(data.Result);
            }

            SelectList sl = new SelectList(roleList, "RoleId", "RoleName");
            ViewBag.roleData = sl;

            return View();
        }

        [HttpPost]

        public IActionResult Register(RegisterVM register)
        {
            // HttpClientHandler clientHandler = new HttpClientHandler();
           //  clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient();

            //if (register.RoleId == 1)
            //{
            //    Uri uri3 = new Uri("https://localhost:44320/api/roles");

            //    var result3 = client.PostAsJsonAsync(uri3, register).Result;
            //    if (result3.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index","home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", result3.ReasonPhrase);
            //    }
            //}
            // else if (register.RoleId == 2)
            {
                Uri uri4 = new Uri("https://localhost:44320/api/Users");

                var result4 = client.PostAsJsonAsync(uri4, register).Result;
                if (result4.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    ModelState.AddModelError("", result4.ReasonPhrase);
                }
            }
            return Redirect("Index");


        }

        public IActionResult Login()
        {
            IEnumerable<RoleVM> roleList = null;

           // HttpClientHandler clientHandler = new HttpClientHandler();
           //  clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:44320/api/Roles");

            var result = client.GetAsync(uri).Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> data = result.Content.ReadAsStringAsync();
                roleList = JsonConvert.DeserializeObject<List<RoleVM>>(data.Result);
                SelectList sl = new SelectList(roleList, "RoleId", "RoleName");
                ViewBag.roleData = sl;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM login,int RoleId)
        {
            MyJwtToken jwttoken;
           // HttpClientHandler clientHandler = new HttpClientHandler();
           //  clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient client = new HttpClient())
           {
                if (login.RoleName == 1)
                {
                    Uri uri = new Uri("https://localhost:44320/api/Users/" + login.UserName + "/" + login.Password);
                    var result = client.GetAsync(uri).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> data = result.Content.ReadAsStringAsync();
                        jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
                        Response.Cookies.Append("jwttoken", jwttoken.Token);
                       // HttpContext.Session.SetString("token", jwttoken.Token);
                        Response.Cookies.Append("username", login.UserName);
                        ViewBag.message = jwttoken.Token;
                    }
                    else
                    {
                        ViewBag.message = result.ReasonPhrase;
                    }
                    return RedirectToAction("index", "Department"); 
                }
                else if (login.RoleName == 2)
                {

                    Uri uri = new Uri("https://localhost:44320/api/Users/" + login.UserName + "/" + login.Password);
                    var result = client.GetAsync(uri).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> data = result.Content.ReadAsStringAsync();
                        jwttoken = JsonConvert.DeserializeObject<MyJwtToken>(data.Result);
                        Response.Cookies.Append("jwttoken", jwttoken.Token);
                       // HttpContext.Session.SetString("token", jwttoken.Token);
                        Response.Cookies.Append("username", login.UserName);
                        ViewBag.message = jwttoken.Token;
                    }
                    else
                    {
                        ViewBag.message = result.ReasonPhrase;
                    }
                    return RedirectToAction("index", "Patient");
                }

                //if (login.UserId == 1)
                //{
                //    return RedirectToAction("index", "Department");
                //}
                //else if(login.UserId==2)
                //{
                //    return RedirectToAction("index", "Patient");
                //}
                //else
                //{
                //    return RedirectToAction("index");
                //}

                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("username");
            return RedirectToAction("login");
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
