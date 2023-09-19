using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IFoodDetailService : IBaseService<FoodDetail>
    {
        /// <summary>
        /// Thêm món ăn và sở thích phục vụ thêm
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>ID món ăn đã thêm</returns>
        /// CreatedBy: NAQUAN(25/04/2023)
        public CukCukResponse InsertFoodDetail(FoodDetail FoodDetail);

        /// <summary>
        /// Cập nhật món ăn
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>Bản ghi bị ảnh hưởng</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (24/04/2023)
        public CukCukResponse UpdateFood(FoodDetail FoodDetail);
    }
}
