using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Server.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        Inotification notification;
        public NotificationController(Inotification notification)
        {
            this.notification = notification;
        }
        [HttpGet("test")]
        public dynamic test()
        { return "success"; }

        [HttpPost("Lay_DS_Thaydoi_I8")]
        public dynamic Lay_DS_Thaydoi_I8([FromBody] RangeDateRequestModel rdrm)
        {
            return notification.Lay_DS_Thaydoi_I8(rdrm);
        }
    }
}
