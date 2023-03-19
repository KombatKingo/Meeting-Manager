using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintMeeting : ControllerBase
    {
        [HttpPut(Name = "PrintMeeting")]
        public string Put(int MeetingId)
        {
            Meeting TempMeeting = Main.ReturnMeetingById(MeetingId);
            if(TempMeeting == null) {
                return "No meeting with that Id exists.";
            }
            return TempMeeting.ToString();
        }
    }
}