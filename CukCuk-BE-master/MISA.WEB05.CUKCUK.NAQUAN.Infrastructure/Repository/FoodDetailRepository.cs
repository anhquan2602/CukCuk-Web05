using Microsoft.Extensions.Configuration;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository
{
    public class FoodDetailRepository : BaseRepository<FoodDetail>, IFoodDetailRepository  
    {
        public FoodDetailRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
