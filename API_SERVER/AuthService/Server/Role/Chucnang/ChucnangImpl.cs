using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Chucnang
{
    public class ChucnangImpl : SqlserverImpl<ChucnangModel>, Ichucnang
    {
        public ChucnangImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_DS_Chucnang()
        {
            return getAll();
        }
        public dynamic Lay_DS_Chucnang_Theo_DS_Chucnang_ID(string dschucnang_id)
        {
            string[] sdschucnang_id = dschucnang_id.Split(',');
            int[] myInts = Array.ConvertAll(sdschucnang_id, s => int.Parse(s));
            DataRespond dataRespond = new DataRespond();
            try
            {
                dataRespond.success = true;
                dataRespond.data = getAll().Where(c => myInts.Contains(c.chucnang_id)).OrderBy(m => m.menu).ThenBy(s => s.stt);
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
