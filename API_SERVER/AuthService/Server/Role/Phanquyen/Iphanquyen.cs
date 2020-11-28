using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Phanquyen
{
    public interface Iphanquyen:Isqlserver<PhanquyenModel>
    {
        dynamic Lay_Quyen_Nguoidung(string ma_nd);
    }
}
