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
            LabelUsdQiwi = new Label();
            LabelUsdSteam = new Label();
            PictureBoxSteam = new PictureBox();
            PictureBoxQiwi = new PictureBox();
            TextBoxInput1 = new TextBox();
            TextBoxOutput1 = new TextBox();
            LabelTextInput1 = new Label();
            LabelTextOutput1 = new Label();
            LabelTextLost1 = new Label();
            TextBoxLost1 = new TextBox();
            LabelRUBLostPercent1 = new Label();
            TextBoxSend1 = new TextBox();
            LabelTextSend1 = new Label();
            ButtonReverse = new Button();
            PictureBoxWeb = new PictureBox();
            LabelUsdWeb = new Label();
            LabelRub1 = new Label();
            TextBoxInputUsdWeb = new TextBox();
            pictureBox1 = new PictureBox();
            LabelUsd1 = new Label();
            LabelRub11 = new Label();
            label1 = new Label();
            label2 = new Label();
            LabelRub22 = new Label();
            LabelUsd2 = new Label();
            pictureBox3 = new PictureBox();
            LabelTextSend2 = new Label();
            TextBoxSend2 = new TextBox();
            LabelRUBLostPercent2 = new Label();
            TextBoxLost2 = new TextBox();
            LabelTextLost2 = new Label();
            LabelTextOutput2 = new Label();
            LabelTextInput2 = new Label();
            TextBoxOutput2 = new TextBox();
            TextBoxInput2 = new TextBox();
            LabelRub2 = new Label();
            LabelSteam = new Label();
            LabelQiwi = new Label();
            LabelWeb = new Label();
            label3 = new Label();
            LabelRub33 = new Label();
            LabelUsd3 = new Label();
            pictureBox2 = new PictureBox();
            LabelTextSend3 = new Label();
            TextBoxSend3 = new TextBox();
            LabelRUBLostPercent3 = new Label();
            TextBoxLost3 = new TextBox();
            LabelTextLost3 = new Label();
            LabelTextOutput3 = new Label();
            LabelTextInput3 = new Label();
            TextBoxOutput3 = new TextBox();
            TextBoxInput3 = new TextBox();
            LabelRub3 = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSteam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxQiwi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxWeb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // ButtonGetRates
            // 
            ButtonGetRates.Location = new Point(13, 13);
            ButtonGetRates.Margin = new Padding(4);
            ButtonGetRates.Name = "ButtonGetRates";
            ButtonGetRates.Size = new Size(135, 40);
            ButtonGetRates.TabIndex = 0;
            ButtonGetRates.Text = "Узнать";
            ButtonGetRates.UseVisualStyleBackColor = true;
            ButtonGetRates.Click += ButtonGet_Click;
            // 
            // LabelUsdQiwi
            // 
            LabelUsdQiwi.AutoSize = true;
            LabelUsdQiwi.Location = new Point(181, 98);
            LabelUsdQiwi.Name = "LabelUsdQiwi";
            LabelUsdQiwi.Size = new Size(55, 28);
            LabelUsdQiwi.TabIndex = 1;
            LabelUsdQiwi.Text = "Курс";
            // 
            // LabelUsdSteam
            // 
            LabelUsdSteam.AutoSize = true;
            LabelUsdSteam.Location = new Point(181, 62);
            LabelUsdSteam.Name = "LabelUsdSteam";
            LabelUsdSteam.Size = new Size(55, 28);
            LabelUsdSteam.TabIndex = 2;
            LabelUsdSteam.Text = "Курс";
            // 
            // PictureBoxSteam
            // 
            PictureBoxSteam.Location = new Point(14, 62);
            PictureBoxSteam.Name = "PictureBoxSteam";
            PictureBoxSteam.Size = new Size(30, 30);
            PictureBoxSteam.TabIndex = 4;
            PictureBoxSteam.TabStop = false;
            // 
            // PictureBoxQiwi
            // 
            PictureBoxQiwi.Location = new Point(14, 98);
            PictureBoxQiwi.Name = "PictureBoxQiwi";
            PictureBoxQiwi.Size = new Size(30, 30);
            PictureBoxQiwi.TabIndex = 5;
            PictureBoxQiwi.TabStop = false;
            // 
            // TextBoxInput1
            // 
            TextBoxInput1.Enabled = false;
            TextBoxInput1.Location = new Point(140, 221);
            TextBoxInput1.Name = "TextBoxInput1";
            TextBoxInput1.Size = new Size(125, 34);
            TextBoxInput1.TabIndex = 6;
            TextBoxInput1.Text = "0";
            TextBoxInput1.TextChanged += TextBoxInput1_TextChanged;
            // 
            // TextBoxOutput1
            // 
            TextBoxOutput1.Location = new Point(140, 301);
            TextBoxOutput1.Name = "TextBoxOutput1";
            TextBoxOutput1.ReadOnly = true;
            TextBoxOutput1.Size = new Size(125, 34);
            TextBoxOutput1.TabIndex = 7;
            TextBoxOutput1.Text = "0";
            TextBoxOutput1.TextChanged += TextBoxOutput1_TextChanged;
            // 
            // LabelTextInput1
            // 
            LabelTextInput1.AutoSize = true;
            LabelTextInput1.Location = new Point(13, 224);
            LabelTextInput1.Name = "LabelTextInput1";
            LabelTextInput1.Size = new Size(121, 28);
            LabelTextInput1.TabIndex = 8;
            LabelTextInput1.Text = "Я отправлю";
            // 
            // LabelTextOutput1
            // 
            LabelTextOutput1.AutoSize = true;
            LabelTextOutput1.Location = new Point(13, 304);
            LabelTextOutput1.Name = "LabelTextOutput1";
            LabelTextOutput1.Size = new Size(95, 28);
            LabelTextOutput1.TabIndex = 10;
            LabelTextOutput1.Text = "Я получу";
            // 
            // LabelTextLost1
            // 
            LabelTextLost1.AutoSize = true;
            LabelTextLost1.Location = new Point(13, 344);
            LabelTextLost1.Name = "LabelTextLost1";
            LabelTextLost1.Size = new Size(109, 28);
            LabelTextLost1.TabIndex = 12;
            LabelTextLost1.Text = "Я потеряю";
            // 
            // TextBoxLost1
            // 
            TextBoxLost1.Location = new Point(140, 341);
            TextBoxLost1.Name = "TextBoxLost1";
            TextBoxLost1.ReadOnly = true;
            TextBoxLost1.Size = new Size(125, 34);
            TextBoxLost1.TabIndex = 14;
            TextBoxLost1.Text = "0";
            // 
            // LabelRUBLostPercent1
            // 
            LabelRUBLostPercent1.AutoSize = true;
            LabelRUBLostPercent1.Location = new Point(271, 344);
            LabelRUBLostPercent1.Name = "LabelRUBLostPercent1";
            LabelRUBLostPercent1.Size = new Size(65, 28);
            LabelRUBLostPercent1.TabIndex = 15;
            LabelRUBLostPercent1.Text = "(+0%)";
            LabelRUBLostPercent1.Visible = false;
            // 
            // TextBoxSend1
            // 
            TextBoxSend1.Location = new Point(140, 261);
            TextBoxSend1.Name = "TextBoxSend1";
            TextBoxSend1.ReadOnly = true;
            TextBoxSend1.Size = new Size(125, 34);
            TextBoxSend1.TabIndex = 20;
            TextBoxSend1.Text = "0";
            // 
            // LabelTextSend1
            // 
            LabelTextSend1.AutoSize = true;
            LabelTextSend1.Location = new Point(13, 264);
            LabelTextSend1.Name = "LabelTextSend1";
            LabelTextSend1.Size = new Size(47, 28);
            LabelTextSend1.TabIndex = 21;
            LabelTextSend1.Text = "или";
            // 
            // ButtonReverse
            // 
            ButtonReverse.BackgroundImageLayout = ImageLayout.None;
            ButtonReverse.Image = Properties.Resources.rev_c;
            ButtonReverse.Location = new Point(155, 14);
            ButtonReverse.Name = "ButtonReverse";
            ButtonReverse.Size = new Size(40, 40);
            ButtonReverse.TabIndex = 22;
            ButtonReverse.UseVisualStyleBackColor = true;
            ButtonReverse.Click += ButtonReverse_Click;
            // 
            // PictureBoxWeb
            // 
            PictureBoxWeb.Location = new Point(14, 134);
            PictureBoxWeb.Name = "PictureBoxWeb";
            PictureBoxWeb.Size = new Size(30, 30);
            PictureBoxWeb.TabIndex = 24;
            PictureBoxWeb.TabStop = false;
            // 
            // LabelUsdWeb
            // 
            LabelUsdWeb.AutoSize = true;
            LabelUsdWeb.Location = new Point(181, 134);
            LabelUsdWeb.Name = "LabelUsdWeb";
            LabelUsdWeb.Size = new Size(55, 28);
            LabelUsdWeb.TabIndex = 23;
            LabelUsdWeb.Text = "Курс";
            // 
            // LabelRub1
            // 
            LabelRub1.AutoSize = true;
            LabelRub1.Location = new Point(271, 224);
            LabelRub1.Name = "LabelRub1";
            LabelRub1.Size = new Size(23, 28);
            LabelRub1.TabIndex = 27;
            LabelRub1.Text = "₽";
            // 
            // TextBoxInputUsdWeb
            // 
            TextBoxInputUsdWeb.Location = new Point(917, 180);
            TextBoxInputUsdWeb.Name = "TextBoxInputUsdWeb";
            TextBoxInputUsdWeb.Size = new Size(125, 34);
            TextBoxInputUsdWeb.TabIndex = 28;
            TextBoxInputUsdWeb.Text = "0";
            TextBoxInputUsdWeb.TextChanged += TextBoxInputUsdWeb_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.qiwi_c;
            pictureBox1.Location = new Point(14, 180);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // LabelUsd1
            // 
            LabelUsd1.AutoSize = true;
            LabelUsd1.Location = new Point(271, 264);
            LabelUsd1.Name = "LabelUsd1";
            LabelUsd1.Size = new Size(23, 28);
            LabelUsd1.TabIndex = 31;
            LabelUsd1.Text = "$";
            // 
            // LabelRub11
            // 
            LabelRub11.AutoSize = true;
            LabelRub11.Location = new Point(271, 304);
            LabelRub11.Name = "LabelRub11";
            LabelRub11.Size = new Size(23, 28);
            LabelRub11.TabIndex = 32;
            LabelRub11.Text = "₽";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 180);
            label1.Name = "label1";
            label1.Size = new Size(150, 28);
            label1.TabIndex = 33;
            label1.Text = "через доллары";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 180);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 47;
            label2.Text = "через тенге";
            // 
            // LabelRub22
            // 
            LabelRub22.AutoSize = true;
            LabelRub22.Location = new Point(610, 304);
            LabelRub22.Name = "LabelRub22";
            LabelRub22.Size = new Size(23, 28);
            LabelRub22.TabIndex = 46;
            LabelRub22.Text = "₽";
            // 
            // LabelUsd2
            // 
            LabelUsd2.AutoSize = true;
            LabelUsd2.Location = new Point(610, 264);
            LabelUsd2.Name = "LabelUsd2";
            LabelUsd2.Size = new Size(23, 28);
            LabelUsd2.TabIndex = 45;
            LabelUsd2.Text = "₸";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.qiwi_c;
            pictureBox3.Location = new Point(353, 180);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.TabIndex = 44;
            pictureBox3.TabStop = false;
            // 
            // LabelTextSend2
            // 
            LabelTextSend2.AutoSize = true;
            LabelTextSend2.Location = new Point(352, 264);
            LabelTextSend2.Name = "LabelTextSend2";
            LabelTextSend2.Size = new Size(47, 28);
            LabelTextSend2.TabIndex = 42;
            LabelTextSend2.Text = "или";
            // 
            // TextBoxSend2
            // 
            TextBoxSend2.Location = new Point(479, 261);
            TextBoxSend2.Name = "TextBoxSend2";
            TextBoxSend2.ReadOnly = true;
            TextBoxSend2.Size = new Size(125, 34);
            TextBoxSend2.TabIndex = 41;
            TextBoxSend2.Text = "0";
            // 
            // LabelRUBLostPercent2
            // 
            LabelRUBLostPercent2.AutoSize = true;
            LabelRUBLostPercent2.Location = new Point(610, 344);
            LabelRUBLostPercent2.Name = "LabelRUBLostPercent2";
            LabelRUBLostPercent2.Size = new Size(65, 28);
            LabelRUBLostPercent2.TabIndex = 40;
            LabelRUBLostPercent2.Text = "(+0%)";
            LabelRUBLostPercent2.Visible = false;
            // 
            // TextBoxLost2
            // 
            TextBoxLost2.Location = new Point(479, 341);
            TextBoxLost2.Name = "TextBoxLost2";
            TextBoxLost2.ReadOnly = true;
            TextBoxLost2.Size = new Size(125, 34);
            TextBoxLost2.TabIndex = 39;
            TextBoxLost2.Text = "0";
            // 
            // LabelTextLost2
            // 
            LabelTextLost2.AutoSize = true;
            LabelTextLost2.Location = new Point(352, 344);
            LabelTextLost2.Name = "LabelTextLost2";
            LabelTextLost2.Size = new Size(109, 28);
            LabelTextLost2.TabIndex = 38;
            LabelTextLost2.Text = "Я потеряю";
            // 
            // LabelTextOutput2
            // 
            LabelTextOutput2.AutoSize = true;
            LabelTextOutput2.Location = new Point(352, 304);
            LabelTextOutput2.Name = "LabelTextOutput2";
            LabelTextOutput2.Size = new Size(95, 28);
            LabelTextOutput2.TabIndex = 37;
            LabelTextOutput2.Text = "Я получу";
            // 
            // LabelTextInput2
            // 
            LabelTextInput2.AutoSize = true;
            LabelTextInput2.Location = new Point(352, 224);
            LabelTextInput2.Name = "LabelTextInput2";
            LabelTextInput2.Size = new Size(121, 28);
            LabelTextInput2.TabIndex = 36;
            LabelTextInput2.Text = "Я отправлю";
            // 
            // TextBoxOutput2
            // 
            TextBoxOutput2.Location = new Point(479, 301);
            TextBoxOutput2.Name = "TextBoxOutput2";
            TextBoxOutput2.ReadOnly = true;
            TextBoxOutput2.Size = new Size(125, 34);
            TextBoxOutput2.TabIndex = 35;
            TextBoxOutput2.Text = "0";
            TextBoxOutput2.TextChanged += TextBoxOutput2_TextChanged;
            // 
            // TextBoxInput2
            // 
            TextBoxInput2.Enabled = false;
            TextBoxInput2.Location = new Point(479, 221);
            TextBoxInput2.Name = "TextBoxInput2";
            TextBoxInput2.Size = new Size(125, 34);
            TextBoxInput2.TabIndex = 34;
            TextBoxInput2.Text = "0";
            TextBoxInput2.TextChanged += TextBoxInput2_TextChanged;
            // 
            // LabelRub2
            // 
            LabelRub2.AutoSize = true;
            LabelRub2.Location = new Point(610, 224);
            LabelRub2.Name = "LabelRub2";
            LabelRub2.Size = new Size(23, 28);
            LabelRub2.TabIndex = 43;
            LabelRub2.Text = "₽";
            // 
            // LabelSteam
            // 
            LabelSteam.AutoSize = true;
            LabelSteam.Location = new Point(50, 62);
            LabelSteam.Name = "LabelSteam";
            LabelSteam.Size = new Size(79, 28);
            LabelSteam.TabIndex = 48;
            LabelSteam.Text = "- Steam";
            // 
            // LabelQiwi
            // 
            LabelQiwi.AutoSize = true;
            LabelQiwi.Location = new Point(50, 98);
            LabelQiwi.Name = "LabelQiwi";
            LabelQiwi.Size = new Size(64, 28);
            LabelQiwi.TabIndex = 49;
            LabelQiwi.Text = "- Qiwi";
            // 
            // LabelWeb
            // 
            LabelWeb.AutoSize = true;
            LabelWeb.Location = new Point(50, 134);
            LabelWeb.Name = "LabelWeb";
            LabelWeb.Size = new Size(125, 28);
            LabelWeb.TabIndex = 50;
            LabelWeb.Text = "- Webmoney";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(728, 180);
            label3.Name = "label3";
            label3.Size = new Size(183, 28);
            label3.TabIndex = 64;
            label3.Text = "через PtP по курсу";
            // 
            // LabelRub33
            // 
            LabelRub33.AutoSize = true;
            LabelRub33.Location = new Point(949, 304);
            LabelRub33.Name = "LabelRub33";
            LabelRub33.Size = new Size(23, 28);
            LabelRub33.TabIndex = 63;
            LabelRub33.Text = "₽";
            // 
            // LabelUsd3
            // 
            LabelUsd3.AutoSize = true;
            LabelUsd3.Location = new Point(949, 264);
            LabelUsd3.Name = "LabelUsd3";
            LabelUsd3.Size = new Size(23, 28);
            LabelUsd3.TabIndex = 62;
            LabelUsd3.Text = "$";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.wm_c;
            pictureBox2.Location = new Point(692, 180);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.TabIndex = 61;
            pictureBox2.TabStop = false;
            // 
            // LabelTextSend3
            // 
            LabelTextSend3.AutoSize = true;
            LabelTextSend3.Location = new Point(691, 264);
            LabelTextSend3.Name = "LabelTextSend3";
            LabelTextSend3.Size = new Size(47, 28);
            LabelTextSend3.TabIndex = 59;
            LabelTextSend3.Text = "или";
            // 
            // TextBoxSend3
            // 
            TextBoxSend3.Location = new Point(818, 261);
            TextBoxSend3.Name = "TextBoxSend3";
            TextBoxSend3.ReadOnly = true;
            TextBoxSend3.Size = new Size(125, 34);
            TextBoxSend3.TabIndex = 58;
            TextBoxSend3.Text = "0";
            // 
            // LabelRUBLostPercent3
            // 
            LabelRUBLostPercent3.AutoSize = true;
            LabelRUBLostPercent3.Location = new Point(949, 344);
            LabelRUBLostPercent3.Name = "LabelRUBLostPercent3";
            LabelRUBLostPercent3.Size = new Size(65, 28);
            LabelRUBLostPercent3.TabIndex = 57;
            LabelRUBLostPercent3.Text = "(+0%)";
            LabelRUBLostPercent3.Visible = false;
            // 
            // TextBoxLost3
            // 
            TextBoxLost3.Location = new Point(818, 341);
            TextBoxLost3.Name = "TextBoxLost3";
            TextBoxLost3.ReadOnly = true;
            TextBoxLost3.Size = new Size(125, 34);
            TextBoxLost3.TabIndex = 56;
            TextBoxLost3.Text = "0";
            // 
            // LabelTextLost3
            // 
            LabelTextLost3.AutoSize = true;
            LabelTextLost3.Location = new Point(691, 344);
            LabelTextLost3.Name = "LabelTextLost3";
            LabelTextLost3.Size = new Size(109, 28);
            LabelTextLost3.TabIndex = 55;
            LabelTextLost3.Text = "Я потеряю";
            // 
            // LabelTextOutput3
            // 
            LabelTextOutput3.AutoSize = true;
            LabelTextOutput3.Location = new Point(691, 304);
            LabelTextOutput3.Name = "LabelTextOutput3";
            LabelTextOutput3.Size = new Size(95, 28);
            LabelTextOutput3.TabIndex = 54;
            LabelTextOutput3.Text = "Я получу";
            // 
            // LabelTextInput3
            // 
            LabelTextInput3.AutoSize = true;
            LabelTextInput3.Location = new Point(691, 224);
            LabelTextInput3.Name = "LabelTextInput3";
            LabelTextInput3.Size = new Size(121, 28);
            LabelTextInput3.TabIndex = 53;
            LabelTextInput3.Text = "Я отправлю";
            // 
            // TextBoxOutput3
            // 
            TextBoxOutput3.Location = new Point(818, 301);
            TextBoxOutput3.Name = "TextBoxOutput3";
            TextBoxOutput3.ReadOnly = true;
            TextBoxOutput3.Size = new Size(125, 34);
            TextBoxOutput3.TabIndex = 52;
            TextBoxOutput3.Text = "0";
            TextBoxOutput3.TextChanged += TextBoxOutput3_TextChanged;
            // 
            // TextBoxInput3
            // 
            TextBoxInput3.Enabled = false;
            TextBoxInput3.Location = new Point(818, 221);
            TextBoxInput3.Name = "TextBoxInput3";
            TextBoxInput3.Size = new Size(125, 34);
            TextBoxInput3.TabIndex = 51;
            TextBoxInput3.Text = "0";
            TextBoxInput3.TextChanged += TextBoxInput3_TextChanged;
            // 
            // LabelRub3
            // 
            LabelRub3.AutoSize = true;
            LabelRub3.Location = new Point(949, 224);
            LabelRub3.Name = "LabelRub3";
            LabelRub3.Size = new Size(23, 28);
            LabelRub3.TabIndex = 60;
            LabelRub3.Text = "₽";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 391);
            Controls.Add(label3);
            Controls.Add(LabelRub33);
            Controls.Add(LabelUsd3);
            Controls.Add(pictureBox2);
            Controls.Add(LabelTextSend3);
            Controls.Add(TextBoxSend3);
            Controls.Add(LabelRUBLostPercent3);
            Controls.Add(TextBoxLost3);
            Controls.Add(LabelTextLost3);
            Controls.Add(LabelTextOutput3);
            Controls.Add(LabelTextInput3);
            Controls.Add(TextBoxOutput3);
            Controls.Add(TextBoxInput3);
            Controls.Add(LabelRub3);
            Controls.Add(LabelWeb);
            Controls.Add(LabelQiwi);
            Controls.Add(LabelSteam);
            Controls.Add(label2);
            Controls.Add(LabelRub22);
            Controls.Add(LabelUsd2);
            Controls.Add(pictureBox3);
            Controls.Add(LabelTextSend2);
            Controls.Add(TextBoxSend2);
            Controls.Add(LabelRUBLostPercent2);
            Controls.Add(TextBoxLost2);
            Controls.Add(LabelTextLost2);
            Controls.Add(LabelTextOutput2);
            Controls.Add(LabelTextInput2);
            Controls.Add(TextBoxOutput2);
            Controls.Add(TextBoxInput2);
            Controls.Add(LabelRub2);
            Controls.Add(label1);
            Controls.Add(LabelRub11);
            Controls.Add(LabelUsd1);
            Controls.Add(pictureBox1);
            Controls.Add(PictureBoxWeb);
            Controls.Add(LabelUsdWeb);
            Controls.Add(ButtonReverse);
            Controls.Add(LabelTextSend1);
            Controls.Add(TextBoxSend1);
            Controls.Add(LabelRUBLostPercent1);
            Controls.Add(TextBoxLost1);
            Controls.Add(LabelTextLost1);
            Controls.Add(LabelTextOutput1);
            Controls.Add(LabelTextInput1);
            Controls.Add(TextBoxOutput1);
            Controls.Add(TextBoxInput1);
            Controls.Add(PictureBoxQiwi);
            Controls.Add(PictureBoxSteam);
            Controls.Add(LabelUsdQiwi);
            Controls.Add(LabelUsdSteam);
            Controls.Add(ButtonGetRates);
            Controls.Add(LabelRub1);
            Controls.Add(TextBoxInputUsdWeb);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1084, 438);
            MinimumSize = new Size(1084, 438);
            Name = "MainForm";
            Text = "Steam Currency от OliveWizard";
            ((System.ComponentModel.ISupportInitialize)PictureBoxSteam).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxQiwi).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxWeb).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonGetRates;
        private Label LabelUsdQiwi;
        private Label LabelUsdSteam;
        private PictureBox PictureBoxSteam;
        private PictureBox PictureBoxQiwi;
        private TextBox TextBoxInput1;
        private TextBox TextBoxOutput1;
        private Label LabelTextInput1;
        private Label LabelTextOutput1;
        private Label LabelTextLost1;
        private TextBox TextBoxLost1;
        private Label LabelRUBLostPercent1;
        private TextBox TextBoxSend1;
        private Label LabelTextSend1;
        private Button ButtonReverse;
        private PictureBox PictureBoxWeb;
        private Label LabelUsdWeb;
        private Label LabelRub1;
        private TextBox TextBoxInputUsdWeb;
        private PictureBox pictureBox1;
        private Label LabelUsd1;
        private Label LabelRub11;
        private Label label1;
        private Label label2;
        private Label LabelRub22;
        private Label LabelUsd2;
        private PictureBox pictureBox3;
        private Label LabelTextSend2;
        private TextBox TextBoxSend2;
        private Label LabelRUBLostPercent2;
        private TextBox TextBoxLost2;
        private Label LabelTextLost2;
        private Label LabelTextOutput2;
        private Label LabelTextInput2;
        private TextBox TextBoxOutput2;
        private TextBox TextBoxInput2;
        private Label LabelRub2;
        private Label LabelSteam;
        private Label LabelQiwi;
        private Label LabelWeb;
        private Label label3;
        private Label LabelRub33;
        private Label LabelUsd3;
        private PictureBox pictureBox2;
        private Label LabelTextSend3;
        private TextBox TextBoxSend3;
        private Label LabelRUBLostPercent3;
        private TextBox TextBoxLost3;
        private Label LabelTextLost3;
        private Label LabelTextOutput3;
        private Label LabelTextInput3;
        private TextBox TextBoxOutput3;
        private TextBox TextBoxInput3;
        private Label LabelRub3;
    }
}