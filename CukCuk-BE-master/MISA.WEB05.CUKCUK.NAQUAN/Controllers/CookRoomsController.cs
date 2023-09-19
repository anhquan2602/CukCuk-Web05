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
    public class CookRoomsController : BaseController<CookRoom>
    {
        #region Properties

        private ICookRoomService _CookRoomService;

        #endregion

        #region Contructor

        public CookRoomsController(ICookRoomService CookRoomService) : base(CookRoomService)
        {
            _CookRoomService = CookRoomService;
        }

        #endregion
        
        #region Method
         [HttpPost]
         public IActionResult InsertCookRoom([FromBody] CookRoom CookRoom)
         {
             try
             {
                 if(CookRoom != null)
                 {
                     var result = _CookRoomService.InsertCookRoom(CookRoom);
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
