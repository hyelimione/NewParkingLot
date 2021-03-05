using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using ErrorEventArgs = TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs;

namespace Parkings
{
    public partial class UserControl2 : UserControl
    {
      
        [Category("ButtonProperty"), Description("ParkingLotId")]
        public int ParkingLotId { get; set; }
        [Category("ButtonProperty"), Description("ParkingPositionId")]
        public int ParkingPositionId { get; set; }
        public UserControl2()
        {
            InitializeComponent();


        }
       
      

        private bool start_sensorvalue_table_dependency()
        {
            try
            {
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
            catch (Exception ex) { log_file(ex.ToString()); }
            return false;
        }


        //해당 parkinglotid와 parkingpositionid를가진 버튼의 색깔을 바꿔주는 함수
    
     /*   public void InitializeGetValuesData(int i, int j)
        {
           


            // 해당 컬럼과 데이터값이 일치한 열의 sens
        }

        public void ChangeColor(int j)
        {
            button1.ParkingPositionId = j;

        }
    */
        public void sensorvalue_table_dependency_Changed(object sender, RecordChangedEventArgs<SensorValue> e)
        {
            try
            {
                Form2 frm = new Form2();
              
                var changedEntity = e.Entity;


                switch (e.ChangeType)
                {
                    case ChangeType.Insert:
                        {
                            // refresh_table();
                            frm.InitializeGetValuesData(e.Entity.ParkingLotId, e.Entity.ParkingPositionId,e.Entity.sensorvalue);
                           // InitializeGetValuesData(e.Entity.ParkingLotId, e.Entity.ParkingPositionId);

                        }
                        break;

                    case ChangeType.Update:
                        {
                            // refresh_table();

                            frm.InitializeGetValuesData(e.Entity.ParkingLotId, e.Entity.ParkingPositionId,e.Entity.sensorvalue);

                            // log_file("Update values:\tParkingLotId:" + changedEntity.ParkingLotId.ToString() + "\tParkingPositionId:" + changedEntity.ParkingPositionId.ToString());

                        }
                        break;
                    case ChangeType.Delete:
                        {
                            // refresh_table();
                            frm.InitializeGetValuesData(e.Entity.ParkingLotId, e.Entity.ParkingPositionId, e.Entity.sensorvalue);

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

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SqlDependency.Stop(strCon);
            try
            {
                stop_sensorvalue_table_dependency();

            }
            catch (Exception ex) { log_file(ex.ToString()); }

        }

    }
}


