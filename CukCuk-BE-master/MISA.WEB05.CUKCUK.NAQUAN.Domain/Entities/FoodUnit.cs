using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities
{
    public class FoodUnit : Base
    {
        /// <summary>
        /// ID đơn vị tính
        /// </summary>
        public Guid FoodUnitID { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string? FoodUnitName { get; set; }   
        
        /// <summary>
        /// mô tả đơn vị tính
        /// </summary>
        public string? FoodUnitDescription{ get; set; }   


    }
}
