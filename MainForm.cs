using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float USD_KZT_Qiwi; // Покупка тенге за доллары (Qiwi)
        float RUB_KZT_Qiwi; // Покупка тенге за рубли (Qiwi)
        float RUB_USD_Qiwi; // Покупка долларов за рубли (Qiwi)

        float RUB_USD_Steam; // Покупка рублей за доллары (Steam)
        float KZT_USD_Steam; // Покупка тенге за доллары (Steam)

        float RUB_USD_Web; // Рублей за доллар (Webmoney)
        float RUB_USD_Web_Real; // Рублей за доллар (Webmoney PtP)

        readonly float QiwiPercentUSD = 0.85024f;
        readonly float QiwiPercentKZT = 0.94091f;
        readonly float QiwiPercent = 1.07022f;
        readonly float WebPercent = 1.16f;

        public MainForm()
        {
            InitializeComponent();
            //ToolTip toolTip = new();
            //toolTip.SetToolTip(CheckBoxLine, "Символы \"-\" и \"_\"");

            USD_KZT_Qiwi = Properties.Settings.Default.USD_KZT_Qiwi;
            RUB_KZT_Qiwi = Properties.Settings.Default.RUB_KZT_Qiwi;
            RUB_USD_Qiwi = Properties.Settings.Default.RUB_USD_Qiwi;
            RUB_USD_Steam = Properties.Settings.Default.RUB_USD_Steam;
            KZT_USD_Steam = Properties.Settings.Default.KZT_USD_Steam;
            RUB_USD_Web = Properties.Settings.Default.RUB_USD_Web;
            RUB_USD_Web_Real = Properties.Settings.Default.RUB_USD_Web_Real;

            if (USD_KZT_Qiwi > 0 && RUB_KZT_Qiwi > 0 && RUB_USD_Qiwi > 0 && RUB_USD_Steam > 0 && KZT_USD_Steam > 0 && RUB_USD_Web > 0)
            {
                if (RUB_USD_Web_Real > 0)
                    textBoxUsdWeb.Text = RUB_USD_Web_Real.ToString(CultureInfo.InvariantCulture);
                else
                    textBoxUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);

                pictureBoxQiwi.Image = Properties.Resources.warn_c;
                pictureBoxWeb.Image = Properties.Resources.warn_c;
                pictureBoxSteam.Image = Properties.Resources.warn_c;

                ButtonGetRates.Text = "Обновить";
                textBoxInputQiwi1.Enabled = true;
                textBoxInputQiwi2.Enabled = true;
                textBoxInputWeb.Enabled = true;
                textBoxUsdWeb.Enabled = true;
            }
            ButtonGetRates.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGetRates.Text = "Обновление";
            textBoxInputQiwi1.Enabled = true;
            textBoxInputQiwi2.Enabled = true;
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
                pictureBoxSteam.Image = Properties.Resources.yes_c;
            }

            // Qiwi
            pictureBoxQiwi.Image = Properties.Resources.wait_c;
            QiwiJson qiwi = QiwiJson.GetData();
            // Покупка тенге за доллары (Qiwi)
            float qiwi1 = qiwi.GetRate(("840", "398"));
            // Покупка тенге за рубли (Qiwi)
            float qiwi2 = qiwi.GetRate(("398", "643"));
            // Покупка долларов за рубли (Qiwi)
            float qiwi3 = qiwi.GetRate(("643", "840"));

            if (qiwi1 == 0 || qiwi2 == 0 || qiwi3 == 0)
            {
                pictureBoxQiwi.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                USD_KZT_Qiwi = qiwi1;
                RUB_KZT_Qiwi = qiwi2;
                RUB_USD_Qiwi = qiwi3;
                Properties.Settings.Default["USD_KZT_Qiwi"] = USD_KZT_Qiwi;
                Properties.Settings.Default["RUB_KZT_Qiwi"] = RUB_KZT_Qiwi;
                Properties.Settings.Default["RUB_USD_Qiwi"] = RUB_USD_Qiwi;
                pictureBoxQiwi.Image = Properties.Resources.yes_c;
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
                pictureBoxWeb.Image = Properties.Resources.yes_c;
            }

            if (ok == 3)
            {
                Properties.Settings.Default.Save();
                ButtonGetRates.Enabled = true;
                ButtonGetRates.Text = "Обновить";
                textBoxInputQiwi1.Enabled = true;
                textBoxInputQiwi2.Enabled = true;
                textBoxInputWeb.Enabled = true;
                textBoxUsdWeb.Enabled = true;
                textBoxInputQiwi1.Focus();
            }

            ButtonGetRates.Text = "Обновить";
        }

        private void TextBoxInputQiwi1_TextChanged(object sender, EventArgs e)
        {
            // Подготовка входных данных
            string text = textBoxInputQiwi1.Text;
            if (text.Length < 2)
                return;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                textBoxConvertQiwi1Kzt.Text = "0";
                textBoxConvertQiwi1Usd.Text = "0";
                textBoxOutputQiwi1RU.Text = "0";
                textBoxOutputQiwi1KZ.Text = "0";
                textBoxLostQiwi1RU.Text = "0";
                return;
            }
            text = text.Replace(',', '.');
            float input = Convert.ToSingle(text, CultureInfo.InvariantCulture);
            float outputUsd, outputKzt;
            // Рубли в тенге
            outputKzt = input * RUB_KZT_Qiwi * QiwiPercentKZT;
            textBoxConvertQiwi1Kzt.Text = Math.Round(outputKzt, 2).ToString(CultureInfo.InvariantCulture);
            // Тенге в доллары
            outputUsd = outputKzt * USD_KZT_Qiwi * QiwiPercentUSD;
            textBoxConvertQiwi1Usd.Text = Math.Round(outputUsd, 2).ToString(CultureInfo.InvariantCulture);
            // В итоге отправляется сумма в долларах
            float output, percent;
            // KZ аккаунт доллары в тенге
            output = outputUsd * KZT_USD_Steam;
            textBoxOutputQiwi1KZ.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            // RU аккаунт доллары в рубли
            output = outputUsd * RUB_USD_Steam;
            textBoxOutputQiwi1RU.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            textBoxLostQiwi1RU.Text = Math.Round(input - output, 2).ToString(CultureInfo.InvariantCulture);
            percent = (input / output - 1) * 100;
            labelLostQiwi1RU.Text = "₽ (" + Math.Round(percent, 2).ToString(CultureInfo.InvariantCulture) + "%)";
        }

        private void TextBoxInputQiwi2_TextChanged(object sender, EventArgs e)
        {
            // Подготовка входных данных
            string text = textBoxInputQiwi2.Text;
            if (text.Length < 2)
                return;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                textBoxConvertQiwi2Usd.Text = "0";
                textBoxOutputQiwi2RU.Text = "0";
                textBoxOutputQiwi2KZ.Text = "0";
                textBoxLostQiwi2RU.Text = "0";
                return;
            }
            text = text.Replace(',', '.');
            float input = Convert.ToSingle(text, CultureInfo.InvariantCulture);
            float outputUsd;
            // Рубли в доллары
            outputUsd = input / (RUB_USD_Qiwi * QiwiPercent);
            textBoxConvertQiwi2Usd.Text = Math.Round(outputUsd, 2).ToString(CultureInfo.InvariantCulture);
            // В итоге отправляется сумма в долларах
            float output, percent;
            // KZ аккаунт доллары в тенге
            output = outputUsd * KZT_USD_Steam;
            textBoxOutputQiwi2KZ.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            // RU аккаунт доллары в рубли
            output = outputUsd * RUB_USD_Steam;
            textBoxOutputQiwi2RU.Text = Math.Round(output, 2).ToString(CultureInfo.InvariantCulture);
            textBoxLostQiwi2RU.Text = Math.Round(input - output, 2).ToString(CultureInfo.InvariantCulture);
            percent = (input / output - 1) * 100;
            labelLostQiwi2RU.Text = "₽ (" + Math.Round(percent, 2).ToString(CultureInfo.InvariantCulture) + "%)";
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
            outputUsd = input / (RUB_USD_Web_Real * WebPercent);
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