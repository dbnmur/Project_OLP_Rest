using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QXS.ChatBot.RulesSets
{
    public interface IRuleSet
    {
        IEnumerable<BotRule> Rules { get; }
    }
}
