using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities
{
    public class ServiceHobby : Base
    {
        /// <summary>
        /// ID Sở thích phục vụ
        /// </summary>
        public Guid? ServiceHobbyID { get; set; }

        /// <summary>
        /// Tên sở thích phục vụ
        /// </summary>
        public string? ServiceHobbyName { get; set; }

        /// <summary>
        /// Tiền thêm
        /// </summary>
        public double? AdditionalPayment { get; set; }

        /// <summary>
        /// ID món ăn
        /// </summary>
        public Guid? FoodID { get; set; }

    

    }
}
