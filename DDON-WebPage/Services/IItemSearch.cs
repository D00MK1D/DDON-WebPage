using Dapper;
using System.Data.Common;
using System.Data;

namespace DDON_WebPage.Services
{
    public interface IItemSearch
    {
        DbConnection GetConnection();

        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}