namespace MeramecNetFlixProject.UI
{
    partial class RentalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentalForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMovies = new System.Windows.Forms.Panel();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.btnSearchByGenre = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTitle.Location = new System.Drawing.Point(134, 188);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(230, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(370, 181);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(498, 893);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(300, 80);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Sign Out";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMovies
            // 
            this.panelMovies.BackColor = System.Drawing.Color.Black;
            this.panelMovies.Location = new System.Drawing.Point(6, 234);
            this.panelMovies.Name = "panelMovies";
            this.panelMovies.Size = new System.Drawing.Size(1253, 371);
            this.panelMovies.TabIndex = 17;
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbRightArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.BackgroundImage")));
            this.pbRightArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRightArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.Image")));
            this.pbRightArrow.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.InitialImage")));
            this.pbRightArrow.Location = new System.Drawing.Point(646, 648);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(85, 85);
            this.pbRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightArrow.TabIndex = 18;
            this.pbRightArrow.TabStop = false;
            this.pbRightArrow.Click += new System.EventHandler(this.pbRightArrow_Click);
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbLeftArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLeftArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftArrow.Image")));
            this.pbLeftArrow.Location = new System.Drawing.Point(555, 648);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(85, 85);
            this.pbLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftArrow.TabIndex = 19;
            this.pbLeftArrow.TabStop = false;
            this.pbLeftArrow.Click += new System.EventHandler(this.pbLeftArrow_Click);
            // 
            // cbGenre
            // 
            this.cbGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(745, 181);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(213, 28);
            this.cbGenre.TabIndex = 20;
            // 
            // btnSearchByGenre
            // 
            this.btnSearchByGenre.BackColor = System.Drawing.Color.Red;
            this.btnSearchByGenre.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchByGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchByGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearchByGenre.ForeColor = System.Drawing.Color.Black;
            this.btnSearchByGenre.Location = new System.Drawing.Point(964, 175);
            this.btnSearchByGenre.Name = "btnSearchByGenre";
            this.btnSearchByGenre.Size = new System.Drawing.Size(86, 40);
            this.btnSearchByGenre.TabIndex = 21;
            this.btnSearchByGenre.Text = "Search";
            this.btnSearchByGenre.UseVisualStyleBackColor = false;
            this.btnSearchByGenre.Click += new System.EventHandler(this.btnSearchByGenre_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.Red;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.Black;
            this.btnShowAll.Location = new System.Drawing.Point(1134, 170);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(107, 49);
            this.btnShowAll.TabIndex = 22;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearchByGenre);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.pbLeftArrow);
            this.Controls.Add(this.pbRightArrow);
            this.Controls.Add(this.panelMovies);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "RentalForm";
            this.Text = "RentalForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelMovies;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button btnSearchByGenre;
        private System.Windows.Forms.Button btnShowAll;
    }
}