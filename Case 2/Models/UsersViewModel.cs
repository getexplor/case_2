using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Octokit;

namespace Case_2.Models
{
    public class UsersViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }


        public IReadOnlyList<Repository> Repositories { get; set; }
        public IReadOnlyList<Repository> StarredRepos { get; set; }
        public IReadOnlyList<User> Followers { get; set; }
        public IReadOnlyList<User> Following { get; set; }

    }
}
