namespace XMLAssignment7
{
    partial class XMLMain
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
            this.goBtn = new System.Windows.Forms.Button();
            this.goRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(47, 28);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // goRTB
            // 
            this.goRTB.Location = new System.Drawing.Point(182, 14);
            this.goRTB.Name = "goRTB";
            this.goRTB.Size = new System.Drawing.Size(325, 233);
            this.goRTB.TabIndex = 1;
            this.goRTB.Text = "";
            // 
            // XMLMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 273);
            this.Controls.Add(this.goRTB);
            this.Controls.Add(this.goBtn);
            this.Name = "XMLMain";
            this.Text = "XML";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.RichTextBox goRTB;
    }
}

