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
    public partial class Rezervari : Form
    {
        public Rezervari()
        {
            InitializeComponent();
        }
        private void refreshGrid(int p)
        {
            rezervariTableAdapter.Fill(dataSet1.Rezervari);
            rezervariContinutTableAdapter.Fill(dataSet1.RezervariContinut);
            rezervariBindingSource.Position = p;
        }
        private void filtreazaDetaliu()
        {
            try
            {
                rezervariContinutBindingSource.Filter = "IdRezervare=" + txtIdRezervare.Text;
            }
            catch { }
        }

        private void Rezervari_Load(object sender, EventArgs e)
        {
           

            refreshGrid(rezervariBindingSource.Position);
            try
            {
                rezervariContinutBindingSource.Filter = "IdRezervare=" + txtIdRezervare.Text;
            }
            catch { }
            //   filtreazaDetaliu();
            refreshGrid(rezervariBindingSource.Position);

        }

      

        private void btnRezervareNoua_Click(object sender, EventArgs e)
        {
            FRezervariAct f = new FRezervariAct();
            f.completeazaTitlu("REZERVARE NOUA");
            f.ShowDialog();
            refreshGrid(rezervariBindingSource.Position);

        }

        private void btnModificareRezervare_Click(object sender, EventArgs e)
        {
            FRezervariAct f = new FRezervariAct();
            f.completeazaTitlu("MODIFICARE REZERVARE");
            f.bs1 = rezervariBindingSource;
            f.bs2 = rezervariContinutBindingSource;
            f.ShowDialog();
            refreshGrid(rezervariBindingSource.Position);

        }

        private void btnStergeRezervare_Click(object sender, EventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";

            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = rezervariTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            // Sterg continut comanda
            cmd.CommandText = "Delete From RezervariContinut Where IdRezervare = " + txtIdRezervare.Text;

           // MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            // Sterg comanda
            cmd.CommandText = "Delete From Rezervari Where IdRezervare = " + txtIdRezervare.Text;
           // MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();

            con.Close();

            // Refresh grid-uri
            refreshGrid(rezervariBindingSource.Position);
            // filtreazaDetaliu();
            try
            {
                rezervariContinutBindingSource.Filter = "IdRezervare=" + txtIdRezervare.Text;
            }
            catch { }

        }

       

        private void rezervariBindingSource_PositionChanged(object sender, EventArgs e)
        {
            filtreazaDetaliu();
        }
    }
}
