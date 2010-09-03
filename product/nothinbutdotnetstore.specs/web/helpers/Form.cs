using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.specs.web.helpers
{
    public static class Form
    {
        private static string modelTypeName;

        public static string For<T>(T model) where T : Identity
        {
            modelTypeName = typeof(T).Name;
            return string.Format("<form name='{0}_form' action='{1}.store' />", modelTypeName, model.id );
        }

    
    }
}