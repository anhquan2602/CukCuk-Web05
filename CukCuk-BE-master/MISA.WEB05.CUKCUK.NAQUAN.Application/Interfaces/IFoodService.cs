using Microsoft.AspNetCore.Http;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Services;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces
{
    public interface IFoodService: IBaseService<Food> 
    {
        /// <summary>
        /// Lọc và sắp xếp bản ghi
        /// </summary>
        /// <param name="filter">Điều kiện lọc và sort dữ liệu </param>
        /// <returns>Danh sách bản ghi theo điều kiện lọc và sắp xếp</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public object FilterFood(Filter filter);

        /// <summary>
        /// Lấy ra mã mới
        /// </summary>
        /// <param name="name">Tên món ăn để lấy mã mới</param>
        /// <returns>Mã mới</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public string GetNewCode(string name);

        /// <summary>
        /// Hiển thị ảnh
        /// </summary>
        /// <param name="imageName">tên ảnh trên server</param>
        /// <returns>Hiển thị ảnh</returns>
        /// CreatedBy: NAQUAN (26/04/2023)
        public ImageDto GetImage(string imageName);

        /// <summary>
        /// Lấy món ăn theo ID
        /// </summary>
        /// <param name="id">ID món ăn cần lấy</param>
        /// <returns>Thông tin bản ghi theo ID</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public Food GetByID(Guid id);

        /// <summary>
        /// Xoá 1 hoặc nhiều món ăn
        /// </summary>
        /// <param name="ids">Chuỗi chứa một hoặc nhiều mã món ăn</param>
        /// <returns>Số bản ghi bị xoá</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public int DeleteFood(string ids);

        /// <summary>
        /// Upload ảnh lên server
        /// </summary>
        /// <param name="fileImage">Obj ảnh</param>
        /// <returns>Tên của ảnh trên server</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        public string UploadImage(IFormFile fileImage);

        /// <summary>
        /// Xoá ảnh trong thư mục
        /// </summary>
        /// <param name="fileName">Tên ảnh muốn xoá</param>
        /// <returns>Xoá ảnh thành công</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN(28/04/2023)
        public void DeleteImage(string imageName);

        /// <summary>
        /// Kiểm tra trùng mã 
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <param name="foodCode">Mã món ăn</param>
        /// <returns>true- nếu trùng mã, false- nếu không trùng mã</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN(28/04/2023)
        public bool IsDuplicate(Guid? foodID, string foodCode);
    }
}
