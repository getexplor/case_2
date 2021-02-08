using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Case_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Case_2.Controllers.api
{
    
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> get()
        {
            List<RepositoryViewModel> listRepo = new List<RepositoryViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/users/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("getexplor", "1"));

                var responseData = client.GetAsync("getexplor/repos");
                responseData.Wait();

                var result = responseData.Result;
                if (result.IsSuccessStatusCode)
                {
                    string readData = await result.Content.ReadAsStringAsync();
                    listRepo = JsonConvert.DeserializeObject<List<RepositoryViewModel>>(readData);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return Ok(listRepo);
        }
    }
}
