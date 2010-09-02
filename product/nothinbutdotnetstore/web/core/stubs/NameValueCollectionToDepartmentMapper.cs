using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class NameValueCollectionToDepartmentMapper : Mapper<NameValueCollection, Department>
    {
        Repository repository;

        public NameValueCollectionToDepartmentMapper(Repository repository)
        {
            this.repository = repository;
        }

        public Department map(NameValueCollection input)
        {
            return repository.get_department(input["department"]);
        }
    }
}