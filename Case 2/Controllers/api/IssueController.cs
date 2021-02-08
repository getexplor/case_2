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
    public class IssueController : ControllerBase
    {
        [Route("api/[controller]/{name}")]
        [HttpGet]
        public async Task<IActionResult> get(string name)
        {
            List<IssueViewModel> issueRepos = new List<IssueViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/repos/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("getexplor", "1"));

                var responseData = client.GetAsync("getexplor/"+ name + "/issues");
                responseData.Wait();

                var result = responseData.Result;
                if (result.IsSuccessStatusCode)
                {
                    string readData = await result.Content.ReadAsStringAsync();
                    issueRepos = JsonConvert.DeserializeObject<List<IssueViewModel>>(readData);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return Ok(issueRepos);
        }
    }
}
