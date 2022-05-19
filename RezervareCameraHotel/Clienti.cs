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
    public partial class Clienti : Form
    {
        private Form master;
        private bool selectie;
        public Clienti()
        {
            InitializeComponent();
        }

        private void Clienti_Load(object sender, EventArgs e)
        {
            btnSelectie.Visible = false;
            A1();
        }
        public void SetMaster(Form caller)
        {
            master = caller;
        }
        public void SetSelectVisible()
        {
            selectie = true;
        }
        private void A1()
        {

            //Umple cu date obiectele DataTable: Persoane, Localitati (din DataSet):
            clientiTableAdapter.Fill(dataSet1.Clienti);

            //Configurare PB
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            //Protectie grid 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            //Protectie txtIdPersoana
            txtIdClient.ReadOnly = true;

            A3();
        }


        private void A2()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "ADAUGARE";

            //Pozitionare cursor pe primul camp
            txtNumeClient.Focus();

            // Golire campuri
            golireCampuri();
        }

        private void A3()
        {
            //Initializare lblOp
            lblOp.Text = "";

            //Çonfigurare(butoane)
            configureazaButoane(true);

            //Protectie componente Panel
            protectiePanel(true);

            //Legare controale
            legareControale(true);
        }

        private void A4()
        {
            if (lblOp.Text == "ADAUGARE")
            {
                if (!validareCampuriObligatorii()) return;

                adauga_inregistrare();

                golireCampuri();

                //Pune cursor pe primul camp
                txtNumeClient.Focus();
                refresh_grid(clientiBindingSource.Position);
            }
            else if (lblOp.Text == "MODIFICARE")
            {
                modifica_inregistrare();
                refresh_grid(clientiBindingSource.Position);
                A3();
            }
            else
                MessageBox.Show("Operatie actualizare neefectuata");
        }

        private void A5(TextBox txtB)
        {
            decimal p;
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            if (lblOp.Text == "") return;
            if (txtB.Text == "") return;
            if (btnRenuntare.Focused) return;

            if (txtB == txtNrTelefon)
            {
                // Validare numericitate
                try { p = Convert.ToDecimal(txtB.Text); }
                catch { MessageBox.Show("Format eronat"); txtB.Focus(); }
                return;
            }

            if (txtB == txtCNP)
            {
                // Validare numericitate
                try { p = Convert.ToDecimal(txtB.Text); }
                catch { MessageBox.Show("Format eronat"); txtB.Focus(); }

                con.ConnectionString = clientiTableAdapter.Connection.ConnectionString;
                cmd.Connection = con;

                if (lblOp.Text == "ADAUGARE")
                {
                    cmd.CommandText = "Select NumeClient From Clienti where CNP='" + txtCNP.Text + "'";
                    con.Open();
                    r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        MessageBox.Show("Cod partener deja existent");
                        txtCNP.Focus();
                    }
                    con.Close();
                }

                else if (lblOp.Text == "MODIFICARE")
                {
                    cmd.CommandText = "Select NumeClient From Clienti where CNP='" + txtCNP.Text +
                                      "' and IdClient  <> " + txtIdClient.Text;
                    con.Open();
                    r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        MessageBox.Show("Cod partener deja existent");
                        txtCNP.Focus();
                    }
                    con.Close();
                }
            }
        }

        private void A6()
        {
            if (lblOp.Text == "")
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSpPoza.Text = openFileDialog1.FileName;
                pb.ImageLocation = txtSpPoza.Text;
            }
        }

        private void A7()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "MODIFICARE";

            //Pozitionare cursor pe primul camp
            txtNumeClient.Focus();
        }

        private void A8()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            con.ConnectionString = clientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            cmd.CommandText = "Select IdClient From Rezervari where IdClient=" + txtIdClient.Text;
            con.Open();
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                MessageBox.Show("Client referit in tabela Rezervari! Nu se poate sterge!");
                con.Close();
                return;
            }
            con.Close();
            
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;
            cmd.CommandText = "Delete From Clienti Where IdClient = " + txtIdClient.Text;

         //   MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            refresh_grid(clientiBindingSource.Position);

        }

        private void configureazaButoane(bool v)
        {
            btnRenuntare.Visible = !v;
            btnConfirmare.Visible = !v;

            btnAdaugare.Enabled = v;
            btnModificare.Enabled = v;
            btnStergere.Enabled = v;
            if (selectie) btnSelectie.Visible = v;
        }

        private void legareControale(bool v)
        {
            if (v)
            {
                txtNumeClient.DataBindings.Add("Text", clientiBindingSource, "NumeClient");
                txtCNP.DataBindings.Add("Text", clientiBindingSource, "CNP");
                txtNrTelefon.DataBindings.Add("Text", clientiBindingSource, "NrTelefon");
                txtSpPoza.DataBindings.Add("Text", clientiBindingSource, "SpPoza");
                txtIdClient.DataBindings.Add("Text", clientiBindingSource, "IdClient");
                pb.DataBindings.Add("ImageLocation", clientiBindingSource, "SpPoza");
            }
            else
            {
                txtNumeClient.DataBindings.Clear();
                txtCNP.DataBindings.Clear();
                txtNrTelefon.DataBindings.Clear();
                txtSpPoza.DataBindings.Clear();
                txtIdClient.DataBindings.Clear();
                pb.DataBindings.Clear();
            }
        }

        private void protectiePanel(bool v)
        {
            txtNumeClient.ReadOnly = v;
            txtCNP.ReadOnly = v;
            txtNrTelefon.ReadOnly = v;
            txtSpPoza.ReadOnly = v;
        }

        private void golireCampuri()
        {
            txtNumeClient.Text = "";
            txtCNP.Text = "";
            txtIdClient.Text = "";
            txtNrTelefon.Text = "";
            txtSpPoza.Text = "";
            pb.ImageLocation = "";
        }

        private bool validareCampuriObligatorii()
        {
          

            //Validare de completare obligatorie campurile: Nume, CNP, Salariu, Localitate
            if (txtNumeClient.Text == "")
            {
                MessageBox.Show("Completati NumeClient !");
                txtNumeClient.Focus();
                return false;
            }
            if (txtCNP.Text == "")
            {
                MessageBox.Show("Completati CNP !");
                txtCNP.Focus();
                return false;
            }
            if (txtNrTelefon.Text == "")
            {
                MessageBox.Show("Completati NrTelefon!");
                txtNrTelefon.Focus();
                return false;
            }

            
            return true;
        }

        private void adauga_inregistrare()
        {
            string listaCampuri;
            string listaValori;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = clientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaCampuri = "NumeClient, CNP, NrTelefon, SpPoza";
            listaValori = "'" + txtNumeClient.Text + "'" +
                          ",'" + txtCNP.Text + "'" +
                          ",'" + txtNrTelefon.Text + "'" +
                          ",'" + txtSpPoza.Text + "'";

            cmd.CommandText = "Insert into Clienti(" + listaCampuri + ") " +
                              "Select " + listaValori;

        //    MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void refresh_grid(int p)
        {
            clientiTableAdapter.Fill(dataSet1.Clienti);
            clientiBindingSource.Position = p;
        }
        private void modifica_inregistrare()
        {
            string listaSet;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = clientiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaSet = "NumeClient = '" + txtNumeClient.Text + "'," +
                       "CNP = '" + txtCNP.Text + "'," +
                       "NrTelefon = '" + txtNrTelefon.Text + "'," +
                       "SpPoza = '" + txtSpPoza.Text + "'";

            cmd.CommandText = "Update Clienti Set " + listaSet + " Where IdClient=" + txtIdClient.Text;

          //  MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            A2();
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            A7();
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A4();
        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            A3();
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
          // const string mesaj = "Confirmati stergerea";
            //const string titlu = "Stergere inregistrare";
           // var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           // if (rezultat == DialogResult.No) return;
            A8();

        }

        private void txtSpPoza_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            A6();
        }

        private void txtCNP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCNP_Leave(object sender, EventArgs e)
        {
            A5(txtCNP);
        }

        private void txtNrTelefon_Leave(object sender, EventArgs e)
        {
            A5(txtNrTelefon);
        }

        private void btnSelectie_Click(object sender, EventArgs e)
        {
            FRezervariAct f = (FRezervariAct)master;
            f.refreshClienti(clientiBindingSource.Position);
            this.Close();
        }
    }
}
