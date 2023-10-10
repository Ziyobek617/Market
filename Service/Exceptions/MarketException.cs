namespace Market.Service.Exceptions;

public class MarketException : Exception
{
    public int StatusCode { get; set; }

    public MarketException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
