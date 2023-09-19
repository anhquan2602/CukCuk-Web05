using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IMenuGroupService : IBaseService<MenuGroup>
    {
        /// <summary>
        /// Thêm menu
        /// </summary>
        /// <param name="MenuGroup">Thêm menu thức ăn</param>
        /// <returns>ID menu đã thêm</returns>
        /// CreatedBy: NAQUAN(25/04/2023)
        public CukCukResponse InsertMenuGroup(MenuGroup MenuGroup);
    }
}
