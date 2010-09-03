using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.helpers
{
    public static class FormField
    {
        private static string modelTypeName;

        public static string For<T>(T model) where T : Identity
        {
            modelTypeName = typeof(T).Name;
            return string.Format("<form name='{0}_form' action='{1}.store' />", modelTypeName, modelTypeName);
        }
    }

    public static class GenerateSubmit
    {
        private static string modelTypeName;

        public static FormInputBuilder For<T>(T model) where T : Identity
        {
            modelTypeName = typeof(T).Name;
            return new FormInputBuilder(modelTypeName);

        }
    }



    public class FormInputBuilder
    {
        private readonly string _name;
        private string text;
        private string action;
        private string classname;

        public FormInputBuilder(string name)
        {
            _name = name;
        }
        
        public FormInputBuilder WithText(string _text)
        {
            this.text = _text;
            return this;
        }

        public FormInputBuilder WithAction(string action)
        {
            this.action = action;
            return this;
        }

        public FormInputBuilder WithClass(string classname)
        {
            this.classname = classname;
            return this;
        }



        public string Build()
        {
            return string.Format("<input type='submit' text='{0}' value='{1}' id='{2}' class='{3}' /></td>",
                     _name, text, action, classname);
        }

        public static implicit operator string(FormInputBuilder inputBuilder)
        {
            return inputBuilder.Build();

        }

    }
}