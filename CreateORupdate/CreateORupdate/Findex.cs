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
    public partial class Findex : Form
    {
        private ClassManagement Business;
        public Findex()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += Findex_Load; // show classes
            this.BtnAddTool.Click += BtnAddTool_Click; // create a class
            this.BtnDeleteTool.Click += BtnDeleteTool_Click; // delete a class
            this.dataGridView1.DoubleClick += dataGridView1_DoubleClick; // edit a class
        }
        private void LoadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.dataGridView1.DataSource = classes;
        }

        void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count==1)
            {
                var UpdateClass = (@class)this.dataGridView1.SelectedRows[0].DataBoundItem;

                var updateForm = new Fupdate(UpdateClass.id);
                updateForm.ShowDialog();
                this.LoadAllClasses();
            }
        }

        void BtnDeleteTool_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this?","Comfirm"
                    ,MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var DelClass = (@class)this.dataGridView1.SelectedRows[0].DataBoundItem; //this button deleted
                    this.Business.DeleteClass(DelClass.id);
                    MessageBox.Show("Delete class succesfully");
                    this.LoadAllClasses();
                }
            }
        }

        void BtnAddTool_Click(object sender, EventArgs e)
        {
            var CreateForm = new Fcreate();
            CreateForm.ShowDialog();
            this.LoadAllClasses();
        }

        void Findex_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }

    }
}
