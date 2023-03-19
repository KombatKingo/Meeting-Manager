using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2match_task
{
    public class User
    {
        public int Id { get; set; }
        public string? Organisation { get; set; }
        public ObservableCollection<Meeting> PotentialMeetings { get; set; }
        public ObservableCollection<Meeting> AttendingMeetings { get; set; }
        public User(int Id, string Organisation) {
            this.Id = Id;
            this.Organisation = Organisation;
            this.PotentialMeetings = new ObservableCollection<Meeting>();
            this.AttendingMeetings = new ObservableCollection<Meeting>();
        }
        public void AcceptInvitation(Meeting meeting)
        {
            if (!meeting.UsersWithPendingInvitation.Contains(this))
            {
                Console.WriteLine("This user isn't invited to that meeting!");
                return;
            }
            if (IsUserAlreadyInAMeeting(meeting))
            {
                Console.WriteLine("This user is already in a meeting in that time!");
                return;
            }
            meeting.AttendingUsers.Add(this);
            this.PotentialMeetings.Add(meeting);
            meeting.UsersWithPendingInvitation.Remove(this);
            meeting.Checker();
            return;
        }
        public bool IsUserAlreadyInAMeeting(Meeting meeting)
        {
            for (int i = 0; i < AttendingMeetings.Count; i++)
            {
                /*
                3 cases for meetings intersecting: 
                    1. start time of meeting 1 is during meeting 2
                    2. end time of meeting 1 is during meeting 2
                    3. meeting 1 completely envelops meeting 2
                in case of meeting 2 being created after meeting 1, the error is caught by the first two cases
                however, if meeting 1 is created after meeting 2, the first two cases will miss the error
                */
                if ((meeting.StartTime >= AttendingMeetings[i].StartTime && meeting.StartTime <= AttendingMeetings[i].EndTime) || (meeting.EndTime >= AttendingMeetings[i].StartTime && meeting.EndTime <= AttendingMeetings[i].EndTime) || (meeting.StartTime <= AttendingMeetings[i].StartTime && meeting.EndTime >= AttendingMeetings[i].EndTime))
                {
                    return true;
                }
            }
            for (int i = 0; i < PotentialMeetings.Count; i++)
            {
                if ((meeting.StartTime >= PotentialMeetings[i].StartTime && meeting.StartTime <= PotentialMeetings[i].EndTime) || (meeting.EndTime >= PotentialMeetings[i].StartTime && meeting.EndTime <= PotentialMeetings[i].EndTime) || (meeting.StartTime <= PotentialMeetings[i].StartTime && meeting.EndTime >= PotentialMeetings[i].EndTime))
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            String UserData = "";
            UserData += "User Id: " + this.Id.ToString() + "\nOrganisation: " + this.Organisation + "\n";
            UserData += "Ids of potential meetings (meetings this user has accepted, but aren't yet confirmed): ";
            foreach(Meeting meeting in this.PotentialMeetings){
                UserData += meeting.Id.ToString() + " ";
            }
            UserData += "\nIds of meetings this user is attending: ";
            foreach (Meeting meeting in this.AttendingMeetings)
            {
                UserData += meeting.Id.ToString() + " ";
            }
            return UserData;
        }
    }
}