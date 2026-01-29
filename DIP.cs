// BAD code
public class EmailNotifierBad
{
    public void Send(string msg) => Console.WriteLine("SMTP send " + msg);
}

public class OrderServiceBadNotification
{
    private readonly EmailNotifierBad _email = new(); // concrete dependency
    public void Notify(string msg) => _email.Send(msg);
}


// Refactored code

public interface INotifier
{
    void Notify(string to, string message);
}

public class EmailNotifier : INotifier
{
    public void Notify(string to, string message) => Console.WriteLine($"Email to {to}: {message}");
}

public class SmsNotifier : INotifier
{
    public void Notify(string to, string message) => Console.WriteLine($"SMS to {to}: {message}");
}

// Order service depends on INotifier
public class NotificationServiceDIP
{
    private readonly INotifier _notifier;
    public NotificationServiceDIP(INotifier notifier) => _notifier = notifier;
    public void Send(string to, string message) => _notifier.Notify(to, message);
}
