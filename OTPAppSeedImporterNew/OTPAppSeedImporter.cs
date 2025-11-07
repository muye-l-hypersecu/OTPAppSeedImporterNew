using Microsoft.VisualBasic.FileIO;
using Model;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OTPAppSeedImporterNew
{
    public partial class OTPAppSeedImporter : Form
    {
        private bool suppressResize = false;
        private bool seedFileSelected;
        private bool dbFileSelected;
        private string databasePath;
        private List<string> dbDuplicates;
        private Pair<List<SeedEntry>, Pair<int, int>> parsedFile;
        // number of spaces between SN and seed in listbox
        private const int NUMBER_OF_SPACES = 10;
        public OTPAppSeedImporter()
        {
            InitializeComponent();
            entriesListView.Columns.Add("Serial Number: ");
            entriesListView.Columns.Add("Seed: ");
            this.Load += entriesListView_Resize;
            seedFileSelected = false;
            dbFileSelected = false;
            databasePath = "";
        }

        private void OTPAppSeedImporter_Load(object sender, EventArgs e)
        {
            specComboBox.SelectedIndex = 0;
        }

        // Import to database button
        private void button1_Click(object sender, EventArgs e)
        {
            int tokenSpec = specComboBox.SelectedIndex;

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
            else if (parsedFile.First.Count == 0)
            {
                MessageBox.Show("There are no tokens to import to database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Check for duplicates in the database, and if there are any, then display the serial numbers
                dbDuplicates = DatabaseManager.CheckForDuplicates(databasePath, parsedFile.First);
                outputLogListBox.Items.Insert(0, string.Empty);
                foreach (string dbDuplicate in dbDuplicates)
                {
                    outputLogListBox.Items.Insert(0, $"- {dbDuplicate}");
                }

                // If there is at least one duplicate, then display error message. Otherwise, import the database
                if (dbDuplicates.Count > 0)
                {
                    button6.Visible = true;
                    if (dbDuplicates.Count == 1)
                    {
                        outputLogListBox.Items.Insert(0, "ERROR: There is 1 token serial number already in the database, which are listed below:");
                    }
                    else
                    {
                        outputLogListBox.Items.Insert(0, $"ERROR: There are {dbDuplicates.Count} token serial numbers already in the database, which are listed below:");
                    }
                }
                else
                {
                    string specId = specComboBox.SelectedItem.ToString();
                    int numEntriesSuccess = DatabaseManager.InsertSeedEntries(databasePath, parsedFile.First, specId);

                    if (numEntriesSuccess == 1)
                    {
                        outputLogListBox.Items.Insert(0, $"SUCCESS: Imported 1 token entry to the database.");
                    }
                    else
                    {
                        outputLogListBox.Items.Insert(0, $"SUCCESS: Imported {numEntriesSuccess} token entries to the database.");
                    }

                    // Reset the page
                    ResetPage();

                }

            }

        }

        // Select a seed file button
        private async void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // If successful, update and display file path
                    label2.Text = openFileDialog1.FileName;
                    seedFileSelected = true;

                    // Parse the seed file
                    parsedFile = await SeedFileParser.ParseSeedFile(openFileDialog1.FileName);

                    // If there is invalid entries of duplicates in the seed file, display the corresponding messages too
                    outputLogListBox.Items.Insert(0, string.Empty);
                    if (parsedFile.Second.First > 0)
                    {
                        if (parsedFile.Second.First == 1)
                        {
                            outputLogListBox.Items.Insert(0, $"WARNING: Omitted 1 invalid entry from seed file.");
                        }
                        else
                        {
                            outputLogListBox.Items.Insert(0, $"WARNING: Omitted {parsedFile.Second.First} invalid entries from seed file.");
                        }
                    }

                    if (parsedFile.Second.Second > 0)
                    {
                        if (parsedFile.Second.Second == 1)
                        {
                            outputLogListBox.Items.Insert(0, $"WARNING: Omitted 1 duplicate from seed file.");
                        }
                        else
                        {
                            outputLogListBox.Items.Insert(0, $"WARNING: Omitted {parsedFile.Second.Second} duplicates from seed file.");
                        }
                    }

                    // Display parsed message. If nothing was parsed, display error message, otherwise display success message
                    if (parsedFile.First.Count > 0)
                    {
                        if (parsedFile.First.Count == 1)
                        {
                            outputLogListBox.Items.Insert(0, $"SUCCESS: Parsed 1 token entry from seed file.");
                        }
                        else
                        {
                            outputLogListBox.Items.Insert(0, $"SUCCESS: Parsed {parsedFile.First.Count} token entries from seed file.");
                        }
                    }
                    else
                    {
                        outputLogListBox.Items.Insert(0, "ERROR: Did not parse any token entries.");
                    }


                    // Set the check mark to visible
                    pictureBox1.Visible = true;

                    // Clear the list boxes, then 
                    entriesListView.Items.Clear();
                    //entriesListView.Items.Add(new ListViewItem(["Serial Number: ", "Seed: "]));

                    // Insert them into listbox entry by entry
                    foreach (SeedEntry entry in parsedFile.First)
                    {
                        entriesListView.Items.Add(new ListViewItem([entry.GetSerialNumber(), entry.GetSeed()]));
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
            openFileDialog2.Filter = "Text files (*.db)|*.db|All Files (*.*)|*.*";
            openFileDialog2.FileName = "";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // If successful, update and display database path, as well as a success message
                label3.Text = openFileDialog2.FileName;
                databasePath = openFileDialog2.FileName;
                dbFileSelected = true;
                pictureBox2.Visible = true;

                outputLogListBox.Items.Insert(0, string.Empty);
                outputLogListBox.Items.Insert(0, "SUCCESS: Database connected.");
            }
        }

        // Remove Entry button
        private void button4_Click(object sender, EventArgs e)
        {
            if (entriesListView.SelectedItems != null && entriesListView.SelectedItems.Count > 0)
            {
                // Get the serial number to remove
                var row = entriesListView.SelectedItems[0];
                string snToRemove = row.Text;
                string seedToRemove = row.SubItems[1].Text;

                // Remove the entry from the parsed file and listview
                parsedFile.First.Remove(new SeedEntry(snToRemove, seedToRemove));

                suppressResize = true;
                entriesListView.Items.Remove(row);
                suppressResize = false;

                label4.Text = $"Removed serial number entry: {snToRemove}";

                // Display warning if there are no entries left.
                if (parsedFile.First.Count == 0)
                {
                    outputLogListBox.Items.Insert(0, string.Empty);
                    outputLogListBox.Items.Insert(0, "WARNING: There are no serial numbers left to import.");
                }
            } else
            {
                label4.Text = $"No serial numbers removed.";
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

                    foreach (ListViewItem row in entriesListView.Items)
                    {
                        string serialNumber = row.Text;
                        string seed = row.SubItems[1].Text;
                        writer.WriteLine($"{serialNumber},{seed}");
                    }
                    writer.Close();
                }
                dlg.Dispose();
            }
        }

        // Remove duplicates button
        private void button6_Click(object sender, EventArgs e)
        {
            // Get confirmation message and remove duplicates. Also make the button invisible
            var confirmationMessage = MessageBox.Show("Are you sure you want to remove duplicates?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationMessage == DialogResult.Yes)
            {
                foreach (string duplicate in dbDuplicates)
                {
                    suppressResize = true;
                    for (int i = entriesListView.Items.Count - 1; i >= 0; i--)
                    {
                        ListViewItem row = entriesListView.Items[i];

                        // First column is the serial number
                        string serial = row.Text;

                        if (serial == duplicate)
                        {
                            // Remove from your underlying data structure
                            var entryToRemove = parsedFile.First.FirstOrDefault(e => e.GetSerialNumber() == duplicate);
                            if (entryToRemove != null)
                            {
                                parsedFile.First.Remove(entryToRemove);
                            }

                            // Remove from UI
                            entriesListView.Items.RemoveAt(i);
                        }
                    }
                    suppressResize = false;
                }
                button6.Visible = false;

                // Add a log to the output
                outputLogListBox.Items.Insert(0, string.Empty);
                if (dbDuplicates.Count == 1)
                {
                    outputLogListBox.Items.Insert(0, $"SUCCESS: Removed 1 token entry.");
                }
                else
                {
                    outputLogListBox.Items.Insert(0, $"SUCCESS: Removed {dbDuplicates.Count} token entries.");
                }

                // Display warning if there are no entries left.
                if (parsedFile.First.Count == 0)
                {
                    outputLogListBox.Items.Insert(0, "WARNING: There are no serial numbers left to import.");
                }
            }

        }

        ///// HELPER FUNCTIONS /////

        // Resets the inputs, except for the bottom listbox message output
        private void ResetPage()
        {
            // Resets the displays
            label4.Text = string.Empty;
            label2.Text = "Seed file path";
            label3.Text = "Database path";
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;

            // Resets the boolean indicators
            seedFileSelected = false;
            dbFileSelected = false;
            databasePath = "";
            specComboBox.SelectedIndex = 0;

            // Wipes the list of seed entries
            entriesListView.Items.Clear();

        }
    }
}
