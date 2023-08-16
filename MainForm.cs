using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float RUB_USD_Steam; // Рублей за доллар (Steam)
        float KZT_USD_Steam; // Тенге за доллар (Steam)
        float KZT_USD_Qiwi; // Тенге за доллар (Qiwi)
        float RUB_KZT_Qiwi; // Рублей за тенге (Qiwi)
        float RUB_USD_Qiwi; // Рублей за доллар (Qiwi)
        float UZS_USD_Qiwi; // Сум за доллар (Qiwi)
        float RUB_UZS_Qiwi; // Рублей за сум (Qiwi)
        float RUB_USD_Web; // Рублей за доллар (Webmoney)
        float RUB_USD_Web_Real; // Рублей за доллар (Webmoney PtP)
        float RUB_Input; // Рублей до конвертации
        float RUB_Output; // Рублей после конвертации

        bool Reverse; // Считать по получаемой (true) или вводимой (false). По умолчанию false

        public MainForm()
        {
            InitializeComponent();
            RUB_USD_Steam = Properties.Settings.Default.RUB_USD_Steam;
            KZT_USD_Steam = Properties.Settings.Default.KZT_USD_Steam;
            KZT_USD_Qiwi = Properties.Settings.Default.KZT_USD_Qiwi;
            RUB_KZT_Qiwi = Properties.Settings.Default.RUB_KZT_Qiwi;
            RUB_USD_Qiwi = Properties.Settings.Default.RUB_USD_Qiwi;
            UZS_USD_Qiwi = Properties.Settings.Default.UZS_USD_Qiwi;
            RUB_UZS_Qiwi = Properties.Settings.Default.RUB_UZS_Qiwi;
            RUB_USD_Web = Properties.Settings.Default.RUB_USD_Web;
            RUB_USD_Web_Real = Properties.Settings.Default.RUB_USD_Web_Real;

            if (RUB_USD_Steam != 0 && KZT_USD_Steam != 0 && KZT_USD_Qiwi != 0 && RUB_USD_Qiwi != 0 && RUB_USD_Web != 0 && RUB_KZT_Qiwi != 0 && UZS_USD_Qiwi != 0 && RUB_UZS_Qiwi != 0)
            {
                LabelUsdSteam.Text = $"Доллар - {Math.Round(RUB_USD_Steam, 2)}, тенге - {Math.Round(KZT_USD_Steam, 2)}";
                LabelUsdQiwi.Text = $"Доллар - {Math.Round(RUB_USD_Qiwi, 2)}, тенге - {Math.Round(KZT_USD_Qiwi, 2)}";
                LabelUsdWeb.Text = $"Доллар - {Math.Round(RUB_USD_Web, 2)}";

                if (RUB_USD_Web_Real > 0)
                    TextBoxInputUsdWeb.Text = RUB_USD_Web_Real.ToString(CultureInfo.InvariantCulture);
                else
                    TextBoxInputUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);

                PictureBoxSteam.Image = Properties.Resources.warn_c;
                PictureBoxQiwi.Image = Properties.Resources.warn_c;
                PictureBoxWeb.Image = Properties.Resources.warn_c;

                ButtonGetRates.Text = "Обновить";
                TextBoxInput1.Enabled = true;
                TextBoxInput2.Enabled = true;
                TextBoxInput3.Enabled = true;
                CalcPercent();
            }

            ButtonGetRates.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGetRates.Text = "Обновление";
            ButtonGetRates.Enabled = false;
            ButtonReverse.Enabled = false;
            TextBoxInput1.Enabled = false;
            TextBoxInput2.Enabled = false;
            TextBoxInput3.Enabled = false;
            TextBoxOutput1.Enabled = false;
            TextBoxOutput2.Enabled = false;
            TextBoxOutput3.Enabled = false;
            TextBoxInputUsdWeb.Enabled = false;

            int ok = 0;

            // Steam
            PictureBoxSteam.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу стима
            float usdSteam = SteamJson.GetRate(1, 5);
            // Тенге за доллар по курсу стима
            float kztSteam = SteamJson.GetRate(1, 37);
            if (usdSteam == 0 || kztSteam == 0)
            {
                PictureBoxSteam.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Steam = usdSteam;
                KZT_USD_Steam = kztSteam;
                Properties.Settings.Default["RUB_USD_Steam"] = RUB_USD_Steam;
                Properties.Settings.Default["KZT_USD_Steam"] = KZT_USD_Steam;
                LabelUsdSteam.Text = $"Доллар - {Math.Round(RUB_USD_Steam, 2)}, тенге - {Math.Round(KZT_USD_Steam, 2)}";
                PictureBoxSteam.Image = Properties.Resources.yes_c;
            }

            // Qiwi
            PictureBoxQiwi.Image = Properties.Resources.wait_c;
            QiwiJson qiwi = QiwiJson.GetData();
            // Рублей за доллар по курсу qiwi
            float kztQiwi = qiwi.GetRate(("643", "840"));
            // Рублей за тенге по курсу qiwi
            float rubQiwi = qiwi.GetRate(("643", "398"));
            // Тенге за доллар по курсу qiwi
            float usdQiwi = qiwi.GetRate(("398", "840"));
            // Сум за рубль по курсу qiwi
            float uzsRubQiwi = qiwi.GetRate(("643", "860"));
            // Долларов за сум по курсу qiwi
            float uzsUsdQiwi = qiwi.GetRate(("860", "840"));


            if (kztQiwi == 0 || rubQiwi == 0 || usdQiwi == 0 || uzsRubQiwi == 0 || uzsUsdQiwi == 0)
            {
                PictureBoxQiwi.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Qiwi = kztQiwi;
                RUB_KZT_Qiwi = rubQiwi;
                KZT_USD_Qiwi = usdQiwi;
                UZS_USD_Qiwi = uzsUsdQiwi;
                RUB_UZS_Qiwi = uzsRubQiwi;
                Properties.Settings.Default["RUB_USD_Qiwi"] = RUB_USD_Qiwi;
                Properties.Settings.Default["RUB_KZT_Qiwi"] = RUB_KZT_Qiwi;
                Properties.Settings.Default["KZT_USD_Qiwi"] = KZT_USD_Qiwi;
                Properties.Settings.Default["UZS_USD_Qiwi"] = UZS_USD_Qiwi;
                Properties.Settings.Default["RUB_UZS_Qiwi"] = RUB_UZS_Qiwi;
                LabelUsdQiwi.Text = $"Доллар - {Math.Round(RUB_USD_Qiwi, 2)}, тенге - {Math.Round(KZT_USD_Qiwi, 2)}";
                PictureBoxQiwi.Image = Properties.Resources.yes_c;
            }

            // Webmoney
            PictureBoxWeb.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу вебмани
            WMJson webmoney = WMJson.GetData();
            float usdWeb = webmoney.GetRate();
            if (usdWeb == 0 || usdWeb == -1)
            {
                PictureBoxWeb.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Web = usdWeb;
                Properties.Settings.Default["RUB_USD_Web"] = RUB_USD_Web;
                TextBoxInputUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);
                LabelUsdWeb.Text = $"Доллар - {Math.Round(RUB_USD_Web, 4)}";
                PictureBoxWeb.Image = Properties.Resources.yes_c;
            }

            if (ok == 3)
            {
                Properties.Settings.Default.Save();
                CalcPercent();
                TextBoxInput1.Enabled = true;
                TextBoxInput2.Enabled = true;
                TextBoxInput3.Enabled = true;
                TextBoxOutput1.Enabled = true;
                TextBoxOutput2.Enabled = true;
                TextBoxOutput3.Enabled = true;
                ButtonGetRates.Enabled = true;
                ButtonReverse.Enabled = true;
                TextBoxInputUsdWeb.Enabled = true;
            }
            ButtonGetRates.Text = "Обновить";
        }

        private void TextBoxInputUsdWeb_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInputUsdWeb.Text;
            if (text.Length < 1)
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
            CalcPercent();
            if (!Reverse)
            {
                string tempText = TextBoxInput3.Text;
                TextBoxInput3.Text = string.Empty;
                TextBoxInput3.Text = tempText;
            }
            else
            {
                string tempText = TextBoxOutput3.Text;
                TextBoxOutput3.Text = string.Empty;
                TextBoxOutput3.Text = tempText;
            }
        }

        private void CalcPercent()
        {
            float tempUsd = 10000 / (RUB_UZS_Qiwi - RUB_UZS_Qiwi / 100 * 4) / UZS_USD_Qiwi;
            float RUB_Output = tempUsd * RUB_USD_Steam;
            float percent = 100 - (100 / (10000 / RUB_Output));
            LabelRUBLostPercent1.Visible = true;
            LabelRUBLostPercent1.Text = $"({Math.Abs(percent):0.##}%)";

            tempUsd = 10000 / RUB_KZT_Qiwi;
            RUB_Output = (tempUsd - (tempUsd / 100 * 4)) / KZT_USD_Steam * RUB_USD_Steam;
            percent = 100 - (100 / (10000 / RUB_Output));
            LabelRUBLostPercent2.Visible = true;
            LabelRUBLostPercent2.Text = $"({Math.Abs(percent):0.##}%)";

            tempUsd = 10000 / RUB_USD_Web_Real;
            RUB_Output = (tempUsd - (tempUsd / 100 * 16)) * RUB_USD_Steam;
            percent = 100 - (100 / (10000 / RUB_Output));
            LabelRUBLostPercent3.Visible = true;
            LabelRUBLostPercent3.Text = $"({Math.Abs(percent):0.##}%)";
        }

        private void ButtonReverse_Click(object sender, EventArgs e)
        {
            if (Reverse) // Переключить на ввод отправляемой суммы
            {
                TextBoxInput1.ReadOnly = false;
                TextBoxOutput1.ReadOnly = true;
                TextBoxInput2.ReadOnly = false;
                TextBoxOutput2.ReadOnly = true;
                TextBoxInput3.ReadOnly = false;
                TextBoxOutput3.ReadOnly = true;
                ButtonReverse.Image = Properties.Resources.rev_c;
                Reverse = false;
            }
            else // Переключить на ввод получаемой суммы
            {
                TextBoxInput1.ReadOnly = true;
                TextBoxOutput1.ReadOnly = false;
                TextBoxInput2.ReadOnly = true;
                TextBoxOutput2.ReadOnly = false;
                TextBoxInput3.ReadOnly = true;
                TextBoxOutput3.ReadOnly = false;
                ButtonReverse.Image = Properties.Resources.rev_c2;
                Reverse = true;
            }
        }

        #region Qiwi USD
        private void TextBoxInput1_TextChanged(object sender, EventArgs e)
        {
            if (!Reverse)
            {
                string text = TextBoxInput1.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend1.Text = "0";
                    TextBoxOutput1.Text = "0";
                    TextBoxLost1.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Input = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли -> Сумы Qiwi -> Доллары Qiwi -> Рубли Steam

                float tempUzs = RUB_Input / (RUB_UZS_Qiwi - RUB_UZS_Qiwi / 100 * 4);
                float tempUsd = tempUzs / UZS_USD_Qiwi;
                TextBoxSend1.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                RUB_Output = tempUsd * RUB_USD_Steam;

                TextBoxOutput1.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost1.Text = "Я потеряю";
                    TextBoxLost1.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost1.Text = "Я выиграю";
                    TextBoxLost1.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void TextBoxOutput1_TextChanged(object sender, EventArgs e)
        {
            if (Reverse)
            {
                string text = TextBoxOutput1.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend1.Text = "0";
                    TextBoxInput1.Text = "0";
                    TextBoxLost1.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Output = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли Steam -> Доллары Qiwi -> Рубли
                float tempUsd = RUB_Output / RUB_USD_Steam;
                TextBoxSend1.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                float tempUzs = tempUsd * UZS_USD_Qiwi;
                RUB_Input = tempUzs * (RUB_UZS_Qiwi + RUB_UZS_Qiwi / 100 * 4);

                TextBoxInput1.Text = Math.Round(RUB_Input, 2).ToString(CultureInfo.InvariantCulture);

                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost1.Text = "Я потеряю";
                    TextBoxLost1.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost1.Text = "Я выиграю";
                    TextBoxLost1.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        #endregion

        #region Qiwi KZT
        private void TextBoxInput2_TextChanged(object sender, EventArgs e)
        {
            if (!Reverse)
            {
                string text = TextBoxInput2.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend2.Text = "0";
                    TextBoxOutput2.Text = "0";
                    TextBoxLost2.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Input = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли -> Тенге Qiwi -> Доллары Steam -> Рубли Steam
                float tempUsd = RUB_Input / RUB_KZT_Qiwi;
                TextBoxSend2.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                RUB_Output = (tempUsd - (tempUsd / 100 * 4)) / KZT_USD_Steam * RUB_USD_Steam;

                TextBoxOutput2.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost2.Text = "Я потеряю";
                    TextBoxLost2.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost2.Text = "Я выиграю";
                    TextBoxLost2.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void TextBoxOutput2_TextChanged(object sender, EventArgs e)
        {
            if (Reverse)
            {
                string text = TextBoxOutput2.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend2.Text = "0";
                    TextBoxInput2.Text = "0";
                    TextBoxLost2.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Output = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли Steam -> Доллары Qiwi -> Рубли
                float tempUsd = (RUB_Output / RUB_USD_Steam) * KZT_USD_Steam;
                TextBoxSend2.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                RUB_Input = (tempUsd + (tempUsd / 100 * 4)) * RUB_KZT_Qiwi;

                TextBoxInput2.Text = Math.Round(RUB_Input, 2).ToString(CultureInfo.InvariantCulture);

                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost2.Text = "Я потеряю";
                    TextBoxLost2.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost2.Text = "Я выиграю";
                    TextBoxLost2.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        #endregion

        #region Web
        private void TextBoxInput3_TextChanged(object sender, EventArgs e)
        {
            if (!Reverse)
            {
                string text = TextBoxInput3.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend3.Text = "0";
                    TextBoxOutput3.Text = "0";
                    TextBoxLost3.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Input = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли -> Доллары Webmoney -> Рубли Steam
                float tempUsd = RUB_Input / RUB_USD_Web_Real;
                tempUsd -= (tempUsd / 100 * 16);
                TextBoxSend3.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                RUB_Output = tempUsd * RUB_USD_Steam;

                TextBoxOutput3.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost3.Text = "Я потеряю";
                    TextBoxLost3.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost3.Text = "Я выиграю";
                    TextBoxLost3.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void TextBoxOutput3_TextChanged(object sender, EventArgs e)
        {
            if (Reverse)
            {
                string text = TextBoxOutput3.Text;
                if (text.Length < 1)
                    return;
                try
                {
                    Convert.ToSingle(text, CultureInfo.InvariantCulture);
                }
                catch
                {
                    TextBoxSend3.Text = "0";
                    TextBoxInput3.Text = "0";
                    TextBoxLost3.Text = "0";
                    return;
                }

                text = text.Replace(',', '.');

                RUB_Output = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                // Рубли Steam -> Доллары Webmoney -> Рубли
                float tempUsd = RUB_Output / RUB_USD_Steam;
                tempUsd += (tempUsd / 100 * 16);
                TextBoxSend3.Text = Math.Round(tempUsd, 2).ToString(CultureInfo.InvariantCulture);
                RUB_Input = tempUsd * RUB_USD_Web_Real;

                TextBoxInput3.Text = Math.Round(RUB_Input, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                if (delta > 0)
                {
                    LabelTextLost3.Text = "Я потеряю";
                    TextBoxLost3.Text = Math.Round(delta, 2).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    LabelTextLost3.Text = "Я выиграю";
                    TextBoxLost3.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        #endregion
    }
}