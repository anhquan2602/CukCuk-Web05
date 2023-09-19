using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO
{
    public class ImageDto
    {
        /// <summary>
        /// Mảng byte chứa dữ liệu hình ảnh
        /// </summary>
        public byte[] ImageBytes { get; set; }

        /// <summary>
        /// Lưu trữ định dạng ảnh
        /// </summary>
        public string MimeType { get; set; }
    }
}
