using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        double USD;
        double KZT_Steam;
        double KZT_Qiwi;
        double RUB;
        double RUB_Output;
        readonly CultureInfo culture = CultureInfo.InvariantCulture;
        readonly string TextUSD = "Доллар - ";
        readonly string TextKZT = "Тенге - ";

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGet.Text = "Обновить";
            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxUSD.Image = Properties.Resources.wait_c;
            string[] RawCurrency = Program.GetCurrency();
            double[] Currency = Program.CalculateCurrency(RawCurrency);
            if (Currency[0] == 0 && Currency[1] == 0 && Currency[2] == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else if (Currency[0] == 0 || Currency[1] == 0 || Currency[2] == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.warn_c;
            }
            else
            {
                USD = Currency[0];
                LabelUSD.Text = TextUSD + Math.Round(USD, 4).ToString(culture);
                KZT_Steam = Currency[1];
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }

            double Qiwi = Program.GetQiwi();
            if (Qiwi == 0)
            {
                PictureBoxKZT.Image = Properties.Resources.no_c;
            }
            else
            {
                KZT_Qiwi = Qiwi;
                LabelKZT.Text = TextKZT + Math.Round(KZT_Qiwi, 4).ToString(culture);
                PictureBoxKZT.Image = Properties.Resources.yes_c;
            }
            TextBoxInput.Enabled = true;
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInput.Text;
            if (text.StartsWith('0'))
            {
                text = text.Substring(1);
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (text[i] != '0')
                    {
                        break;
                    }
                }
            }
            TextBoxInput.Text = text;

            labelRUB1.Text = Program.ChangeEnd(text);

            if (text.Length == 0)
            {
                RUB = 0;
            }
            else
            {
                RUB = Convert.ToDouble(text, culture);
            }

            RUB_Output = Program.CalculateFunds(RUB, KZT_Qiwi, KZT_Steam, USD);
            TextBoxOutput.Text = Convert.ToString(Math.Round(RUB_Output, 2), culture);
            double delta = RUB - RUB_Output;
            TextBoxLost.Text = Convert.ToString(Math.Round(delta, 2), culture);
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            labelRUB2.Text = Program.ChangeEnd(TextBoxOutput.Text);
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
            labelRUB2.Text = Program.ChangeEnd(TextBoxLost.Text);

            double percent = 100 - (100 / (RUB / RUB_Output));
            labelPercent.Visible = true;
            labelPercent.Text = "(" + Convert.ToString(Math.Round(percent, 2), culture) + "%)";
        }
    }
}