using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using TPS;
using MySql.Data.MySqlClient;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ConnectionDB_ServerUserDatabasePassword_ReturnedEquality()
        {
            DB myDB = new DB();

            string[] connection = myDB.GetConfiguration().Split(new char[] { '=', ';', '"' }, StringSplitOptions.RemoveEmptyEntries);

            string[] str1 = new string[4] { "server", "user", "database", "password" };
            string[] str2 = new string[4];

            

            for (int i = 0, j = 0; i < connection.Length; i += 2, j++)
            {
                str2[j] = connection[i];
            }

            CollectionAssert.AreEqual(str1, str2);
        }

        [TestMethod]
        public void OpenConnectionDB_MySqlConnection_ReturnedOpenConnection()
        {
            DB myDB = new DB();
            Assert.IsNotNull(myDB.GetMySqlConnection());
        }

        [TestMethod]
        public void CreateDataTable_DataTable_Created()
        {
            ConcreteController myController = new ConcreteController();
            Assert.IsNotNull(myController.GetTable());
        }
    }
}
