﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class DanhsachNguoidungModel
    {
        public string nguoidung_ID { get; set; } 
        public string ma_ND { get; set; }
        public string ma_NV { get; set; }
        public string ten_NV { get; set; }
        public string so_DT { get; set; }
        public int nhanvien_ID { get; set; }
        public int trangThai { get; set; }
        public string ghiChu { get; set; }
    }
}