using ResistanceCalculator.Helpers;
using ResistanceCalculator.Objects;

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

            button1.Click += Calculate_Resistance;
        }

        private void Calculate_Resistance(object? sender, EventArgs e)
        {
            double result = 0;
            string digitConcat = "";


            var boxes = panel1.Controls.OfType<ComboBox>();
            int totalBands = boxes.Count();

            for (int i = 0; i < totalBands; i++)
            {
                ComboBox comboBox = boxes.ElementAt(i);
                if (comboBox == null) return;

                var color = comboBox.SelectedItem as BandColor;
                comboBox.SelectedItem = color.Color;


                if( i == totalBands - 2) // multiplier
                {
                    double digits = Convert.ToDouble(digitConcat);
                    result = digits * color.Multiplier;
                }
                else if (i < totalBands - 2) // tolerance
                {
                    digitConcat += color.Digit.ToString();
                }
            }

            textBox1.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
