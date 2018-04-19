using QXS.ChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Rest.RuleSets
{
    public interface IRuleSet
    {
        IEnumerable<BotRule> Rules { get; set; }
    }
}
