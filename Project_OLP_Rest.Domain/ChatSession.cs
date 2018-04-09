using System;
using System.Collections.Generic;
using System.Text;

namespace Project_OLP_Rest.Domain
{
    public class ChatSession
    {
        public Guid Id { get; set; }

        public int ChatBotId { get; set; }
        public ChatBot ChatBot { get; set; }
        public string Data { get; set; }
    }
}
