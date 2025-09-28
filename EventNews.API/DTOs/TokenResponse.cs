namespace EventNews.API.DTOs
{
    public class TokenResponse
    {
        public string Token { get; set; }
    }

    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
