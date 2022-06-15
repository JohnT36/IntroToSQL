using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToSQL
{
    public interface IDepartmentRepository 
    {
        public IEnumerable<Department> GetAllDepartments();

    }
}
