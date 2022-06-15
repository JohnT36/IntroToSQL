using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IntroToSQL
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID )
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name, price, categoryID});
        }
        public void UpdateProductName(string updatedName, int productID)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM Reviews WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID;",
                new { productID = productID });
        }

        //          Collection
        public IEnumerable<Product> GetAllProducts()
        {
           return _connection.Query<Product>($"SELECT * FROM products;");
        }
    }
}
