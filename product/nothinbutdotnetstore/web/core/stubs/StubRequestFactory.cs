using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
            public string departmentname
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}