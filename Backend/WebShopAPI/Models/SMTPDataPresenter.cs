namespace WebShopAPI.Models
{
    [type: Serializable]
    public sealed class SMTPDataPresenter
    {
        public required string sender;
        public required string target;
        public required string host;
        public required int port;
        public required (string name, string password) credential;
    }
}
