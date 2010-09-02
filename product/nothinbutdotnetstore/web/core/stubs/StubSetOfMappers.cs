using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
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
                typeof(NameValueCollection), new Dictionary<Type, Func<object>> {{typeof (Department), () => new NamevalueCollectionToDepartmentmapper()}});
        }
    }

    public class NamevalueCollectionToDepartmentmapper : Mapper<NameValueCollection, Department>
    {
        public Department map(NameValueCollection input)
        {
            return new Department() {name = input["department"] };
        }
    }
}