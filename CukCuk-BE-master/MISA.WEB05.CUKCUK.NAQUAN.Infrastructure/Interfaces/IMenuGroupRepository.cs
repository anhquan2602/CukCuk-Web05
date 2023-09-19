using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces
{
    public interface IMenuGroupRepository : IBaseRepository<MenuGroup>
    {
        /// <summary>
        /// Thêm nhóm thực đơn
        /// </summary>
        /// <param name="MenuGroup"></param>
        /// <param name="menugroup">Thông tin thực đơn muốn thêmm </param>
        /// CreatedBy: NAQUAN (22/04/2023)
        public Guid InsertMenuGroup(MenuGroup MenuGroup);
    }
}
