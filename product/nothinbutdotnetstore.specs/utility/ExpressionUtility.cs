using System;
using System.Linq.Expressions;
using System.Reflection;

namespace nothinbutdotnetstore.specs.utility
{
    public class ExpressionUtility
    {

        public static ExpressionFactory<Item> create_expression_builder<Item>()
        {
            return new ExpressionFactory<Item>();
        }
    }

    public class ExpressionFactory<Item>
    {

        public ConstructorInfo get_constructor(Expression<Func<Item>> factory)
        {
            return ((NewExpression) factory.Body).Constructor;
        }

        public string get_the_name_of_the_member<ReturnType>(Expression<Func<Item, ReturnType>> accessor)
        {
            return ((MemberExpression) accessor.Body).Member.Name;
        }
    }
}