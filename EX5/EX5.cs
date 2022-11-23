using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ex2_Assigment2_PRN211
{
    public partial class EX5 : Form
    {
        public EX5()
        {
            InitializeComponent();

            //DataProvider dao = new DataProvider();
            //DataTable dt = dao.executeQuery("select d.WordID, d.Word, d.EditDate, d.Meaning, w.TypeName from Dictionary d\r\n\tinner join WordType w\r\n\ton d.ID = w.ID");
            // dgvDictionary.DataSource = dt;
        }

        private void EX5_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        DataProvider d = new DataProvider();
        private void LoadData()
        {
            try
            {
                string sql = "select d.WordID,d.Word,d.Meaning,CONVERT(date,d.EditDate) as EditDate,w.TypeName " +
                 "from Dictionary d inner join WordType w on d.ID = w.ID";
                DataTable dt = d.executeQuery(sql);
                dgvDictionary.DataSource = dt;

                string data2 = "select * from WordType";
                DataTable dt2 = d.executeQuery(data2);
                cbxType.DataSource = dt2;
                cbxType.ValueMember = "ID";
                cbxType.DisplayMember = "TypeName";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Load Error!" + ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to exit?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);

            }
        }
        string wordID = " ";

        private void dgvDictionary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            wordID = dgvDictionary.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            txtWord.Text = dgvDictionary.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtMeaning.Text = dgvDictionary.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            cbxType.Text = dgvDictionary.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string today = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                string typeID = getTypeId(cbxType.Text);
                string strInsert = "insert into Dictionary (Word, EditDate, Meaning, ID) " +
                    "values('" + txtWord.Text + "','" + today + "','" + txtMeaning.Text + "','" + typeID + "')";
                if (d.executeNonQuery(strInsert))
                {
                    LoadData();
                    MessageBox.Show("Insert success.......");
                }
                else
                {
                    MessageBox.Show("Insert Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }
        private string getTypeId(string str)
        {
            string id = null;
            string sql = "select ID from WordType where TypeName = '" + str + "'";
            DataTable dt = d.executeQuery(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    id = row["ID"] + "";
                    break;
                }
            }
            return id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkIDExist(wordID))
            {
                try
                {
                    string today = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                    string typeID = getTypeId(cbxType.Text);
                    string strUpdate = "update Dictionary " +
                        "set Word = '" + txtWord.Text + "'," +
                        "EditDate = '" + today + "'," +
                        "Meaning = '" + txtMeaning.Text + "'," +
                        "ID = '" + typeID + "' where WordID = '" + wordID + "'";
                    if (d.executeNonQuery(strUpdate))
                    {
                        LoadData();
                        MessageBox.Show("Update success!");
                    }
                    else
                    {
                        MessageBox.Show("Update Error!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                MessageBox.Show("WordID does not exist!");
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkIDExist(wordID))
            {
                try
                {
                    string strDelete = " delete from Dictionary\r\nwhere WordID = " + wordID;


                    if (MessageBox.Show(this, "A U sure to Delete?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        d.executeNonQuery(strDelete);
                        MessageBox.Show("Delete Success.....");
                        LoadData();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Error!");

                }

            }
            else
            {
                MessageBox.Show("WordID dose not exist!");
            }
        }

        private bool checkIDExist(string wordID)
        {
            try
            {
                string sql = "select * from Dictionary where WordID = " + wordID;
                DataTable dt = d.executeQuery(sql);
                if (dt.Rows.Count > 0) return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
            return false;
        }
    }
}
