using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateEvent : ControllerBase
    {
        [HttpPut(Name = "CreateEvent")]
        public string Put(int Id, string IdsOfAttendingUsers)
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            string[] UserIds = IdsOfAttendingUsers.Split(' ');
            int[] UserIdsInt = new int[UserIds.Length];
            for(int i = 0; i < UserIds.Length; i++)
            {
                UserIdsInt[i] = Convert.ToInt32(UserIds[i]);
            }
            foreach (Event @event in Main.EventList)
            {
                if (@event.Id == Id)
                {
                    return "Event with that Id already exists, so no new event was created.";
                }
            }
            foreach(int UserId in UserIdsInt)
            {
                if (Main.ReturnUserById(UserId) == null)
                {
                    return "At least one user Id is invalid, so no event was created";
                }
                users.Add(Main.ReturnUserById(UserId));
            }
            Event NewEvent = new Event(Id, users);
            Main.EventList.Add(NewEvent);
            return "Event created successfully.";
        }
    }
}