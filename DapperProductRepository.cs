﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Threading;

namespace IntroSQL

{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;


        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;

        }

        public void CreateProduct(string name, double price, int categoryID)
        {

            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");

        }


        public void UpdateProductName(int productID, string updateName)

        {
            _connection.Execute("UPDATE product SET Name = @updateName WHERE ProductID = @productID;",
                new { productID = productID, updateName = updateName });
            Console.WriteLine($"Product {productID}Updated");
            Thread.Sleep(3000);
        }

    }
}
       
