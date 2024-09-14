using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using PasswordHashing.Models;

namespace PasswordHashing.Mappings
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Username);
            Map(x => x.PasswordHash);
        }
    }
}