﻿using SteamCurrencyLib;
using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float USD_Steam; // Рублей за доллар (Steam)
        float KZT_Qiwi; // Рублей за тенге (Qiwi)
        float USD_Qiwi; // Тенге за доллар (Qiwi)
        float USD_Web; // Рублей за доллар (Webmoney)
        float RUB_Input; // Рублей до конвертации
        float RUB_Output; // Рублей после конвертации

        bool Reverse; // Считать по получаемой (true) или вводимой (false). По умолчанию false
        bool PaySystem = true; // Qiwi (true) или WebMoney (false). По умолчанию true

        public MainForm()
        {
            InitializeComponent();
            USD_Steam = Properties.Settings.Default.USD_Steam;
            KZT_Qiwi = Properties.Settings.Default.KZT_Qiwi;
            USD_Qiwi = Properties.Settings.Default.USD_Qiwi;
            USD_Web = Properties.Settings.Default.USD_Web;

            if (USD_Steam != 0 && USD_Qiwi != 0 && KZT_Qiwi != 0 && USD_Web != 0)
            {
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(USD_Steam, 4)}";
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(USD_Web, 4)} (P2P)";
                LabelKZT.Text = $"Рублей за тенге     - {Math.Round(KZT_Qiwi, 3)}";
                LabelKZT_USD.Text = $"Тенге за доллар    - {Math.Round(USD_Qiwi, 2)}";

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

            PictureBoxUSD.Image = Properties.Resources.wait_c;
            SteamJson steam = new();
            // Рублей за доллар по курсу стима
            float usdSteam = steam.GetRate();
            if (usdSteam == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                USD_Steam = usdSteam;
                Properties.Settings.Default["USD_Steam"] = USD_Steam;
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(USD_Steam, 4)}";
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }

            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxKZTUSD.Image = Properties.Resources.wait_c;
            QiwiJson qiwi = new();
            qiwi = qiwi.GetData();
            // Рублей за тенге по курсу qiwi
            float kzt = qiwi.GetRate(("643", "398"));
            if (kzt == 0)
            {
                PictureBoxKZT.Image = Properties.Resources.no_c;
            }
            else
            {
                KZT_Qiwi = kzt;
                Properties.Settings.Default["KZT_Qiwi"] = KZT_Qiwi;
                LabelKZT.Text = $"Рублей за тенге     - {Math.Round(KZT_Qiwi, 3)}";
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
                USD_Qiwi = usdQiwi;
                Properties.Settings.Default["USD_Qiwi"] = USD_Qiwi;
                LabelKZT_USD.Text = $"Тенге за доллар    - {Math.Round(USD_Qiwi, 2)}";
                PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
            }

            PictureBoxUSDWeb.Image = Properties.Resources.wait_c;
            WMJson webmoney = new();
            // Рублей за доллар по курсу вебмани
            webmoney = webmoney.GetData();
            float usdWeb = webmoney.GetRate();
            if (usdWeb == 0 || usdWeb == -1)
            {
                PictureBoxUSDWeb.Image = Properties.Resources.no_c;
            }
            else
            {
                USD_Web = usdWeb;
                Properties.Settings.Default["USD_Web"] = USD_Web;
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(USD_Web, 4)} (P2P)";
                PictureBoxUSDWeb.Image = Properties.Resources.yes_c;
            }

            Properties.Settings.Default.Save();
            CalcPercent();
            TextBoxInput.Enabled = true;
            TextBoxOutput.Enabled = true;
            ButtonGetRates.Enabled = true;
            ButtonReverse.Enabled = true;
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

            LabelRUBInput.Text = Program.ChangeEnding(text);

            if (Reverse == false)
            {
                if (text.Contains(','))
                {
                    text = text.Replace(',', '.');
                }

                RUB_Input = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);


                if (PaySystem)
                {
                    // Рубли -> Тенге -> Доллары -> Рубли
                    RUB_Output = ((RUB_Input / KZT_Qiwi) / (USD_Qiwi + 0.0415f * USD_Qiwi)) * USD_Steam;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Output = (RUB_Input / USD_Web) * 0.96f * USD_Steam;
                }

                TextBoxOutput.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / KZT_Qiwi, 2, MidpointRounding.ToNegativeInfinity).ToString(CultureInfo.InvariantCulture);
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

            LabelRUBOutput.Text = Program.ChangeEnding(text);

            if (Reverse)
            {
                if (text.Contains(','))
                {
                    text = text.Replace(',', '.');
                }

                RUB_Output = text.Length == 0 ? 0 : Convert.ToSingle(text, CultureInfo.InvariantCulture);

                if (PaySystem)
                {
                    // Рубли -> Доллары -> Тенге -> Рубли
                    RUB_Input = (RUB_Output / USD_Steam) * (USD_Qiwi + 0.0415f * USD_Qiwi) * KZT_Qiwi;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Input = (RUB_Output / USD_Steam) * 1.04f * USD_Web;
                }

                RUB_Input = Convert.ToSingle(Math.Round(RUB_Input));
                TextBoxInput.Text = RUB_Input.ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / KZT_Qiwi, 2, MidpointRounding.ToNegativeInfinity).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void TextBoxLost_TextChanged(object sender, EventArgs e)
        {
            if (RUB_Output != 0)
            {
                LabelRUBLost.Text = Program.ChangeEnding(TextBoxLost.Text);
            }
        }

        private void CalcPercent()
        {
            float RUB_Output, percent;
            RUB_Output = PaySystem ? ((10000 / KZT_Qiwi) / (USD_Qiwi + 0.0415f * USD_Qiwi)) * USD_Steam : (10000 / USD_Web) * 0.96f * USD_Steam;
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
            }
            else
            {
                ButtonTargetSystem.Image = Properties.Resources.qiwi_c;
                PaySystem = true;
                LabelTextSend.Visible = true;
                TextBoxInputKZT.Visible = true;
                LabelKZTInput.Visible = true;
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
    }
}