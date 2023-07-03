using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SteamCurrencyLib;

namespace SteamCurrencyLegacy
{
    public partial class MainForm : Form
    {
        float RUB_USD_Steam; // Рублей за доллар (Steam)
        float KZT_USD_Steam; // Тенге за доллар (Steam)
        float KZT_USD_Qiwi; // Тенге за доллар (Qiwi)
        float RUB_USD_Qiwi; // Рублей за доллар (Qiwi)
        float RUB_USD_Web; // Рублей за доллар (Webmoney)
        float RUB_USD_Web_Real; // Рублей за доллар (Webmoney PtP)
        float RUB_Input; // Рублей до конвертации
        float RUB_Output; // Рублей после конвертации

        bool Reverse; // Считать по получаемой (true) или вводимой (false). По умолчанию false
        bool PaySystem = true; // Qiwi (true) или WebMoney (false). По умолчанию true

        public MainForm()
        {
            InitializeComponent();
            RUB_USD_Steam = Properties.Settings.Default.RUB_USD_Steam;
            KZT_USD_Steam = Properties.Settings.Default.KZT_USD_Steam;
            KZT_USD_Qiwi = Properties.Settings.Default.KZT_USD_Qiwi;
            RUB_USD_Qiwi = Properties.Settings.Default.RUB_USD_Qiwi;
            RUB_USD_Web = Properties.Settings.Default.RUB_USD_Web;
            RUB_USD_Web_Real = Properties.Settings.Default.RUB_USD_Web_Real;

            if (RUB_USD_Steam != 0 && KZT_USD_Steam != 0 && KZT_USD_Qiwi != 0 && RUB_USD_Qiwi != 0 && RUB_USD_Web != 0)
            {
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Steam, 4)} (Steam)";
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Web, 4)} (Webmoney)";
                LabelKZT.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Qiwi, 4)} (Qiwi)";
                LabelKZT_USD.Text = $"Тенге за доллар    - {Math.Round(KZT_USD_Qiwi, 2)} (Qiwi)";

                if (RUB_USD_Web_Real > 0)
                    TextBoxInputUsdWeb.Text = RUB_USD_Web_Real.ToString(CultureInfo.InvariantCulture);
                else
                    TextBoxInputUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);

                PictureBoxUSD.Image = Properties.Resources.warn_c;
                PictureBoxUSDWeb.Image = Properties.Resources.warn_c;
                PictureBoxKZT.Image = Properties.Resources.warn_c;
                PictureBoxKZTUSD.Image = Properties.Resources.warn_c;

                ButtonGetRates.Text = "Обновить";
                TextBoxInput.Enabled = true;
                CalcPercent();
            }

            ButtonGetRates.Focus();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            ButtonGetRates.Text = "Обновление";
            ButtonGetRates.Enabled = false;
            ButtonReverse.Enabled = false;
            TextBoxInput.Enabled = false;
            TextBoxOutput.Enabled = false;
            TextBoxInputUsdWeb.Enabled = false;

            PictureBoxUSD.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу стима
            float usdSteam = SteamJson.GetRate(1, 5);
            if (usdSteam == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                RUB_USD_Steam = usdSteam;
                Properties.Settings.Default["RUB_USD_Steam"] = RUB_USD_Steam;
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Steam, 4)} (Steam)";
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }
            // Тенге за доллар по курсу стима
            float kztSteam = SteamJson.GetRate(1, 37);
            if (kztSteam == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                KZT_USD_Steam = kztSteam;
                Properties.Settings.Default["KZT_USD_Steam"] = KZT_USD_Steam;
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }

            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxKZTUSD.Image = Properties.Resources.wait_c;
            QiwiJson qiwi = new QiwiJson();
            qiwi = qiwi.GetData();
            // Рублей за доллар по курсу qiwi
            float kzt = qiwi.GetRate(("643", "840"));
            if (kzt == 0)
            {
                PictureBoxKZT.Image = Properties.Resources.no_c;
            }
            else
            {
                RUB_USD_Qiwi = kzt;
                Properties.Settings.Default["RUB_USD_Qiwi"] = RUB_USD_Qiwi;
                LabelKZT.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Qiwi, 4)} (Qiwi)";
                PictureBoxKZT.Image = Properties.Resources.yes_c;
            }
            // Тенге за доллар по курсу qiwi
            float usdQiwi = qiwi.GetRate(("398", "840"));
            if (usdQiwi == 0)
            {
                PictureBoxKZTUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                KZT_USD_Qiwi = usdQiwi;
                Properties.Settings.Default["KZT_USD_Qiwi"] = KZT_USD_Qiwi;
                LabelKZT_USD.Text = $"Тенге за доллар    - {Math.Round(KZT_USD_Qiwi, 2)} (Qiwi)";
                PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
            }

            PictureBoxUSDWeb.Image = Properties.Resources.wait_c;
            WMJson webmoney = new WMJson();
            // Рублей за доллар по курсу вебмани
            webmoney = webmoney.GetData();
            float usdWeb = webmoney.GetRate();
            if (usdWeb == 0 || usdWeb == -1)
            {
                PictureBoxUSDWeb.Image = Properties.Resources.no_c;
            }
            else
            {
                RUB_USD_Web = usdWeb;
                Properties.Settings.Default["RUB_USD_Web"] = RUB_USD_Web;
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Web, 4)} (Webmoney)";
                TextBoxInputUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);
                PictureBoxUSDWeb.Image = Properties.Resources.yes_c;
            }

            Properties.Settings.Default.Save();
            CalcPercent();
            TextBoxInput.Enabled = true;
            TextBoxOutput.Enabled = true;
            ButtonGetRates.Enabled = true;
            ButtonReverse.Enabled = true;
            TextBoxInputUsdWeb.Enabled = true;
            ButtonGetRates.Text = "Обновить";
            if (Reverse)
            {
                TextBoxOutput.Focus();
            }
            else
            {
                TextBoxInput.Focus();
            }
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInput.Text;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                TextBoxInputKZT.Text = "0";
                TextBoxOutput.Text = "0";
                TextBoxLost.Text = "0";
                return;
            }

            if (Reverse == false)
            {
                if (text.Contains(','))
                {
                    text = text.Replace(',', '.');
                }
                if (text.Contains('б'))
                {
                    text = text.Replace('б', '.');
                }
                if (text.Contains('ю'))
                {
                    text = text.Replace('ю', '.');
                }

                RUB_Input = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);


                if (PaySystem)
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Output = (RUB_Input / RUB_USD_Qiwi) * 0.91f * RUB_USD_Steam;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Output = (RUB_Input / RUB_USD_Web_Real) * 0.82f * RUB_USD_Steam;
                }

                TextBoxOutput.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / RUB_USD_Qiwi, 4, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxOutput.Text;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                TextBoxInputKZT.Text = "0";
                TextBoxInput.Text = "0";
                TextBoxLost.Text = "0";
                return;
            }

            if (Reverse)
            {
                if (text.Contains(','))
                {
                    text = text.Replace(',', '.');
                }
                if (text.Contains('б'))
                {
                    text = text.Replace('б', '.');
                }
                if (text.Contains('ю'))
                {
                    text = text.Replace('ю', '.');
                }

                RUB_Output = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);

                if (PaySystem)
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Input = (RUB_Output / RUB_USD_Steam) * 1.09f * RUB_USD_Qiwi;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Input = (RUB_Output / RUB_USD_Steam) * 1.18f * RUB_USD_Web_Real;
                }

                RUB_Input = Convert.ToSingle(Math.Round(RUB_Input));
                TextBoxInput.Text = RUB_Input.ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / RUB_USD_Qiwi, 4, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
        }

        private void CalcPercent()
        {
            float RUB_Output, percent;
            RUB_Output = PaySystem ? (10000 / (RUB_USD_Qiwi * 1.09f)) * RUB_USD_Steam : (10000 / RUB_USD_Web_Real) * 0.82f * RUB_USD_Steam;
            percent = 100 - (100 / (10000 / RUB_Output));
            LabelTextLost.Text = percent < 0 ? "Я выиграю" : "Я потеряю";
            LabelRUBLostPercent.Visible = true;
            LabelRUBLostPercent.Text = $"({Math.Abs(percent):0.##}%)";
        }

        private void ButtonReverse_Click(object sender, EventArgs e)
        {
            if (Reverse) // Переключить на ввод отправляемой суммы
            {
                TextBoxInput.ReadOnly = false;
                TextBoxOutput.ReadOnly = true;
                ButtonReverse.Image = Properties.Resources.rev_c;
                Reverse = false;
            }
            else // Переключить на ввод получаемой суммы
            {
                TextBoxInput.ReadOnly = true;
                TextBoxOutput.ReadOnly = false;
                ButtonReverse.Image = Properties.Resources.rev_c2;
                Reverse = true;
            }
        }

        private void ButtonTargetSystem_Click(object sender, EventArgs e)
        {
            if (PaySystem)
            {
                ButtonTargetSystem.Image = Properties.Resources.wm_c;
                PaySystem = false;
                LabelTextSend.Visible = false;
                TextBoxInputKZT.Visible = false;
                LabelKZTInput.Visible = false;
                LabelTextSendWeb.Visible = true;
                LabelUsdInputWeb.Visible = true;
                TextBoxInputUsdWeb.Visible = true;
            }
            else
            {
                ButtonTargetSystem.Image = Properties.Resources.qiwi_c;
                PaySystem = true;
                LabelTextSend.Visible = true;
                TextBoxInputKZT.Visible = true;
                LabelKZTInput.Visible = true;
                LabelTextSendWeb.Visible = false;
                LabelUsdInputWeb.Visible = false;
                TextBoxInputUsdWeb.Visible = false;
            }
            string temp;
            if (Reverse == false)
            {
                temp = TextBoxInput.Text;
                TextBoxInput.Text = string.Empty;
                TextBoxInput.Text = temp;
            }
            else
            {
                temp = TextBoxOutput.Text;
                TextBoxOutput.Text = string.Empty;
                TextBoxOutput.Text = temp;
            }
            CalcPercent();
        }

        private void TextBoxInputUsdWeb_TextChanged(object sender, EventArgs e)
        {
            string text = TextBoxInputUsdWeb.Text;
            try
            {
                Convert.ToSingle(text, CultureInfo.InvariantCulture);
            }
            catch
            {
                return;
            }

            if (text.Contains(','))
            {
                text = text.Replace(',', '.');
            }
            if (text.Contains('б'))
            {
                text = text.Replace('б', '.');
            }
            if (text.Contains('ю'))
            {
                text = text.Replace('ю', '.');
            }

            RUB_USD_Web_Real = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);

            Properties.Settings.Default["RUB_USD_Web_Real"] = RUB_USD_Web_Real;
            Properties.Settings.Default.Save();
            string temp;
            if (Reverse == false)
            {
                temp = TextBoxInput.Text;
                TextBoxInput.Text = string.Empty;
                TextBoxInput.Text = temp;
            }
            else
            {
                temp = TextBoxOutput.Text;
                TextBoxOutput.Text = string.Empty;
                TextBoxOutput.Text = temp;
            }
            CalcPercent();
        }
    }
}
