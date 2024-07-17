using System.IO;
using System;
using System.Windows.Forms;

namespace MedicationDosageCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblClientId;
        private TextBox txtClientId;
        private Label lblPetName;
        private TextBox txtPetName;
        private Label lblWeight;
        private TextBox txtWeight;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblMedicationName;
        private TextBox txtMedicationName;
        private Label lblDosagePerKg;
        private TextBox txtDosagePerKg;
        private Button btnCalculate;
        private Button btnSave;
        private Button btnLoad;
        private DataGridView dgvResults;


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Получаем введенные данные
            string clientId = txtClientId.Text;
            string petName = txtPetName.Text;
            double weight = double.Parse(txtWeight.Text);
            int age = int.Parse(txtAge.Text);
            string medicationName = txtMedicationName.Text;
            double dosagePerKg = double.Parse(txtDosagePerKg.Text);

            // Расчет дозировки
            double dosage = weight * dosagePerKg;

            // Добавление строки в DataGridView
            dgvResults.Rows.Add(clientId, petName, weight, age, medicationName, dosage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Записываем заголовки столбцов
                    for (int i = 0; i < dgvResults.Columns.Count; i++)
                    {
                        writer.Write(dgvResults.Columns[i].HeaderText);
                        if (i < dgvResults.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();

                    // Записываем строки данных
                    for (int i = 0; i < dgvResults.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvResults.Columns.Count; j++)
                        {
                            writer.Write(dgvResults.Rows[i].Cells[j].Value);
                            if (j < dgvResults.Columns.Count - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    // Очищаем существующие строки
                    dgvResults.Rows.Clear();

                    // Пропускаем заголовки столбцов
                    string headerLine = reader.ReadLine();

                    // Читаем строки данных
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        dgvResults.Rows.Add(values);
                    }
                }
            }
        }
    

    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblClientId = new Label();
            this.txtClientId = new TextBox();
            this.lblPetName = new Label();
            this.txtPetName = new TextBox();
            this.lblWeight = new Label();
            this.txtWeight = new TextBox();
            this.lblAge = new Label();
            this.txtAge = new TextBox();
            this.lblMedicationName = new Label();
            this.txtMedicationName = new TextBox();
            this.lblDosagePerKg = new Label();
            this.txtDosagePerKg = new TextBox();
            this.btnCalculate = new Button();
            this.btnSave = new Button();
            this.btnLoad = new Button();
            this.dgvResults = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();

            // lblClientId
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(12, 15);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(56, 13);
            this.lblClientId.TabIndex = 0;
            this.lblClientId.Text = "ID клиента";

            // txtClientId
            this.txtClientId.Location = new System.Drawing.Point(150, 12);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(100, 20);
            this.txtClientId.TabIndex = 1;

            // lblPetName
            this.lblPetName.AutoSize = true;
            this.lblPetName.Location = new System.Drawing.Point(12, 41);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(96, 13);
            this.lblPetName.TabIndex = 2;
            this.lblPetName.Text = "Кличка животного";

            // txtPetName
            this.txtPetName.Location = new System.Drawing.Point(150, 38);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(100, 20);
            this.txtPetName.TabIndex = 3;

            // lblWeight
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(12, 67);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(26, 13);
            this.lblWeight.TabIndex = 4;
            this.lblWeight.Text = "Вес";

            // txtWeight
            this.txtWeight.Location = new System.Drawing.Point(150, 64);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 5;

            // lblAge
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(12, 93);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(44, 13);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Возраст";

            // txtAge
            this.txtAge.Location = new System.Drawing.Point(150, 90);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 20);
            this.txtAge.TabIndex = 7;

            // lblMedicationName
            this.lblMedicationName.AutoSize = true;
            this.lblMedicationName.Location = new System.Drawing.Point(12, 119);
            this.lblMedicationName.Name = "lblMedicationName";
            this.lblMedicationName.Size = new System.Drawing.Size(102, 13);
            this.lblMedicationName.TabIndex = 8;
            this.lblMedicationName.Text = "Наименование лекарства";

            // txtMedicationName
            this.txtMedicationName.Location = new System.Drawing.Point(150, 116);
            this.txtMedicationName.Name = "txtMedicationName";
            this.txtMedicationName.Size = new System.Drawing.Size(100, 20);
            this.txtMedicationName.TabIndex = 9;

            // lblDosagePerKg
            this.lblDosagePerKg.AutoSize = true;
            this.lblDosagePerKg.Location = new System.Drawing.Point(12, 145);
            this.lblDosagePerKg.Name = "lblDosagePerKg";
            this.lblDosagePerKg.Size = new System.Drawing.Size(87, 13);
            this.lblDosagePerKg.TabIndex = 10;
            this.lblDosagePerKg.Text = "Доза на кг (мг/кг)";

            // txtDosagePerKg
            this.txtDosagePerKg.Location = new System.Drawing.Point(150, 142);
            this.txtDosagePerKg.Name = "txtDosagePerKg";
            this.txtDosagePerKg.Size = new System.Drawing.Size(100, 20);
            this.txtDosagePerKg.TabIndex = 11;

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(15, 168);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(205, 23);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "Рассчитать дозу";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(240, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить таблицу";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(400, 168);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 23);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Загрузить таблицу";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // dgvResults
            this.dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "ID клиента" },
            new DataGridViewTextBoxColumn { HeaderText = "Кличка животного" },
            new DataGridViewTextBoxColumn { HeaderText = "Вес" },
            new DataGridViewTextBoxColumn { HeaderText = "Возраст" },
            new DataGridViewTextBoxColumn { HeaderText = "Наименование лекарства" },
            new DataGridViewTextBoxColumn { HeaderText = "Доза" } });
            this.dgvResults.Location = new System.Drawing.Point(15, 197);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(543, 150);
            this.dgvResults.TabIndex = 15;

            // Form1
            this.ClientSize = new System.Drawing.Size(570, 359);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtDosagePerKg);
            this.Controls.Add(this.lblDosagePerKg);
            this.Controls.Add(this.txtMedicationName);
            this.Controls.Add(this.lblMedicationName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtPetName);
            this.Controls.Add(this.lblPetName);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.lblClientId);
            this.Name = "Form1";
            this.Text = "Расчет дозировки лекарств";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
