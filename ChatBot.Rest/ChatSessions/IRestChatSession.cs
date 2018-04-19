using QXS.ChatBot;

namespace ChatBot.Rest.ChatSessions
{
    public interface IRestChatSession : ChatSessionInterface
    {
        int Id { get; set; }
    }
}
