namespace WebShopAPI.Models.Messangers
{
    public interface IMessanger
    {
        Task SendAsync(string data, CancellationToken token);
        event Action<(bool hasErrors, object? errors)>? Callback;
    }
}
