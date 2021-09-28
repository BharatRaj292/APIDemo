using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Models.Requests
{
    public class ListOfUsersModel
    {
            public long Id { get; set; }
            public string Email { get; set; }
            public string first_name { get; set; }
            public string LastName { get; set; }
            public Uri Avatar { get; set; }
    }
}
