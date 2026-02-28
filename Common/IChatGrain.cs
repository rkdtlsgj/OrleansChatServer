using Orleans;


public interface IChatRoomGrain : IGrainWithStringKey
{
    Task Join(string nickname, IChatRoomObserver observer);
    Task Leave(string nickname);
    Task SendMessage(string nickname, string text);
}