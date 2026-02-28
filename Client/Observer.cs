

public class ConsoleChatObserver : IChatRoomObserver
{
    public void Receive(ChatMessage message)
    {
        Console.WriteLine(message.text);
    }

    public void System(string text)
    {
        Console.WriteLine(text);
    }
}