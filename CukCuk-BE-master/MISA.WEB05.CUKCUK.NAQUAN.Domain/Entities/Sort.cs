using MISA.WEB05.CUKCUK.NAQUAN.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities
{
    public class Sort
    {
        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Sắp xếp theo thứ tự
        /// </summary>
        public Direction direction { get; set; }
    }
}
