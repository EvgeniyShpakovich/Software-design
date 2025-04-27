public sealed class Authenticator
{
    private static readonly object _lock = new object();
    private static Authenticator? _instance;

    private Authenticator()
    {
        Console.WriteLine("Authenticator instance created.");
    }

    public static Authenticator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }
            return _instance;
        }
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating {username}...");
    }
}

class Program
{
    static void Main()
    {
        Authenticator auth1 = Authenticator.Instance;
        Authenticator auth2 = Authenticator.Instance;

        Console.WriteLine(auth1 == auth2 ? "Same instance" : "Different instances");

        auth1.Authenticate("user1", "password123");
    }
}
