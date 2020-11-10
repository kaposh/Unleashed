namespace APIClient
{
    public abstract class ApiClient
    {
        public abstract ApiResponse Get(string uri);
        public abstract ApiResponse Post(string uri, string data);
    }
}
