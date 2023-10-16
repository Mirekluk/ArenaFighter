using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class EntryEvent:Event
    {
        
        public string Message { get; set; }
        public EntryEvent(string name,string message):base(name)
        {
            Message = message;
            
        }
        public EntryEvent(string name) : base(name)
        {
            Message = "Not defined";
            
        }
        public EntryEvent(string name, string message, Event e) : base(name, e)
        {
            Message = message;
            AddFollower(e);
        }

    }
}
