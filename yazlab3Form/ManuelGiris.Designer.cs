namespace yazlab3Form
{
    partial class ManuelGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nodeList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeIsmi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nodeList
            // 
            this.nodeList.FormattingEnabled = true;
            this.nodeList.ItemHeight = 16;
            this.nodeList.Location = new System.Drawing.Point(111, 50);
            this.nodeList.Name = "nodeList";
            this.nodeList.ScrollAlwaysVisible = true;
            this.nodeList.Size = new System.Drawing.Size(753, 228);
            this.nodeList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vana İsmi";
            // 
            // nodeIsmi
            // 
            this.nodeIsmi.Location = new System.Drawing.Point(151, 311);
            this.nodeIsmi.Name = "nodeIsmi";
            this.nodeIsmi.Size = new System.Drawing.Size(100, 22);
            this.nodeIsmi.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Değiştir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(725, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Devam et";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManuelGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nodeIsmi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nodeList);
            this.Name = "ManuelGiris";
            this.Text = "ManuelGiriscs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox nodeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nodeIsmi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}