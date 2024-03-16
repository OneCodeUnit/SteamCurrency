namespace SteamCurrency
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label labelSteam;
            Label labelWeb;
            Label labelCurrencyWebKztOutput;
            Label labelCurrencyWebRubOutput;
            Label labelCurrencyWebUsd;
            PictureBox pictureBoxWebUsd;
            Label labelCurrencyWebRub;
            Label labelUsdWeb;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ButtonGetRates = new Button();
            LabelCurrencyRates = new Label();
            pictureBoxSteam = new PictureBox();
            pictureBoxWeb = new PictureBox();
            labelLostWebRU = new Label();
            textBoxLostWebRU = new TextBox();
            textBoxOutputWebKZ = new TextBox();
            textBoxOutputWebRU = new TextBox();
            textBoxConvertWebUsd = new TextBox();
            textBoxInputWeb = new TextBox();
            textBoxUsdWeb = new TextBox();
            labelCurrencyWeb = new Label();
            labelCurrencySteam = new Label();
            labelCurrencySteamKzt = new Label();
            labelSteam = new Label();
            labelWeb = new Label();
            labelCurrencyWebKztOutput = new Label();
            labelCurrencyWebRubOutput = new Label();
            labelCurrencyWebUsd = new Label();
            pictureBoxWebUsd = new PictureBox();
            labelCurrencyWebRub = new Label();
            labelUsdWeb = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebUsd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSteam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWeb).BeginInit();
            SuspendLayout();
            // 
            // labelSteam
            // 
            labelSteam.AutoSize = true;
            labelSteam.Location = new Point(47, 48);
            labelSteam.Name = "labelSteam";
            labelSteam.Size = new Size(66, 28);
            labelSteam.TabIndex = 2;
            labelSteam.Text = "Steam";
            // 
            // labelWeb
            // 
            labelWeb.AutoSize = true;
            labelWeb.Location = new Point(47, 119);
            labelWeb.Name = "labelWeb";
            labelWeb.Size = new Size(113, 28);
            labelWeb.TabIndex = 23;
            labelWeb.Text = "WebMoney";
            // 
            // labelCurrencyWebKztOutput
            // 
            labelCurrencyWebKztOutput.AutoSize = true;
            labelCurrencyWebKztOutput.Location = new Point(139, 406);
            labelCurrencyWebKztOutput.Name = "labelCurrencyWebKztOutput";
            labelCurrencyWebKztOutput.Size = new Size(153, 28);
            labelCurrencyWebKztOutput.TabIndex = 76;
            labelCurrencyWebKztOutput.Text = "₸ на KZ аккаунт";
            // 
            // labelCurrencyWebRubOutput
            // 
            labelCurrencyWebRubOutput.AutoSize = true;
            labelCurrencyWebRubOutput.Location = new Point(139, 366);
            labelCurrencyWebRubOutput.Name = "labelCurrencyWebRubOutput";
            labelCurrencyWebRubOutput.Size = new Size(156, 28);
            labelCurrencyWebRubOutput.TabIndex = 74;
            labelCurrencyWebRubOutput.Text = "₽ на RU аккаунт";
            // 
            // labelCurrencyWebUsd
            // 
            labelCurrencyWebUsd.AutoSize = true;
            labelCurrencyWebUsd.Location = new Point(139, 326);
            labelCurrencyWebUsd.Name = "labelCurrencyWebUsd";
            labelCurrencyWebUsd.Size = new Size(145, 28);
            labelCurrencyWebUsd.TabIndex = 70;
            labelCurrencyWebUsd.Text = "$ я отправляю";
            // 
            // pictureBoxWebUsd
            // 
            pictureBoxWebUsd.BackColor = SystemColors.Control;
            pictureBoxWebUsd.BackgroundImageLayout = ImageLayout.None;
            pictureBoxWebUsd.Enabled = false;
            pictureBoxWebUsd.Image = Properties.Resources.wm_c;
            pictureBoxWebUsd.Location = new Point(8, 203);
            pictureBoxWebUsd.Name = "pictureBoxWebUsd";
            pictureBoxWebUsd.Size = new Size(34, 34);
            pictureBoxWebUsd.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxWebUsd.TabIndex = 67;
            pictureBoxWebUsd.TabStop = false;
            // 
            // labelCurrencyWebRub
            // 
            labelCurrencyWebRub.AutoSize = true;
            labelCurrencyWebRub.Location = new Point(139, 246);
            labelCurrencyWebRub.Name = "labelCurrencyWebRub";
            labelCurrencyWebRub.Size = new Size(145, 28);
            labelCurrencyWebRub.TabIndex = 66;
            labelCurrencyWebRub.Text = "₽ я отправляю";
            // 
            // labelUsdWeb
            // 
            labelUsdWeb.AutoSize = true;
            labelUsdWeb.Location = new Point(139, 286);
            labelUsdWeb.Name = "labelUsdWeb";
            labelUsdWeb.Size = new Size(149, 28);
            labelUsdWeb.TabIndex = 85;
            labelUsdWeb.Text = "₽ (курс сделки)";
            // 
            // ButtonGetRates
            // 
            ButtonGetRates.Location = new Point(11, 156);
            ButtonGetRates.Margin = new Padding(4);
            ButtonGetRates.Name = "ButtonGetRates";
            ButtonGetRates.Size = new Size(135, 40);
            ButtonGetRates.TabIndex = 0;
            ButtonGetRates.Text = "Узнать";
            ButtonGetRates.UseVisualStyleBackColor = true;
            ButtonGetRates.Click += ButtonGet_Click;
            // 
            // LabelCurrencyRates
            // 
            LabelCurrencyRates.AutoSize = true;
            LabelCurrencyRates.Location = new Point(12, 9);
            LabelCurrencyRates.Name = "LabelCurrencyRates";
            LabelCurrencyRates.Size = new Size(191, 28);
            LabelCurrencyRates.TabIndex = 3;
            LabelCurrencyRates.Text = "Получение данных:";
            // 
            // pictureBoxSteam
            // 
            pictureBoxSteam.Location = new Point(12, 48);
            pictureBoxSteam.Name = "pictureBoxSteam";
            pictureBoxSteam.Size = new Size(30, 30);
            pictureBoxSteam.TabIndex = 4;
            pictureBoxSteam.TabStop = false;
            // 
            // pictureBoxWeb
            // 
            pictureBoxWeb.Location = new Point(12, 119);
            pictureBoxWeb.Name = "pictureBoxWeb";
            pictureBoxWeb.Size = new Size(30, 30);
            pictureBoxWeb.TabIndex = 24;
            pictureBoxWeb.TabStop = false;
            // 
            // labelLostWebRU
            // 
            labelLostWebRU.AutoSize = true;
            labelLostWebRU.Location = new Point(139, 446);
            labelLostWebRU.Name = "labelLostWebRU";
            labelLostWebRU.Size = new Size(163, 28);
            labelLostWebRU.TabIndex = 79;
            labelLostWebRU.Text = "₽ разница (+0%)";
            // 
            // textBoxLostWebRU
            // 
            textBoxLostWebRU.Location = new Point(8, 443);
            textBoxLostWebRU.Name = "textBoxLostWebRU";
            textBoxLostWebRU.ReadOnly = true;
            textBoxLostWebRU.Size = new Size(125, 34);
            textBoxLostWebRU.TabIndex = 78;
            textBoxLostWebRU.Text = "0";
            // 
            // textBoxOutputWebKZ
            // 
            textBoxOutputWebKZ.Location = new Point(8, 403);
            textBoxOutputWebKZ.Name = "textBoxOutputWebKZ";
            textBoxOutputWebKZ.ReadOnly = true;
            textBoxOutputWebKZ.Size = new Size(125, 34);
            textBoxOutputWebKZ.TabIndex = 75;
            textBoxOutputWebKZ.Text = "0";
            // 
            // textBoxOutputWebRU
            // 
            textBoxOutputWebRU.Location = new Point(8, 363);
            textBoxOutputWebRU.Name = "textBoxOutputWebRU";
            textBoxOutputWebRU.ReadOnly = true;
            textBoxOutputWebRU.Size = new Size(125, 34);
            textBoxOutputWebRU.TabIndex = 71;
            textBoxOutputWebRU.Text = "0";
            // 
            // textBoxConvertWebUsd
            // 
            textBoxConvertWebUsd.Location = new Point(8, 323);
            textBoxConvertWebUsd.Name = "textBoxConvertWebUsd";
            textBoxConvertWebUsd.ReadOnly = true;
            textBoxConvertWebUsd.Size = new Size(125, 34);
            textBoxConvertWebUsd.TabIndex = 69;
            textBoxConvertWebUsd.Text = "0";
            // 
            // textBoxInputWeb
            // 
            textBoxInputWeb.Location = new Point(8, 243);
            textBoxInputWeb.Name = "textBoxInputWeb";
            textBoxInputWeb.Size = new Size(125, 34);
            textBoxInputWeb.TabIndex = 68;
            textBoxInputWeb.Text = "0";
            textBoxInputWeb.TextChanged += TextBoxInputWeb_TextChanged;
            // 
            // textBoxUsdWeb
            // 
            textBoxUsdWeb.Location = new Point(8, 283);
            textBoxUsdWeb.Name = "textBoxUsdWeb";
            textBoxUsdWeb.Size = new Size(125, 34);
            textBoxUsdWeb.TabIndex = 83;
            textBoxUsdWeb.Text = "0";
            textBoxUsdWeb.TextChanged += TextBoxUsdWeb_TextChanged;
            // 
            // labelCurrencyWeb
            // 
            labelCurrencyWeb.AutoSize = true;
            labelCurrencyWeb.Location = new Point(170, 119);
            labelCurrencyWeb.Name = "labelCurrencyWeb";
            labelCurrencyWeb.Size = new Size(123, 28);
            labelCurrencyWeb.TabIndex = 86;
            labelCurrencyWeb.Text = "Курс USD = ";
            // 
            // labelCurrencySteam
            // 
            labelCurrencySteam.AutoSize = true;
            labelCurrencySteam.Location = new Point(170, 48);
            labelCurrencySteam.Name = "labelCurrencySteam";
            labelCurrencySteam.Size = new Size(123, 28);
            labelCurrencySteam.TabIndex = 87;
            labelCurrencySteam.Text = "Курс USD = ";
            // 
            // labelCurrencySteamKzt
            // 
            labelCurrencySteamKzt.AutoSize = true;
            labelCurrencySteamKzt.Location = new Point(170, 76);
            labelCurrencySteamKzt.Name = "labelCurrencySteamKzt";
            labelCurrencySteamKzt.Size = new Size(122, 28);
            labelCurrencySteamKzt.TabIndex = 88;
            labelCurrencySteamKzt.Text = "Курс KZT  = ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.Honeydew;
            ClientSize = new Size(397, 488);
            Controls.Add(labelCurrencySteamKzt);
            Controls.Add(labelCurrencySteam);
            Controls.Add(labelCurrencyWeb);
            Controls.Add(labelUsdWeb);
            Controls.Add(textBoxUsdWeb);
            Controls.Add(labelLostWebRU);
            Controls.Add(textBoxLostWebRU);
            Controls.Add(labelCurrencyWebKztOutput);
            Controls.Add(textBoxOutputWebKZ);
            Controls.Add(labelCurrencyWebRubOutput);
            Controls.Add(textBoxOutputWebRU);
            Controls.Add(labelCurrencyWebUsd);
            Controls.Add(textBoxConvertWebUsd);
            Controls.Add(textBoxInputWeb);
            Controls.Add(pictureBoxWebUsd);
            Controls.Add(labelCurrencyWebRub);
            Controls.Add(pictureBoxWeb);
            Controls.Add(labelWeb);
            Controls.Add(pictureBoxSteam);
            Controls.Add(LabelCurrencyRates);
            Controls.Add(labelSteam);
            Controls.Add(ButtonGetRates);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(562, 802);
            Name = "MainForm";
            Text = "Сколько придёт на Steam?";
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebUsd).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSteam).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWeb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonGetRates;
        private Label labelSteam;
        private Label LabelCurrencyRates;
        private PictureBox pictureBoxSteam;
        private PictureBox pictureBoxWeb;
        private Label labelWeb;
        private Label labelLostWebRU;
        private TextBox textBoxLostWebRU;
        private TextBox textBoxOutputWebKZ;
        private TextBox textBoxOutputWebRU;
        private TextBox textBoxConvertWebUsd;
        private TextBox textBoxInputWeb;
        private TextBox textBoxUsdWeb;
        private Label labelCurrencyWeb;
        private Label labelCurrencySteam;
        private Label labelCurrencySteamKzt;
    }
}