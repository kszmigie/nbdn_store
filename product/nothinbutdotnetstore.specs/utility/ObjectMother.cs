using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectMother
    {
        public static HttpContextBuilder create_http_context()
        {
            return new HttpContextBuilder("blah.aspx",new NameValueCollection());
        }

    }

    public class HttpContextBuilder
    {
        string page;
        NameValueCollection querystring;

        public HttpContextBuilder(string page, NameValueCollection querystring)
        {
            this.page = page;
            this.querystring = querystring;
        }

        public static implicit operator HttpContext(HttpContextBuilder builder)
        {
           return new HttpContext(create_request(builder.page,builder.querystring.ToString()), create_response()); 
        }

        public HttpContextBuilder with_payload_value<T>(string key, T value)
        {
            return new HttpContextBuilder(page, querystring);
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        static HttpRequest create_request(string page,string query_string)
        {
            return new HttpRequest(page, "http://localhost/blah.aspx", query_string);
        }
    }
}