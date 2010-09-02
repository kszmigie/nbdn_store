using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.startup.stubs
{
    public class StubSetOfMappers
    {
        public static IDictionary<Type, IDictionary<Type, Func<object>>> set_of_mappers { get; private set; }

        static StubSetOfMappers()
        {
            set_of_mappers = new Dictionary<Type, IDictionary<Type, Func<object>>>();
            set_of_mappers.Add(
                typeof(NameValueCollection), new Dictionary<Type, Func<object>> {{typeof (Department), () => new NamevalueCollectionToDepartmentmapper(IOC.retrieve.an<Repository>())}});
        }
    }

    public class NamevalueCollectionToDepartmentmapper : Mapper<NameValueCollection, Department>
    {
        private Repository repository;

        public NamevalueCollectionToDepartmentmapper(Repository repository)
        {
            this.repository = repository;
        }

        public Department map(NameValueCollection input)
        {
            return repository.get_department(input["department"]);
        }
    }
}