using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2match_task
{
    public static class Main
    {
        public static ObservableCollection<Event> EventList { get; set; } = new ObservableCollection<Event>();
        public static ObservableCollection<Meeting> MeetingList { get; set; } = new ObservableCollection<Meeting>();
        public static ObservableCollection<User> UserList { get; set; } = new ObservableCollection<User>();
        public static User? ReturnUserById(int Id)
        {
            foreach(User user in UserList)
            {
                if (user.Id == Id) return user;
            }
            Console.WriteLine("No user with that Id was found, returned null reference.");
            return null;
        }
        public static Meeting? ReturnMeetingById(int Id)
        {
            foreach(Meeting meeting in MeetingList)
            {
                if(meeting.Id == Id) return meeting;
            }
            Console.WriteLine("No meeting with that Id was found, returned null reference.");
            return null;
        }
        public static Event? ReturnEventById(int Id)
        {
            foreach(Event @event in EventList)
            {
                if(@event.Id== Id) return @event;
            }
            Console.WriteLine("No event with that Id was found, returned null reference.");
            return null;
        }
    }
}
