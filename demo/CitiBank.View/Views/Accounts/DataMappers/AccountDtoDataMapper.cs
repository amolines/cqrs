using System.Collections.Generic;
using System.Data.Common;
using CitiBank.View.Views.Accounts.Dtos;
using Xendor.QueryModel.Data;

namespace CitiBank.View.Views.Accounts.DataMappers
{
    public class AccountDtoDataMapper : IDataMapper<DbDataReader, IEnumerable<AccountDto>>
    {
        public IEnumerable<AccountDto> Mapper(DbDataReader source)
        {
            var accounts = new List<AccountDto>();
            while (source.Read())
            {
                var accountDto = new AccountDto
                {
                    Id = source.GetGuid(0),
                    Key = source.GetInt64(8),
                    Number = source.GetString(1),
                    Product = new ProductDto()
                    {
                        Id = source.GetGuid(2),
                        Name = source.GetString(3)
                    },
                    Client = new ClientDto()
                    {
                        Id = source.GetGuid(4),
                        Name = source.GetString(5),
                        LastName = source.GetString(6),
                        Email = source.GetString(7)
                    }
                };
                accounts.Add(accountDto);
                
            }
            source.Close();

            return accounts;
        }
    }
}