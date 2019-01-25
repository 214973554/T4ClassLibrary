using System.Data;

namespace DB
{
    public abstract class SQLHelper
    {
        public abstract IDbConnection GetDbConnection();
    }
}
