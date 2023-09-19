using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces
{
    public interface IServiceHobbyRepository : IBaseRepository<ServiceHobby>
    {
        /// <summary>
        /// Thêm sở thích phục vụ thêm
        /// </summary>
        /// <param name="serviceHobby">Sở thích phục vụ thêm</param>
        /// <returns>Số sở thích được thêm</returns>
        /// CreatedBy: NAQUAN(27/04/2023)
        public int InsertServiceHobby(ServiceHobby serviceHobby);
        //public int InsertServiceHobby(ServiceHobby serviceHobby, MySqlTransaction? mySqlTransaction);

        /// <summary>
        /// Lấy ra các sở thích phục vụ thêm từ món ăn
        /// </summary>
        /// <param name="foodID">Mã món ăn </param>
        /// <returns>Danh sách sở thích phục vụ thêm từ mã ID truyền vào</returns>
        /// CreatedBy: NAQUAN(27/04/2023)
        public IEnumerable<ServiceHobby> GetListService(Guid foodID);

        /// <summary>
        /// Xoá các sở thích phục vụ thêm từ ID món ăn
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <returns>Số sở thích bị xoá </returns>
        /// CreatedBy: NAQUAN(27/04/2023)
        public int DeleteServiceHobby(Guid foodID);
    }
}
