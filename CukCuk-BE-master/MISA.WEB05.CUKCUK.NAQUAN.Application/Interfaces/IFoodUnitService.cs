using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IFoodUnitService : IBaseService<FoodUnit>
    {
        /// <summary>
        /// Thêm món ăn và sở thích phục vụ thêm
        /// </summary>
        /// <param name="FoodUnit">Thêm đơn vị tính</param>
        /// <returns>ID đơn vị đã thêm</returns>
        /// CreatedBy: NAQUAN(25/04/2023)
        public CukCukResponse InsertFoodUnit(FoodUnit FoodUnit);
    }
}
