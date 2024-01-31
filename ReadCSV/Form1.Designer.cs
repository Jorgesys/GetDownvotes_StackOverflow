
namespace ReadCSV
{
    partial class Form1
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
            this.btnReadCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadCompare
            // 
            this.btnReadCompare.Location = new System.Drawing.Point(657, 12);
            this.btnReadCompare.Name = "btnReadCompare";
            this.btnReadCompare.Size = new System.Drawing.Size(131, 27);
            this.btnReadCompare.TabIndex = 0;
            this.btnReadCompare.Text = "Read and Compare";
            this.btnReadCompare.UseVisualStyleBackColor = true;
            this.btnReadCompare.Click += new System.EventHandler(this.btnReadCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReadCompare);
            this.Name = "Form1";
            this.Text = "Read .CSV";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadCompare;
    }
}

