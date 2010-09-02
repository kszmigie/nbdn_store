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
            return new HttpContextBuilder("blah.aspx",new NameValueCollection(), "http://localhost/test.store");
        }

    }

    public class HttpContextBuilder
    {
        string page;
        NameValueCollection querystring;
        string url;

        public HttpContextBuilder(string page, NameValueCollection querystring, string url)
        {
            this.page = page;
            this.querystring = querystring;
            this.url = url;
        }

        public static implicit operator HttpContext(HttpContextBuilder builder)
        {
           return new HttpContext(create_request(builder.page,builder.querystring.ToString(), builder.url), create_response()); 
        }

        public HttpContextBuilder with_payload_value<T>(string key, T value)
        {
            return new HttpContextBuilder(page, querystring, "http://localhost/blah.aspx");
        }

        public HttpContextBuilder with_url_value(string url)
        {
            return new HttpContextBuilder(page, querystring, url);
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        static HttpRequest create_request(string page,string query_string)
        {
            return create_request(page, query_string, "http://localhost/blah.aspx");
        }

        static HttpRequest create_request(string page, string query_string, string url)
        {
            return new HttpRequest(page, url, query_string);
        }
    }
}