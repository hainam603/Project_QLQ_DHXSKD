using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class QuyenSudungChucnangModel
    {
        [Key]
        public int quyen_id { get; set; }
        public int chucnang_id { get; set; }
    }
}
