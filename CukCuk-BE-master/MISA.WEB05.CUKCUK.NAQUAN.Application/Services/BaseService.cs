using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Attributes;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Properties

        private IBaseRepository<TEntity> _BaseRepository;
        protected List<string> errorList;
        protected bool IsValid = true;

        #endregion

        #region Contructor

        public BaseService(IBaseRepository<TEntity> BaseRepository) 
        {
            _BaseRepository = BaseRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// CreatedBy NAQUAN 20/04/2023
        public IEnumerable<TEntity> GetAll()
        {
            return _BaseRepository.GetALL();
        }
        

        #endregion
    }
}
