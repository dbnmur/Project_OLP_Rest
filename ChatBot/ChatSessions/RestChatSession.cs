using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QXS.ChatBot.ChatSessions
{
    public class RestChatSession : ChatSessionInterface
    {
        public bool IsInteractive { get { return true; } set { } }
        public SessionStorage SessionStorage { get; set; }

        public event Action<ChatSessionInterface, string> OnMessageReceived;
        public event Action<ChatSessionInterface, string> OnMessageSent;

        protected List<BotResponse> _responseHistory = new List<BotResponse>();

        public RestChatSession()
        {
            SessionStorage = new SessionStorage();
        }

        public RestChatSession(Dictionary<string, string> sessionStorageData)
        {
            SessionStorage = new SessionStorage(sessionStorageData);
        }

        public void AddResponseToHistory(BotResponse response)
        {
            _responseHistory.Add(response);
        }

        public string AskQuestion(string message)
        {
            SendMessage(message);
            return ReadMessage();
        }

        public Stack<BotResponse> GetResponseHistory()
        {
            _responseHistory.Reverse();
            return new Stack<BotResponse>(_responseHistory);
        }

        public string ReadMessage()
        {
            // Get response from rest call
            string str = null;
            if (str != null && OnMessageReceived != null)
            {
                OnMessageReceived(this, str);
            }
            return str;
        }

        public void SendMessage(string message)
        {
            // Send response as rest call
            if (message != null && OnMessageSent != null)
            {
                OnMessageSent(this, message);
            }
        }

        public void SetResponseHistorySize(int Size) { }
    }
}
