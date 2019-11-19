using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateORupdate
{
    public partial class Fcreate : Form
    {
        private ClassManagement business;
   
        public Fcreate()
        {
            InitializeComponent();
            this.business = new ClassManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var descrip = this.txtDes.Text;

            this.business.AddClass(name, descrip);
            MessageBox.Show("Add New Class Successfully");
            this.Close();
        }

        

    }
}
