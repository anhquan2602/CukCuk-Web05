using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces
{
    public interface ICookRoomRepository : IBaseRepository<CookRoom>
    {
        
        public Guid InsertCookRoom(CookRoom CookRoom);
    }
}
