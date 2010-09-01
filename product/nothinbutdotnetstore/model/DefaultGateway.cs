using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.model
{
    public interface Gateway
    {
        IEnumerable<Department> get_all_departments();
    }

    public class DefaultGateway : Gateway
    {
        public IEnumerable<Department> get_all_departments()
        {
            IList<Department> departments = new List<Department>
                                                {
                                                    new Department("Grocery"),
                                                    new Department("Bakery"),
                                                    new Department("Frozen Goods")
                                                };
            return departments;
        }
    }
}
