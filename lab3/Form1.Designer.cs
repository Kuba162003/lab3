namespace lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ID = new DataGridViewTextBoxColumn();
            Imię = new DataGridViewTextBoxColumn();
            Nazwisko = new DataGridViewTextBoxColumn();
            Wiek = new DataGridViewTextBoxColumn();
            Stanowisko = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Imię, Nazwisko, Wiek, Stanowisko });
            dataGridView1.Location = new Point(26, 39);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(543, 150);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(602, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(602, 128);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Usuń";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(61, 248);
            button3.Name = "button3";
            button3.Size = new Size(114, 23);
            button3.TabIndex = 3;
            button3.Text = "Zapis do .csv";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(262, 248);
            button4.Name = "button4";
            button4.Size = new Size(102, 23);
            button4.TabIndex = 4;
            button4.Text = "Odczyt z .csv";
            button4.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Imię
            // 
            Imię.HeaderText = "Imię";
            Imię.Name = "Imię";
            // 
            // Nazwisko
            // 
            Nazwisko.HeaderText = "Nazwisko";
            Nazwisko.Name = "Nazwisko";
            // 
            // Wiek
            // 
            Wiek.HeaderText = "Wiek";
            Wiek.Name = "Wiek";
            // 
            // Stanowisko
            // 
            Stanowisko.HeaderText = "Stanowisko";
            Stanowisko.Name = "Stanowisko";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 323);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Imię;
        private DataGridViewTextBoxColumn Nazwisko;
        private DataGridViewTextBoxColumn Wiek;
        private DataGridViewTextBoxColumn Stanowisko;
    }
}
