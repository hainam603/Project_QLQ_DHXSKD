using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class QuyenModel
    {
        [Key]
        public int quyen_id { get; set; }
        public string ten_quyen { get; set; }
    }
}
