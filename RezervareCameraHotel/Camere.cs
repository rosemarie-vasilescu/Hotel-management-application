using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RezervareCameraHotel
{
    public partial class Camere : Form
    {
        const int IdCameraIndex = 0;
        const int NrCameraIndex = 1;
        const int NrLocuriIndex = 2;
        const int EtajIndex = 3;
        const int PretZiIndex = 4;
        const int SplImagineIndex = 5;

        public Camere()
        {
            InitializeComponent();
        }
        private void config(bool v)
        {
            dataGridView1.AllowUserToAddRows = !v;
            dataGridView1.AllowUserToDeleteRows = !v;

            //Protectie coloane
            dataGridView1.Columns[NrCameraIndex].ReadOnly = v;
            dataGridView1.Columns[NrLocuriIndex].ReadOnly = v;
            dataGridView1.Columns[EtajIndex].ReadOnly = v;
            dataGridView1.Columns[PretZiIndex].ReadOnly = v;
            dataGridView1.Columns[SplImagineIndex].ReadOnly = v;

            btnActualizare.Enabled = v;
            btnSalvare.Visible = !v;
            btnRenuntare.Visible = !v;
        }
        private void refresh()
        {
            camereTableAdapter.Fill(dataSet1.Camere);
            pictureBox1.ImageLocation = txtSpPoza.Text;
        }
        private bool completareCampuri()
        {
            bool raspuns = true;
            foreach (DataRow r in dataSet1.Camere)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                if (r["NrCamera"] == DBNull.Value)
                {   
                    MessageBox.Show("Completati NrCamera la linia cu Id " + r["IdCamera"]);
                    raspuns = false;
                }
                if (r["NrLocuri"] == DBNull.Value)
                {
                    MessageBox.Show("Completati NrLocuri la linia cu Id " + r["IdCamera"]);
                    raspuns = false;
                }
                if (r["Etaj"] == DBNull.Value)
                {
                    MessageBox.Show("Completati Etaj la linia cu Id " + r["IdCamera"]);
                    raspuns = false;
                }
                if (r["PretZi"] == DBNull.Value)
                {
                    MessageBox.Show("Completati PretZi la linia cu Id " + r["IdCamera"]);
                    raspuns = false;
                }
                if (r["SplImagine"] == DBNull.Value)
                {
                    MessageBox.Show("Completati SplImagine la linia cu Id " + r["IdCamera"]);
                    raspuns = false;
                }


            }
            return raspuns;
        }

        private void Camere_Load(object sender, EventArgs e)
        {
            //A1
            config(true);
            refresh();
            dataGridView1.Columns[IdCameraIndex].ReadOnly = true;


        }

        private void btnActualizare_Click(object sender, EventArgs e)
        {
            //A2
            config(false);

        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (!completareCampuri()) return;
            try
            {
                camereTableAdapter.Update(dataSet1.Camere);
                config(true);
                refresh();
            }
            catch (Exception exc)
            {
                string s = exc.Message;

                if (s.IndexOf("duplicate values") > 0)
                    MessageBox.Show("Inregistrare deja existenta !");
                else if (s.IndexOf("cannot be deleted") > 0)
                    MessageBox.Show("Ati sters inregistrari referite in alte tabele !");
            }

        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            //A3
            config(true);
            refresh();

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (btnRenuntare.Focused)
            {
                dataGridView1.CancelEdit();
                //A3
                config(true);
                refresh();

                return;
            }
            MessageBox.Show("Format eronat");
           

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnActualizare.Enabled) return;

            if (dataGridView1.CurrentCell.ColumnIndex == SplImagineIndex)
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string s = openFileDialog1.FileName; ;
                    dataGridView1.CurrentRow.Cells[SplImagineIndex].Value = s;
                    pictureBox1.ImageLocation = s;
                    dataGridView1.EndEdit();

                }

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            con.ConnectionString = camereTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;


                cmd.CommandText = "Select IdCamera From RezervariContinut where IdCamera=" + Convert.ToString(id);
                
            
            con.Open();
            
            r = cmd.ExecuteReader();
           
            if (r.Read() )
            {
                MessageBox.Show("Camera referita in tabela RezervariContinut! Nu se poate sterge!");
                e.Cancel = true;
                con.Close();
                return;
            }
            con.Close();
            
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) e.Cancel = true;


        }

        private void camereBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = txtSpPoza.Text;
        }
    }
}
