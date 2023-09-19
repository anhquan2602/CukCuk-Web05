using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class CookRoomService : BaseService<CookRoom> , ICookRoomService
    {
        #region Properties

        private ICookRoomRepository _CookRoomRepository;

        #endregion

        #region Contructor

        public CookRoomService(ICookRoomRepository CookRoomRepository) : base(CookRoomRepository)
        {
            _CookRoomRepository = CookRoomRepository;
        }

        #endregion
        
        
        #region Method
        public CukCukResponse InsertCookRoom(CookRoom CookRoom)
        {
            var res = _CookRoomRepository.InsertCookRoom(CookRoom);
            if (Guid.Equals(res, Guid.Empty))
            {
                return new CukCukResponse()
                {
                    StatusCode = 400,
                    ListErrors = new List<string>() { "0" }
                };
            }
        
            return new CukCukResponse()
            {
                StatusCode = 201,
                ListErrors = new List<string>() { "1" }
            };
        }
        #endregion
    }
}
