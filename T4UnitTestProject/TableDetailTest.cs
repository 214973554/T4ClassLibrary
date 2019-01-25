using DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T4UnitTestProject
{
    [TestClass]
    public class TableDetailTest
    {
        [TestMethod]
        public void GetTableDetailTest()
        {
            TableDetailDAO dao = new TableDetailDAO();
            var tableDetail = dao.GetTableDetail("CommonType");
        }

        [TestMethod]
        public void GetAllTablesTest()
        {
            TableDetailDAO dao = new TableDetailDAO();
            var tables = dao.GetAllTables();
        }
    }
}
