using SteamCurrencyLib;
using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        double USD_Steam; //Рублей за доллар (Steam)
        double KZT_Qiwi; //Рублей за тенге (Qiwi)
        double USD_Qiwi; //Тенге за доллар (Qiwi)
        double RUB_Input; //Рублей до конвертации
        double RUB_Output; //Рублей после конвертации
        readonly CultureInfo culture = CultureInfo.InvariantCulture;

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
            TextBoxInput.Enabled = false;

            SteamHttpClient client = new();
            //1 - доллары, 5 - рубли, 37 - тенге
            SteamJson jsonUSD = client.GetSteamJson(1);
            SteamJson jsonRUB = client.GetSteamJson(5);

            string RawUSD = jsonUSD.lowest_price[1..^4];
            string RawRUB = jsonRUB.lowest_price[0..^5];

            if (jsonUSD.success == false || jsonRUB.success == false)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                CultureInfo cultureUSD = new("en-US");
                double SteamUSD = Convert.ToDouble(RawUSD, cultureUSD);
                CultureInfo cultureRUB = new("ru-RU");
                double SteamRUB = Convert.ToDouble(RawRUB, cultureRUB);
                USD_Steam = SteamRUB / SteamUSD;
                LabelUSD.Text = "Доллар - " + Math.Round(USD_Steam, 4).ToString(culture);
                PictureBoxUSD.Image = Properties.Resources.yes_c;
                TextBoxInput.Enabled = true;
            }

            //398 - тенге, 643 - рубли, 840 - доллары, 978 - евро, 156 - юани
            QiwiJsonRoot Qiwi = client.GetQiwiJson();

            PictureBoxKZT.Image = Properties.Resources.no_c;
            PictureBoxKZTUSD.Image = Properties.Resources.no_c;
            for (int i = 0; i < Qiwi.result.Count; i++)
            {
                if (Qiwi.result[i].from == "643" && Qiwi.result[i].to == "398")
                {
                    KZT_Qiwi = Qiwi.result[i].rate;
                    LabelKZT.Text = "Тенге - " + Math.Round(KZT_Qiwi, 4).ToString(culture);
                    PictureBoxKZT.Image = Properties.Resources.yes_c;
                    TextBoxInput.Enabled = true;
                }
                if (Qiwi.result[i].from == "398" && Qiwi.result[i].to == "840")
                {
                    USD_Qiwi = Qiwi.result[i].rate;
                    LabelKZT_USD.Text = "Тенге за доллар - " + Math.Round(USD_Qiwi, 2).ToString(culture);
                    PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
                    TextBoxInput.Enabled = true;
                }
            }

            ButtonGet.Enabled = true;
            ButtonGet.Text = "Обновить";
            TextBoxInput.Focus();
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInput.Text;
            if (text.StartsWith('0'))
            {
                for (int i = 1; i < text.Length - 1; i++)
                {
                    if (text[i] != '0')
                    {
                        text = text[i..];
                        break;
                    }
                }
            }
            TextBoxInput.Text = text;
            labelRUB1.Text = Program.ChangeEnding(text);

            if (text.Length == 0)
            {
                RUB_Input = 0;
            }

            else
            {
                RUB_Input = Convert.ToDouble(text, culture);
            }

            //Рубли -> Тенге -> Доллары -> Рубли
            RUB_Output = ((RUB_Input / KZT_Qiwi) / (USD_Qiwi + 0.0415 * USD_Qiwi)) * USD_Steam;
            TextBoxOutput.Text = Convert.ToString(Math.Round(RUB_Output, 2), culture);
            double delta = RUB_Input - RUB_Output;
            TextBoxLost.Text = Convert.ToString(Math.Round(delta, 2), culture);
            LabelInput.Visible = true;
            LabelInput.Text = "(это " + Convert.ToString(Math.Round(RUB_Input / KZT_Qiwi, 2), culture) + "₸)";
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            labelRUB2.Text = Program.ChangeEnding(TextBoxOutput.Text);
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
            labelRUB3.Text = Program.ChangeEnding(TextBoxLost.Text);

            double percent = 100 - (100 / (RUB_Input / RUB_Output));
            labelPercent.Visible = true;
            labelPercent.Text = "(" + Convert.ToString(Math.Round(percent, 2), culture) + "%)";
        }
    }
}