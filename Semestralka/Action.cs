using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    enum Target{Self,Creature,Multiple }
    class Action
    {
        public string Name { get; set; }
        public Target Target { get; set; }
        public string SucessMessage { get; set; }
        public string FailureMessage { get; set; }
        public int ChanceOfSuccess { get; set; }
        public Action(string name, Target target)
        {
            Name = name;
            Target = Target;
            SucessMessage = $"{Name} has been used sucessfully ";
            FailureMessage = $"{Name} has been tried and failed";
            ChanceOfSuccess = 100;
        }
        public Action(string name,Target target,string sucessMessage,string failureMessage,int chanceOfSuccess)
        {
            Name = name;
            Target = target;
            SucessMessage = sucessMessage;
            FailureMessage = failureMessage;
            ChanceOfSuccess = chanceOfSuccess;
        }

    }
}
