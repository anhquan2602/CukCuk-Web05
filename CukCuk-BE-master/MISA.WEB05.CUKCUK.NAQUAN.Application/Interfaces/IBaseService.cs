using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy NAQUAN 20/08/2023
        public IEnumerable<TEntity> GetAll();

        
    }
}
