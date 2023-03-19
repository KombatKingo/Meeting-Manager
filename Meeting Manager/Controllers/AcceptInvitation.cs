using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcceptInvitation : ControllerBase
    {
        [HttpPut(Name = "AcceptInvitation")]
        public string Put(int UserId, int MeetingId)
        {
            Meeting TempMeeting = Main.ReturnMeetingById(MeetingId);
            User TempUser = Main.ReturnUserById(UserId);
            if (TempMeeting == null)
            {
                return "No meeting with that Id exists.";
            }
            if (TempUser == null)
            {
                return "No user with that Id exists.";
            }
            if (!TempMeeting.UsersWithPendingInvitation.Contains(TempUser))
            {
                return "This user isn't invited to that meeting.";
            }
            if (TempUser.IsUserAlreadyInAMeeting(TempMeeting))
            {
                return "This user is already in a meeting at this time.";
            }
            TempMeeting.AttendingUsers.Add(TempUser);
            TempUser.PotentialMeetings.Add(TempMeeting);
            TempMeeting.UsersWithPendingInvitation.Remove(TempUser);
            TempMeeting.Checker();
            return "Successfully accepted invitation.";
        }
    }
}