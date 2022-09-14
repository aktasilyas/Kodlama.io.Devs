using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSocialMediaAddress:Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public User? User { get; set; }


        public UserSocialMediaAddress()
        {
        }
        public UserSocialMediaAddress(int id,string githubUrl,int userId):this()
        {
            Id = id;
            GithubUrl = githubUrl;
            UserId = userId; 
        }
    }
}
