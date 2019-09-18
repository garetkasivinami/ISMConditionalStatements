using System;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using static System.Math;

namespace WinFormTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo ci = (CultureInfo.InvariantCulture.Clone() as CultureInfo);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        private void OnCalculate_Click(object sender, EventArgs e)
        {
            double x, y, z, r;
            try
            {
                if (double.TryParse(textBoxX.Text, out x))
                {
                    if (double.TryParse(textBoxY.Text, out y))
                    {
                        if (double.TryParse(textBoxZ.Text, out z))
                        {
                            r = (2 * Cos(Pow(x, 2)) - 0.5) / (0.5 + Sin(Pow(y, 2 - z)))
                                + (Pow(z, 2)) / (7 - z / 3.0); // використовуємо статичні функції класа Math
                            if (double.IsInfinity(r) || double.IsNaN(r))
                            {
                                MessageBox.Show("Щось пішло не так, оберіть інші числа!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxR.Text = "error!";
                                return;
                            }
                            textBoxR.Text = r.ToString("F2");
                        }
                        else
                        {
                            MessageBox.Show("Помилка перетворення числа z", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show("Помилка перетворення числа y", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Помилка перетворення числа x", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception Ex)
            {
                MessageBox.Show("Критична помилка програми! Повідомте про неї творцю програми."+ "\n\n" + Ex, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
