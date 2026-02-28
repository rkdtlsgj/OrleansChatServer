[GenerateSerializer]
public record ChatMessage(string channel, string nickname, string text, DateTimeOffset timestamp);