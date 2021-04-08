namespace Chess_ai_design
{
    partial class TableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BoardPanel.BackgroundImage")));
            this.BoardPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BoardPanel.Location = new System.Drawing.Point(197, 26);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(400, 400);
            this.BoardPanel.TabIndex = 0;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BoardPanel);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BoardPanel;
    }
}