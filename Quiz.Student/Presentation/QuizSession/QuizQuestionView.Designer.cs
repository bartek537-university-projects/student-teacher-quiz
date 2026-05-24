namespace QuizApp.Student.Presentation.QuizSession
{
    partial class QuizQuestionView
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
            pcControls = new PageControl();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbTitle = new Label();
            lbPoints = new Label();
            alAnswers = new AnswerList();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pcControls
            // 
            pcControls.CurrentPage = 3;
            pcControls.Dock = DockStyle.Bottom;
            pcControls.Location = new Point(3, 248);
            pcControls.Name = "pcControls";
            pcControls.PageCount = 20;
            pcControls.Size = new Size(433, 32);
            pcControls.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(lbTitle);
            flowLayoutPanel1.Controls.Add(lbPoints);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 12, 0, 0);
            flowLayoutPanel1.Size = new Size(433, 33);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 12F);
            lbTitle.Location = new Point(3, 12);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(39, 21);
            lbTitle.TabIndex = 3;
            lbTitle.Text = "Title";
            // 
            // lbPoints
            // 
            lbPoints.AutoSize = true;
            lbPoints.Location = new Point(48, 16);
            lbPoints.Margin = new Padding(3, 4, 3, 0);
            lbPoints.Name = "lbPoints";
            lbPoints.Size = new Size(40, 15);
            lbPoints.TabIndex = 4;
            lbPoints.Text = "(0 pts)";
            // 
            // alAnswers
            // 
            alAnswers.AutoScroll = true;
            alAnswers.AutoSize = true;
            alAnswers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            alAnswers.Dock = DockStyle.Fill;
            alAnswers.Location = new Point(3, 36);
            alAnswers.Marked = false;
            alAnswers.Name = "alAnswers";
            alAnswers.Padding = new Padding(0, 16, 0, 0);
            alAnswers.Size = new Size(433, 212);
            alAnswers.TabIndex = 3;
            // 
            // QuizQuestionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(alAnswers);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pcControls);
            Name = "QuizQuestionView";
            Padding = new Padding(3);
            Size = new Size(439, 283);
            Load += QuizQuestionView_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PageControl pcControls;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbTitle;
        private Label lbPoints;
        private AnswerList alAnswers;
    }
}
