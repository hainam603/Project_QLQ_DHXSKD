using AuthService.Server.Role;
using AuthService.Server.Role.Chucnang;
using AuthService.Server.Role.Phanquyen;
using AuthService.Server.Role.QuyenSudungChucnang;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        Iphanquyen phanquyen;
        Iquyen quyen;
        Ichucnang chucnang;
        IquyenSudungChucnang quyensudungchucnang;

        public RoleController(Iphanquyen phanquyen, Iquyen quyen, 
            Ichucnang chucnang, IquyenSudungChucnang quyensudungchucnang)
        {
            this.phanquyen = phanquyen;
            this.quyen = quyen;
            this.chucnang = chucnang;
            this.quyensudungchucnang = quyensudungchucnang;
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
        //Chức năng
        [HttpGet("Lay_DS_Chucnang")]
        public dynamic Lay_DS_Chucnang()
        {
            return chucnang.Lay_DS_Chucnang();
        }

        [HttpGet("Lay_DS_Chucnang_Theo_DS_Chucnang_ID")]
        public dynamic Lay_DS_Chucnang_Theo_DS_Chucnang_ID(string dschucnang_id)
        {
            return chucnang.Lay_DS_Chucnang_Theo_DS_Chucnang_ID(dschucnang_id);
        }
        //Quyền sử dụng chức năng
        [HttpGet("Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID")]
        public dynamic Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(int quyen_id)
        {
            return quyensudungchucnang.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(quyen_id);
        }
       
    }
}
