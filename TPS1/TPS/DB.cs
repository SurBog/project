using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace TPS
{
    public class DB
    {
        //string str = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        static MySqlConnection Start;

        public DB()
        {
            try
            {
                Start = new MySqlConnection(str);
                Start.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Exception", MessageBoxButtons.OK);
                Start = null;
            }
        }

        public MySqlConnection GetMySqlConnection()
        {
            return Start;
        }

        public string GetConfiguration()
        {
            return str;
        }

        public int AddCarblank(string CarNumber, string name, string lastname, string Model, string year, string Type, string Issues)
        {
            MySqlCommand command = new MySqlCommand(@"Insert into Carblank(CarNumber, Name, LastName, Model, Year, Type, Issues)
                value ('" + CarNumber + "', '" + name + "', '" + lastname+ "',  '" + Model + "', '" + year + "', '" + Type + "', '" + Issues + "');", Start);

            try
            {
                command.ExecuteScalar();
                MessageBox.Show("Carblank add");
                return 1;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
                return 0;
            }
        }

        public MySqlDataReader GetCarblank()
        {
            MySqlCommand command = new MySqlCommand(@"select *from CarBlank;", Start);
            MySqlDataReader read = command.ExecuteReader();

            return read;
        }
    }
}
