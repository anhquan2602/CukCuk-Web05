using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        ///Lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy NAQUAN 20/04/2023
        /// 
        public IEnumerable<TEntity> GetALL();
        
       
    }
}
