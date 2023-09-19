using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IServiceHobbyService : IBaseService<ServiceHobby>
    {
        /// <summary>
        /// Lấy ra danh sách sở thích phục vụ thêm theo ID món ăn
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <returns>danh sách sở thích phục vụ thêm theo ID món ăn</returns>
        /// CreatedBy: NAQUAN (24/04/2023)
        public IEnumerable<ServiceHobby> GetListService(Guid foodID);
    }
}
