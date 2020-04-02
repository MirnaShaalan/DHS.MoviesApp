using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHS.MoviesApp.Web.Client.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace DHS.MoviesApp.Web.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly string BaseUrl = "https://localhost:44339/api/movies";
        HttpClient httpClient;

        public HomeController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(BaseUrl + "/Get");

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                var movies = JsonConvert.DeserializeObject<List<MovieModel>>(response);
                return View(movies);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(MovieModel movie, IFormFile postedFile)
        {
            string image;
            if (postedFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    postedFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    image = Convert.ToBase64String(fileBytes);
                    movie.Image = image;
                }
            }

            string url = BaseUrl + "/Add";
            StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                var MovieResult = JsonConvert.DeserializeObject<MovieModel>(response);
                return Json(MovieResult);
            }
            else
            {
                return Json("Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(MovieModel movie, IFormFile postedFile)
        {
            string image;
            if (postedFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    postedFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    image = Convert.ToBase64String(fileBytes);
                    movie.Image = image;
                }
            }

            string url = BaseUrl + "/Edit";
            StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PutAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                var MovieResult = JsonConvert.DeserializeObject<MovieModel>(response);
                return Json(MovieResult);
            }
            else
            {
                return Json("Error");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var url = BaseUrl + $"/Delete?id={id}";
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = responseMessage.Content.ReadAsStringAsync().Result;
                return Ok(response);
            }
            else
            {
                return Json("Error");
            }
        }

    }
}
