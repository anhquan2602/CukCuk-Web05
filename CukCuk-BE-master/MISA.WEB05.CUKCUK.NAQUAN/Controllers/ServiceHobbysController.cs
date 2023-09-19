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
    public class ServiceHobbysController : BaseController<ServiceHobby>
    {
        #region Properties

        private IServiceHobbyService _ServiceHobbyService;

        #endregion

        #region Properties

        public ServiceHobbysController(IServiceHobbyService ServiceHobbyService) : base(ServiceHobbyService)
        {
            _ServiceHobbyService = ServiceHobbyService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Controller lấy ra danh sách phục thêm theo ID món ăn
        /// </summary>
        /// <param name="foodID">ID món ăn</param>
        /// <returns>Danh sách phục vụ thêm theo ID</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (24/04/2023)
        [HttpGet("list-service-byid")]
        public IActionResult GetListService(Guid foodID)
        {
            try
            {
                if (!Guid.Equals(foodID, Guid.Empty))
                {
                    var res = _ServiceHobbyService.GetListService(foodID);
                    return Ok(res);
                }
                else
                {
                    throw new ErrorException(devMsg: Resources.NullData);
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
