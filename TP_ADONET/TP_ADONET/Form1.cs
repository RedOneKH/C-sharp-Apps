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

namespace TP_ADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("user id=KaiTo;" +
                                     "password=red;server=localhost;" +
                                     "Trusted_Connection=yes;" +
                                     "database=test; " +
                                     "connection timeout=30");
            try
            {
                myConnection.Open();
                Console.WriteLine("yeeeey");

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = myConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from new_schema.Ouvrage where Prix between "+val1.Text+" and "+val2.Text;
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                dataGridView1.DataSource = dtRecord;

                DataSet ds = new DataSet();
                sqlDataAdap.Fill(ds);

                this.listBox1.Items.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    
                        this.listBox1.Items.Add(row[1]);
                }

                using (SaveFileDialog fileSave = new SaveFileDialog())
                {
                    fileSave.Filter = "Fichiers xml|*.xml";
                    fileSave.InitialDirectory = @"c:\";
                    if (fileSave.ShowDialog() == DialogResult.OK)
                    {
                        // Mémorise le nom du fichier
                        string nomFichier = fileSave.FileName;
                        // Sauvegarde les informations
                        ds.WriteXml(nomFichier);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileOpen =
                new System.Windows.Forms.OpenFileDialog())
            {
                fileOpen.Filter = "Fichiers xml|*.xml";
                fileOpen.InitialDirectory = @"c:\";
                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(fileOpen.FileName);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {


                        this.listBox1.Items.Add(row[1]);
                    }

                    dataGridView1.DataSource = ds;


                }
            }
        }
    }
}
