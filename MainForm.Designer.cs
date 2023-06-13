﻿namespace SteamCurrency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ButtonGetRates = new Button();
            LabelUSD = new Label();
            LabelKZT = new Label();
            LabelCurrencyRates = new Label();
            PictureBoxKZT = new PictureBox();
            PictureBoxUSD = new PictureBox();
            TextBoxInput = new TextBox();
            TextBoxOutput = new TextBox();
            LabelTextInput = new Label();
            LabelRUBInput = new Label();
            LabelTextOutput = new Label();
            LabelRUBOutput = new Label();
            LabelTextLost = new Label();
            LabelRUBLost = new Label();
            TextBoxLost = new TextBox();
            LabelRUBLostPercent = new Label();
            PictureBoxKZTUSD = new PictureBox();
            LabelKZT_USD = new Label();
            LabelKZTInput = new Label();
            TextBoxInputKZT = new TextBox();
            LabelTextSend = new Label();
            ButtonReverse = new Button();
            PictureBoxUSDWeb = new PictureBox();
            LabelUSDWeb = new Label();
            ButtonTargetSystem = new Button();
            LabelTextSendWeb = new Label();
            LabelUsdInputWeb = new Label();
            TextBoxInputUsdWeb = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZTUSD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSDWeb).BeginInit();
            SuspendLayout();
            // 
            // ButtonGetRates
            // 
            ButtonGetRates.Location = new Point(294, 13);
            ButtonGetRates.Margin = new Padding(4);
            ButtonGetRates.Name = "ButtonGetRates";
            ButtonGetRates.Size = new Size(135, 40);
            ButtonGetRates.TabIndex = 0;
            ButtonGetRates.Text = "Узнать";
            ButtonGetRates.UseVisualStyleBackColor = true;
            ButtonGetRates.Click += ButtonGet_Click;
            // 
            // LabelUSD
            // 
            LabelUSD.AutoSize = true;
            LabelUSD.Location = new Point(46, 94);
            LabelUSD.Name = "LabelUSD";
            LabelUSD.Size = new Size(192, 28);
            LabelUSD.TabIndex = 1;
            LabelUSD.Text = "Рублей за доллар - ";
            // 
            // LabelKZT
            // 
            LabelKZT.AutoSize = true;
            LabelKZT.Location = new Point(48, 58);
            LabelKZT.Name = "LabelKZT";
            LabelKZT.Size = new Size(193, 28);
            LabelKZT.TabIndex = 2;
            LabelKZT.Text = "Рублей за тенге     - ";
            // 
            // LabelCurrencyRates
            // 
            LabelCurrencyRates.AutoSize = true;
            LabelCurrencyRates.Location = new Point(11, 19);
            LabelCurrencyRates.Name = "LabelCurrencyRates";
            LabelCurrencyRates.Size = new Size(134, 28);
            LabelCurrencyRates.TabIndex = 3;
            LabelCurrencyRates.Text = "Курсы валют:";
            // 
            // PictureBoxKZT
            // 
            PictureBoxKZT.Location = new Point(11, 58);
            PictureBoxKZT.Name = "PictureBoxKZT";
            PictureBoxKZT.Size = new Size(30, 30);
            PictureBoxKZT.TabIndex = 4;
            PictureBoxKZT.TabStop = false;
            // 
            // PictureBoxUSD
            // 
            PictureBoxUSD.Location = new Point(11, 94);
            PictureBoxUSD.Name = "PictureBoxUSD";
            PictureBoxUSD.Size = new Size(30, 30);
            PictureBoxUSD.TabIndex = 5;
            PictureBoxUSD.TabStop = false;
            // 
            // TextBoxInput
            // 
            TextBoxInput.Enabled = false;
            TextBoxInput.Location = new Point(138, 207);
            TextBoxInput.Name = "TextBoxInput";
            TextBoxInput.Size = new Size(125, 34);
            TextBoxInput.TabIndex = 6;
            TextBoxInput.Text = "0";
            TextBoxInput.TextChanged += TextBoxInput_TextChanged;
            // 
            // TextBoxOutput
            // 
            TextBoxOutput.Location = new Point(138, 287);
            TextBoxOutput.Name = "TextBoxOutput";
            TextBoxOutput.ReadOnly = true;
            TextBoxOutput.Size = new Size(125, 34);
            TextBoxOutput.TabIndex = 7;
            TextBoxOutput.Text = "0";
            TextBoxOutput.TextChanged += TextBoxOutput_TextChanged;
            // 
            // LabelTextInput
            // 
            LabelTextInput.AutoSize = true;
            LabelTextInput.Location = new Point(11, 207);
            LabelTextInput.Name = "LabelTextInput";
            LabelTextInput.Size = new Size(121, 28);
            LabelTextInput.TabIndex = 8;
            LabelTextInput.Text = "Я отправлю";
            // 
            // LabelRUBInput
            // 
            LabelRUBInput.AutoSize = true;
            LabelRUBInput.Location = new Point(269, 207);
            LabelRUBInput.Name = "LabelRUBInput";
            LabelRUBInput.Size = new Size(79, 28);
            LabelRUBInput.TabIndex = 9;
            LabelRUBInput.Text = "руб.";
            // 
            // LabelTextOutput
            // 
            LabelTextOutput.AutoSize = true;
            LabelTextOutput.Location = new Point(11, 287);
            LabelTextOutput.Name = "LabelTextOutput";
            LabelTextOutput.Size = new Size(95, 28);
            LabelTextOutput.TabIndex = 10;
            LabelTextOutput.Text = "Я получу";
            // 
            // LabelRUBOutput
            // 
            LabelRUBOutput.AutoSize = true;
            LabelRUBOutput.Location = new Point(269, 287);
            LabelRUBOutput.Name = "LabelRUBOutput";
            LabelRUBOutput.Size = new Size(79, 28);
            LabelRUBOutput.TabIndex = 11;
            LabelRUBOutput.Text = "руб.";
            // 
            // LabelTextLost
            // 
            LabelTextLost.AutoSize = true;
            LabelTextLost.Location = new Point(11, 327);
            LabelTextLost.Name = "LabelTextLost";
            LabelTextLost.Size = new Size(109, 28);
            LabelTextLost.TabIndex = 12;
            LabelTextLost.Text = "Я потеряю";
            // 
            // LabelRUBLost
            // 
            LabelRUBLost.AutoSize = true;
            LabelRUBLost.Location = new Point(269, 327);
            LabelRUBLost.Name = "LabelRUBLost";
            LabelRUBLost.Size = new Size(79, 28);
            LabelRUBLost.TabIndex = 13;
            LabelRUBLost.Text = "руб.";
            // 
            // TextBoxLost
            // 
            TextBoxLost.Location = new Point(138, 327);
            TextBoxLost.Name = "TextBoxLost";
            TextBoxLost.ReadOnly = true;
            TextBoxLost.Size = new Size(125, 34);
            TextBoxLost.TabIndex = 14;
            TextBoxLost.Text = "0";
            TextBoxLost.TextChanged += TextBoxLost_TextChanged;
            // 
            // LabelRUBLostPercent
            // 
            LabelRUBLostPercent.AutoSize = true;
            LabelRUBLostPercent.Location = new Point(354, 327);
            LabelRUBLostPercent.Name = "LabelRUBLostPercent";
            LabelRUBLostPercent.Size = new Size(65, 28);
            LabelRUBLostPercent.TabIndex = 15;
            LabelRUBLostPercent.Text = "(+0%)";
            LabelRUBLostPercent.Visible = false;
            // 
            // PictureBoxKZTUSD
            // 
            PictureBoxKZTUSD.Location = new Point(11, 165);
            PictureBoxKZTUSD.Name = "PictureBoxKZTUSD";
            PictureBoxKZTUSD.Size = new Size(30, 30);
            PictureBoxKZTUSD.TabIndex = 16;
            PictureBoxKZTUSD.TabStop = false;
            // 
            // LabelKZT_USD
            // 
            LabelKZT_USD.AutoSize = true;
            LabelKZT_USD.Location = new Point(48, 165);
            LabelKZT_USD.Name = "LabelKZT_USD";
            LabelKZT_USD.Size = new Size(191, 28);
            LabelKZT_USD.TabIndex = 17;
            LabelKZT_USD.Text = "Тенге за доллар    - ";
            // 
            // LabelKZTInput
            // 
            LabelKZTInput.AutoSize = true;
            LabelKZTInput.Location = new Point(269, 247);
            LabelKZTInput.Name = "LabelKZTInput";
            LabelKZTInput.Size = new Size(60, 28);
            LabelKZTInput.TabIndex = 19;
            LabelKZTInput.Text = "тенге";
            // 
            // TextBoxInputKZT
            // 
            TextBoxInputKZT.Location = new Point(138, 247);
            TextBoxInputKZT.Name = "TextBoxInputKZT";
            TextBoxInputKZT.ReadOnly = true;
            TextBoxInputKZT.Size = new Size(125, 34);
            TextBoxInputKZT.TabIndex = 20;
            TextBoxInputKZT.Text = "0";
            // 
            // LabelTextSend
            // 
            LabelTextSend.AutoSize = true;
            LabelTextSend.Location = new Point(48, 247);
            LabelTextSend.Name = "LabelTextSend";
            LabelTextSend.Size = new Size(47, 28);
            LabelTextSend.TabIndex = 21;
            LabelTextSend.Text = "или";
            // 
            // ButtonReverse
            // 
            ButtonReverse.BackgroundImageLayout = ImageLayout.None;
            ButtonReverse.Image = Properties.Resources.rev_c;
            ButtonReverse.Location = new Point(354, 289);
            ButtonReverse.Name = "ButtonReverse";
            ButtonReverse.Size = new Size(30, 30);
            ButtonReverse.TabIndex = 22;
            ButtonReverse.UseVisualStyleBackColor = true;
            ButtonReverse.Click += ButtonReverse_Click;
            // 
            // PictureBoxUSDWeb
            // 
            PictureBoxUSDWeb.Location = new Point(11, 129);
            PictureBoxUSDWeb.Name = "PictureBoxUSDWeb";
            PictureBoxUSDWeb.Size = new Size(30, 30);
            PictureBoxUSDWeb.TabIndex = 24;
            PictureBoxUSDWeb.TabStop = false;
            // 
            // LabelUSDWeb
            // 
            LabelUSDWeb.AutoSize = true;
            LabelUSDWeb.Location = new Point(46, 129);
            LabelUSDWeb.Name = "LabelUSDWeb";
            LabelUSDWeb.Size = new Size(324, 28);
            LabelUSDWeb.TabIndex = 23;
            LabelUSDWeb.Text = "Рублей за доллар (справочный) - ";
            // 
            // ButtonTargetSystem
            // 
            ButtonTargetSystem.Image = Properties.Resources.qiwi_c;
            ButtonTargetSystem.Location = new Point(354, 204);
            ButtonTargetSystem.Margin = new Padding(4);
            ButtonTargetSystem.Name = "ButtonTargetSystem";
            ButtonTargetSystem.Size = new Size(75, 40);
            ButtonTargetSystem.TabIndex = 25;
            ButtonTargetSystem.UseVisualStyleBackColor = true;
            ButtonTargetSystem.Click += ButtonTargetSystem_Click;
            // 
            // LabelTextSendWeb
            // 
            LabelTextSendWeb.AutoSize = true;
            LabelTextSendWeb.Location = new Point(11, 247);
            LabelTextSendWeb.Name = "LabelTextSendWeb";
            LabelTextSendWeb.Size = new Size(108, 28);
            LabelTextSendWeb.TabIndex = 26;
            LabelTextSendWeb.Text = "по курсу $";
            LabelTextSendWeb.Visible = false;
            // 
            // LabelUsdInputWeb
            // 
            LabelUsdInputWeb.AutoSize = true;
            LabelUsdInputWeb.Location = new Point(269, 247);
            LabelUsdInputWeb.Name = "LabelUsdInputWeb";
            LabelUsdInputWeb.Size = new Size(79, 28);
            LabelUsdInputWeb.TabIndex = 27;
            LabelUsdInputWeb.Text = "руб.";
            LabelUsdInputWeb.Visible = false;
            // 
            // TextBoxInputUsdWeb
            // 
            TextBoxInputUsdWeb.Location = new Point(138, 247);
            TextBoxInputUsdWeb.Name = "TextBoxInputUsdWeb";
            TextBoxInputUsdWeb.Size = new Size(125, 34);
            TextBoxInputUsdWeb.TabIndex = 28;
            TextBoxInputUsdWeb.Text = "0";
            TextBoxInputUsdWeb.Visible = false;
            TextBoxInputUsdWeb.TextChanged += TextBoxInputUsdWeb_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 371);
            Controls.Add(ButtonTargetSystem);
            Controls.Add(PictureBoxUSDWeb);
            Controls.Add(LabelUSDWeb);
            Controls.Add(ButtonReverse);
            Controls.Add(LabelTextSend);
            Controls.Add(TextBoxInputKZT);
            Controls.Add(LabelKZTInput);
            Controls.Add(LabelKZT_USD);
            Controls.Add(PictureBoxKZTUSD);
            Controls.Add(LabelRUBLostPercent);
            Controls.Add(TextBoxLost);
            Controls.Add(LabelRUBLost);
            Controls.Add(LabelTextLost);
            Controls.Add(LabelRUBOutput);
            Controls.Add(LabelTextOutput);
            Controls.Add(LabelRUBInput);
            Controls.Add(LabelTextInput);
            Controls.Add(TextBoxOutput);
            Controls.Add(TextBoxInput);
            Controls.Add(PictureBoxUSD);
            Controls.Add(PictureBoxKZT);
            Controls.Add(LabelCurrencyRates);
            Controls.Add(LabelUSD);
            Controls.Add(LabelKZT);
            Controls.Add(ButtonGetRates);
            Controls.Add(LabelTextSendWeb);
            Controls.Add(LabelUsdInputWeb);
            Controls.Add(TextBoxInputUsdWeb);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(465, 418);
            MinimumSize = new Size(465, 418);
            Name = "MainForm";
            Text = "Steam Currency от OliveWizard";
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZT).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSD).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZTUSD).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSDWeb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonGetRates;
        private Label LabelUSD;
        private Label LabelKZT;
        private Label LabelCurrencyRates;
        private PictureBox PictureBoxKZT;
        private PictureBox PictureBoxUSD;
        private TextBox TextBoxInput;
        private TextBox TextBoxOutput;
        private Label LabelTextInput;
        private Label LabelRUBInput;
        private Label LabelTextOutput;
        private Label LabelRUBOutput;
        private Label LabelTextLost;
        private Label LabelRUBLost;
        private TextBox TextBoxLost;
        private Label LabelRUBLostPercent;
        private PictureBox PictureBoxKZTUSD;
        private Label LabelKZT_USD;
        private Label LabelKZTInput;
        private TextBox TextBoxInputKZT;
        private Label LabelTextSend;
        private Button ButtonReverse;
        private PictureBox PictureBoxUSDWeb;
        private Label LabelUSDWeb;
        private Button ButtonTargetSystem;
        private Label LabelTextSendWeb;
        private Label LabelUsdInputWeb;
        private TextBox TextBoxInputUsdWeb;
    }
}