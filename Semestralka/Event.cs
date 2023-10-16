using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class Event
    {
        public string Name { get; set; }
        protected List<Event> followerList;
        public Event()
        {
            Name = "Not defined";
        }
        public Event(string name)
        {
            Name = name;
        }
        public Event(string name, Event e)
        {
            Name = name;
            this.AddFollower(e);
        }
        public Event(string name,List<Event>followerList)
        {
            Name = name;
            this.followerList = followerList;
        }
        public void AddFollower(Event e)
        {
            followerList.Add(e);
        }        
        public Event FindFollower(string name)
        {
            return followerList.Find(x=>x.Name==name);
        }
        virtual public void Execute()
        {
            Console.WriteLine("No other Execute found, using Execute from Event class");
        }

    }
}
