namespace Ru.Kassa.Models.Response
{
    public interface IResponse
    {
        string Error { get; set; }
        string Message { get; set; }
    }
}