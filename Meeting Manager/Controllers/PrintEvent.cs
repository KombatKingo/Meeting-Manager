using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintEvent : ControllerBase
    {
        [HttpPut(Name = "PrintEvent")]
        public string Put(int EventId)
        {
            Event TempEvent = Main.ReturnEventById(EventId);
            if(TempEvent == null) {
                return "No event with that Id exists.";
            }
            return TempEvent.ToString();
        }
    }
}