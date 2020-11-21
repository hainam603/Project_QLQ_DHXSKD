using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Server.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Iuser user;
        public UserController(Iuser user)
        {
            this.user = user;
        }
        [HttpGet("test")]
        public dynamic test()
        { return "success"; }
        [HttpGet("Lay_DS_Nguoidung")]
        public dynamic Lay_DS_Nguoidung()
        {
            return user.Lay_DS_Nguoidung();
        }
        [HttpGet("Lay_DS_Quyen_Nguoidung")]
        public dynamic Lay_DS_Quyen_Nguoidung(string nhanvien_id)
        {
            return user.Lay_DS_Quyen_Nguoidung(nhanvien_id);
        }
    }
}
