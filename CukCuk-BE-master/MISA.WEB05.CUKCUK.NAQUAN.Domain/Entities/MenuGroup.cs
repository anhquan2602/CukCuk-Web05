using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities
{
    public class MenuGroup : Base
    {
        /// <summary>
        /// ID nhóm thực đơn
        /// </summary>
        public Guid? MenuGroupID { get; set; }   

        /// <summary>
        /// Tên nhóm thực đơn
        /// </summary>
        public string? MenuGroupName { get; set; }
        
        /// <summary>
        /// Mã nhóm thực đơn
        /// </summary>
        public string? MenuGroupCode { get; set; }
        
        
        /// <summary>
        /// Mã nhóm thực đơn
        /// </summary>
        public int? MenuGroupType { get; set; }
        
        
        /// <summary>
        /// Mã nhóm thực đơn
        /// </summary>
        public string? MenuGroupDescription { get; set; }
        
    }
}
