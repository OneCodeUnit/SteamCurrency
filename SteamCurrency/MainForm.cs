using SteamCurrencyLib;
using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float USD_Steam; //Рублей за доллар (Steam)
        float KZT_Qiwi; //Рублей за тенге (Qiwi)
        float USD_Qiwi; //Тенге за доллар (Qiwi)
        float RUB_Input; //Рублей до конвертации
        float RUB_Output; //Рублей после конвертации

        public MainForm()
        {
            InitializeComponent();
            USD_Steam = Properties.Settings.Default.USD_Steam;
            KZT_Qiwi = Properties.Settings.Default.KZT_Qiwi;
            USD_Qiwi = Properties.Settings.Default.USD_Qiwi;

            if (USD_Steam != 0 && USD_Qiwi != 0 && KZT_Qiwi != 0)
            {
                LabelUSD.Text = "Доллар - " + Math.Round(USD_Steam, 4).ToString(CultureInfo.InvariantCulture);
                LabelKZT.Text = "Тенге - " + Math.Round(KZT_Qiwi, 4).ToString(CultureInfo.InvariantCulture);
                LabelKZT_USD.Text = "Тенге за доллар - " + Math.Round(USD_Qiwi, 2).ToString(CultureInfo.InvariantCulture);

                PictureBoxUSD.Image = Properties.Resources.warn_c;
                PictureBoxKZT.Image = Properties.Resources.warn_c;
                PictureBoxKZTUSD.Image = Properties.Resources.warn_c;

                TextBoxInput.Enabled = true;
            }

            ButtonGetRates.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGetRates.Text = "Обновление";
            ButtonGetRates.Enabled = false;
            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxUSD.Image = Properties.Resources.wait_c;
            PictureBoxKZTUSD.Image = Properties.Resources.wait_c;
            TextBoxInput.Enabled = false;

            // 1 - доллары, 5 - рубли (https://partner.steamgames.com/doc/store/pricing/currencies)
            SteamJson jsonUSD = SteamHttpClient.GetSteamJson(1);
            SteamJson jsonRUB = SteamHttpClient.GetSteamJson(5);

            string rawUSD = jsonUSD.lowest_price[1..^4];
            string rawRUB = jsonRUB.lowest_price[0..^5];

            if (jsonUSD.success == false || jsonRUB.success == false)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                float steamUSD = Convert.ToSingle(rawUSD, new CultureInfo("en-US"));
                float steamRUB = Convert.ToSingle(rawRUB, new CultureInfo("ru-RU"));
                USD_Steam = steamRUB / steamUSD;

                Properties.Settings.Default["USD_Steam"] = USD_Steam;
                LabelUSD.Text = "Доллар - " + Math.Round(USD_Steam, 4).ToString(CultureInfo.InvariantCulture);
                PictureBoxUSD.Image = Properties.Resources.yes_c;
                TextBoxInput.Enabled = true;
            }

            //398 - тенге, 643 - рубли, 840 - доллары, 978 - евро, 156 - юани
            QiwiJson jsonQiwi = SteamHttpClient.GetQiwiJson();

            PictureBoxKZT.Image = Properties.Resources.no_c;
            PictureBoxKZTUSD.Image = Properties.Resources.no_c;
            foreach (var rateIter in jsonQiwi.result)
            {
                if (rateIter.from == "643" && rateIter.to == "398")
                {
                    KZT_Qiwi = rateIter.rate;

                    Properties.Settings.Default["KZT_Qiwi"] = KZT_Qiwi;
                    LabelKZT.Text = "Тенге - " + Math.Round(KZT_Qiwi, 4).ToString(CultureInfo.InvariantCulture);
                    PictureBoxKZT.Image = Properties.Resources.yes_c;
                    TextBoxInput.Enabled = true;
                }
                if (rateIter.from == "398" && rateIter.to == "840")
                {
                    USD_Qiwi = rateIter.rate;

                    Properties.Settings.Default["USD_Qiwi"] = USD_Qiwi;
                    LabelKZT_USD.Text = "Тенге за доллар - " + Math.Round(USD_Qiwi, 2).ToString(CultureInfo.InvariantCulture);
                    PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
                    TextBoxInput.Enabled = true;
                }
            }

            Properties.Settings.Default.Save();
            ButtonGetRates.Enabled = true;
            ButtonGetRates.Text = "Обновить";
            TextBoxInput.Focus();
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInput.Text;
            RUB_Output = 0;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                LabelInputKZT.Visible = false;
                LabelRUBLostPercent.Visible = false;
                TextBoxOutput.Text = "0";
                TextBoxLost.Text = "0";
                return;
            }
            LabelRUBInput.Text = Program.ChangeEnding(text);

            RUB_Input = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);

            //Рубли -> Тенге -> Доллары -> Рубли
            RUB_Output = ((RUB_Input / KZT_Qiwi) / (USD_Qiwi + 0.0415f * USD_Qiwi)) * USD_Steam;
            TextBoxOutput.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
            float delta = RUB_Input - RUB_Output;
            TextBoxLost.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
            LabelInputKZT.Visible = true;
            LabelInputKZT.Text = $"(это {RUB_Input / KZT_Qiwi:0.##}₸)";
            }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            LabelRUBOutput.Text = Program.ChangeEnding(TextBoxOutput.Text);
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
            if (RUB_Output != 0)
            {
                LabelRUBLost.Text = Program.ChangeEnding(TextBoxLost.Text);

                float percent = 100 - (100 / (RUB_Input / RUB_Output));
                LabelRUBLostPercent.Visible = true;
                LabelRUBLostPercent.Text = $"({percent:0.##}%)";
            }
        }
    }
}