﻿using System;
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

namespace AuthService.Server.auth
{
    public class AuthImpl:Iauth
    {
        public dynamic login(LoginRequestModel lrm)
        {
            var datarespond = new DataRespond();
            var connection = new Connection();
            var result = new NguoiDungLoginModel();
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_username", OracleDbType.Varchar2, ParameterDirection.Input, lrm.ma_ND);
                dyParam.Add("p_password", OracleDbType.Varchar2, ParameterDirection.Input, lrm.Matkhau);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.Lay_thong_tin_login";
                    result = SqlMapper.Query<NguoiDungLoginModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                }
                if (result.message != "0")
                {
                    datarespond.success = true;
                    datarespond.data = new { token = genToken(result.ma_ND), nguoidung = result };
                    datarespond.message = "Login success";
                }
                else
                {
                    datarespond.success = false;
                    datarespond.message = "Username or Password is not correct";
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        public dynamic genToken(string username)
        {
            var audience = new Audience();
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audience.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audience.Iss,
                ValidateAudience = true,
                ValidAudience = audience.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: audience.Iss,
                audience: audience.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromDays(1)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var responseJson = new
            {
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromDays(1).TotalSeconds
            };

            return responseJson;
        }
    }
}
