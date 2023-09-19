using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;

namespace MISA.WEB05.CUKCUK.NAQUAN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodUnitsController : BaseController<FoodUnit>
    {
        #region Properties

        private IFoodUnitService _FoodUnitService;

        #endregion

        #region Contructor

        public FoodUnitsController(IFoodUnitService FoodUnitService) : base(FoodUnitService)
        {
            _FoodUnitService = FoodUnitService;
        }

        #endregion

        #region Method
        [HttpPost]
        public IActionResult InsertFoodUnit([FromBody] FoodUnit FoodUnit)
        {
            try
            {
                if(FoodUnit != null)
                {
                    var result = _FoodUnitService.InsertFoodUnit(FoodUnit);
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
        
        
        #endregion
    }
}
