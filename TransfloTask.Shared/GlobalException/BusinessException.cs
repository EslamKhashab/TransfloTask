using System.Net;

namespace TransfloTask.Shared.GlobalException
{
    public class BusinessException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;
        public BusinessException()
        {
        }
        public BusinessException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public BusinessException(string errorMessage, HttpStatusCode status)
        {
            ErrorMessage = errorMessage;
            Status = status;
        }
    }
}