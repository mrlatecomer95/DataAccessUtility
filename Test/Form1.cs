using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessUtility;

namespace Test
{
    public partial class Form1 : Form
    {
        MSSQLDB _Db;
        public Form1()
        {
            InitializeComponent();
            _Db= new MSSQLDB("Server=localhost\\sqlexpress;Database=TestDB;User Id=sa;Password=admin1234;");
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = _Db.CreateTable("SELECT * FROM dbo.TestTable");
	    }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            //_Db.RunSql("INSERT INTO dbo.TestTable(Name)VALUES(@name)", _Db.CreateParam("@name", this.textEdit1.Text));

            //IDataParameter[] xsp = {_Db.CreateParam("@LName", this.textEdit1.Text),
            //                      _Db.CreateParam("@FName", this.textEdit2.Text),
            //                      _Db.CreateParam("@MName", this.textEdit3.Text)};
            //_Db.RunSql("INSERT INTO dbo.TestTable(LName,)VALUES(@LName)", _Db.CreateParam("@LName", this.textEdit3.Text));
            //this.gridControl1.DataSource = _Db.CreateTable("SELECT * FROM dbo.TestTable");

            MessageBox.Show(_Db.DLookUp("LName", "TestTable", "", "[LName]= 'MNAMEAEW'"));

        }

    }
}
