using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Windows.Forms;
using Utility;
using Model;
using System.Threading.Tasks;

namespace OTPAppSeedImporterNew
{
    public partial class OTPAppSeedImporter : Form
    {
        private bool seedFileSelected;
        private bool dbFileSelected;
        private string databasePath;
        private int numEntriesSuccess;
        private Pair<List<SeedEntry>, Pair<int, int>> parsedFile;
        public OTPAppSeedImporter()
        {
            InitializeComponent();
            seedFileSelected = false;
            dbFileSelected = false;
            databasePath = "";
        }

        private void OTPAppSeedImporter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        // Import to database button
        private void button1_Click(object sender, EventArgs e)
        {
            int tokenSpec = comboBox1.SelectedIndex;
            if (!seedFileSelected)
            {
                MessageBox.Show("A seed file is not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!dbFileSelected)
            {
                MessageBox.Show("Database is not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(tokenSpec == 1 || tokenSpec == 2 | tokenSpec == 3))
            {
                MessageBox.Show("A token spec is not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<string> dbDuplicates = DatabaseManager.CheckForDuplicates(databasePath, parsedFile.First);
                string duplicate = "";
                foreach (string dbDuplicate in dbDuplicates)
                {
                    duplicate += dbDuplicate + " ";
                }
                if (dbDuplicates.Count > 0)
                {
                    label6.ForeColor = Color.Red;
                    label6.Text = $"These serial numbers already exist in the database. Please remove: {duplicate}.";
                }
                else
                {
                    string specId = comboBox1.SelectedItem.ToString();
                    int numEntriesSuccess = DatabaseManager.InsertSeedEntries(databasePath, parsedFile.First, specId);

                    label6.ForeColor = Color.Green;
                    label6.Text = $"{numEntriesSuccess} entries inserted successfully.";
                }

            }

        }

        // Select a seed file button
        private async void button2_Click(object sender, EventArgs e)
        {
            // only text files accepted
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    label2.Text = openFileDialog1.FileName;
                    seedFileSelected = true;

                    parsedFile = await SeedFileParser.ParseSeedFile(openFileDialog1.FileName);
                    listBox1.Items.Clear();
                    numEntriesSuccess = parsedFile.First.Count;
                    if (parsedFile.Second.First > 0)
                    {
                        label6.ForeColor = Color.Green;
                        if (parsedFile.Second.First == 1)
                        {
                            label6.Text = "1 invalid entry in the selected seed file has been removed.";
                        }
                        else
                        {
                            label6.Text = $"{parsedFile.Second.ToString()} invalid entries in the selected seed file have been removed.";
                        }
                    }
                    else
                    {
                        label6.Text = "";
                    }
                    pictureBox1.Visible = true;

                    listBox1.Items.Add("Serial Number           Seed");

                    foreach (SeedEntry entry in parsedFile.First)
                    {
                        listBox1.Items.Add($"{entry.GetSerialNumber()}\t {entry.GetSeed()}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Select database button
        private void button3_Click(object sender, EventArgs e)
        {
            // only text files accepted
            openFileDialog2.Filter = "Text files (*.db)|*.db";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog2.FileName;
                databasePath = openFileDialog2.FileName;
                dbFileSelected = true;
                pictureBox2.Visible = true;
                label6.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selectedSn = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(listBox1.SelectedItem);
            if (selectedSn.Length > 11 && parsedFile.First.Contains(selectedSn.Substring(0, 12)))
            {

            }
        }

    }
}
