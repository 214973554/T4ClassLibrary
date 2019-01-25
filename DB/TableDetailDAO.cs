using Dapper;
using System.Collections.Generic;

namespace DB
{
    public class TableDetailDAO
    {
        private SQLHelper dbHelper = new MSSQHelper();
        public IEnumerable<TableDetail> GetTableDetail(string table)
        {
            string sql = @"SELECT  obj.name AS TableName ,
        ISNULL(epTwo.value, '') AS TableDescription,
        col.colorder AS ColumnIndexNo ,
        col.name AS ColumnName ,
        ISNULL(ep.[value], '') AS ColumnDescription,
        t.name AS ColumnType ,
        col.length AS Length ,
        ISNULL(COLUMNPROPERTY(col.id, col.name, 'Scale'), 0) AS ScaleLength,
        CASE WHEN COLUMNPROPERTY(col.id, col.name, 'IsIdentity') = 1 THEN 1
             ELSE 0
        END AS IsKeyColumn ,
        CASE WHEN col.isnullable = 1 THEN 1
             ELSE 0
        END AS Nullable
FROM    dbo.syscolumns col
        LEFT JOIN dbo.systypes t ON col.xtype = t.xusertype
        INNER JOIN dbo.sysobjects obj ON col.id = obj.id
                                         AND obj.xtype = 'U'
                                         AND obj.status >= 0
        LEFT JOIN dbo.syscomments comm ON col.cdefault = comm.id
        LEFT JOIN sys.extended_properties ep ON col.id = ep.major_id
                                                 AND col.colid = ep.minor_id
                                                 AND ep.name = 'MS_Description'
        LEFT JOIN sys.extended_properties epTwo ON obj.id = epTwo.major_id
                                                    AND epTwo.minor_id = 0
                                                    AND epTwo.name = 'MS_Description'
WHERE obj.name = @table
ORDER BY col.colorder";

            IDictionary<string, object> param = new Dictionary<string, object>();
            param.Add("table", table);

            using (var conn = dbHelper.GetDbConnection())
            {
                conn.Open();
                return conn.Query<TableDetail>(sql, param);
            }
        }

        public IEnumerable<string> GetAllTables()
        {
            string sql = @"SELECT  obj.name AS TableName
FROM dbo.sysobjects obj
WHERE obj.xtype = 'U'
        AND obj.status >= 0";

            using (var conn = dbHelper.GetDbConnection())
            {
                conn.Open();
                return conn.Query<string>(sql);
            }
        }
    }
}