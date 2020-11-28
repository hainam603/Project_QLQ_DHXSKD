using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class PhanquyenModel
    {
        [Key]
        public string ma_nd { get; set; }
        public int quyen_id { get; set; }
    }
}
