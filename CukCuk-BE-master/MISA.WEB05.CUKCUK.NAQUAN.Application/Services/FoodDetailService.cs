using Microsoft.Extensions.Configuration;
using MISA.WEB05.CUKCUK.NAQUAN.Application.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Attributes;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Entities.DTO;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Exceptions;
using MISA.WEB05.CUKCUK.NAQUAN.Domain.Resources;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Interfaces;
using MISA.WEB05.CUKCUK.NAQUAN.Infrastructure.Repository;
using MySql.Data.MySqlClient;
using MySqlConnector;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlTransaction = MySql.Data.MySqlClient.MySqlTransaction;

namespace MISA.WEB05.CUKCUK.NAQUAN.Application.Services
{
    public class FoodDetailService : BaseService<FoodDetail>, IFoodDetailService
    {
        #region Properties

        private IFoodDetailRepository _FoodDetailRepository;
        private IFoodRepository _FoodRepository;
        private IServiceHobbyRepository _ServiceHobbyRepository;
        private IConfiguration _configuration;
        protected List<string> ErrorValidateMsgs;

        #endregion

        #region Properties

        public FoodDetailService(IFoodDetailRepository FoodDetailRepository, IFoodRepository FoodRepository, IServiceHobbyRepository ServiceHobbyRepository, IConfiguration configuration) : base(FoodDetailRepository)
        {
            _FoodDetailRepository = FoodDetailRepository;
            _FoodRepository = FoodRepository;
            _ServiceHobbyRepository = ServiceHobbyRepository;
            _configuration = configuration;
        }

        #endregion


        #region Properties

        
        // Hàm validate obj gửi lên
        public CukCukResponse ValidateObject(object obj, Guid? id)
        {
            
            // tạo một list mới để thêm lỗi, nếu xuất hiện lỗi thì thêm 
            var errorList = new List<string>();
            Type objectType = obj.GetType();
            foreach (PropertyInfo property in objectType.GetProperties())
            {
                bool isNotAllowedNull = property.IsDefined(typeof(NotAllowedNull), true);
                bool isNotAllowedDuplicate = property.IsDefined(typeof(NotAllowedDuplicate), true);
                string propName = property.IsDefined(typeof(PropsName), true)
                    ? ((PropsName)property.GetCustomAttribute(typeof(PropsName), true)).Name
                    : property.Name;

                // Kiểm tra thuộc tính NotAllowedNull
                if (isNotAllowedNull)
                {
                    if (property.PropertyType == typeof(Guid))
                    {
                        Guid propValue = (Guid)property.GetValue(obj);
                        if (Guid.Equals(propValue, Guid.Empty))
                        {
                            errorList.Add(String.Format(Validate.NotAllowedNull, propName));
                        }
                    }
                    else if (string.IsNullOrEmpty(property.GetValue(obj)?.ToString()))
                    {
                        errorList.Add(String.Format(Validate.NotAllowedNull, propName));
                    }
                }

                // Kiểm tra thuộc tính NotAllowedDuplicate (chỉ xét kiểu string)
                if (isNotAllowedDuplicate && property.PropertyType == typeof(string))
                {
                    string? propValue = property.GetValue(obj)?.ToString();
                    if (!string.IsNullOrEmpty(propValue) && _FoodRepository.IsDuplicate(id, propValue))
                    {
                        errorList.Add(String.Format(Validate.NotAllowedDuplicate, propName));
                    }
                }
            }
            if (errorList.Count > 0)
            {
                return new CukCukResponse
                {
                    Timestamp = DateTime.Now,
                    ListErrors = errorList
                };
            }
            else
            {
                return new CukCukResponse
                {
                    ListErrors = null
                };
            }
        }

        /// <summary>
        /// Thêm món ăn và sở thích phục vụ thêm
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>ID món ăn đã thêm</returns>
        /// CreatedBy: NAQUAN(25/04/2023)
        public CukCukResponse InsertFoodDetail(FoodDetail FoodDetail)
        {   
            // Check null
            if (FoodDetail.food == null)
            {
                throw new ErrorException(devMsg: Resources.ExceptionInsert);
            }
            
            // Validate obj gửi lên
            var isValid = ValidateObject(FoodDetail.food, FoodDetail.food.FoodID);
            if (isValid.ListErrors != null)
            {
                return isValid;
            }
            
            
            // Không có lỗi thì gọi vào repo để thêm
            var res = _FoodRepository.InsertFood(FoodDetail.food);
            if (Guid.Equals(res, Guid.Empty))
            {
                return new CukCukResponse()
                {
                    StatusCode = 400,
                    ListErrors = new List<string>() { "0" }
                };
            }
            
            // Nếu có sở thích phục vụ thì thêm
            if (FoodDetail.serviceHobbies != null && FoodDetail.serviceHobbies.Count > 0)
            {
                foreach (var hobby in FoodDetail.serviceHobbies)
                {
                    if (!string.IsNullOrWhiteSpace(hobby.ServiceHobbyName))
                    {
                        hobby.FoodID = res;
                        _ServiceHobbyRepository.InsertServiceHobby(hobby);
                    }
                }
            }
            
            // Thành công trả về mã 201
            return new CukCukResponse()
            {
                StatusCode = 201,
                ListErrors = new List<string>() { "1" }
            };

        }


        /// <summary>
        /// Cập nhật món ăn
        /// </summary>
        /// <param name="FoodDetail">Món ăn và list sở thích phụ vụ thêm</param>
        /// <returns>Bản ghi bị ảnh hưởng</returns>
        /// <exception cref="ErrorException"></exception>
        /// CreatedBy: NAQUAN (24/04/2023)
        public CukCukResponse UpdateFood(FoodDetail FoodDetail)
        {   
            // Check null 
            if (FoodDetail.food != null)
            {   
                // Validate obj cập nhật mới
                var IsValid = ValidateObject(FoodDetail.food, FoodDetail.food.FoodID);
                if (IsValid.ListErrors == null)
                {   
                    //  Không có lỗi thì cập nhật
                    var res = _FoodRepository.UpdateFood(FoodDetail.food); // Cập nhật thông tin món ăn
                    if (res > 0)
                    {
                        // Xóa các dịch vụ liên quan đến món ăn nếu có 
                        var deleteService = _ServiceHobbyRepository.DeleteServiceHobby(FoodDetail.food.FoodID);
                        if (deleteService >= 0)
                        {
                            if (FoodDetail.serviceHobbies != null)
                            {
                                if (FoodDetail.serviceHobbies.Count > 0)
                                {
                                    for (var i = 0; i < FoodDetail.serviceHobbies.Count; i++)
                                    {
                                        if (FoodDetail.serviceHobbies[i].ServiceHobbyName == null || string.IsNullOrWhiteSpace(FoodDetail.serviceHobbies[i].ServiceHobbyName))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            FoodDetail.serviceHobbies[i].FoodID = FoodDetail.food.FoodID;
                                            _ServiceHobbyRepository.InsertServiceHobby(FoodDetail.serviceHobbies[i]);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new ErrorException(devMsg: Resources.ExceptionInsert);
                        }

                        return new CukCukResponse()
                        {
                            StatusCode = 200,
                            ListErrors = new List<string>() { "1" }
                        };
                    }
                    else
                    {
                        return new CukCukResponse()
                        {
                            StatusCode = 400,
                            ListErrors = new List<string>() { "0" }
                        };
                    }
                }
                else
                {
                    return IsValid;
                }
            }
            else
            {
                throw new ErrorException(devMsg: Resources.ExceptionInsert);
            }

        }


        #endregion
    }
}
