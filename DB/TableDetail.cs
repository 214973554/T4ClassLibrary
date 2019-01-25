namespace DB
{
    public class TableDetail
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        public string TableDescription { get; set; }

        /// <summary>
        /// 列序号
        /// </summary>
        public string ColumnIndexNo { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDescription { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 列长
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 小数类型，小数长度
        /// </summary>
        public int ScaleLength { get; set; }

        /// <summary>
        /// 是否主键列
        /// </summary>
        public bool IsKeyColumn { get; set; }

        /// <summary>
        /// 是否可为空
        /// </summary>
        public bool Nullable { get; set; }
    }
}
