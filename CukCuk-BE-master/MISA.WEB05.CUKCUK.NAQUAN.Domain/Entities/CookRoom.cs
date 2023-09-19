using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities
{
    public class CookRoom : Base
    {
    /// <summary>
    /// ID Nơi chế biến
    /// </summary>
        public Guid? CookRoomID { get; set; }   

        /// <summary>
        /// Tên nơi chế biến
        /// </summary>
        public string? CookRoomName { get; set; }
        
        /// <summary>
        /// mô tả đơn vị tính
        /// </summary>
        public string? CookRoomDescription{ get; set; }   
    }
}
