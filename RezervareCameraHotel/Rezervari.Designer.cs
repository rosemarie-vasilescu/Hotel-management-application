
namespace RezervareCameraHotel
{
    partial class Rezervari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rezervariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new RezervareCameraHotel.DataSet1();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rezervariContinutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtIdRezervare = new System.Windows.Forms.TextBox();
            this.btnRezervareNoua = new System.Windows.Forms.Button();
            this.btnModificareRezervare = new System.Windows.Forms.Button();
            this.btnStergeRezervare = new System.Windows.Forms.Button();
            this.rezervariTableAdapter = new RezervareCameraHotel.DataSet1TableAdapters.RezervariTableAdapter();
            this.rezervariContinutTableAdapter = new RezervareCameraHotel.DataSet1TableAdapters.RezervariContinutTableAdapter();
            this.idRezervareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataRezervariiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrRezervareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRezervareDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrCrtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCameraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCazariiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrCameraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretZiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrZileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariContinutBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRezervareDataGridViewTextBoxColumn,
            this.dataRezervariiDataGridViewTextBoxColumn,
            this.idClientDataGridViewTextBoxColumn,
            this.numeClientDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.nrRezervareDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rezervariBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(54, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(815, 171);
            this.dataGridView1.TabIndex = 0;
            // 
            // rezervariBindingSource
            // 
            this.rezervariBindingSource.DataMember = "Rezervari";
            this.rezervariBindingSource.DataSource = this.dataSet1;
            this.rezervariBindingSource.PositionChanged += new System.EventHandler(this.rezervariBindingSource_PositionChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRezervareDataGridViewTextBoxColumn1,
            this.nrCrtDataGridViewTextBoxColumn,
            this.idCameraDataGridViewTextBoxColumn,
            this.dataCazariiDataGridViewTextBoxColumn,
            this.nrCameraDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.pretZiDataGridViewTextBoxColumn,
            this.nrZileDataGridViewTextBoxColumn,
            this.valoareDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.rezervariContinutBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(12, 378);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1373, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // rezervariContinutBindingSource
            // 
            this.rezervariContinutBindingSource.DataMember = "RezervariContinut";
            this.rezervariContinutBindingSource.DataSource = this.dataSet1;
            // 
            // txtIdRezervare
            // 
            this.txtIdRezervare.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rezervariBindingSource, "IdRezervare", true));
            this.txtIdRezervare.Location = new System.Drawing.Point(921, 63);
            this.txtIdRezervare.Name = "txtIdRezervare";
            this.txtIdRezervare.Size = new System.Drawing.Size(103, 22);
            this.txtIdRezervare.TabIndex = 2;
            // 
            // btnRezervareNoua
            // 
            this.btnRezervareNoua.Location = new System.Drawing.Point(921, 109);
            this.btnRezervareNoua.Name = "btnRezervareNoua";
            this.btnRezervareNoua.Size = new System.Drawing.Size(103, 47);
            this.btnRezervareNoua.TabIndex = 3;
            this.btnRezervareNoua.Text = "Rezervare noua";
            this.btnRezervareNoua.UseVisualStyleBackColor = true;
            this.btnRezervareNoua.Click += new System.EventHandler(this.btnRezervareNoua_Click);
            // 
            // btnModificareRezervare
            // 
            this.btnModificareRezervare.Location = new System.Drawing.Point(921, 162);
            this.btnModificareRezervare.Name = "btnModificareRezervare";
            this.btnModificareRezervare.Size = new System.Drawing.Size(103, 46);
            this.btnModificareRezervare.TabIndex = 4;
            this.btnModificareRezervare.Text = "Modificare rezervare";
            this.btnModificareRezervare.UseVisualStyleBackColor = true;
            this.btnModificareRezervare.Click += new System.EventHandler(this.btnModificareRezervare_Click);
            // 
            // btnStergeRezervare
            // 
            this.btnStergeRezervare.Location = new System.Drawing.Point(921, 214);
            this.btnStergeRezervare.Name = "btnStergeRezervare";
            this.btnStergeRezervare.Size = new System.Drawing.Size(103, 49);
            this.btnStergeRezervare.TabIndex = 5;
            this.btnStergeRezervare.Text = "Sterge rezervare";
            this.btnStergeRezervare.UseVisualStyleBackColor = true;
            this.btnStergeRezervare.Click += new System.EventHandler(this.btnStergeRezervare_Click);
            // 
            // rezervariTableAdapter
            // 
            this.rezervariTableAdapter.ClearBeforeFill = true;
            // 
            // rezervariContinutTableAdapter
            // 
            this.rezervariContinutTableAdapter.ClearBeforeFill = true;
            // 
            // idRezervareDataGridViewTextBoxColumn
            // 
            this.idRezervareDataGridViewTextBoxColumn.DataPropertyName = "IdRezervare";
            this.idRezervareDataGridViewTextBoxColumn.HeaderText = "IdRezervare";
            this.idRezervareDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.idRezervareDataGridViewTextBoxColumn.Name = "idRezervareDataGridViewTextBoxColumn";
            this.idRezervareDataGridViewTextBoxColumn.Width = 2;
            // 
            // dataRezervariiDataGridViewTextBoxColumn
            // 
            this.dataRezervariiDataGridViewTextBoxColumn.DataPropertyName = "DataRezervarii";
            this.dataRezervariiDataGridViewTextBoxColumn.HeaderText = "DataRezervarii";
            this.dataRezervariiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataRezervariiDataGridViewTextBoxColumn.Name = "dataRezervariiDataGridViewTextBoxColumn";
            this.dataRezervariiDataGridViewTextBoxColumn.Width = 125;
            // 
            // idClientDataGridViewTextBoxColumn
            // 
            this.idClientDataGridViewTextBoxColumn.DataPropertyName = "IdClient";
            this.idClientDataGridViewTextBoxColumn.HeaderText = "IdClient";
            this.idClientDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.idClientDataGridViewTextBoxColumn.Name = "idClientDataGridViewTextBoxColumn";
            this.idClientDataGridViewTextBoxColumn.Width = 2;
            // 
            // numeClientDataGridViewTextBoxColumn
            // 
            this.numeClientDataGridViewTextBoxColumn.DataPropertyName = "NumeClient";
            this.numeClientDataGridViewTextBoxColumn.HeaderText = "NumeClient";
            this.numeClientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numeClientDataGridViewTextBoxColumn.Name = "numeClientDataGridViewTextBoxColumn";
            this.numeClientDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // nrRezervareDataGridViewTextBoxColumn
            // 
            this.nrRezervareDataGridViewTextBoxColumn.DataPropertyName = "NrRezervare";
            this.nrRezervareDataGridViewTextBoxColumn.HeaderText = "NrRezervare";
            this.nrRezervareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nrRezervareDataGridViewTextBoxColumn.Name = "nrRezervareDataGridViewTextBoxColumn";
            this.nrRezervareDataGridViewTextBoxColumn.Width = 125;
            // 
            // idRezervareDataGridViewTextBoxColumn1
            // 
            this.idRezervareDataGridViewTextBoxColumn1.DataPropertyName = "IdRezervare";
            this.idRezervareDataGridViewTextBoxColumn1.HeaderText = "IdRezervare";
            this.idRezervareDataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.idRezervareDataGridViewTextBoxColumn1.Name = "idRezervareDataGridViewTextBoxColumn1";
            this.idRezervareDataGridViewTextBoxColumn1.Width = 2;
            // 
            // nrCrtDataGridViewTextBoxColumn
            // 
            this.nrCrtDataGridViewTextBoxColumn.DataPropertyName = "NrCrt";
            this.nrCrtDataGridViewTextBoxColumn.HeaderText = "NrCrt";
            this.nrCrtDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nrCrtDataGridViewTextBoxColumn.Name = "nrCrtDataGridViewTextBoxColumn";
            this.nrCrtDataGridViewTextBoxColumn.Width = 125;
            // 
            // idCameraDataGridViewTextBoxColumn
            // 
            this.idCameraDataGridViewTextBoxColumn.DataPropertyName = "IdCamera";
            this.idCameraDataGridViewTextBoxColumn.HeaderText = "IdCamera";
            this.idCameraDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.idCameraDataGridViewTextBoxColumn.Name = "idCameraDataGridViewTextBoxColumn";
            this.idCameraDataGridViewTextBoxColumn.Width = 2;
            // 
            // dataCazariiDataGridViewTextBoxColumn
            // 
            this.dataCazariiDataGridViewTextBoxColumn.DataPropertyName = "DataCazarii";
            this.dataCazariiDataGridViewTextBoxColumn.HeaderText = "DataCazarii";
            this.dataCazariiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataCazariiDataGridViewTextBoxColumn.Name = "dataCazariiDataGridViewTextBoxColumn";
            this.dataCazariiDataGridViewTextBoxColumn.Width = 125;
            // 
            // nrCameraDataGridViewTextBoxColumn
            // 
            this.nrCameraDataGridViewTextBoxColumn.DataPropertyName = "NrCamera";
            this.nrCameraDataGridViewTextBoxColumn.HeaderText = "NrCamera";
            this.nrCameraDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nrCameraDataGridViewTextBoxColumn.Name = "nrCameraDataGridViewTextBoxColumn";
            this.nrCameraDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NrLocuri";
            this.dataGridViewTextBoxColumn1.HeaderText = "NrLocuri";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Etaj";
            this.dataGridViewTextBoxColumn2.HeaderText = "Etaj";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // pretZiDataGridViewTextBoxColumn
            // 
            this.pretZiDataGridViewTextBoxColumn.DataPropertyName = "PretZi";
            this.pretZiDataGridViewTextBoxColumn.HeaderText = "PretZi";
            this.pretZiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pretZiDataGridViewTextBoxColumn.Name = "pretZiDataGridViewTextBoxColumn";
            this.pretZiDataGridViewTextBoxColumn.Width = 125;
            // 
            // nrZileDataGridViewTextBoxColumn
            // 
            this.nrZileDataGridViewTextBoxColumn.DataPropertyName = "NrZile";
            this.nrZileDataGridViewTextBoxColumn.HeaderText = "NrZile";
            this.nrZileDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nrZileDataGridViewTextBoxColumn.Name = "nrZileDataGridViewTextBoxColumn";
            this.nrZileDataGridViewTextBoxColumn.Width = 125;
            // 
            // valoareDataGridViewTextBoxColumn
            // 
            this.valoareDataGridViewTextBoxColumn.DataPropertyName = "Valoare";
            this.valoareDataGridViewTextBoxColumn.HeaderText = "Valoare";
            this.valoareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valoareDataGridViewTextBoxColumn.Name = "valoareDataGridViewTextBoxColumn";
            this.valoareDataGridViewTextBoxColumn.ReadOnly = true;
            this.valoareDataGridViewTextBoxColumn.Width = 125;
            // 
            // Rezervari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 565);
            this.Controls.Add(this.btnStergeRezervare);
            this.Controls.Add(this.btnModificareRezervare);
            this.Controls.Add(this.btnRezervareNoua);
            this.Controls.Add(this.txtIdRezervare);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Rezervari";
            this.Text = "Rezervari";
            this.Load += new System.EventHandler(this.Rezervari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervariContinutBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtIdRezervare;
        private System.Windows.Forms.Button btnRezervareNoua;
        private System.Windows.Forms.Button btnModificareRezervare;
        private System.Windows.Forms.Button btnStergeRezervare;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrLocuriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn etajDataGridViewTextBoxColumn;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource rezervariBindingSource;
        private DataSet1TableAdapters.RezervariTableAdapter rezervariTableAdapter;
        private System.Windows.Forms.BindingSource rezervariContinutBindingSource;
        private DataSet1TableAdapters.RezervariContinutTableAdapter rezervariContinutTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRezervareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataRezervariiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrRezervareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRezervareDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrCrtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCameraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCazariiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrCameraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretZiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrZileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoareDataGridViewTextBoxColumn;
    }
}