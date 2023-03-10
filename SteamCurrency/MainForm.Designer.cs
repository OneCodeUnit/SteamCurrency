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
            LabelInputKZT = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZTUSD).BeginInit();
            SuspendLayout();
            // 
            // ButtonGetRates
            // 
            ButtonGetRates.Location = new Point(294, 13);
            ButtonGetRates.Margin = new Padding(4);
            ButtonGetRates.Name = "ButtonGetRates";
            ButtonGetRates.Size = new Size(135, 40);
            ButtonGetRates.TabIndex = 0;
            ButtonGetRates.Text = "Получить";
            ButtonGetRates.UseVisualStyleBackColor = true;
            ButtonGetRates.Click += ButtonGet_Click;
            // 
            // LabelUSD
            // 
            LabelUSD.AutoSize = true;
            LabelUSD.Location = new Point(46, 76);
            LabelUSD.Name = "LabelUSD";
            LabelUSD.Size = new Size(100, 28);
            LabelUSD.TabIndex = 1;
            LabelUSD.Text = "Доллар - ";
            // 
            // LabelKZT
            // 
            LabelKZT.AutoSize = true;
            LabelKZT.Location = new Point(48, 40);
            LabelKZT.Name = "LabelKZT";
            LabelKZT.Size = new Size(80, 28);
            LabelKZT.TabIndex = 2;
            LabelKZT.Text = "Тенге - ";
            // 
            // LabelCurrencyRates
            // 
            LabelCurrencyRates.AutoSize = true;
            LabelCurrencyRates.Location = new Point(11, 9);
            LabelCurrencyRates.Name = "LabelCurrencyRates";
            LabelCurrencyRates.Size = new Size(134, 28);
            LabelCurrencyRates.TabIndex = 3;
            LabelCurrencyRates.Text = "Курсы валют:";
            // 
            // PictureBoxKZT
            // 
            PictureBoxKZT.Location = new Point(11, 40);
            PictureBoxKZT.Name = "PictureBoxKZT";
            PictureBoxKZT.Size = new Size(30, 30);
            PictureBoxKZT.TabIndex = 4;
            PictureBoxKZT.TabStop = false;
            // 
            // PictureBoxUSD
            // 
            PictureBoxUSD.Location = new Point(11, 76);
            PictureBoxUSD.Name = "PictureBoxUSD";
            PictureBoxUSD.Size = new Size(30, 30);
            PictureBoxUSD.TabIndex = 5;
            PictureBoxUSD.TabStop = false;
            // 
            // TextBoxInput
            // 
            TextBoxInput.Enabled = false;
            TextBoxInput.Location = new Point(138, 173);
            TextBoxInput.Name = "TextBoxInput";
            TextBoxInput.Size = new Size(125, 34);
            TextBoxInput.TabIndex = 6;
            TextBoxInput.Text = "0";
            TextBoxInput.TextChanged += TextBoxInput_TextChanged;
            // 
            // TextBoxOutput
            // 
            TextBoxOutput.Location = new Point(138, 213);
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
            LabelTextInput.Location = new Point(11, 173);
            LabelTextInput.Name = "LabelTextInput";
            LabelTextInput.Size = new Size(121, 28);
            LabelTextInput.TabIndex = 8;
            LabelTextInput.Text = "Я отправлю";
            // 
            // LabelRUBInput
            // 
            LabelRUBInput.AutoSize = true;
            LabelRUBInput.Location = new Point(269, 173);
            LabelRUBInput.Name = "LabelRUBInput";
            LabelRUBInput.Size = new Size(79, 28);
            LabelRUBInput.TabIndex = 9;
            LabelRUBInput.Text = "рублей";
            // 
            // LabelTextOutput
            // 
            LabelTextOutput.AutoSize = true;
            LabelTextOutput.Location = new Point(11, 213);
            LabelTextOutput.Name = "LabelTextOutput";
            LabelTextOutput.Size = new Size(95, 28);
            LabelTextOutput.TabIndex = 10;
            LabelTextOutput.Text = "Я получу";
            // 
            // LabelRUBOutput
            // 
            LabelRUBOutput.AutoSize = true;
            LabelRUBOutput.Location = new Point(269, 213);
            LabelRUBOutput.Name = "LabelRUBOutput";
            LabelRUBOutput.Size = new Size(79, 28);
            LabelRUBOutput.TabIndex = 11;
            LabelRUBOutput.Text = "рублей";
            // 
            // LabelTextLost
            // 
            LabelTextLost.AutoSize = true;
            LabelTextLost.Location = new Point(11, 253);
            LabelTextLost.Name = "LabelTextLost";
            LabelTextLost.Size = new Size(109, 28);
            LabelTextLost.TabIndex = 12;
            LabelTextLost.Text = "Я потеряю";
            // 
            // LabelRUBLost
            // 
            LabelRUBLost.AutoSize = true;
            LabelRUBLost.Location = new Point(269, 253);
            LabelRUBLost.Name = "LabelRUBLost";
            LabelRUBLost.Size = new Size(79, 28);
            LabelRUBLost.TabIndex = 13;
            LabelRUBLost.Text = "рублей";
            // 
            // TextBoxLost
            // 
            TextBoxLost.Location = new Point(138, 253);
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
            LabelRUBLostPercent.Location = new Point(345, 253);
            LabelRUBLostPercent.Name = "LabelRUBLostPercent";
            LabelRUBLostPercent.Size = new Size(65, 28);
            LabelRUBLostPercent.TabIndex = 15;
            LabelRUBLostPercent.Text = "(+0%)";
            LabelRUBLostPercent.Visible = false;
            // 
            // PictureBoxKZTUSD
            // 
            PictureBoxKZTUSD.Location = new Point(11, 114);
            PictureBoxKZTUSD.Name = "PictureBoxKZTUSD";
            PictureBoxKZTUSD.Size = new Size(30, 30);
            PictureBoxKZTUSD.TabIndex = 16;
            PictureBoxKZTUSD.TabStop = false;
            // 
            // LabelKZT_USD
            // 
            LabelKZT_USD.AutoSize = true;
            LabelKZT_USD.Location = new Point(48, 114);
            LabelKZT_USD.Name = "LabelKZT_USD";
            LabelKZT_USD.Size = new Size(176, 28);
            LabelKZT_USD.TabIndex = 17;
            LabelKZT_USD.Text = "Тенге за доллар - ";
            // 
            // LabelInputKZT
            // 
            LabelInputKZT.AutoSize = true;
            LabelInputKZT.Location = new Point(138, 142);
            LabelInputKZT.Name = "LabelInputKZT";
            LabelInputKZT.Size = new Size(46, 28);
            LabelInputKZT.TabIndex = 18;
            LabelInputKZT.Text = "(0₸)";
            LabelInputKZT.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 303);
            Controls.Add(LabelInputKZT);
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
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(460, 350);
            MinimumSize = new Size(460, 350);
            Name = "MainForm";
            Text = "Steam Currency by OliveWizard";
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZT).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSD).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZTUSD).EndInit();
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
        private Label LabelInputKZT;
    }
}