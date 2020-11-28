using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Phanquyen
{
    public class PhanquyenImpl : SqlserverImpl<PhanquyenModel>, Iphanquyen
    {
        public PhanquyenImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_Quyen_Nguoidung(string ma_nd)
        {
            DataRespond dataRespond = new DataRespond();
            try
            {
                dataRespond.success = true;
                dataRespond.data = getById(ma_nd);
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {

                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }
    }
}
