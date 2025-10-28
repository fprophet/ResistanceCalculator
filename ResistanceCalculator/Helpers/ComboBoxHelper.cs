using ResistanceCalculator.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceCalculator.Helpers
{
    public static class ComboBoxHelper
    {
        public static List<BandColor> BandColors { get; private set; } = new List<BandColor>()
        {
                new BandColor{Digit = 0, Color = Color.Black, Multiplier = 1, Tollerance = "" },
                new BandColor{Digit = 1, Color = Color.Brown, Multiplier = 10, Tollerance = "±1%" },
                new BandColor{Digit = 2, Color = Color.Red, Multiplier = 100, Tollerance = "±2%" },
                new BandColor{Digit = 3, Color = Color.Orange, Multiplier = 1000, Tollerance = "" },
                new BandColor{Digit = 4, Color = Color.Yellow, Multiplier = 10000, Tollerance = "" },
                new BandColor{Digit = 5, Color = Color.Green, Multiplier = 100000, Tollerance = "±5%" },
                new BandColor{Digit = 6, Color = Color.Blue, Multiplier = 1000000, Tollerance = "±0.25%" },
                new BandColor{Digit = 7, Color = Color.Violet, Multiplier = 10000000, Tollerance = "±0.1%" },
                new BandColor{Digit = 8, Color = Color.Gray, Multiplier = 1 , Tollerance = "±0.05%"},
                new BandColor{Digit = 9, Color = Color.White, Multiplier = 1, Tollerance = "" },
                new BandColor{Digit = 10, Color = Color.Gold, Multiplier = 0.1, Tollerance = "±5%" },
                new BandColor{Digit = 11, Color = Color.Silver, Multiplier = 0.01, Tollerance = "±10%" }
        };


        private static void Combo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = (ComboBox)sender;
            BandColor colorData = (BandColor)combo.Items[e.Index];
            Color color = colorData.Color;
            e.DrawBackground();

            using (Brush brush = new SolidBrush(color))
            {
                var width = combo.Width - 6;
                e.Graphics.FillRectangle(brush, e.Bounds.Left + 2, e.Bounds.Top + 2, width, e.Bounds.Height - 4);
                e.Graphics.DrawRectangle(Pens.Black, e.Bounds.Left + 2, e.Bounds.Top + 2, width, e.Bounds.Height - 4);
            }

            e.DrawFocusRectangle();
        }

        public static void CreateComboBoxes(Panel panel, int count)
        {
            int spacing = 10;      // space between ComboBoxes
            int startX = 0;        // left margin
            int startY = 5;        // top margin
            int boxWidth = 80;
            int boxHeight = 28;

            for (int i = 0; i < count; i++)
            {
                int x = startX + i * (boxWidth + spacing);

                string labelText;
                if (i == count - 2)
                {
                    labelText = $"Multiplier";
                }
                else if( i == count - 1)
                {
                    labelText = "Tolerance";
                }
                else
                {   
                    labelText = "Band " + (i + 1);
                }

                Label label = new Label()
                {
                    Text = labelText,
                    Location = new Point(x,startY),
                    Size = new Size(boxWidth, 15),
                };

                ComboBox comboBox = new ComboBox()
                {
                    Name = $"Band{i+1}",
                    Size = new Size(boxWidth, boxHeight),
                    Location = new Point(x, startY + 15),
                    DrawMode = DrawMode.OwnerDrawFixed,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                };
                comboBox.Items.AddRange(BandColors.ToArray());
                comboBox.DrawItem += Combo_DrawItem;

                panel.Controls.Add(label);
                panel.Controls.Add(comboBox);

                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                comboBox.Tag = i;
            }
        }

        private static void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Trace.WriteLine($"ComboBox {((ComboBox)sender).Name} selected index: {((ComboBox)sender).SelectedIndex}");
        }
    }
}
