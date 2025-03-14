using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Models.Dtos;

namespace DataAccess
{
    public class ErrorCode : IErrorCode
    {
        public Response GetError(int idError, object? additionalData = null)
        {
            Response response = new()
            {
                IdError = idError,
                AdditionalData = additionalData
            };

            if (idError == 0)
            {
                response.Message = "Se realizó el proceso exitosamente.";
            } 
            else if (idError == -999)
            {
                response.Message = "Error, contacte al administrador.";
            }

            return response;
        }
    }
}
