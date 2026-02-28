using Orleans;


public interface IChatRoomObserver : IGrainObserver
{
    void Receive(ChatMessage message);
    void System(string text);
}