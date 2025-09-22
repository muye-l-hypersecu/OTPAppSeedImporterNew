using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Windows.Forms;
using Utility;
using Model;
using System.Threading.Tasks;
using System.Globalization;

namespace OTPAppSeedImporterNew
{
    public partial class OTPAppSeedImporter : Form
    {
        private bool seedFileSelected;
        private bool dbFileSelected;
        private string databasePath;
        private Pair<List<SeedEntry>, Pair<int, int>> parsedFile;
        // number of spaces between SN and seed in listbox
        private const int NUMBER_OF_SPACES = 10;
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

            // If inputs are not properly selected, then display error message, otherwise, attempt to import to database
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
                // Check for duplicates in the database, and if there are any, then display the serial numbers
                List<string> dbDuplicates = DatabaseManager.CheckForDuplicates(databasePath, parsedFile.First);
                listBox2.Items.Insert(0, string.Empty);
                foreach (string dbDuplicate in dbDuplicates)
                {
                    listBox2.Items.Insert(0, $"- {dbDuplicate}");
                }

                // If there is at least one duplicate, then display error message. Otherwise, import the database
                if (dbDuplicates.Count > 0)
                {
                    if (dbDuplicates.Count == 1)
                    { 
                        listBox2.Items.Insert(0, "ERROR: There is 1 token serial number already in the database, which are listed below:");
                    } else
                    {
                        listBox2.Items.Insert(0, $"ERROR: There are {dbDuplicates.Count} token serial numbers already in the database, which are listed below:");
                    }
                }
                else
                {
                    string specId = comboBox1.SelectedItem.ToString();
                    int numEntriesSuccess = DatabaseManager.InsertSeedEntries(databasePath, parsedFile.First, specId);
                    
                    if (numEntriesSuccess == 1)
                    {
                        listBox2.Items.Insert(0, $"SUCCESS: Successfully imported 1 token entriers to the database");
                    } else
                    {
                        listBox2.Items.Insert(0, $"SUCCESS: Successfully imported {numEntriesSuccess} token entry to the database");
                    }

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
                    // If successful, update and display database path
                    label2.Text = openFileDialog1.FileName;
                    seedFileSelected = true;

                    // Parse the seed file
                    parsedFile = await SeedFileParser.ParseSeedFile(openFileDialog1.FileName);

                    // If there is invalid entries of duplicates in the seed file, display the corresponding messages too
                    listBox2.Items.Insert(0, string.Empty);
                    if (parsedFile.Second.First > 0) listBox2.Items.Insert(0, $"WARNING: Removed {parsedFile.Second.First} invalid entries from seed file");
                    if (parsedFile.Second.Second > 0) listBox2.Items.Insert(0, $"WARNING: Removed {parsedFile.Second.Second} duplicates from seed file");

                    // Display parsed message. If nothing was parsed, display error message, otherwise display success message
                    if (parsedFile.First.Count > 0)
                    {
                        if (parsedFile.First.Count == 1)
                        {
                            listBox2.Items.Insert(0, $"SUCCESS: Parsed 1 token entry from seed file");
                        } else
                        {
                            listBox2.Items.Insert(0, $"SUCCESS: Parsed {parsedFile.First.Count} token entries from seed file");
                        }
                    }
                    else
                    {
                        listBox2.Items.Insert(0, "ERROR: Did not successfully parse any entries");
                    }


                    // Set the check mark to visible
                    pictureBox1.Visible = true;

                    // Load in the serial numbers to the top listbox
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Serial Number           Seed");

                    // Insert them into listbox entry by entry
                    foreach (SeedEntry entry in parsedFile.First)
                    {
                        listBox1.Items.Add($"{entry.GetSerialNumber()}          {entry.GetSeed()}");
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
                // If successful, update and display database path, as well as a success message
                label3.Text = openFileDialog2.FileName;
                databasePath = openFileDialog2.FileName;
                dbFileSelected = true;
                pictureBox2.Visible = true;

                listBox2.Items.Insert(0, string.Empty);
                listBox2.Items.Insert(0, "SUCCESS: Database successfully imported");
            }
        }

        // Remove Entry button
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox1.SelectedIndex != 0)
            {
                string selectedEntry = listBox1.SelectedItem.ToString();
                SeedEntry entry = new SeedEntry(selectedEntry.Substring(0, 12), selectedEntry.Substring(12 + NUMBER_OF_SPACES));
                bool listContainsBefore = parsedFile.First.Contains(entry);

                // Removes from the list of SeedEntry
                if (parsedFile.First.Contains(entry))
                {
                    parsedFile.First.Remove(entry);
                }
                // Removes from listbox
                listBox1.Items.Remove(listBox1.SelectedItem);

                bool listContainsAfter = parsedFile.First.Contains(entry);
                string text = "";
                if (listContainsBefore && !listContainsAfter)
                {
                    text = "Successfully removed.";
                }
                else
                {
                    text = listContainsBefore ? "Remove unsuccessful." : "List doesn't contain the item.";
                }
                label4.Text = text;
            }
        }


        // Download Entry button
        private void button5_Click(object sender, EventArgs e)
        {
            if (seedFileSelected)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Files (*.txt) | *.txt";
                dlg.Title = "Save file as";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    for (int i = 1; i < listBox1.Items.Count; i++)
                    {
                        string item = listBox1.Items[i].ToString().Substring(0, 12) + "," + listBox1.Items[i].ToString().Substring(12 + NUMBER_OF_SPACES);
                        writer.WriteLine(item);
                    }
                    writer.Close();
                }
                dlg.Dispose();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
