using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO
{
    public class FoodDetail
    {
        /// <summary>
        /// Món ăn
        /// </summary>
        public Food food { get; set; }

        /// <summary>
        /// List sở thích phục vụ thêm
        /// </summary>
        public List<ServiceHobby>? serviceHobbies { get; set; }
        
        /// <summary>
        /// Ngày và giờ thêm
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
