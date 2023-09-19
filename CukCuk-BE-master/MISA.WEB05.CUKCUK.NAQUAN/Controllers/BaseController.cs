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
    public class BaseController<TEntity> : ControllerBase
    {
        #region Properties

        private IBaseService<TEntity> _BaseService;

        #endregion

        #region Contructor
        public BaseController(IBaseService<TEntity> BaseService)
        {
            _BaseService = BaseService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Controller lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        /// Created By: NAQUAN(20/08/2023)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _BaseService.GetAll();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }
        


        /// <summary>
        /// Exception xử lý ngoại lệ
        /// </summary>
        /// <param name="ex">Ngoại lệ được bắt</param>
        /// <returns>Lỗi</returns>
        /// Created By: NAQUAN(20/08/2023)
        protected IActionResult HandleException(dynamic ex)
        {
            var error = new
            {
                devMsg = ex.Message,
                userMsg = Resources.ResourceManager.GetString(name: "ErrorException"),
                errorMsg = ex.Data["Error"]
            };

            if (ex is ErrorException)
            {
                return BadRequest(error);
            }
            return StatusCode(500, error);
        }

        #endregion
    }
}
