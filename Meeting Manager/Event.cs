using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2match_task
{
    public class Event
    {
        public int Id { get; set; }
        public ObservableCollection<User> attendingUsers { get; set; }
        public Event(int Id, ObservableCollection<User> attendingUsers) {
            this.Id = Id;
            this.attendingUsers = new ObservableCollection<User>(attendingUsers);
        }
        public override String ToString()
        {
            String EventData = "";
            EventData += "Event Id: " + this.Id.ToString() + "\n";
            EventData += "Ids of attending users: ";
            foreach(User user in attendingUsers) {
                EventData += user.Id.ToString() + " ";
            }
            return EventData;
        }
    }
}
