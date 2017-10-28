using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSqliteEntity
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
