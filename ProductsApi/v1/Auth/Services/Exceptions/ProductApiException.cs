namespace ProductsApi.v1.Auth.Services.Exceptions;

public class ProductApiException : Exception
{
    public int Code { get; set; }
    public bool? Global { get; set; }
    public ProductApiException(int code, string message,bool? global = true) : base(message)
    {
        Code = code;
        Global = global;
    }
}
