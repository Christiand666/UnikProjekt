using System;
namespace MVC.Models
{
    public class ErrorMessage
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
