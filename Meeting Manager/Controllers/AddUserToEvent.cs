using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddUserToEvent : ControllerBase
    {
        [HttpPut(Name = "AddUserToEvent")]
        public string Put(int UserId, int EventId)
        {
            User TempUser = Main.ReturnUserById(UserId);
            Event TempEvent = Main.ReturnEventById(EventId);
            if (TempEvent==null)
            {
                return "No event with that Id exists.";
            }
            if (TempUser==null)
            {
                return "No user with that Id exists.";
            }
            if (TempEvent.attendingUsers.Contains(TempUser))
            {
                return "User is already part of that event.";
            }
            TempEvent.attendingUsers.Add(TempUser);
            return "Added user to event successfully.";
        }
    }
}