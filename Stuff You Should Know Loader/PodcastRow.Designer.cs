namespace Stuff_You_Should_Know_Loader
{
  partial class PodcastRow
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.titleLabel = new System.Windows.Forms.Label();
      this.dateLabel = new System.Windows.Forms.Label();
      this.descriptionLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox
      // 
      this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox.Location = new System.Drawing.Point(0, 0);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(120, 70);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      // 
      // titleLabel
      // 
      this.titleLabel.AutoSize = true;
      this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.titleLabel.Location = new System.Drawing.Point(127, 0);
      this.titleLabel.Name = "titleLabel";
      this.titleLabel.Size = new System.Drawing.Size(248, 24);
      this.titleLabel.TabIndex = 1;
      this.titleLabel.Text = "How XXXXXXXXXX works";
      // 
      // dateLabel
      // 
      this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.dateLabel.Location = new System.Drawing.Point(696, 8);
      this.dateLabel.Name = "dateLabel";
      this.dateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.dateLabel.Size = new System.Drawing.Size(120, 16);
      this.dateLabel.TabIndex = 2;
      this.dateLabel.Text = "Septemberr 3, 2013";
      this.dateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // descriptionLabel
      // 
      this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.descriptionLabel.Location = new System.Drawing.Point(131, 28);
      this.descriptionLabel.Name = "descriptionLabel";
      this.descriptionLabel.Size = new System.Drawing.Size(682, 42);
      this.descriptionLabel.TabIndex = 3;
      this.descriptionLabel.Text = "label1";
      // 
      // PodcastRow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.descriptionLabel);
      this.Controls.Add(this.dateLabel);
      this.Controls.Add(this.titleLabel);
      this.Controls.Add(this.pictureBox);
      this.Name = "PodcastRow";
      this.Size = new System.Drawing.Size(816, 70);
      this.Load += new System.EventHandler(this.PodcastRow_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label dateLabel;
    private System.Windows.Forms.Label descriptionLabel;
  }
}
