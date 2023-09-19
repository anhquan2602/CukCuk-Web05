using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces
{
    public interface IFoodUnitRepository : IBaseRepository<FoodUnit>
    {
        /// <summary>
        /// Thêm đơn vị tính
        /// </summary>
        /// <param name="FoodUnit"></param>
        /// <param name="food">Thông tin món ăn muốn thêmm </param>
        /// <returns>Mã món ăn mới thêm</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public Guid InsertFoodUnit(FoodUnit FoodUnit);
    }
}
