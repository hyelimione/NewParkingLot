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
using System.IO;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using ErrorEventArgs = TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs;

namespace Parkings
{
    public partial class Form1 : Form
    {
        //속도에 중점을 맞춤
        public SqlTableDependency<SensorValue> sensorvalue_table_dependency;
        public string strCon = "Data Source=192.168.4.175;Initial Catalog=Parkings;User ID=sa;Password=1234";

        SqlConnection con;
        Form2 form2 = new Form2();

        int Total1, Total2, Total3, Total4, Total5, Total6, Total7, Total8, Total9, Total10;
        //  Total11, Total12, Total13, Total14, Total15, Total16, Total17, Total18, Total19,
        // Total20, Total21, Total22, Total23, Total24, Total25, Total26, Total27, Total28, Total29, Total30;

        int Count1, Count2, Count3, Count4, Count5, Count6, Count7, Count8, Count9, Count10,
        Count11, Count12, Count13, Count14, Count15, Count16, Count17, Count18, Count19, Count20;


        bool sensorvalue;
        int parkinglotid;

        // OleDbConnection Cn = null; //ExecuteScalar를 이용해 테이블의 열의 개수세기, 쿼리문필요
        //object count, ParkingLotMaxCount;//OleDbConnection방식일때, 값은 안정적으로 구할 수 있으나 프로그램의 속도가 느리다.


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(strCon);
            // refresh_table();
            start_sensorvalue_table_dependency();
            InitializeGetCountData();
        }
        public void 신설1주차장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Form2))
                {
                    frm.Activate();
                    frm.BringToFront();
                    return;
                }
            }

           
            form2.MdiParent = this;
            form2.WindowState = FormWindowState.Maximized;
            form2.Show();

        }

        public void 신설2주차장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Form3))
                {
                    frm.Activate();
                    frm.BringToFront();
                    return;
                }
            }

            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.WindowState = FormWindowState.Maximized;
            form3.Show();
        }

        public void InitializeGetCountData()
        {
            GetCountData();

            //주차가능한 자리 수 
            label1.Text = Count1.ToString(); label2.Text = Count2.ToString();
            label3.Text = Count3.ToString(); label4.Text = Count4.ToString();
            label5.Text = Count5.ToString();

            label16.Text = Count11.ToString();
            label17.Text = Count12.ToString(); label18.Text = Count13.ToString();
            label19.Text = Count14.ToString(); label20.Text = Count15.ToString();


            //주차되어진 자리 수
            label6.Text = Count6.ToString(); label7.Text = Count7.ToString();
            label8.Text = Count8.ToString(); label9.Text = Count9.ToString();
            label10.Text = Count10.ToString();

            label21.Text = Count16.ToString();
            label22.Text = Count17.ToString(); label23.Text = Count18.ToString();
            label24.Text = Count19.ToString(); label25.Text = Count20.ToString();

            //총 주차면 수
            label11.Text = Total1.ToString(); label12.Text = Total2.ToString();
            label13.Text = Total3.ToString(); label14.Text = Total4.ToString();
            label15.Text = Total5.ToString();

            label26.Text = Total6.ToString();
            label27.Text = Total7.ToString(); label28.Text = Total8.ToString();
            label29.Text = Total9.ToString(); label30.Text = Total10.ToString();


            //지우지 말 것
            Count1 = 0; Count2 = 0; Count3 = 0; Count4 = 0; Count5 = 0;
            Count6 = 0; Count7 = 0; Count8 = 0; Count9 = 0; Count10 = 0;
            Count11 = 0; Count12 = 0; Count13 = 0; Count14 = 0; Count15 = 0;
            Count16 = 0; Count17 = 0; Count18 = 0; Count19 = 0; Count20 = 0;

            Total1 = 0; Total2 = 0; Total3 = 0; Total4 = 0; Total5 = 0;
            Total6 = 0; Total7 = 0; Total8 = 0; Total9 = 0; Total10 = 0;



        }
        public int GetCountData()
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

                    if (parkinglotid.ToString() == "1")
                    {
                        Total1++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count6++;
                        }
                        else
                        {
                            Count1++;
                        }

                    }


                    if (parkinglotid.ToString() == "2")
                    {
                        Total2++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count7++;
                        }
                        else
                        {
                            Count2++;
                        }

                    }

                    if (parkinglotid.ToString() == "3")
                    {
                        Total3++;
                        if (parkinglotid.ToString() == "3")
                        {
                            Count8++;
                        }
                        else
                        {
                            Count3++;
                        }

                    }


                    if (parkinglotid.ToString() == "4")
                    {
                        Total4++;
                        if (sensorvalue.ToString() == "True")
                        {
                            Count9++;
                        }
                        else
                        {
                            Count4++;
                        }

                    }

                    if (parkinglotid.ToString() == "5")
                    {
                        Total5++;
                        if (parkinglotid.ToString() == "True")
                        {
                            Count10++;
                        }
                        else
                        {
                            Count5++;
                        }
                    }

                    if (parkinglotid.ToString() == "6")
                    {
                        Total6++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count16++;
                        }
                        else
                        {
                            Count11++;
                        }
                    }
                    if (parkinglotid.ToString() == "7")
                    {
                        Total7++;

                        if (sensorvalue.ToString() == "True" && parkinglotid.ToString() == "7")
                        {
                            Count17++;
                        }
                        else
                        {
                            Count12++;
                        }
                    }
                    if (parkinglotid.ToString() == "8")
                    {
                        Total8++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count18++;
                        }
                        else
                        {
                            Count13++;
                        }
                    }

                    if (parkinglotid.ToString() == "9")
                    {
                        Total9++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count19++;
                        }
                        else
                        {
                            Count14++;
                        }
                    }

                    if (parkinglotid.ToString() == "10")
                    {
                        Total10++;

                        if (sensorvalue.ToString() == "True")
                        {
                            Count20++;
                        }
                        else
                        {
                            Count15++;
                        }
                    }


                }

                reader.Close();
                con.Close();

                return 0;
            }


        }
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SqlDependency.Stop(strCon);
            try
            {
                stop_sensorvalue_table_dependency();

            }
            catch (Exception ex) { log_file(ex.ToString()); }

        }


        public bool start_sensorvalue_table_dependency()
        {
            try
            {
                // SensorValue라는 테이블에서 데이터를 감시한다.
                sensorvalue_table_dependency = new SqlTableDependency<SensorValue>(strCon);
                sensorvalue_table_dependency.OnChanged += sensorvalue_table_dependency_Changed;
                sensorvalue_table_dependency.OnError += sensorvalue_table_dependency_OnError;

                sensorvalue_table_dependency.Start();
                return true;
            }
            catch (Exception ex)
            {
                log_file(ex.ToString());
                //log_file(DateTime.Now.ToString("HH:mm:ss:fff") + "\t" + Environment.NewLine);
            }
            return false;
        }

        public bool stop_sensorvalue_table_dependency()
        {
            try
            {
                if (sensorvalue_table_dependency != null)
                {
                    sensorvalue_table_dependency.Stop();

                    return true;
                }
            }
            catch (Exception ex) { log_file(ex.ToString()); }
            return false;
        }
        /* private void refresh_table()
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

         }*/
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

       
        // 데이터 값이 '변화'됬다는 이벤트를 알린다.
        public void sensorvalue_table_dependency_Changed(object sender, RecordChangedEventArgs<SensorValue> e)
        {
            try
            {
                
                var changedEntity = e.Entity;


                switch (e.ChangeType)
                {
                    // 어떠한 필드든지 Row가 추가되는 이벤트가 발생되면 
                    case ChangeType.Insert:
                        {
                            // Count 및 Total 수를 다시 센다.
                            InitializeGetCountData();

                        }
                        break;
                        // 데이터 값(모든 열
                    case ChangeType.Update:
                        {
                            // Count 및 Total 수를 다시 센다.
                            InitializeGetCountData();

                            // Sensorvalue값에 따라 button의 색상을 설정해준다.
                            form2.ChangeButtonColor(e.Entity.ParkingLotId, e.Entity.ParkingPositionId, e.Entity.sensorvalue);
                            
                            // 변화된 Sensorvalue값에 따라 button의 색상을 바꾼다.

                        }
                        break;
                    case ChangeType.Delete:
                        {
                            // refresh_table();
                            InitializeGetCountData();

                        }
                        break;
                }
                
                

            }
            catch (Exception ex)
            {
                log_file(ex.ToString());
            }

        }
  

        private void sensorvalue_table_dependency_OnError(object sender, ErrorEventArgs e)
        {
            log_file(e.Error.Message);
        }

        public void log_file(string logText)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", logText);
        }
    }
}

  