﻿using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace IntroToSQL
{
    class Program
    {
        //allows us to grab the connection string information from the appsettings.json file
        //-----------------------------------------------------------------
        static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");
        //-----------------------------------------------------------------

        //create our IDbConnection that uses MySql, so Dapper can extend it
        static IDbConnection conn = new MySqlConnection(connString);
        static void Main(string[] args)
        {


            var repoD = new DapperDepartmentRepository(conn);

            var departments = repoD.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }
            var repoP = new DapperProductRepository(conn);
            repoP.CreateProduct("Turtleshoes", 200, 7);


            var products = repoP.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($" {product.ProductID}, {product.Name}, {product.Price}");
            }




            foreach (var product in products)
            {
                if (product.ProductID > 887)
                {
                    Console.WriteLine(product.ProductID);
                }
            }
        }
            public static void DeleteProduct()
            {
                //ProductRepository instance - so we can call our dapper methods
                var prodRepo = new DapperProductRepository(conn);

                //User interaction
                Console.WriteLine($"Please enter the productID of the product you would like to delete:");
                var productID = Convert.ToInt32(Console.ReadLine());

                //Call the Dapper method
                prodRepo.DeleteProduct(productID);
            }

            public static void UpdateProductName()
            {
                var prodRepo = new DapperProductRepository(conn);

                Console.WriteLine($"What is the productID of the product you would like to update?");
                var productID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"What is the new name you would like for the product with an id of {productID}?");
                var updatedName = Console.ReadLine();

                prodRepo.UpdateProductName(updatedName, productID);
            }

            public static void CreateAndListProducts()
            {
                //created instance so we can call methods that hit the database
                var prodRepo = new DapperProductRepository(conn);

                Console.WriteLine($"What is the new product name?");
                var prodName = Console.ReadLine();

                Console.WriteLine($"What is the new product's price?");
                var price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"What is the new product's category id?");
                var categoryID = Convert.ToInt32(Console.ReadLine());

                prodRepo.CreateProduct(prodName, price, categoryID);


                //call the GetAllProducts method using that instance and store the result
                //in the products variable
                var products = prodRepo.GetAllProducts();

                //print each product from the products collection to the console
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductID} {product.Name}");
                }
            }

            public static void ListProducts()
            {
                var prodRepo = new DapperProductRepository(conn);
                var products = prodRepo.GetAllProducts();

                //print each product from the products collection to the console
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductID} {product.Name}");
                }
            }

            public static void ListDepartments()
            {
                var repo = new DapperDepartmentRepository(conn);

                var departments = repo.GetAllDepartments();

                foreach (var item in departments)
                {
                    Console.WriteLine($"{item.DepartmentID} {item.Name}");
                }
            }

            public static void DepartmentUpdate()
            {
                var repo = new DapperDepartmentRepository(conn);

                Console.WriteLine($"Would you like to update a department? yes or no");

                if (Console.ReadLine().ToUpper() == "YES")
                {
                    Console.WriteLine($"What is the ID of the Department you would like to update?");

                    var id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"What would you like to change the name of the department to?");

                    var newName = Console.ReadLine();

                    repo.UpdateDepartment(id, newName);

                    var depts = repo.GetAllDepartments();

                    foreach (var item in depts)
                    {
                        Console.WriteLine($"{item.DepartmentID} {item.Name}");
                    }
                }
            }




        
    }
}
