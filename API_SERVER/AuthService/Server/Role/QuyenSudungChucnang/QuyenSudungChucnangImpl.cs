using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;
using Newtonsoft.Json;

namespace AuthService.Server.Role.QuyenSudungChucnang
{
    public class QuyenSudungChucnangImpl : SqlserverImpl<QuyenSudungChucnangModel>, IquyenSudungChucnang
    {
        public QuyenSudungChucnangImpl(DataContext dataContext) : base(dataContext)
        {
        }

        dynamic IquyenSudungChucnang.Lay_DS_Quyen_Sudung_Chucnang()
        {
            DataRespond dataRespond = new DataRespond();
            try
            {
                dataRespond.success = true;
                dataRespond.data = getAll();
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

        dynamic IquyenSudungChucnang.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(int quyen_id)
        {
            DataRespond dataRespond = new DataRespond();
            try
            {
                var result= getAll().Where(c => c.quyen_id == quyen_id);
                string dschucnang = "";
                foreach(QuyenSudungChucnangModel item in result)
                {
                    dschucnang += item.chucnang_id + ",";
                }
                dschucnang = dschucnang.Substring(0, dschucnang.Length - 1);
                dataRespond.success = true;
                dataRespond.data = new {quyen_id = quyen_id, dschucnang = dschucnang};
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
