using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateUser : ControllerBase
    {
        [HttpPut(Name = "CreateUser")]
        public string Put(int Id, string Organisation)
        {
            foreach(User user in Main.UserList)
            {
                if(user.Id == Id) {
                    return "User with that Id already exists, so no new user was created.";
                }
            }
            User NewUser = new User(Id, Organisation);
            Main.UserList.Add(NewUser);
            return ("User added successfully");
        }
    }
}