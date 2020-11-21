using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Server.user
{
    public interface Iuser
    {
        dynamic Lay_DS_Nguoidung();
        dynamic Lay_DS_Quyen_Nguoidung(string nhanvien_id);
    }
}
