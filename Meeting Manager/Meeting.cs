using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2match_task
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ObservableCollection<User> UsersWithPendingInvitation { get; set; }
        public ObservableCollection<User> AttendingUsers { get; set; }
        public bool IsHappening { get; set; }
        public Meeting(int Id, DateTime startTime, DateTime endTime, ObservableCollection<User> InvitedUsers) { 
            this.Id = Id;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.UsersWithPendingInvitation = new ObservableCollection<User>(InvitedUsers);
            this.AttendingUsers = new ObservableCollection<User>();
            this.IsHappening = true;
        }
        public void Checker()
        {
            if(!this.IsHappening)
            {
                foreach(User user in AttendingUsers)
                {
                    user.PotentialMeetings.Remove(this);
                }
                Main.MeetingList.Remove(this);
                return;
            }
            if (UsersWithPendingInvitation.Count == 0)
            {
                foreach(User user in AttendingUsers)
                {
                    user.PotentialMeetings.Remove(this);
                    user.AttendingMeetings.Add(this);
                    return;
                }
            }
        }
        public override string ToString()
        {
            String MeetingData = "";
            MeetingData += "Meeting Id: " + this.Id.ToString() + "\nStart time: " + this.StartTime.ToString() + "\nEnd time: " + this.EndTime.ToString() + "\n";
            MeetingData += "User Ids of users with pending invitation: ";
            foreach(User user in this.UsersWithPendingInvitation)
            {
                MeetingData += user.Id.ToString() + " ";
            }
            MeetingData += "\nUser Ids of users attending this meeting: ";
            foreach(User user in this.AttendingUsers)
            {
                MeetingData += user.Id.ToString() + " ";
            }
            MeetingData += "\nIs this meeting happening: " + this.IsHappening.ToString();
            return MeetingData;
        }
    }
}
