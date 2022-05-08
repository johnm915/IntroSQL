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

           // Console.WriteLine(connString);

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            Console.WriteLine($"Hello, Here are the current departments:");
            Console.WriteLine("Press Enter");
            Console.ReadLine();

            var depos = repo.GetAllDepartments();
            print(depos);
            

            Console.WriteLine("Do you want to add another Department?");
            string userResopnse = Console.ReadLine();

            if (userResopnse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of the new department?");
                userResopnse = Console.ReadLine();

                repo.InsertDepartment(userResopnse);
                print(repo.GetAllDepartments());
            }

            Console.WriteLine("Have a nice day!");



            var repository = new DapperProductRepository(conn);

            repository.CreateProduct("new items", 20, 1);

            var products = repository.GetAllProducts();

            foreach(var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }



        }
        
        
            public static void print(IEnumerable<Department> depos)
            {

                foreach (var depo in depos)
                {
                    Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
                }
            }
    }

}

