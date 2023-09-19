using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class ServiceHobbyService : BaseService<ServiceHobby> , IServiceHobbyService
    {
        private IServiceHobbyRepository _ServiceHobbyRepository;

        public ServiceHobbyService(IServiceHobbyRepository ServiceHobbyRepository) : base(ServiceHobbyRepository)
        {
            _ServiceHobbyRepository = ServiceHobbyRepository;
        }

        /// <summary>
        /// Lấy ra danh sách sở thích phục vụ thêm theo ID món ăn
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <returns>danh sách sở thích phục vụ thêm theo ID món ăn</returns>
        /// CreatedBy: NAQUAN (24/04/2023)
        public IEnumerable<ServiceHobby> GetListService(Guid foodID)
        {
            return _ServiceHobbyRepository.GetListService(foodID);
        }

    }
}
