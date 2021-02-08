using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Case_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Case_2.Controllers
{
    public class HomeController : Controller
    {

        List<RepositoryViewModel> repos = new List<RepositoryViewModel>();
        List<IssueViewModel> issue = new List<IssueViewModel>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Issue()
        {
            return View();
        }

        //public async Task<IActionResult> Issue(string name)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44305/api/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var responseData = client.GetAsync("issue" + "/" + name);
        //        responseData.Wait();

        //        var result = responseData.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            string readData = await result.Content.ReadAsStringAsync();
        //            issue = JsonConvert.DeserializeObject<List<IssueViewModel>>(readData);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Server Error");
        //        }
        //    }
        //    return View(issue);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
