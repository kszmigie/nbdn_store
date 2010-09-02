using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_departments();
    }
}