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
    public partial class Fupdate : Form
    {
        private int classID;
        private ClassManagement business;
        public Fupdate(int id)
        {
            InitializeComponent();
            this.classID = id;
            this.business = new ClassManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += Fupdate_Load;
        }

        void Fupdate_Load(object sender, EventArgs e)
        {
            var OldClass = this.business.GetClass(this.classID);
            this.txtName.Text = OldClass.name;
            this.txtDes.Text = OldClass.descrip;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var des = this.txtDes.Text;
            this.business.EditClass(this.classID, name, des);
            MessageBox.Show("Update class succesfully");
            this.Close();
        }
    }
}
