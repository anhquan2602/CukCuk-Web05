using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;

namespace MISA.WEB05.CUKCUK.NAQUAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDetailsController : BaseController<FoodDetail>
    {
        #region Properties

        private IFoodDetailService _FoodDetailService;

        #endregion

        #region Contructor

        public FoodDetailsController(IFoodDetailService FoodDetailService) : base(FoodDetailService)
        {
            _FoodDetailService = FoodDetailService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Controller thêm món ăn và sở thích phục vụ thêm
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>ID món ăn đã thêm</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (24/04/2023)
        [HttpPost]
        public IActionResult InsertFood([FromBody] FoodDetail FoodDetail)
        {
            try
            {
                if(FoodDetail != null)
                {
                    var result = _FoodDetailService.InsertFoodDetail(FoodDetail);
                    return StatusCode((int)result.StatusCode, result);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.InputNullData);
                } 
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Controller cập nhật món ăn
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>Bản ghi bị ảnh hưởng</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (24/04/2023)
        [HttpPut("{id}")]
        public IActionResult UpdateFood( [FromBody] FoodDetail FoodDetail)
        {
            try
            {
                if (FoodDetail != null)
                {
                    var result = _FoodDetailService.UpdateFood(FoodDetail);
                    return StatusCode((int)result.StatusCode, result);
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

        #endregion
    }
}