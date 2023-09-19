using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;

namespace MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
    {
        #region Field

        protected string connectionString;
        protected MySqlConnection mySqlConnection;
        protected string className;
        protected Guid classID;
        protected List<string> errorList;

        #endregion

        public BaseRepository(IConfiguration configuration)
        {
            errorList = new List<string>();
            // Khai báo thông tin kết nối
            connectionString = configuration.GetConnectionString("dataBase");
            className = typeof(TEntity).Name;
            classID = typeof(TEntity).GUID;

        }

        public void OpenConnect()
        {
            mySqlConnection = new MySqlConnection(connectionString);
            if(mySqlConnection != null && mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();
            }    
        }

       
        public void CloseConnect()
        {
            mySqlConnection.Close(); 
            mySqlConnection.Dispose();
        }

        public IEnumerable<TEntity> GetALL()
        {
            OpenConnect();
            var procCommnand = $"Proc_Select_{className}_All";
            var result = mySqlConnection.Query<TEntity>(procCommnand, commandType: System.Data.CommandType.StoredProcedure);
            if(result == null)
            {
                throw new ErrorException(devMsg: Resources.InvalidData);
            }
            CloseConnect();
            return result;
        }

        
    }
}
