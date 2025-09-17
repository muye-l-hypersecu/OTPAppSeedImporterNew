using Utility;

namespace OTPAppSeedImporterNew
{
    public partial class OTPAppSeedImporter : Form
    {
        public OTPAppSeedImporter()
        {
            InitializeComponent();
        }

        private void OTPAppSeedImporter_Load(object sender, EventArgs e)
        {
            SeedFileParser.DoThis(); // This is just a dummy function, remove later. 
            DatabaseManager.DoThisManager(); // Another dummy function, remove later.
        }
    }
}
