using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup.stubs
{
    public class StubStartupServices : StartupServices
    {
        IDictionary<Type, DependencyResolver> resolvers = new Dictionary<Type, DependencyResolver>();

        public IEnumerator<KeyValuePair<Type, DependencyResolver>> GetEnumerator()
        {
            return resolvers.GetEnumerator();
        }

        public void Add(KeyValuePair<Type, DependencyResolver> item)
        {
            resolvers.Add(item);
        }

        public void Clear()
        {
            resolvers.Clear();
        }

        public bool Contains(KeyValuePair<Type, DependencyResolver> item)
        {
            return resolvers.Contains(item);
        }

        public void CopyTo(KeyValuePair<Type, DependencyResolver>[] array, int arrayIndex)
        {
            resolvers.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<Type, DependencyResolver> item)
        {
            return resolvers.Remove(item);
        }

        public int Count
        {
            get { return resolvers.Count; }
        }

        public bool IsReadOnly
        {
            get { return resolvers.IsReadOnly; }
        }

        public bool ContainsKey(Type key)
        {
            return resolvers.ContainsKey(key);
        }

        public void Add(Type key, DependencyResolver value)
        {
            resolvers.Add(key, value);
        }

        public bool Remove(Type key)
        {
            return resolvers.Remove(key);
        }

        public bool TryGetValue(Type key, out DependencyResolver value)
        {
            return resolvers.TryGetValue(key, out value);
        }

        public DependencyResolver this[Type key]
        {
            get { return resolvers[key]; }
            set { resolvers[key] = value; }
        }

        public ICollection<Type> Keys
        {
            get { return resolvers.Keys; }
        }

        public ICollection<DependencyResolver> Values
        {
            get { return resolvers.Values; }
        }

        public void register_dependency_factory<Contract>(Func<object> resolver)
        {
            Add(typeof (Contract), new FunctionalDependencyResolver(resolver));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}