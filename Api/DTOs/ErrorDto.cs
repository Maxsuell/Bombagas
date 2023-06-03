namespace api.Dtos
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public ErrorDto(int statusCode, string message, string details)
        {
            Details = details;
            Message = message;
            StatusCode = statusCode;


        }


    }
}