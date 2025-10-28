using ResistanceCalculator.Helpers;

namespace ResistanceCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //populate panel 1
            ComboBoxHelper.CreateComboBoxes(panel1, 4);
            ComboBoxHelper.CreateComboBoxes(panel2, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
