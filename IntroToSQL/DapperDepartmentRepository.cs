using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IntroToSQL
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
       
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }
        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }

    }
}
