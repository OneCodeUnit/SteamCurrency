using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float RUB_USD_Steam; // Покупка рублей за доллары (Steam)
        float KZT_USD_Steam; // Покупка тенге за доллары (Steam)

        float RUB_USD_Web; // Рублей за доллар (Webmoney)
        float RUB_USD_Web_Real; // Рублей за доллар (Webmoney PtP)

        readonly float WebPercent = 0.1593f;

        public MainForm()
        {
            InitializeComponent();

            RUB_USD_Steam = Properties.Settings.Default.RUB_USD_Steam;
            KZT_USD_Steam = Properties.Settings.Default.KZT_USD_Steam;
            RUB_USD_Web = Properties.Settings.Default.RUB_USD_Web;
            RUB_USD_Web_Real = Properties.Settings.Default.RUB_USD_Web_Real;

            if (RUB_USD_Steam > 0 && KZT_USD_Steam > 0 && RUB_USD_Web > 0)
            {
                if (RUB_USD_Web_Real > 0)
                    textBoxUsdWeb.Text = RUB_USD_Web_Real.ToString(CultureInfo.InvariantCulture);
                else
                    textBoxUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);

                pictureBoxWeb.Image = Properties.Resources.warn_c;
                pictureBoxSteam.Image = Properties.Resources.warn_c;

                labelCurrencyWeb.Text = "Курс USD = " + Math.Round(RUB_USD_Web, 2);
                labelCurrencySteam.Text= "Курс USD = " + Math.Round(RUB_USD_Steam, 2);
                labelCurrencySteamKzt.Text = "Курс KZT  = " + Math.Round(KZT_USD_Steam, 2);

                ButtonGetRates.Text = "Обновить";
                textBoxInputWeb.Enabled = true;
                textBoxUsdWeb.Enabled = true;
            }
            ButtonGetRates.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGetRates.Text = "Обновление";
            textBoxInputWeb.Enabled = true;
            textBoxUsdWeb.Enabled = true;

            int ok = 0;

            // Steam
            pictureBoxSteam.Image = Properties.Resources.wait_c;
            // Покупка рублей за доллары (Steam)
            float steam1 = SteamJson.GetRate(1, 5);
            // Покупка тенге за доллары (Steam)
            float steam2 = SteamJson.GetRate(1, 37);
            if (steam1 == 0 || steam2 == 0)
            {
                pictureBoxSteam.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Steam = steam1;
                KZT_USD_Steam = steam2;
                Properties.Settings.Default["RUB_USD_Steam"] = RUB_USD_Steam;
                Properties.Settings.Default["KZT_USD_Steam"] = KZT_USD_Steam;
                labelCurrencySteam.Text = "Курс USD = " + Math.Round(RUB_USD_Steam, 2);
                labelCurrencySteamKzt.Text = "Курс KZT = " + Math.Round(KZT_USD_Steam, 2);
                pictureBoxSteam.Image = Properties.Resources.yes_c;
            }

            // Webmoney
            pictureBoxWeb.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу вебмани
            WMJson webmoney = WMJson.GetData();
            float usdWeb = webmoney.GetRate();
            if (usdWeb == 0 || usdWeb == -1)
            {
                pictureBoxWeb.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Web = usdWeb;
                Properties.Settings.Default["RUB_USD_Web"] = RUB_USD_Web;
                labelCurrencyWeb.Text = "Курс USD = " + Math.Round(RUB_USD_Web, 2);
                pictureBoxWeb.Image = Properties.Resources.yes_c;
            }

            if (ok == 2)
            {
                Properties.Settings.Default.Save();
                ButtonGetRates.Enabled = true;
                ButtonGetRates.Text = "Обновить";
                textBoxInputWeb.Enabled = true;
                textBoxUsdWeb.Enabled = true;
            }

            ButtonGetRates.Text = "Обновить";
        }

        private void TextBoxInputWeb_TextChanged(object sender, EventArgs e)
        {
            // Подготовка входных данных
            string text = textBoxInputWeb.Text;
            if (text.Length < 2)
                return;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                textBoxConvertWebUsd.Text = "0";
                textBoxOutputWebRU.Text = "0";
                textBoxOutputWebKZ.Text = "0";
                textBoxLostWebRU.Text = "0";
                return;
            }
            text = text.Replace(',', '.');
            float input = Convert.ToSingle(text, CultureInfo.InvariantCulture);
            float outputUsd;
            // Рубли в доллары
            outputUsd = (input / RUB_USD_Web_Real) - (input / RUB_USD_Web_Real * WebPercent);
            textBoxConvertWebUsd.Text = Math.Round(outputUsd, 2).ToString(CultureInfo.InvariantCulture);
            // В итоге отправляется сумма в долларах
            float output, percent;
            // KZ аккаунт доллары в тенге
            output = outputUsd * KZT_USD_Steam;
            textBoxOutputWebKZ.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            // RU аккаунт доллары в рубли
            output = outputUsd * RUB_USD_Steam;
            textBoxOutputWebRU.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            textBoxLostWebRU.Text = Math.Round(input - output, 2).ToString(CultureInfo.InvariantCulture);
            percent = (input / output - 1) * 100;
            labelLostWebRU.Text = "₽ (" + Math.Round(percent, 2).ToString(CultureInfo.InvariantCulture) + "%)";
        }

        private void TextBoxUsdWeb_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxUsdWeb.Text;
            if (text.Length < 2)
                return;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                return;
            }
            text = text.Replace(',', '.');

            RUB_USD_Web_Real = Convert.ToSingle(text, CultureInfo.InvariantCulture);
            Properties.Settings.Default["RUB_USD_Web_Real"] = RUB_USD_Web_Real;
            Properties.Settings.Default.Save();

            string temp = textBoxInputWeb.Text;
            textBoxInputWeb.Text = string.Empty;
            textBoxInputWeb.Text = temp;
        }
    }
}