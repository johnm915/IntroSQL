using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace IntroSQL
{
   public class Program  
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DapperProductRepository(connection);

            var products = repo.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");

            }

           // var repo = new DepartmentRepository(conn);
           // var departments = repo.GetAllDepartments(); 

          //  foreach (var dept in departments)
            //{
              //  Console.WriteLine($"{dept.Name}");
          //  }
        }
            
                
            
    }
}
