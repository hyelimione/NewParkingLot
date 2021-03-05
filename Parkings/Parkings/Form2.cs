using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using ErrorEventArgs = TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs;

namespace Parkings
{
    public partial class Form2 : Form
    {
        UserControl2 uc2 = new UserControl2();
        Form1 form1 = new Form1();

        public SqlTableDependency<SensorValue> sensorvalue_table_dependency;
        public string strCon = "Data Source=192.168.4.175;Initial Catalog=Parkings;User ID=sa;Password=1234";


        public Form2()
        {
            InitializeComponent();
            start_sensorvalue_table_dependency();
            SqlDependency.Start(strCon);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          form1.start_sensorvalue_table_dependency();
          SqlDependency.Start(strCon);
            // refresh_table();
          
        }


        public void InitializeGetValuesData(int parkinglotId, int parkingpositionId, bool sensorvalue)
        {
            // foreach()
            if (uc2.ParkingLotId == parkinglotId && uc2.ParkingPositionId == parkingpositionId)
            {
                ChangeColor(sensorvalue);
            }
        }
        public void ChangeColor(bool sensorvalue)
        {

            if (sensorvalue == true)
            { 
                uc2.button1.BackColor = Color.Red;
            }
            else uc2.button1.BackColor = Color.Blue; 
        }

 
    }

}
