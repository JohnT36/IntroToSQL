using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace IntroToSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

           // var repoD = new DapperDepartmentRepository(conn);
           //
           // var departments = repoD.GetAllDepartments();
           //
           // foreach (var department in departments)
           // {
           //     Console.WriteLine($"{department.DepartmentID} {department.Name}");
           // }
            var repoP = new DapperProductRepository(conn);

            var products = repoP.GetAllProducts();
            
            foreach (var product in products)
            {
                Console.WriteLine($" {product.ProductID}, {product.Name}, {product.Price}");
            }

            
           

            foreach (var product in products)
            {
                if (product.ProductID > 890)
                {
                    Console.WriteLine(product.ProductID);
                }
            }




        }
    }
}
