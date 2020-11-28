using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Model.Connection.SQLServer
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //Tên dbset phải giống hệt trong sqlserver
        public DbSet<QuyenModel> Quyen { get; set; }
        public DbSet<PhanquyenModel> PhanQuyen { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
