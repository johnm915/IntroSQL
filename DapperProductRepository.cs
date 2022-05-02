using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

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
            _connection.Execute("INSERT INTO products (NAME , PRICE, CATEGORYID) VALUES ( @eachParemeter ) ");
        }

        

        //public IEnumerable<Product> GetAllDepartments()
        //{
        //  return  _connection.Query<Product>("SELECT * FROM PRODUCTS;");
       // }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        //public IEnumerable<Product> GetAllProducts()
        //{
        //  throw new NotImplementedException();
        //}

        //internal object GetAllProducts()
        //{
        //  throw new NotImplementedException();
        // }

        // IEnumerable<Product> IProductRepository.GetAllProducts()
        //{
        //   throw new NotImplementedException();
        //}
    }
}
