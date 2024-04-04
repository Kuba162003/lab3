using System.Data;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab3
{
    public partial class Form1 : Form
    {
        public List<Person> people = new List<Person>();
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
            // Tworzenie nag��wka pliku CSV
            string csvContent = "ID, Imi�, Nazwisko, Wiek, Stanowisko" + Environment.NewLine;
            // Dodawanie danych z DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Pomijaj wiersze niemieszcz�ce si� w DataGridView (np. wiersz zaznaczania)
                if (!row.IsNewRow)
                {
                    // Dodaj kolejne warto�ci w wierszu, oddzielone przecinkami
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            // Zapisanie zawarto�ci do pliku CSV
            File.WriteAllText(filePath, csvContent);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Wy�wietlanie okna dialogowego wyboru lokalizacji zapisu
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizacj� zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            // Je�li u�ytkownik wybierze lokalizacj� i zatwierdzi, zapisz plik CSV
            if (saveFileDialog1.FileName != "")
            {
                // U�yj metody ExportToCSV i podaj obiekt DataGridView oraz �cie�k� do pliku CSV
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }

        }

        private void LoadCSVToDataGridView(string filePath)
        {
            // Sprawd�, czy plik istnieje
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Odczytaj zawarto�� pliku CSV
            string[] lines = File.ReadAllLines(filePath);
            // Tworzenie tabeli danych
            dataGridView1.Columns.Clear();
            DataTable dataTable = new DataTable();
            // Dodanie kolumn na podstawie nag��wka
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
            // Wy�wietlenie okna dialogowego wyboru pliku CSV
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            openFileDialog1.ShowDialog();
            // Je�li u�ytkownik wybierze plik i zatwierdzi, wczytaj dane z pliku CSV
            if (openFileDialog1.FileName != "")
            {
                // Wywo�anie funkcji wczytuj�cej dane z pliku CSV
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
        }

        public void SerializeToXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, people);
            }
            Console.WriteLine("Obiekt zosta� zserializowany do pliku XML.");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SerializeToXML("serializacja.xml");
        }

        // Metoda do deserializacji z XML
        public static List<Person> DeserializeFromXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextReader reader = new StreamReader(fileName))
            {
                List<Person> person = (List<Person>)serializer.Deserialize(reader);
                Console.WriteLine("Obiekt zosta� odczytany z pliku XML.");
                return person;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            people = DeserializeFromXML("serializacja.xml");
            foreach (Person person in people) {
                dataGridView1.Rows.Add(new object[] { employer_ID, person.FirstName, person.LastName, person.Age });
                employer_ID++;
            }
        }
    }

}
