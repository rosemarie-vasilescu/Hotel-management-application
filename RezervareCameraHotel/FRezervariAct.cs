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
    public partial class FRezervariAct : Form
    {
        private OleDbConnection con = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataReader rdr;
        private int idRez;
        public BindingSource bs1;
        public BindingSource bs2;
        public FRezervariAct()
        {
            InitializeComponent();
        }
        public void completeazaTitlu(String titlu)
        {
            lblOp.Text = titlu;
        }
        private void completeazaRezervare()
        {
            DataRowView current = (DataRowView)bs1.Current;

            idRez = (int)current["IdRezervare"];
            txtNrRezervare.Text = Convert.ToString(current["NrRezervare"]);

            cmbClient.Text = current["NumeClient"].ToString();
            txtTotal.Text = current["Total"].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(current["DataRezervarii"]);
            // dtpCazare.Value = Convert.ToDateTime(current["DataCazarii"]);

            bs2.MoveFirst();

            dataSet1.rezervareContinutManevra.Clear();


            for (int i = 1; i <= bs2.Count; i++)
            {
                current = (DataRowView)bs2.Current;

                DataSet1.rezervareContinutManevraRow r = dataSet1.rezervareContinutManevra.NewrezervareContinutManevraRow();

                r.NrCrt = Convert.ToInt16(current["NrCrt"]);
                r.IdCamera = Convert.ToInt32(current["IdCamera"]);
                r.NrCamera = Convert.ToString(current["NrCamera"]);
                r.NrLocuri = Convert.ToInt32(current["NrLocuri"]);
                r.Etaj = Convert.ToString(current["Etaj"]);
                r.NrZile = Convert.ToDecimal(current["NrZile"]);
                r.PretZi = Convert.ToDecimal(current["PretZi"]);
                r.Valoare = Convert.ToDecimal(current["Valoare"]);
                r.DataCazarii = Convert.ToDateTime(current["DataCazarii"]);
               // dtpCazare.Value = Convert.ToDateTime(current["DataCazarii"]);

                dataSet1.rezervareContinutManevra.Rows.Add(r);
                bs2.MoveNext();
            }
        }
        private void A1()
        {
            //Incarcare DataTable Produse
            camereTableAdapter.Fill(dataSet1.Camere);
            //Incarcare DataTable Clienti
            clientiTableAdapter.Fill(dataSet1.Clienti);

            // Protectie la modificare
            txtNrRezervare.ReadOnly = true;
            txtTotal.ReadOnly = true;
            nrCrtDataGridViewTextBoxColumn.ReadOnly = true;
          nrLocuriDataGridViewTextBoxColumn.ReadOnly = true;
         etajDataGridViewTextBoxColumn.ReadOnly = true;
            pretZiDataGridViewTextBoxColumn.ReadOnly = true;
            idCameraDataGridViewTextBoxColumn.ReadOnly = true;


            if (lblOp.Text == "MODIFICARE REZERVARE") completeazaRezervare();
            else if (lblOp.Text == "REZERVARE NOUA") cmbClient.SelectedIndex = -1;
            //completeazaRezervare();
            //cmbClient.SelectedIndex = -1;
        }
        private void A2()
        {
            if (!validareCampuriObligatorii()) return;
            if (lblOp.Text == "MODIFICARE REZERVARE")
            {
                modificaInregistrare();
                stergeContinut();
                adaugaInregistrariRezervariContinut();
                this.Close();
            }
            else if (lblOp.Text == "REZERVARE NOUA")
            {
                generez_nr_rez();
                adaugaInregistrareRezervari();
                cautaInregistrare();
                adaugaInregistrariRezervariContinut();
                golireCampuri();
            }
        }
        private void A3()
        {
            // Generare NrCrt
            DataRowView current = (DataRowView)rezervareContinutManevraBindingSource.Current;
            try { current["NrCrt"] = rezervareContinutManevraBindingSource.Position + 1; }
            catch { }
        }
        private void A4()
        {
            try
            {

                

                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    DataRowView current = (DataRowView)camereBindingSource.Current;
                    dataGridView1.CurrentRow.Cells[2].Value = current["NrLocuri"];
                    dataGridView1.CurrentRow.Cells[3].Value = current["Etaj"];
                    dataGridView1.CurrentRow.Cells[4].Value = current["PretZi"];
                    dataGridView1.CurrentRow.Cells[7].Value = current["IdCamera"];
                    //dataGridView1.CurrentRow.Cells[9].Value = current["SplImagine"];
                    calcTotal();
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    rezervareContinutManevraBindingSource.EndEdit();
                    calcTotal();
                }
            }
            catch { }
          
        }
        private void A5(DataGridViewRowCancelEventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) e.Cancel = true;
        }
        private void FRezervariAct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Camere' table. You can move, or remove it, as needed.
            this.camereTableAdapter.Fill(this.dataSet1.Camere);
            // TODO: This line of code loads data into the 'dataSet1.Clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.dataSet1.Clienti);
            refreshClienti(-1);
            A1();

        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A2();
        }
        private void calcTotal()
        {
            decimal t = 0;
            foreach (DataRow r in dataSet1.rezervareContinutManevra)
            {
                if (r["Valoare"] != DBNull.Value)
                    t += (decimal)r["Valoare"];
            }
            txtTotal.Text = Convert.ToString(t);
        }
        private void generez_nr_rez()
        {
            con.ConnectionString = camereTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;
            cmd.CommandText = "SELECT Max(Rezervari.NrRezervare) AS NrMax FROM Rezervari";
            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();
           
                txtNrRezervare.Text = rdr.IsDBNull(0) ? "1" : Convert.ToString(rdr.GetInt32(0) + 1); ;
            
            rdr.Close();
            con.Close();
        }
        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campul Client
            if (cmbClient.Text == "")
            {
                MessageBox.Show("Completati Client !");
                cmbClient.Focus();
                return false;
            }
            // Validare completare continut
            if (rezervareContinutManevraBindingSource.Count == 0)
            {
                MessageBox.Show("Completati continut rezervare !");
                dataGridView1.Focus();
                return false;
            }
            return true;
        }
        private void adaugaInregistrareRezervari()
        {
            string listaCampuri;
            string listaValori;
            DateTime d = dateTimePicker1.Value;

            listaCampuri = "NrRezervare, DataRezervarii, IdClient";
            listaValori = "'"+txtNrRezervare.Text +
                          "',#" + Convert.ToString(d.Month) + "/"
                               + Convert.ToString(d.Day) + "/"
                               + Convert.ToString(d.Year) + "#,"
                               + cmbClient.SelectedValue;

            cmd.CommandText = "Insert into Rezervari(" + listaCampuri + ") " +
                              "Select " + listaValori;

            //MessageBox.Show(cmd.CommandText);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void cautaInregistrare()
        {
            DateTime d = dateTimePicker1.Value;
             cmd.CommandText = "SELECT IdRezervare From Rezervari Where NrRezervare = " + txtNrRezervare.Text;
           // cmd.CommandText = "SELECT IdRezervare From Rezervari Where DataRezervarii = " + "#" + Convert.ToString(d.Month) + "/"
           //                    + Convert.ToString(d.Day) + "/"
           //                    + Convert.ToString(d.Year) + "#" + " AND IdClient= " +cmbClient.SelectedValue;
           // MessageBox.Show(cmd.CommandText);
            
            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();

            idRez = rdr.GetInt32(0);
           // MessageBox.Show(Convert.ToString(idRez));
            rdr.Close();
            con.Close();
        }
        private void adaugaInregistrariRezervariContinut()
        {
            string listaCampuri = "IdRezervare, NrCrt, IdCamera, DataCazarii, PretZi, NrZile";
            string listaValori;
            // DateTime d = dtpCazare.Value;
          //  DateTime d2 = (DateTime)dataGridView1.CurrentRow.Cells[8].Value;
           
            con.Open();
            foreach (DataRow r in dataSet1.rezervareContinutManevra)
            {
                DateTime d2 =Convert.ToDateTime(r["DataCazarii"]);
                listaValori = idRez + ","
                    + r["NrCrt"] + ","
                    + r["IdCamera"] + ","
                    
                    + "#" + Convert.ToString(d2.Month) + "/"
                               + Convert.ToString(d2.Day) + "/"
                               + Convert.ToString(d2.Year) + "#,"
                    + r["PretZi"] + ","
                    + r["NrZile"];
                
                cmd.CommandText = "Insert into RezervariContinut(" + listaCampuri + ") " + "Select " + listaValori;

               // MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void golireCampuri()
        {
            txtNrRezervare.Text = "";
            cmbClient.SelectedIndex = -1;
            txtTotal.Text = "";
            dataSet1.rezervareContinutManevra.Clear();
        }
        private void modificaInregistrare()
        {
            DateTime d1 = dateTimePicker1.Value;
           // DateTime d2 = (DateTime)dataGridView1.CurrentRow.Cells[8].Value;
            con.ConnectionString = camereTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            string clauzaWhere = " Where IdRezervare = " + idRez;

            string clauzaSet = "Set DataRezervarii = #" + d1.Month + "/"
                               + d1.Day + "/"
                               + d1.Year + "#,"
                               + "IdClient = '" + cmbClient.SelectedValue+"'";

            cmd.CommandText = "Update Rezervari " + clauzaSet + clauzaWhere;

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void stergeContinut()
        {
            cmd.CommandText = "Delete from RezervariContinut Where IdRezervare = " + idRez;

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            A4();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            A5(e);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
            MessageBox.Show("Format eronat");

        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calcTotal();
        }

        private void rezervareContinutManevraBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            A3();
        }
        public void refreshClienti(int pozitie)
        {
            clientiTableAdapter.Fill(dataSet1.Clienti);
            cmbClient.SelectedIndex = pozitie;
        }

        private void btnClienti_Click(object sender, EventArgs e)
        {
            Clienti f = new Clienti();
            f.SetMaster(this);
            f.SetSelectVisible();
            f.ShowDialog();
        }
    }
}
