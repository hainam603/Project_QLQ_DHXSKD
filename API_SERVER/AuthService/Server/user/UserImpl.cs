using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Connection;
using Model.Connection.Oracle;
using Model.Model;
using Oracle.ManagedDataAccess.Client;

namespace AuthService.Server.user
{
    public class UserImpl : Iuser
    {
        DataRespond datarespond = new DataRespond();
        Connection connection = new Connection();
        public dynamic Lay_DS_Nguoidung()
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.Lay_ds_nguoi_dung";
                    result = SqlMapper.Query<DanhsachNguoidungModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "get list users success";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
    }
        
    
}
