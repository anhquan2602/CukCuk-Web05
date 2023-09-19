using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;
using System.Xml.Linq;
using ClosedXML.Excel;
using Microsoft.Net.Http.Headers;

namespace MISA.WEB05.CUKCUK.NAQUAN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodsController : BaseController<Food>
    {
        #region Properties

        private IFoodService _FoodService;

        #endregion

        #region Contructor

        public FoodsController(IFoodService FoodService) : base(FoodService)
        {
            _FoodService = FoodService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Controller xoá 1 hoặc nhiều món ăn
        /// </summary>
        /// <param name="ids">Chuỗi chứa một hoặc nhiều mã món ăn</param>
        /// <returns>Số bản ghi bị xoá</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        [HttpDelete]
        public IActionResult DeleteFood([FromBody] string ids)
        {
            try
            {
                if (ids != null && ids.Length > 0)
                {
                    // Gọi service lọc và phân trang danh sách thực đơn
                    var res = _FoodService.DeleteFood(ids);

                    // Trả kết quả về cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }
            }
            catch (Exception ex)
            {
                return base.HandleException(ex);
            }
        }

        /// <summary>
        /// Controller upload ảnh lên server
        /// </summary>
        /// <param name="fileImage">Obj ảnh</param>
        /// <returns>Tên của ảnh trên server</returns>
        /// CreatedBy: NAQUAN (22/04/2023)
        [HttpPost("upload-image")]
        public IActionResult UploadImage(IFormFile fileImage)
        {
            try
            {
                if(fileImage != null)
                {
                    // Gọi service upload ảnh
                    var res = _FoodService.UploadImage(fileImage);

                    // Trả lại kết quả cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                } 
                    
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xoá ảnh trong thư mục
        /// </summary>
        /// <param name="fileName">Tên ảnh muốn xoá</param>
        /// <returns>Xoá ảnh thành công</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN(28/04/2023)
        [HttpPost("remove-image")]
        public IActionResult DeleteImage(string fileName)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(fileName))
                {
                    _FoodService.DeleteImage(fileName);
                    return Ok();
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                } 
                    
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Controller hiển thị ảnh
        /// </summary>
        /// <param name="imageName">tên ảnh trên server</param>
        /// <returns>Hiển thị ảnh</returns>
        /// CreatedBy: NAQUAN (26/04/2023)
        [HttpGet("get-image/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imageName))
                {
                    var ImageDto = _FoodService.GetImage(imageName);

                    if (ImageDto == null)
                    {
                        return NotFound();
                    }

                    return File(ImageDto.ImageBytes, ImageDto.MimeType);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Lấy món ăn theo ID
        /// </summary>
        /// <param name="id">ID món ăn cần lấy</param>
        /// <returns>Thông tin bản ghi theo ID</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (22/04/2023)
        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            try
            {
                if (!Guid.Equals(id, Guid.Empty))
                {
                    // Gọi service lọc và phân trang danh sách thực đơn
                    var res = _FoodService.GetByID(id);

                    // Trả kết quả về cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }
            }
            catch (Exception ex)
            {
                return base.HandleException(ex);
            }
        }

        /// <summary>
        /// Controller lọc và sắp xếp bản ghi
        /// </summary>
        /// <param name="filter">Điều kiện lọc và sort dữ liệu </param>
        /// <returns>Danh sách bản ghi theo điều kiện lọc và sắp xếp</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (22/04/2023)
        [HttpPost("filter")]
        public IActionResult FilterFood(Filter filter)
        {
            try
            {
                if (filter != null)
                {
                    // Gọi service lọc và phân trang danh sách thực đơn
                    var res = _FoodService.FilterFood(filter);

                    // Trả kết quả về cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }


            }
            catch (Exception ex)
            {
                return base.HandleException(ex);
            }
        }

        /// <summary>
        /// Controller lấy ra mã mới
        /// </summary>
        /// <param name="name">Tên món ăn để lấy mã mới</param>
        /// <returns>Mã mới</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (22/04/2023)
        [HttpGet("new-code")]
        public IActionResult GetNewCode(String name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    var res = _FoodService.GetNewCode(name);

                    // Trả kết quả về cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }
            }
            catch (Exception ex)
            {
                return base.HandleException(ex);
            }
        }

        /// <summary>
        /// Kiểm tra trùng mã 
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <param name="foodCode">Mã món ăn</param>
        /// <returns>true- nếu trùng mã, false- nếu không trùng mã</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN(28/04/2023)
        [HttpGet("duplicate-code")]
        public IActionResult IsDuplicate(Guid? foodID, string foodCode)
        {
            try
            {
                if (foodID != null && !string.IsNullOrEmpty(foodCode))
                {
                    var res = _FoodService.IsDuplicate(foodID, foodCode);

                    // Trả kết quả về cho client
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                }
            }
            catch (Exception ex)
            {
                return base.HandleException(ex);
            }
        }
        
        
        [HttpGet("export")]
        public IActionResult ExportExel()
        {
            var records =  _FoodService.GetAll();
            if (records.Any())
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Sheet1");

                var mergedRange = worksheet.Range("A1:I1");
                mergedRange.Merge();

                // Add content to merged cell
                mergedRange.Value = "Thông tin món ăn/đồ uống";
                mergedRange.Style.Font.Bold = true;
                mergedRange.Style.Font.FontSize = 18;
                mergedRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                mergedRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Row(1).Height = 35;
                
                // build de lay ten cot
                    worksheet.Cells("A2").Value = "Mã món(*)";
                    worksheet.Cells("B2").Value = "Tên món(*)";
                    worksheet.Cells("C2").Value = "Nhóm thực đơn(*)";
                    worksheet.Cells("D2").Value = "Đơn vị tính(*)";
                    worksheet.Cells("E2").Value = "Giá vốn";
                    worksheet.Cells("F2").Value = "Giá bán";
                    worksheet.Cells("G2").Value = "Hiển thị trên thực đơn";
                    worksheet.Cells("H2").Value = "Ngừng bán";
                    worksheet.Cells("I2").Value = "Ngày tạo";
                    
                    var styleHeader = worksheet.Range("A2:I2");
                    styleHeader.Style.Font.Bold = true;
                    styleHeader.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    styleHeader.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    styleHeader.Style.Fill.BackgroundColor = XLColor.FromHtml("#be6bde"); // Đặt màu nền cho dòng
                    worksheet.Row(2).Height = 25;
                    
                    

                    for (int i = 0; i < records.ToList().Count; i++)
                    {
                        Food food = records.ToList()[i];
                        worksheet.Cell(i + 3, 1).Value = food.FoodCode;
                        worksheet.Cell(i + 3, 2).Value = food.FoodName;
                        worksheet.Cell(i + 3, 3).Value = food.MenuGroupName;
                        worksheet.Cell(i + 3, 4).Value = food.FoodUnitName;
                        worksheet.Cell(i + 3, 5).Value = food.FoodCost;
                        worksheet.Cell(i + 3, 6).Value = food.FoodPrice;
                        worksheet.Cell(i + 3, 7).Value = (food.ShowOnMenu.Value == 0) ? "Không" : "Có";
                        worksheet.Cell(i + 3, 8).Value = (food.StopSelling.Value == 0) ? "Không" : "Có";
                        worksheet.Cell(i + 3, 9).Value = food.CreatedDate.ToString();

                    }
                    worksheet.Columns().AdjustToContents();
                    var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                    var contentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Exported_food_data.xlsx"
                    };
                    Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            return StatusCode(StatusCodes.Status200OK, null);
        }

    }
    #endregion

}
