using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Net.Http;

namespace ConsumeWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Uri baseAddress = new Uri("https://localhost:7269/api/");
        HttpClient client;
        public HomeController(ILogger<HomeController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CateCarViewModel> modelList = new List<CateCarViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "CateCar/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data= response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<CateCarViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CateCarViewModel model)
        {   
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "CateCar/CreateCategoryCar",content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(CateCarViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "CateCar/EditProfileCategoryCar/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CateCarViewModel>(data);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //public IActionResult Edit(int id)
        //{
        //    CateCarViewModel model = new CateCarViewModel();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "CateCar/EditProfileCategoryCar/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        model = JsonConvert.DeserializeObject<CateCarViewModel>(data);
        //    }
        //    return View(model);
        //    //"Create", model
        //}
        //[HttpPut]
        //public IActionResult Edit(CateCarViewModel model)
        //{
        //    string data = JsonConvert.SerializeObject(model);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PutAsync(client.BaseAddress + "CateCar/EditProfileCategoryCar/" + model.Id, content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        public IActionResult Delete(CateCarViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "CateCar/DeleteVategoryCar/" + model.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}