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
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Parkings
{
    public partial class Form1 : Form
    {
        public SqlTableDependency<SensorValue> sensorvalue_table_dependency;
        string strCon = "Data Source=192.168.4.175;Initial Catalog=Parkings;User ID=sa;Password=1234";
        SqlConnection con;
        int Total1, Total2, Total3, Total4, Total5, Total6, Total7, Total8, Total9, Total10;
        int Count1, Count2, Count3, Count4, Count5, Count6, Count7, Count8, Count9, Count10;
        bool sensorvalue;
        int parkinglotid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(strCon);
            refresh_table();
            start_sensorvalue_table_dependency();
            InitializeGetCountData();
        }

        private void InitializeGetCountData()
        {
            GetCountData();

            label1.Text = Count1.ToString();
            Count1 = 0;//초기화

            label2.Text = Count2.ToString();
            Count2 = 0;

            label3.Text = Count3.ToString();
            Count3 = 0;

            label6.Text = Total1.ToString();
            Total1 = 0;

            label7.Text = Total2.ToString();
            Total2 = 0;

            label8.Text = Total3.ToString();
            Total3 = 0;
        }
        private int GetCountData()
        {
            string sqlCommand = "select * from SensorValue;";

            using (con = new SqlConnection(@strCon))
            {
                SqlCommand command = new SqlCommand(sqlCommand, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // 한 줄씩 읽어 내려온다.
                {
                    sensorvalue = (bool)reader["SensorValue"];
                    parkinglotid = (int)reader["ParkingLotId"];

                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "1")
                    {
                        Count1++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "2")
                    {
                        Count2++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "3")
                    {
                        Count3++;
                    }
                    if (parkinglotid.ToString() == "1")
                    {
                        Total1++;
                    }
                    if (parkinglotid.ToString() == "2")
                    {
                        Total2++;
                    }
                    if (parkinglotid.ToString() == "3")
                    {
                        Total3++;
                    }

                }

                reader.Close();
                con.Close();

                return 0;
            }


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SqlDependency.Stop(strCon);
            try
            {
                stop_sensorvalue_table_dependency();
                    
            }
            catch(Exception ex) { return; }

        }

        private bool start_sensorvalue_table_dependency()
        {
            try
            {
                sensorvalue_table_dependency = new SqlTableDependency<SensorValue>(strCon);
                sensorvalue_table_dependency.OnChanged += sensorvalue_table_dependency_Changed;
                // sensorvalue_table_dependency.OnError += sensorvalue_table_dependency_OnError;
                sensorvalue_table_dependency.Start();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool stop_sensorvalue_table_dependency()
        {
            try
            {
                if (sensorvalue_table_dependency != null)
                {
                    sensorvalue_table_dependency.Stop();

                    return true;
                }
            }
            catch (Exception ex) { return false; }
            return false;
        }
        private void refresh_table()
        {
            string sql = "select * from SensorValue";
            con = new SqlConnection(strCon);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            dataadapter.Fill(ds, "SensorValue");
            con.Close();
            ThreadSafe(() => dataGridView1.DataSource = ds);
            ThreadSafe(() => dataGridView1.DataMember = "SensorValue");
          //ThreadSafe(() => dataGridView1.DataMember = "ParkingPositionId");
          //ThreadSafe(() => dataGridView1.DataMember = "PkaringLotId");

        }
        private void ThreadSafe(MethodInvoker method)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(method);
                else
                    method();
            }
            catch (ObjectDisposedException) { }

        }

        private void sensorvalue_table_dependency_Changed(object sender, RecordChangedEventArgs<SensorValue> e)
        {
            try
            {
                var changedEntity = e.Entity;
                switch (e.ChangeType)
                {
                    case ChangeType.Insert:
                        {
                            refresh_table();
                            InitializeGetCountData();
                        }
                        break;

                    case ChangeType.Update:
                        {
                            refresh_table();
                            InitializeGetCountData();
                        }
                        break;
                    case ChangeType.Delete:
                        {
                            refresh_table();
                            InitializeGetCountData();
                        }
                        break;
                }

            }
            catch(Exception ex)
            {
                return;
            }

            }
    }
}

  