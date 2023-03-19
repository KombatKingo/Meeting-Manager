using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintListOfEverything : ControllerBase
    {
        [HttpPut(Name = "PrintListOfEverything")]
        public string Put()
        {
            String TempString = "";
            TempString += "Event Ids: ";
            foreach (Event @event in Main.EventList)
            {
                TempString += @event.Id.ToString() + " ";
            }
            TempString += "\nMeeting Ids: ";
            foreach (Meeting meeting in Main.MeetingList)
            {
                TempString += meeting.Id.ToString() + " ";
            }
            TempString += "\nUser Ids: ";
            foreach (User user in Main.UserList)
            {
                TempString += user.Id.ToString() + " ";
            }
            return TempString;
        }
    }
}