using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using static IntroSQL.IProductRepository;

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
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("What is the name of the new product?");
            var prodName = Console.ReadLine();
            Console.WriteLine("What is the price");
            var prodPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the Category ID?");
            var prodCat = int.Parse(Console.ReadLine());
            var productRepo = new DapperProductRepository(conn);
            productRepo.CreateProduct(prodName, prodPrice, prodCat);
            var prodList = productRepo.GetAllProducts();
            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");

            }
        }
    }
}
                

       
