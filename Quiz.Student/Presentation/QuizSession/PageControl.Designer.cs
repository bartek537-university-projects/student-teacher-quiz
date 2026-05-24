namespace QuizApp.Student.Presentation.QuizSession
{
    partial class PageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageControl));
            btnNext = new Button();
            btnPrevious = new Button();
            lbPage = new Label();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Right;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageAlign = ContentAlignment.MiddleLeft;
            btnNext.Location = new Point(176, 0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(80, 32);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.TextAlign = ContentAlignment.MiddleRight;
            btnNext.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Dock = DockStyle.Left;
            btnPrevious.Location = new Point(0, 0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(80, 32);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lbPage
            // 
            lbPage.Dock = DockStyle.Fill;
            lbPage.Location = new Point(80, 0);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(96, 32);
            lbPage.TabIndex = 4;
            lbPage.Text = "1 of 20";
            lbPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbPage);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Name = "PageControl";
            Size = new Size(256, 32);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNext;
        private Button btnPrevious;
        private Label lbPage;
    }
}
