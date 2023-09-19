using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using MySqlX.XDevAPI.Common;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class FoodUnitService : BaseService<FoodUnit> , IFoodUnitService
    {
        private IFoodUnitRepository _FoodUnitRepository;
        public FoodUnitService(IFoodUnitRepository FoodUnitRepository): base(FoodUnitRepository)
        {
            _FoodUnitRepository = FoodUnitRepository;   
        }


        public CukCukResponse InsertFoodUnit(FoodUnit FoodUnit)
        {
            var res = _FoodUnitRepository.InsertFoodUnit(FoodUnit);
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
