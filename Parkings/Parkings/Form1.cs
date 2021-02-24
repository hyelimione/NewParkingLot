using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Parkings
{
    public partial class Form1 : Form
    {
        string strConn = "Data Source=192.168.4.175;Initial Catalog=Parkings;User ID=sa;Password=1234";
        private BindingSource ParkingLotbindingSource = new BindingSource();
        SqlDependency sd;
        SqlConnection con;
        int OutTotal, TopTotal, NewTotal;
        int OutTrueCount, TopTrueCount, NewTrueCount;
        bool sensorvalue = new bool();
        int parkinglotid, parkingpositionid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(strConn);

            InitializeGetCountData();
        }

        private void InitializeGetCountData()
        {
            GetCountData();
            label1.Text = OutTrueCount.ToString();
            OutTrueCount = 0;//초기화
            label2.Text = TopTrueCount.ToString();
            TopTrueCount = 0;
            label3.Text = NewTrueCount.ToString();
            NewTrueCount = 0;
            label6.Text = OutTotal.ToString();
            OutTotal = 0;
            label7.Text = TopTotal.ToString();
            TopTotal = 0;
            label8.Text = NewTotal.ToString();
            NewTotal = 0;
        }
        private int GetCountData()
        {
            string sqlCommand = "select * from SensorValue;";

            using (con = new SqlConnection(@strConn))
            {
                SqlCommand command = new SqlCommand(sqlCommand, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // 한 줄씩 읽어 내려온다.
                {
                    sensorvalue = (bool)reader["SensorValue"];
                    parkinglotid = (int)reader["ParkingLotId"];
                    parkingpositionid = (int)reader["ParkingPositionId"];

                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "1")
                    {
                        OutTrueCount++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "2")
                    {
                        TopTrueCount++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "3")
                    {
                        NewTrueCount++;
                    }
                    if (parkinglotid.ToString() == "1")
                    {
                        OutTotal++;
                    }
                    if (parkinglotid.ToString() == "2")
                    {
                        TopTotal++;
                    }
                    if (parkinglotid.ToString() == "3")
                    {
                        NewTotal++;
                    }

                }

                reader.Close();
                con.Close();

                return 0;
            }


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlDependency.Stop(strConn);

        }

    }
}
