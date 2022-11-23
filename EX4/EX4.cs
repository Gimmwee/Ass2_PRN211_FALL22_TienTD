using EX4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EX4
{
    public partial class EX4 : Form
    {
        public EX4()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string today = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                Dictionary d = new Dictionary
                {
                    Word = txtWord.Text,
                    Meaning = txtMeaning.Text,
                    EditDate = DateTime.Parse(today),
                    Id = (int)cbxType.SelectedValue
                };

                context.Dictionaries.Add(d);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Insert success....!");
                    loadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string today = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            try
            {
                Dictionary d = context.Dictionaries.FirstOrDefault(x => x.WordId == Int32.Parse(textBox1.Text));
                if (d != null)
                {
                    d.Word = txtWord.Text;
                    d.Meaning = txtMeaning.Text;
                    d.EditDate = DateTime.Parse(today);
                    d.Id = (int)cbxType.SelectedValue;
                }
             
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Update success..!");
                    loadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary d = context.Dictionaries.FirstOrDefault(x => x.WordId == Int32.Parse(code));

                if (MessageBox.Show(this, "A U sure to Delete?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (d != null)
                    {
                        context.Dictionaries.Remove(d);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Delete success!");
                            loadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Delete Error!" + ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to exit?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void EX4_Load(object sender, EventArgs e)
        {
            loadData();
        }
        MyDB2Context context = new MyDB2Context();
        string code;
        private void loadData()
        {
            var data = context.Dictionaries.Select(p => new
            {
                WordId = p.WordId,
                Word = p.Word,
                Meaning = p.Meaning,
                EditDate = p.EditDate,
                TypeName = p.IdNavigation.TypeName
            }).ToList();

            dgvDictionary.DataSource = data;


            var data2 = context.WordTypes.ToList();
            cbxType.DataSource = data2;
            cbxType.DisplayMember = "TypeName";
            cbxType.ValueMember = "Id";

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", data, "WordId");
            textBox1.Enabled = false;
            textBox1.Visible = false;


            txtWord.DataBindings.Clear();
            txtWord.DataBindings.Add("Text", data, "Word");

            txtMeaning.DataBindings.Clear();
            txtMeaning.DataBindings.Add("Text", data, "Meaning");

            cbxType.DataBindings.Clear();
            cbxType.DataBindings.Add("Text", data, "TypeName");

        }

        private void dgvDictionary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            code = dgvDictionary.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
