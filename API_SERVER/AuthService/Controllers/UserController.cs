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
        // Quyền người dùng
        [HttpGet("Lay_DS_Quyen_Nguoidung")]
        public dynamic Lay_DS_Quyen_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_Quyen_Nguoidung(ma_nd);
        }
        //Menu người dùng
        [HttpGet("Lay_DS_Menu_Nguoidung")]
        public dynamic Lay_DS_Menu_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_Menu_Nguoidung(ma_nd);
        }
        [HttpGet("Lay_DS_LoaiNV_Nguoidung")]
        public dynamic Lay_DS_LoaiNV_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_LoaiNV_Nguoidung(ma_nd);
        }
        //Báo cáo người dùng
        [HttpGet("Lay_DS_Nhombaocao_Nguoidung")]
        public dynamic Lay_DS_Nhombaocao_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_Nhombaocao_Nguoidung(ma_nd);
        }
        [HttpGet("Lay_DS_Baocao_Nguoidung")]
        public dynamic Lay_DS_Baocao_Nguoidung(string ma_nd, string nhom_bc_id)
        {
            return user.Lay_DS_Baocao_Nguoidung(ma_nd, nhom_bc_id);
        }
    }
}
