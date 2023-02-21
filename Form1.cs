using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        double USD; //Рублей за доллар (Steam)
        double KZT_Qiwi; //Рублей за тенге (Qiwi)
        double USD_Qiwi; //Тенге за доллар (Qiwi)
        double RUB; //Рублей до конвертации
        double RUB_Output; //Рублей после конвертации
        readonly CultureInfo culture = CultureInfo.InvariantCulture;
        readonly string TextUSD = "Доллар - ";
        readonly string TextKZT = "Тенге - ";
        readonly string TextKZTUSD = "Тенге за доллар - ";

        public MainForm()
        {
            InitializeComponent();
            ButtonGet.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGet.Text = "Обновление";
            ButtonGet.Enabled = false;
            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxUSD.Image = Properties.Resources.wait_c;
            PictureBoxKZTUSD.Image = Properties.Resources.wait_c;
            string[] RawCurrency;
            double Currency;

            RawCurrency = Program.GetCurrencySteam();
            Currency = Program.CalculateCurrency(RawCurrency);
            if (Currency == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                USD = Currency;
                LabelUSD.Text = TextUSD + Math.Round(USD, 4).ToString(culture);
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }

            double[] Qiwi = Program.GetCurrencyQiwi();
            if (Qiwi[0] == 0)
            {
                PictureBoxKZT.Image = Properties.Resources.no_c;
            }
            else
            {
                KZT_Qiwi = Qiwi[0];
                LabelKZT.Text = TextKZT + Math.Round(KZT_Qiwi, 4).ToString(culture);
                PictureBoxKZT.Image = Properties.Resources.yes_c;
            }
            if (Qiwi[1] == 0)
            {
                PictureBoxKZTUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                USD_Qiwi = Qiwi[1];
                LabelKZTUSD.Text = TextKZTUSD + Math.Round(USD_Qiwi, 2).ToString(culture);
                PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
            }
            TextBoxInput.Enabled = true;
            ButtonGet.Enabled = true;
            ButtonGet.Text = "Обновить";
            TextBoxInput.Focus();
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

            RUB_Output = Program.CalculateFunds(RUB, KZT_Qiwi, USD_Qiwi, USD);
            TextBoxOutput.Text = Convert.ToString(Math.Round(RUB_Output, 2), culture);
            double delta = RUB - RUB_Output;
            TextBoxLost.Text = Convert.ToString(Math.Round(delta, 2), culture);
            LabelInput.Visible = true;
            LabelInput.Text = "(" + Convert.ToString(Math.Round(RUB / KZT_Qiwi, 2), culture) + "₸)";
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            labelRUB2.Text = Program.ChangeEnd(TextBoxOutput.Text);
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
            labelRUB3.Text = Program.ChangeEnd(TextBoxLost.Text);

            double percent = 100 - (100 / (RUB / RUB_Output));
            labelPercent.Visible = true;
            labelPercent.Text = "(" + Convert.ToString(Math.Round(percent, 2), culture) + "%)";
        }
    }
}