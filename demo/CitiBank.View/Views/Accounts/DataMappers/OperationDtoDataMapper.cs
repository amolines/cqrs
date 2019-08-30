using System.Collections.Generic;
using System.Data.Common;
using CitiBank.View.Views.Accounts.Dtos;
using Xendor.Data;

namespace CitiBank.View.Views.Accounts.DataMappers
{
    public class OperationDtoDataMapper : IDataMapper<DbDataReader, IEnumerable<OperationDto>>
    {
        public IEnumerable<OperationDto> Mapper(DbDataReader source)
        {
            var operations = new List<OperationDto>();
            while (source.Read())
            {
                var operationDto = new OperationDto()
                {
                    Date = source.GetDateTime(0),
                    Amount = source.GetDecimal(1),
                    Description = source.GetString(2)
                };
                operations.Add(operationDto);
            }

            return operations;
        }
    }
}