using System.Globalization;

namespace SteamCurrency
{
    public partial class MainForm : Form
    {
        float RUB_USD_Steam; // Рублей за доллар (Steam)
        float RUB_KZT_Qiwi; // Рублей за тенге (Qiwi)
        float KZT_USD_Qiwi; // Тенге за доллар (Qiwi)
        float RUB_USD_Web; // Рублей за доллар (Webmoney)
        float RUB_USD_Web_Real; // Рублей за доллар (Webmoney PtP)
        float RUB_Input; // Рублей до конвертации
        float RUB_Output; // Рублей после конвертации

        bool Reverse; // Считать по получаемой (true) или вводимой (false). По умолчанию false
        bool PaySystem = true; // Qiwi (true) или WebMoney (false). По умолчанию true

        readonly float QiwiPercent = 0.0415f;
        readonly float WebPercent = 0.16f;

        public MainForm()
        {
            InitializeComponent();
            RUB_USD_Steam = Properties.Settings.Default.RUB_USD_Steam;
            RUB_KZT_Qiwi = Properties.Settings.Default.RUB_KZT_Qiwi;
            KZT_USD_Qiwi = Properties.Settings.Default.KZT_USD_Qiwi;
            RUB_USD_Web = Properties.Settings.Default.RUB_USD_Web;
            RUB_USD_Web_Real = Properties.Settings.Default.RUB_USD_Web_Real;

            if (RUB_USD_Steam != 0 && KZT_USD_Qiwi != 0 && RUB_KZT_Qiwi != 0 && RUB_USD_Web != 0)
            {
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Steam, 4)} (Steam)";
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Web, 4)} (Webmoney)";
                LabelKZT.Text = $"Рублей за тенге     - {Math.Round(RUB_KZT_Qiwi, 3)} (Qiwi)";
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

            int ok = 0;

            // Steam
            PictureBoxUSD.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу стима
            float usdSteam = SteamJson.GetRate(1, 5);
            if (usdSteam == 0)
            {
                PictureBoxUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Steam = usdSteam;
                Properties.Settings.Default["RUB_USD_Steam"] = RUB_USD_Steam;
                LabelUSD.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Steam, 4)} (Steam)";
                PictureBoxUSD.Image = Properties.Resources.yes_c;
            }

            // Qiwi
            PictureBoxKZT.Image = Properties.Resources.wait_c;
            PictureBoxKZTUSD.Image = Properties.Resources.wait_c;
            QiwiJson qiwi = QiwiJson.GetData();
            // Рублей за тенге по курсу qiwi
            float rubQiwi = qiwi.GetRate(("643", "398"));
            // Тенге за доллар по курсу qiwi
            float usdQiwi = qiwi.GetRate(("398", "840"));


            if (rubQiwi == 0 || usdQiwi == 0)
            {
                PictureBoxKZT.Image = Properties.Resources.no_c;
                PictureBoxKZTUSD.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_KZT_Qiwi = rubQiwi;
                KZT_USD_Qiwi = usdQiwi;
                Properties.Settings.Default["RUB_KZT_Qiwi"] = RUB_KZT_Qiwi;
                Properties.Settings.Default["KZT_USD_Qiwi"] = KZT_USD_Qiwi;
                LabelKZT.Text = $"Рублей за тенге     - {Math.Round(RUB_KZT_Qiwi, 3)} (Qiwi)";
                LabelKZT_USD.Text = $"Тенге за доллар    - {Math.Round(KZT_USD_Qiwi, 2)} (Qiwi)";
                PictureBoxKZT.Image = Properties.Resources.yes_c;
                PictureBoxKZTUSD.Image = Properties.Resources.yes_c;
            }

            // Webmoney
            PictureBoxUSDWeb.Image = Properties.Resources.wait_c;
            // Рублей за доллар по курсу вебмани
            WMJson webmoney = WMJson.GetData();
            float usdWeb = webmoney.GetRate();
            if (usdWeb == 0 || usdWeb == -1)
            {
                PictureBoxUSDWeb.Image = Properties.Resources.no_c;
            }
            else
            {
                ok++;
                RUB_USD_Web = usdWeb;
                Properties.Settings.Default["RUB_USD_Web"] = RUB_USD_Web;
                TextBoxInputUsdWeb.Text = RUB_USD_Web.ToString(CultureInfo.InvariantCulture);
                LabelUSDWeb.Text = $"Рублей за доллар - {Math.Round(RUB_USD_Web, 4)} (Webmoney)";
                PictureBoxUSDWeb.Image = Properties.Resources.yes_c;
            }

            if (ok == 3)
            {
                Properties.Settings.Default.Save();
                CalcPercent();
                TextBoxInput.Enabled = true;
                TextBoxOutput.Enabled = true;
                ButtonGetRates.Enabled = true;
                ButtonReverse.Enabled = true;
                TextBoxInputUsdWeb.Enabled = true;
                ButtonGetRates.Text = "Обновить";
            }
            if (Reverse)
            {
                TextBoxOutput.Focus();
            }
            else
            {
                TextBoxInput.Focus();
            }
            ButtonGetRates.Text = "Обновить";
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (!Reverse)
            {
                string text = TextBoxInput.Text;
                if (text.Length < 1)
                    return;
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

                text = text.Replace(',', '.');

                RUB_Input = Convert.ToSingle(text, CultureInfo.InvariantCulture);


                if (PaySystem)
                {
                    // Рубли -> Тенге -> Доллары -> Рубли
                    RUB_Output = ((RUB_Input / RUB_KZT_Qiwi) / (KZT_USD_Qiwi + QiwiPercent * KZT_USD_Qiwi)) * RUB_USD_Steam;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Output = (RUB_Input / RUB_USD_Web_Real) * (1 - WebPercent) * RUB_USD_Steam;
                }

                TextBoxOutput.Text = Math.Round(RUB_Output, 2).ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / RUB_KZT_Qiwi, 2, MidpointRounding.ToNegativeInfinity).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            if (Reverse)
            {
                string text = TextBoxOutput.Text;
                if (text.Length < 1)
                    return;
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

                text = text.Replace(',', '.');

                RUB_Output = Convert.ToSingle(text, CultureInfo.InvariantCulture);

                if (PaySystem)
                {
                    // Рубли -> Доллары -> Тенге -> Рубли
                    RUB_Input = (RUB_Output / RUB_USD_Steam) * (KZT_USD_Qiwi + QiwiPercent * KZT_USD_Qiwi) * RUB_KZT_Qiwi;
                }
                else
                {
                    // Рубли -> Доллары -> Рубли
                    RUB_Input = (RUB_Output / RUB_USD_Steam) * (1 + WebPercent) * RUB_USD_Web_Real;
                }

                RUB_Input = Convert.ToSingle(Math.Round(RUB_Input));
                TextBoxInput.Text = RUB_Input.ToString(CultureInfo.InvariantCulture);
                float delta = RUB_Input - RUB_Output;
                TextBoxLost.Text = Math.Round(Math.Abs(delta), 2).ToString(CultureInfo.InvariantCulture);
                TextBoxInputKZT.Text = Math.Round(RUB_Input / RUB_KZT_Qiwi, 2, MidpointRounding.ToNegativeInfinity).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void CalcPercent()
        {
            float RUB_Output, percent;
            RUB_Output = PaySystem ? ((10000 / RUB_KZT_Qiwi) / (KZT_USD_Qiwi + QiwiPercent * KZT_USD_Qiwi)) * RUB_USD_Steam : (10000 / RUB_USD_Web_Real) * (1 - WebPercent) * RUB_USD_Steam;
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
            string temp;
            if (!Reverse)
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