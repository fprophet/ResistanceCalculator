using ResistanceCalculator.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceCalculator.Helpers
{
    public static class ComboBoxHelper
    {
        public static void SetupColorCombo(ComboBox combo)
        {
            combo.DrawMode = DrawMode.OwnerDrawFixed;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Items.AddRange(new object[]
            {
                new ColorData{ColorNumber = 0, Color = Color.Red },
                new ColorData{ColorNumber = 1, Color = Color.Green },
                new ColorData{ColorNumber = 2, Color = Color.Blue },
                new ColorData{ColorNumber = 3, Color = Color.Yellow },
                new ColorData{ColorNumber = 4, Color = Color.Orange },
                new ColorData{ColorNumber = 5, Color = Color.Purple },
                new ColorData{ColorNumber = 6, Color = Color.Gray },
                new ColorData{ColorNumber = 7, Color = Color.Black },
                new ColorData{ColorNumber = 8, Color = Color.White }
            });
            combo.DrawItem += Combo_DrawItem;
        }


        private static void Combo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = (ComboBox)sender;
            ColorData colorData = (ColorData)combo.Items[e.Index];
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

        private static void CreateComboBoxes(Panel panel, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Name = $"comboBox{i}";
                Helpers.ComboBoxHelper.SetupColorCombo(comboBox);
                panel.Controls.Add(comboBox);
            }
        }
    }
}
