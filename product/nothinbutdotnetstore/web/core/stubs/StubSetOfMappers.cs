using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup.stubs
{
    public class StubSetOfMappers
    {
        public static IDictionary<Type, IDictionary<Type, Func<object>>> set_of_mappers { get; private set; }

        static StubSetOfMappers()
        {
            set_of_mappers = new Dictionary<Type, IDictionary<Type, Func<object>>>();
            set_of_mappers.Add(
                typeof(NameValueCollection), new Dictionary<Type, Func<object>> {{typeof (Department), () => new NameValueCollectionToDepartmentMapper(IOC.retrieve.an<Repository>())}});
        }
    }
}