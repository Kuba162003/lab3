using System.Data;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int employer_ID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tworzenie nag³ówka pliku CSV
            string csvContent = "Column1,Column2,Column3" + Environment.NewLine;
            // Dodawanie danych z DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Pomijaj wiersze niemieszcz¹ce siê w DataGridView (np. wiersz zaznaczania)
                if (!row.IsNewRow)
                {
                    // Dodaj kolejne wartoœci w wierszu, oddzielone przecinkami
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            // Zapisanie zawartoœci do pliku CSV
            File.WriteAllText("zapis.csv", csvContent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SprawdŸ, czy plik istnieje
            if (!File.Exists("odczyt.csv"))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Odczytaj zawartoœæ pliku CSV
            string[] lines = File.ReadAllLines("odczyt.csv");
            // Tworzenie tabeli danych
            DataTable dataTable = new DataTable();
            // Dodanie kolumn na podstawie nag³ówka
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            // Dodawanie wierszy do tabeli danych
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                dataTable.Rows.Add(values);
            }
            // Przypisanie tabeli danych do DataGridView
            dataGridView1.DataSource = dataTable;

        }
    }

}
