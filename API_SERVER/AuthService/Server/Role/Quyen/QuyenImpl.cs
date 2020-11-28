using System;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role
{
    public class QuyenImpl : SqlserverImpl<QuyenModel>, Iquyen
    {

        public QuyenImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_DS_Quyen()
        {
            DataRespond dataRespond = new DataRespond();
            dynamic result;
            try
            {
                result = getAll();
                dataRespond.success = true;
                dataRespond.data = result;
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
