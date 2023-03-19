using b2match_task;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace Meeting_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintUser : ControllerBase
    {
        [HttpPut(Name = "PrintUser")]
        public string Put(int UserId)
        {
            User TempUser = Main.ReturnUserById(UserId);
            if(TempUser == null) {
                return "No user with that Id exists.";
            }
            return TempUser.ToString();
        }
    }
}