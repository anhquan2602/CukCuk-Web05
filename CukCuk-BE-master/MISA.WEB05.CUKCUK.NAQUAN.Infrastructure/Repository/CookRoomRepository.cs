using Microsoft.Extensions.Configuration;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository
{
    public class CookRoomRepository : BaseRepository<CookRoom> , ICookRoomRepository
    {
        public CookRoomRepository(IConfiguration configuration) : base(configuration)
        {
            
        }
        
        public Guid InsertCookRoom(CookRoom CookRoom)
        {
            OpenConnect();
            using (var transaction = mySqlConnection.BeginTransaction())
            {
                try
                {
                    var procCommnand = $"Proc_Insert_CookRoom";
                    var paramProc = new DynamicParameters(CookRoom);
                    var newGuid = Guid.NewGuid();
                    CookRoom.CookRoomID = newGuid;
                    var result = mySqlConnection.Execute(procCommnand, param: paramProc, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                    if (result == 0)
                    {
                        throw new ErrorException(devMsg: Resources.ExceptionInsert);
                    }
                    else
                    {
                        transaction.Commit();
                        return newGuid;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
        
                }
                finally
                {
                    CloseConnect();
                }
            }
        }
    }
}
