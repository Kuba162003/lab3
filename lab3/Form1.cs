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

        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            // Tworzenie nag³ówka pliku CSV
            string csvContent = "ID, Imiê, Nazwisko, Wiek, Stanowisko" + Environment.NewLine;
            // Dodawanie danych z DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
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
            File.WriteAllText(filePath, csvContent);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Wyœwietlanie okna dialogowego wyboru lokalizacji zapisu
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizacjê zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            // Jeœli u¿ytkownik wybierze lokalizacjê i zatwierdzi, zapisz plik CSV
            if (saveFileDialog1.FileName != "")
            {
                // U¿yj metody ExportToCSV i podaj obiekt DataGridView oraz œcie¿kê do pliku CSV
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }

        }

        private void LoadCSVToDataGridView(string filePath)
        {
            // SprawdŸ, czy plik istnieje
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            // Odczytaj zawartoœæ pliku CSV
            string[] lines = File.ReadAllLines(filePath);
            // Tworzenie tabeli danych
            dataGridView1.Columns.Clear();
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
        private void button4_Click(object sender, EventArgs e)
        {
            // Wyœwietlenie okna dialogowego wyboru pliku CSV
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            openFileDialog1.ShowDialog();
            // Jeœli u¿ytkownik wybierze plik i zatwierdzi, wczytaj dane z pliku CSV
            if (openFileDialog1.FileName != "")
            {
                // Wywo³anie funkcji wczytuj¹cej dane z pliku CSV
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }
    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
        }
    }

}
