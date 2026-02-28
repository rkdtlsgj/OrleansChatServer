using Orleans;

namespace OrleansChatServer
{

    public class ChatRoomGrain : Grain, IChatRoomGrain
    {
        private readonly Dictionary<string, IChatRoomObserver> _members = new(StringComparer.OrdinalIgnoreCase);


        public Task Join(string nickname, IChatRoomObserver observer)
        {
            _members[nickname] = observer;
            BroadcastSystem($"[{nickname}] 님이 입장했습니다]");
            return Task.CompletedTask;
        }

        public Task Leave(string nickname)
        {
            if (_members.Remove(nickname))
            {
                BroadcastSystem($"[{nickname}] 님이 퇴장했습니다]");
            }

            return Task.CompletedTask;
        }

        public Task SendMessage(string nickname, string text)
        {
            var msg = new ChatMessage(
                channel: this.GetPrimaryKeyString(),
                nickname: nickname,
                text: text,
                timestamp: DateTimeOffset.Now);

            foreach (var obj in _members.Values)
            {
                obj.Receive(msg);
            }

            return Task.CompletedTask;
        }

        private void BroadcastSystem(string text)
        {
            foreach (var obj in _members.Values)
            {
                obj.System(text);
            }
        }
    }
}
