using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordHashing.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store the hashed password
    }

}