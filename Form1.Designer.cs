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
            this.ButtonGet = new System.Windows.Forms.Button();
            this.LabelUSD = new System.Windows.Forms.Label();
            this.LabelKZT = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.PictureBoxKZT = new System.Windows.Forms.PictureBox();
            this.PictureBoxUSD = new System.Windows.Forms.PictureBox();
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.TextBoxOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRUB1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRUB2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRUB3 = new System.Windows.Forms.Label();
            this.TextBoxLost = new System.Windows.Forms.TextBox();
            this.labelPercent = new System.Windows.Forms.Label();
            this.PictureBoxKZTUSD = new System.Windows.Forms.PictureBox();
            this.LabelKZTUSD = new System.Windows.Forms.Label();
            this.LabelInput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKZT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKZTUSD)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonGet
            // 
            this.ButtonGet.Location = new System.Drawing.Point(294, 13);
            this.ButtonGet.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonGet.Name = "ButtonGet";
            this.ButtonGet.Size = new System.Drawing.Size(135, 40);
            this.ButtonGet.TabIndex = 0;
            this.ButtonGet.Text = "Получить";
            this.ButtonGet.UseVisualStyleBackColor = true;
            this.ButtonGet.Click += new System.EventHandler(this.ButtonGet_Click);
            // 
            // LabelUSD
            // 
            this.LabelUSD.AutoSize = true;
            this.LabelUSD.Location = new System.Drawing.Point(46, 76);
            this.LabelUSD.Name = "LabelUSD";
            this.LabelUSD.Size = new System.Drawing.Size(100, 28);
            this.LabelUSD.TabIndex = 1;
            this.LabelUSD.Text = "Доллар - ";
            // 
            // LabelKZT
            // 
            this.LabelKZT.AutoSize = true;
            this.LabelKZT.Location = new System.Drawing.Point(48, 40);
            this.LabelKZT.Name = "LabelKZT";
            this.LabelKZT.Size = new System.Drawing.Size(80, 28);
            this.LabelKZT.TabIndex = 2;
            this.LabelKZT.Text = "Тенге - ";
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Location = new System.Drawing.Point(11, 9);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(134, 28);
            this.MainLabel.TabIndex = 3;
            this.MainLabel.Text = "Курсы валют:";
            // 
            // PictureBoxKZT
            // 
            this.PictureBoxKZT.Location = new System.Drawing.Point(12, 40);
            this.PictureBoxKZT.Name = "PictureBoxKZT";
            this.PictureBoxKZT.Size = new System.Drawing.Size(30, 30);
            this.PictureBoxKZT.TabIndex = 4;
            this.PictureBoxKZT.TabStop = false;
            // 
            // PictureBoxUSD
            // 
            this.PictureBoxUSD.Location = new System.Drawing.Point(12, 76);
            this.PictureBoxUSD.Name = "PictureBoxUSD";
            this.PictureBoxUSD.Size = new System.Drawing.Size(30, 30);
            this.PictureBoxUSD.TabIndex = 5;
            this.PictureBoxUSD.TabStop = false;
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Enabled = false;
            this.TextBoxInput.Location = new System.Drawing.Point(138, 173);
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.Size = new System.Drawing.Size(125, 34);
            this.TextBoxInput.TabIndex = 6;
            this.TextBoxInput.Text = "0";
            this.TextBoxInput.TextChanged += new System.EventHandler(this.TextBoxInput_TextChanged);
            // 
            // TextBoxOutput
            // 
            this.TextBoxOutput.Location = new System.Drawing.Point(138, 213);
            this.TextBoxOutput.Name = "TextBoxOutput";
            this.TextBoxOutput.ReadOnly = true;
            this.TextBoxOutput.Size = new System.Drawing.Size(125, 34);
            this.TextBoxOutput.TabIndex = 7;
            this.TextBoxOutput.Text = "0";
            this.TextBoxOutput.TextChanged += new System.EventHandler(this.TextBoxOutput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Я отправлю";
            // 
            // labelRUB1
            // 
            this.labelRUB1.AutoSize = true;
            this.labelRUB1.Location = new System.Drawing.Point(269, 176);
            this.labelRUB1.Name = "labelRUB1";
            this.labelRUB1.Size = new System.Drawing.Size(79, 28);
            this.labelRUB1.TabIndex = 9;
            this.labelRUB1.Text = "рублей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Я получу";
            // 
            // labelRUB2
            // 
            this.labelRUB2.AutoSize = true;
            this.labelRUB2.Location = new System.Drawing.Point(269, 219);
            this.labelRUB2.Name = "labelRUB2";
            this.labelRUB2.Size = new System.Drawing.Size(79, 28);
            this.labelRUB2.TabIndex = 11;
            this.labelRUB2.Text = "рублей";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Я потеряю";
            // 
            // labelRUB3
            // 
            this.labelRUB3.AutoSize = true;
            this.labelRUB3.Location = new System.Drawing.Point(269, 257);
            this.labelRUB3.Name = "labelRUB3";
            this.labelRUB3.Size = new System.Drawing.Size(79, 28);
            this.labelRUB3.TabIndex = 13;
            this.labelRUB3.Text = "рублей";
            // 
            // TextBoxLost
            // 
            this.TextBoxLost.Location = new System.Drawing.Point(138, 253);
            this.TextBoxLost.Name = "TextBoxLost";
            this.TextBoxLost.ReadOnly = true;
            this.TextBoxLost.Size = new System.Drawing.Size(125, 34);
            this.TextBoxLost.TabIndex = 14;
            this.TextBoxLost.Text = "0";
            this.TextBoxLost.TextChanged += new System.EventHandler(this.TextBoxLost_TextChanged);
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(345, 256);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(65, 28);
            this.labelPercent.TabIndex = 15;
            this.labelPercent.Text = "(+0%)";
            this.labelPercent.Visible = false;
            // 
            // PictureBoxKZTUSD
            // 
            this.PictureBoxKZTUSD.Location = new System.Drawing.Point(12, 112);
            this.PictureBoxKZTUSD.Name = "PictureBoxKZTUSD";
            this.PictureBoxKZTUSD.Size = new System.Drawing.Size(30, 30);
            this.PictureBoxKZTUSD.TabIndex = 16;
            this.PictureBoxKZTUSD.TabStop = false;
            // 
            // LabelKZTUSD
            // 
            this.LabelKZTUSD.AutoSize = true;
            this.LabelKZTUSD.Location = new System.Drawing.Point(48, 114);
            this.LabelKZTUSD.Name = "LabelKZTUSD";
            this.LabelKZTUSD.Size = new System.Drawing.Size(176, 28);
            this.LabelKZTUSD.TabIndex = 17;
            this.LabelKZTUSD.Text = "Тенге за доллар - ";
            // 
            // LabelInput
            // 
            this.LabelInput.AutoSize = true;
            this.LabelInput.Location = new System.Drawing.Point(269, 148);
            this.LabelInput.Name = "LabelInput";
            this.LabelInput.Size = new System.Drawing.Size(46, 28);
            this.LabelInput.TabIndex = 18;
            this.LabelInput.Text = "(0₸)";
            this.LabelInput.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 303);
            this.Controls.Add(this.LabelInput);
            this.Controls.Add(this.LabelKZTUSD);
            this.Controls.Add(this.PictureBoxKZTUSD);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.TextBoxLost);
            this.Controls.Add(this.labelRUB3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelRUB2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRUB1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxOutput);
            this.Controls.Add(this.TextBoxInput);
            this.Controls.Add(this.PictureBoxUSD);
            this.Controls.Add(this.PictureBoxKZT);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.LabelUSD);
            this.Controls.Add(this.LabelKZT);
            this.Controls.Add(this.ButtonGet);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 350);
            this.MinimumSize = new System.Drawing.Size(460, 350);
            this.Name = "MainForm";
            this.Text = "Steam Currency by OliveWizard";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKZT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxKZTUSD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label LabelKZTUSD;
        private Label LabelInput;
    }
}