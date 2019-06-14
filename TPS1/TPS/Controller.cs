using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TPS
{
    public class AbstractController : DB
    {
        // DB myDB = new DB();
        protected DataTable myTable = new DataTable();

        

        public AbstractController()
        {
            myTable.Columns.Add("Car Number");
            myTable.Columns.Add("Name");
            myTable.Columns.Add("LastName");
            myTable.Columns.Add("Model");
            myTable.Columns.Add("Year");
            myTable.Columns.Add("Type");
            myTable.Columns.Add("Issues");
        }

        public DataTable GetTable()
        {
            return myTable;
        }

        public int ClearForm(string CarNumber, string name, string lastname, string Model, string year, string Type, string Issues)
        {
            if (AddCarblank(CarNumber, name, lastname, Model, year, Type, Issues) == 1)
            {
                return 1;
            }

            return 0;
        }

        public void FindCarblank()
        {
            MySqlDataReader read = GetCarblank();
            myTable.Rows.Clear();

            while (read.Read())
            {
                myTable.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6]);
            }

            read.Close();
        }

        public void FindCarblank(string FindStr)
        {
            string[] str = FindStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            myTable.Rows.Clear();

            MySqlDataReader read = GetCarblank();
            while (read.Read())
            {
                bool check = true;
                for (int i = 0; i < str.Length; i++)
                {
                    bool checkDB = true;
                    for (int j = 0; j < 6 && checkDB; j++)
                    {
                        if (str[i] == read[j].ToString())
                        {
                            checkDB = false;
                        }
                    }

                    if (checkDB == true)
                    {
                        string[] strDB = read[6].ToString().Split(new char[] { ' ', '.', ',' }
                            , StringSplitOptions.RemoveEmptyEntries);

                        checkDB = true;
                        for (int j = 0; j < strDB.Length && checkDB; j++)
                        {
                            if (strDB[j] == str[i])
                            {
                                checkDB = false;
                            }
                        }

                        if (checkDB == true)
                        {
                            check = false;
                            break;
                        }
                    }
                }

                if (check)
                {
                    myTable.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6]);
                }

                read.Close();
            }
        }
    }
    
}