using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class MenuGroupService : BaseService<MenuGroup> , IMenuGroupService
    {
        private IMenuGroupRepository _MenuGroupRepository;

        public MenuGroupService(IMenuGroupRepository MenuGroupRepository) : base(MenuGroupRepository)
        {
            _MenuGroupRepository = MenuGroupRepository;
        }

        public CukCukResponse InsertMenuGroup(MenuGroup MenuGroup)
        {
            var res = _MenuGroupRepository.InsertMenuGroup(MenuGroup);
            if (Guid.Equals(res, Guid.Empty))
            {
                return new CukCukResponse()
                {
                    StatusCode = 400,
                    ListErrors = new List<string>() { "0" }
                };
            }
        
            return new CukCukResponse()
            {
                StatusCode = 201,
                ListErrors = new List<string>() { "1" }
            };
        }
    }
}
