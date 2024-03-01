using System.Net;

namespace AddinsPremierducts
{
    public class MessageModel
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}