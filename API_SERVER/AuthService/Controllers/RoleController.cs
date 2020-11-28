using AuthService.Server.Role;
using AuthService.Server.Role.Phanquyen;

using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        Iphanquyen phanquyen;
        Iquyen quyen;

        public RoleController(Iphanquyen phanquyen, Iquyen quyen)
        {
            this.phanquyen = phanquyen;
            this.quyen = quyen;
        }
        [HttpGet("test")]
        public dynamic test()
        {
            return "success";
        }

        [HttpGet("Lay_DS_Quyen")]
        public dynamic Lay_DS_Quyen()
        {
            return quyen.Lay_DS_Quyen();
        }
        [HttpGet("Lay_Quyen_Nguoidung")]
        public dynamic Lay_Quyen_Nguoidung(string ma_nd)
        {
            return phanquyen.Lay_Quyen_Nguoidung(ma_nd);
        }
    }
}
