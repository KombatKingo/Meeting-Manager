using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateMeeting : ControllerBase
    {
        [HttpPut(Name = "CreateMeeting")]
        public string Put(int IdOfUserStartingMeeting, int MeetingId, DateTime StartTime, DateTime EndTime, string IdsOfInvitedUsers)
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            string[] UserIds = IdsOfInvitedUsers.Split(' ');
            int[] UserIdsInt = new int[UserIds.Length];
            for (int i = 0; i < UserIds.Length; i++)
            {
                UserIdsInt[i] = Convert.ToInt32(UserIds[i]);
            }
            foreach (Meeting meeting in Main.MeetingList)
            {
                if (meeting.Id == MeetingId)
                {
                    return "Meeting with that Id already exists, so no new meeting was created.";
                }
            }
            if (Main.ReturnUserById(IdOfUserStartingMeeting)==null) {
                return "At least one user Id is invalid, so no meeting was created.";
            }
            if (UserIdsInt.Contains(IdOfUserStartingMeeting))
            {
                return "User who is starting the meeting cannot invite themselves to the meeting, so no meeting was created.";
            }
            users.Add(Main.ReturnUserById(IdOfUserStartingMeeting));
            foreach(int Id in UserIdsInt)
            {
                if(Main.ReturnUserById(Id) == null) {
                    return "At least one user Id is invalid, so no meeting was created";
                }
                bool UsersShareEvent = false;
                foreach (Event @event in Main.EventList)
                {
                    if (@event.attendingUsers.Contains(Main.ReturnUserById(IdOfUserStartingMeeting)) && @event.attendingUsers.Contains(Main.ReturnUserById(Id)))
                    {
                        UsersShareEvent = true;
                    }
                }
                if (!UsersShareEvent)
                {
                    return "At least one of the invited users doesn't share an event with the user creating the meeting, so no meeting was created.";
                }
                users.Add(Main.ReturnUserById(Id));
            }
            Meeting NewMeeting = new Meeting(IdOfUserStartingMeeting, StartTime, EndTime, users);
            Main.MeetingList.Add(NewMeeting);
            return "Meeting created successfully";
            }
    }
}