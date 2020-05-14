using System;
using System.Threading.Tasks;

namespace Xendor.QueryModel.Data
{
    public interface IDataBase : IDisposable , ICommand

    {
        Task OpenAsync();

        void Close();
    }
}