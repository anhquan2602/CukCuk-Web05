using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface ICookRoomService : IBaseService<CookRoom>
    {
        public CukCukResponse InsertCookRoom(CookRoom CookRoom);
    }
}
