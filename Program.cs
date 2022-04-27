using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace IntroSQL
{
    class Program  
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DepartmentRepository(conn);
            var departments = repo.GetAllDepartments(); 

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Name}");
            }
        }
            
                
            
    }
}
