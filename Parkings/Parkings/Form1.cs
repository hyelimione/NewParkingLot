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
       // OleDbConnection Cn = null; //ExecuteScalar를 이용해 테이블의 열의 개수세기, 쿼리문필요
        string strCon = "Data Source=192.168.4.175;Initial Catalog=Parkings;User ID=sa;Password=1234";
        SqlConnection con;
        int Total1, Total2, Total3, Total4, Total5, Total6, Total7, Total8, Total9, Total10;
        int Count1, Count2, Count3, Count4, Count5, Count6, Count7, Count8, Count9, Count10;
        //object count, ParkingLotMaxCount;//OleDbConnection방식일때, 값은 안정적으로 구할 수 있으나 프로그램의 속도가 느리다.
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


            Count1 = 0; Count2 = 0; Count3 = 0; Count4 = 0; Count5 = 0;
            Count6 = 0; Count7 = 0; Count8 = 0; Count9 = 0; Count10 = 0;

            label1.Text = Count1.ToString();label2.Text = Count2.ToString();
            label3.Text = Count3.ToString();label4.Text = Count4.ToString();
            label5.Text = Count5.ToString(); label11.Text = Count6.ToString();
            label12.Text = Count7.ToString(); label13.Text = Count8.ToString();
            label14.Text = Count9.ToString(); label15.Text = Count10.ToString();

            label6.Text = Total1.ToString();label7.Text = Total2.ToString();
            label8.Text = Total3.ToString(); label9.Text = Total4.ToString();
            label10.Text = Total5.ToString(); label16.Text = Total6.ToString();
            label17.Text = Total7.ToString(); label18.Text = Total8.ToString();
            label19.Text = Total9.ToString(); label20.Text = Total10.ToString();

            
        }
        private void GetCountData()
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
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "4")
                    {
                        Count4++;
                    }

                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "5")
                    {
                        Count5++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "6")
                    {
                        Count6++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "7")
                    {
                        Count7++;
                    }

                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "8")
                    {
                        Count8++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "9")
                    {
                        Count9++;
                    }
                    if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "10")
                    {
                        Count10++;
                    }

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
                    if (parkinglotid.ToString() == "4")
                    {
                        Total4++;
                    }
                    if (parkinglotid.ToString() == "5")
                    {
                        Total5++;
                    }
                    if (parkinglotid.ToString() == "6")
                    {
                        Total6++;
                    }
                    if (parkinglotid.ToString() == "7")
                    {
                        Total7++;
                    }
                    if (parkinglotid.ToString() == "8")
                    {
                        Total8++;
                    }
                    if (parkinglotid.ToString() == "9")
                    {
                        Total9++;
                    }
                    if (parkinglotid.ToString() == "10")
                    {
                        Total10++;
                    }


                }

                reader.Close();
                con.Close();
            }

            /* OleDbConnection방식은 열의 개수 최소갯수 알기 위해 수행하는 것이 효율적.테이블 연결하는 방식이 안정적이긴 하나 속도가 느림. 

           Cn = new OleDbConnection("Provider = Microsoft OLE DB Provider for SQL Server;" + @strCon);
           Cn.Open();
           OleDbCommand cmdSelectParkingLotMaxCount;
           cmdSelectParkingLotMaxCount = new OleDbCommand("select count(ParkingLotId) from ParkingLot", Cn); //주차장 총 수 카운팅
           ParkingLotMaxCount = cmdSelectParkingLotMaxCount.ExecuteScalar();
           OleDbCommand cmdSelect1, cmdSelect2, cmdSelect3, cmdSelect4, cmdSelect5,
           cmdSelect6, cmdSelect7, cmdSelect8, cmdSelect9, cmdSelect10;


           cmdSelect1 = new OleDbCommand("select count(SensorValue) from SensorValue where ParkingLotId=1", Cn); //1번주차장 전체 면 카운팅  
           count = cmdSelect1.ExecuteScalar();
           label6.Text = count.ToString();

           cmdSelect2 = new OleDbCommand("select count(SensorValue) from SensorValue where ParkingLotId=2", Cn); //2번주차장 전체 면 카운팅 
           count = cmdSelect2.ExecuteScalar();
           label7.Text = count.ToString();

           cmdSelect3 = new OleDbCommand("select count(SensorValue) from SensorValue where ParkingLotId=3", Cn); //3번 주차장 전체 면 카운팅
           count = cmdSelect3.ExecuteScalar();
           label8.Text = count.ToString();


           Cn.Close();
             */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                stop_sensorvalue_table_dependency();

            }
            catch (Exception ex) { return; }

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
            ThreadSafe(() => dataGridView1.DataMember = "SensorValue"); //테이블명


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
                var changedEntity = e.Entity; //이벤트가 발생한 매개변수를 changedEntity변수로 받는다.
                switch (e.ChangeType) //e.ChangedType이 변경되었다면
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
            catch (Exception ex)
            {
                return;
            }

        }
    }
}

