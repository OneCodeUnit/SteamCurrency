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
            ButtonGet = new Button();
            LabelUSD = new Label();
            LabelKZT = new Label();
            MainLabel = new Label();
            PictureBoxKZT = new PictureBox();
            PictureBoxUSD = new PictureBox();
            TextBoxInput = new TextBox();
            TextBoxOutput = new TextBox();
            label1 = new Label();
            labelRUB1 = new Label();
            label2 = new Label();
            labelRUB2 = new Label();
            label3 = new Label();
            labelRUB3 = new Label();
            TextBoxLost = new TextBox();
            labelPercent = new Label();
            PictureBoxKZTUSD = new PictureBox();
            LabelKZT_USD = new Label();
            LabelInput = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxUSD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxKZTUSD).BeginInit();
            SuspendLayout();
            // 
            // ButtonGet
            // 
            ButtonGet.Location = new Point(294, 13);
            ButtonGet.Margin = new Padding(4);
            ButtonGet.Name = "ButtonGet";
            ButtonGet.Size = new Size(135, 40);
            ButtonGet.TabIndex = 0;
            ButtonGet.Text = "Получить";
            ButtonGet.UseVisualStyleBackColor = true;
            ButtonGet.Click += ButtonGet_Click;
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
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Location = new Point(11, 9);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(134, 28);
            MainLabel.TabIndex = 3;
            MainLabel.Text = "Курсы валют:";
            // 
            // PictureBoxKZT
            // 
            PictureBoxKZT.Location = new Point(12, 40);
            PictureBoxKZT.Name = "PictureBoxKZT";
            PictureBoxKZT.Size = new Size(30, 30);
            PictureBoxKZT.TabIndex = 4;
            PictureBoxKZT.TabStop = false;
            // 
            // PictureBoxUSD
            // 
            PictureBoxUSD.Location = new Point(12, 76);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 176);
            label1.Name = "label1";
            label1.Size = new Size(121, 28);
            label1.TabIndex = 8;
            label1.Text = "Я отправлю";
            // 
            // labelRUB1
            // 
            labelRUB1.AutoSize = true;
            labelRUB1.Location = new Point(269, 176);
            labelRUB1.Name = "labelRUB1";
            labelRUB1.Size = new Size(79, 28);
            labelRUB1.TabIndex = 9;
            labelRUB1.Text = "рублей";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 219);
            label2.Name = "label2";
            label2.Size = new Size(95, 28);
            label2.TabIndex = 10;
            label2.Text = "Я получу";
            // 
            // labelRUB2
            // 
            labelRUB2.AutoSize = true;
            labelRUB2.Location = new Point(269, 219);
            labelRUB2.Name = "labelRUB2";
            labelRUB2.Size = new Size(79, 28);
            labelRUB2.TabIndex = 11;
            labelRUB2.Text = "рублей";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 257);
            label3.Name = "label3";
            label3.Size = new Size(109, 28);
            label3.TabIndex = 12;
            label3.Text = "Я потеряю";
            // 
            // labelRUB3
            // 
            labelRUB3.AutoSize = true;
            labelRUB3.Location = new Point(269, 257);
            labelRUB3.Name = "labelRUB3";
            labelRUB3.Size = new Size(79, 28);
            labelRUB3.TabIndex = 13;
            labelRUB3.Text = "рублей";
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
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(345, 256);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(65, 28);
            labelPercent.TabIndex = 15;
            labelPercent.Text = "(+0%)";
            labelPercent.Visible = false;
            // 
            // PictureBoxKZTUSD
            // 
            PictureBoxKZTUSD.Location = new Point(12, 112);
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
            // LabelInput
            // 
            LabelInput.AutoSize = true;
            LabelInput.Location = new Point(138, 142);
            LabelInput.Name = "LabelInput";
            LabelInput.Size = new Size(46, 28);
            LabelInput.TabIndex = 18;
            LabelInput.Text = "(0₸)";
            LabelInput.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 303);
            Controls.Add(LabelInput);
            Controls.Add(LabelKZT_USD);
            Controls.Add(PictureBoxKZTUSD);
            Controls.Add(labelPercent);
            Controls.Add(TextBoxLost);
            Controls.Add(labelRUB3);
            Controls.Add(label3);
            Controls.Add(labelRUB2);
            Controls.Add(label2);
            Controls.Add(labelRUB1);
            Controls.Add(label1);
            Controls.Add(TextBoxOutput);
            Controls.Add(TextBoxInput);
            Controls.Add(PictureBoxUSD);
            Controls.Add(PictureBoxKZT);
            Controls.Add(MainLabel);
            Controls.Add(LabelUSD);
            Controls.Add(LabelKZT);
            Controls.Add(ButtonGet);
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

        private Button ButtonGet;
        private Label LabelUSD;
        private Label LabelKZT;
        private Label MainLabel;
        private PictureBox PictureBoxKZT;
        private PictureBox PictureBoxUSD;
        private TextBox TextBoxInput;
        private TextBox TextBoxOutput;
        private Label label1;
        private Label labelRUB1;
        private Label label2;
        private Label labelRUB2;
        private Label label3;
        private Label labelRUB3;
        private TextBox TextBoxLost;
        private Label labelPercent;
        private PictureBox PictureBoxKZTUSD;
        private Label LabelKZT_USD;
        private Label LabelInput;
    }
}