using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace SQLite_net40_test.Entity
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }
}
