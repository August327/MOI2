using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MOI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string _ConnectionString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath+@"\TABAN_2.accdb";
        OleDbConnection con = new OleDbConnection(_ConnectionString);
         private void VeriYaz()
        {
            try
            {
                using (OleDbConnection con1 = new OleDbConnection(_ConnectionString)) 
                using (OleDbCommand cmd = new OleDbCommand()) 
                {
                    cmd.Connection = con1;
                    cmd.CommandText = "INSERT INTO table1 (ADI,SOYADI,DURUM,NOT FINAL) values (P1,P2,P3,P4)";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@P4", OleDbType.Integer).Value = Convert.ToInt64(textBox1.Text);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();

                }
            }
            catch
            {
                ;
            }

        }
         private void VeriOku()
        {
            try
            {
                using (OleDbConnection con2 = new OleDbConnection(_ConnectionString))
                using (OleDbCommand cmd1 = new OleDbCommand())
                {
                    cmd1.Connection = con2;
                    cmd1.CommandText = "SELECT * FROM table1 ";
                    DataTable dt = new DataTable();
                    con2.Open();
                    OleDbDataAdapter Adpt = new OleDbDataAdapter(cmd1);
                    Adpt.Fill(dt);
                    con2.Close();
                    dataGridView1.DataSource = dt;
                }
            }
            catch 
            {
                ;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                textBox4.UseSystemPasswordChar = true;
            }
            else
            {
                textBox4.UseSystemPasswordChar= false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VeriYaz();
            VeriOku();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VeriOku();
        }


        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.A)
        //    {
        //        DialogResult dr = new DialogResult();
        //        dr = MessageBox.Show("Kapatmak istiyor mususnuz?", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //        if (dr == DialogResult.Cancel)
        //        {
        //            MessageBox.Show("iptal");
        //        }
        //        else
        //        {
        //            Close();
        //        }

        //    }
        //}
        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    label1.Text = treeView1.SelectedNode.Text;
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    treeView1.Nodes.Clear();

        //    //TreeNode[] tnod = { new TreeNode("1.Donem dersler") };
        //    TreeNode tana = new TreeNode("Dosya");
        //    treeView1.Nodes.Add(tana);

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    TreeNode talt1 = new TreeNode("Matematik");
        //    TreeNode talt2 = new TreeNode("fizik");
        //    TreeNode talt3 = new TreeNode("kimya");
        //    TreeNode talt4 = new TreeNode("lineer cebir");
        //    TreeNode talt5 = new TreeNode("ingilizce");
        //    TreeNode[] Talt = {talt1, talt2, talt3, talt4, talt5};
        //    Talt[0]=talt1;
        //    Talt[1]=talt2;
        //    Talt[2]=talt3;
        //    Talt[3]=talt4;
        //    Talt[4]=talt5;
        //    //for (int i=0 ; i < Talt.Length; i++)

        //        TreeNode Ta = new TreeNode("1.Donem ders", Talt);
        //        treeView1.Nodes[0].Nodes.Add(Ta);






        //        }

        //        private void button3_Click(object sender, EventArgs e)
        //        {
        //            treeView1.Nodes.Clear();


        //        }
        //        private void getir()
        //        {
        //            String[] suruculer = Directory.GetLogicalDrives();
        //            foreach(string surucu in suruculer)
        //            {
        //                treeView2.Nodes.Add(surucu);
        //            }    
        //        }
        //        private void button4_Click(object sender, EventArgs e)
        //        {
        //            getir();
        //        }

        //        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        //        {
        //            string yol = treeView2.SelectedNode.Text;
        //            try
        //            {
        //                string[] Dosyalar = Directory.GetFiles(yol);
        //                string[] klasorler = Directory.GetDirectories(yol);
        //                  foreach ( string d in Dosyalar)
        //                {
        //                    e.Node.Nodes.Add(d);
        //                }
        //                  foreach (string k in klasorler)
        //                {
        //                    e.Node.Nodes.Add(k);
        //                }
        //            }
        //            catch (Exception)
        //            { 
        //                try
        //                {
        //                    System.Diagnostics.Process.Start(yol);
        //                }
        //                catch (Exception)
        //                {
        //                    ;
        //                }
        //            }

        //        }

        //        private void button5_Click(object sender, EventArgs e)
        //        {
        //            dataGridView1.RowCount = 4;
        //            dataGridView1.ColumnCount = 5;
        //            dataGridView1[1, 2].Value = "AUGUSTINE";

        //        }

        //        private void button6_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                Random rd = new Random();
        //                for (int i = 1; i < dataGridView1.RowCount; i++)
        //                {
        //                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
        //                    {
        //                        dataGridView1[i, j].Value = rd.Next(0, 100);
        //                    }
        //                }
        //            }
        //            catch(Exception) 
        //            {;
        //            }

        //        }
        //        int selectedRow =-1,selectedColumn=-1;

        //        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //            selectedRow = e.RowIndex;
        //            selectedColumn = e.ColumnIndex;
        //        }

        //        private void button7_Click(object sender, EventArgs e)
        //        {
        //            if (selectedRow!=-1 &&  selectedColumn != -1)
        //            {
        //                dataGridView1.SelectedCells[0].Value = "";
        //            }
        //        }


        //    }
    }
}


