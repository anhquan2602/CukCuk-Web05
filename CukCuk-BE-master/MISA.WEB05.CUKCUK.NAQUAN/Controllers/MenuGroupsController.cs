using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;

namespace MISA.WEB05.CUKCUK.NAQUAN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuGroupsController : BaseController<MenuGroup>
    {
        #region Properties

        private IMenuGroupService _MenuGroupService;

        #endregion

        #region Contructor

        public MenuGroupsController(IMenuGroupService MenuGroupService) : base(MenuGroupService)
        {
            _MenuGroupService = MenuGroupService;
            
        }
        #endregion
        
        [HttpPost]
        public IActionResult InsertMenuGroup([FromBody] MenuGroup MenuGroup)
        {
            try
            {
                if(MenuGroup != null)
                {
                    var result = _MenuGroupService.InsertMenuGroup(MenuGroup);
                    return StatusCode((int)result.StatusCode, result);
                }
                else
                {
                    throw new ErrorException();
                } 
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return HandleException(ex);
            }
        }
        
    }
}
