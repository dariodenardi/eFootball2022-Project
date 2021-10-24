using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EvoTool.Utils
{
    public class UtilGUI
    {
        public static void ChangeColorLabel(Label label)
        {
            try
            {
                if (int.Parse(label.Text) < 75)
                {
                    label.ForeColor = Color.Black;
                }
                if (int.Parse(label.Text) >= 75 & int.Parse(label.Text) < 80)
                {
                    label.ForeColor = Color.GreenYellow;
                }
                else if (int.Parse(label.Text) >= 80 & int.Parse(label.Text) < 90)
                {
                    label.ForeColor = Color.Yellow;
                }
                else if (int.Parse(label.Text) >= 90 & int.Parse(label.Text) < 95)
                {
                    label.ForeColor = Color.Orange;
                }
                else if (int.Parse(label.Text) >= 95)
                {
                    label.ForeColor = Color.Red;
                }
            }
            catch
            {
                label.ForeColor = Color.Black;
            }
        }

        public static void ChangeBackColorLabel(Label label)
        {
            try
            {
                if (int.Parse(label.Text) < 75)
                {
                    label.BackColor = Color.LightGray;
                }
                if (int.Parse(label.Text) >= 75 & int.Parse(label.Text) < 80)
                {
                    label.BackColor = Color.GreenYellow;
                }
                else if (int.Parse(label.Text) >= 80 & int.Parse(label.Text) < 90)
                {
                    label.BackColor = Color.Yellow;
                }
                else if (int.Parse(label.Text) >= 90 & int.Parse(label.Text) < 95)
                {
                    label.BackColor = Color.Orange;
                }
                else if (int.Parse(label.Text) >= 95)
                {
                    label.BackColor = Color.Red;
                }
            }
            catch
            {
                label.BackColor = Color.LightGray;
            }
        }

        public static void ChangeBackColorTextBox(TextBox textBox)
        {
            try
            {
                if (int.Parse(textBox.Text) < 75)
                {
                    textBox.BackColor = Color.White;
                }
                else if (int.Parse(textBox.Text) >= 75 & int.Parse(textBox.Text) < 80)
                {
                    textBox.BackColor = Color.GreenYellow;
                }
                else if (int.Parse(textBox.Text) >= 80 & int.Parse(textBox.Text) < 90)
                {
                    textBox.BackColor = Color.Yellow;
                }
                else if (int.Parse(textBox.Text) >= 90 & int.Parse(textBox.Text) < 95)
                {
                    textBox.BackColor = Color.Orange;
                }
                else if (int.Parse(textBox.Text) >= 95)
                {
                    textBox.BackColor = Color.Red;
                }
            }
            catch
            {
                textBox.BackColor = Color.White;
            }
        }

    }
}
