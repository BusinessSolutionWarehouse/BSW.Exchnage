namespace PackList.ExchangePlugin.Transformation
{
    partial class frmMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.lstInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstInfo
            // 
            this.lstInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstInfo.Location = new System.Drawing.Point(0, 0);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(490, 261);
            this.lstInfo.TabIndex = 5;
            this.lstInfo.UseCompatibleStateImageBehavior = false;
            this.lstInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 485;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 261);
            this.Controls.Add(this.lstInfo);
            this.Name = "frmMain";
            this.Text = "Pack List Transformation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

