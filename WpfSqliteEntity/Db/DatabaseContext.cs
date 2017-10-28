using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSqliteEntity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : 
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = "Resources/sqlite.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
            
        }

        public DbSet<User> User { get; set; }
    }
}
