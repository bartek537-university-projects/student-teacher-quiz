namespace QuizApp.Student.Presentation.QuizSession
{
    partial class QuizSessionView
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
            scMainLayout = new SplitContainer();
            btnFinishQuiz = new Button();
            btnStartQuiz = new Button();
            ((System.ComponentModel.ISupportInitialize)scMainLayout).BeginInit();
            scMainLayout.Panel1.SuspendLayout();
            scMainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // scMainLayout
            // 
            scMainLayout.BackColor = SystemColors.Window;
            scMainLayout.Dock = DockStyle.Fill;
            scMainLayout.FixedPanel = FixedPanel.Panel1;
            scMainLayout.Location = new Point(0, 0);
            scMainLayout.Name = "scMainLayout";
            // 
            // scMainLayout.Panel1
            // 
            scMainLayout.Panel1.Controls.Add(btnFinishQuiz);
            scMainLayout.Panel1.Controls.Add(btnStartQuiz);
            scMainLayout.Size = new Size(554, 326);
            scMainLayout.SplitterDistance = 200;
            scMainLayout.TabIndex = 0;
            // 
            // btnFinishQuiz
            // 
            btnFinishQuiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnFinishQuiz.Image = Properties.Resources.Stop;
            btnFinishQuiz.Location = new Point(3, 282);
            btnFinishQuiz.Name = "btnFinishQuiz";
            btnFinishQuiz.Size = new Size(194, 32);
            btnFinishQuiz.TabIndex = 1;
            btnFinishQuiz.Text = "Finish quiz";
            btnFinishQuiz.TextAlign = ContentAlignment.MiddleRight;
            btnFinishQuiz.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinishQuiz.UseVisualStyleBackColor = true;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStartQuiz.Image = Properties.Resources.Run;
            btnStartQuiz.Location = new Point(3, 244);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(194, 32);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Start quiz";
            btnStartQuiz.TextAlign = ContentAlignment.MiddleRight;
            btnStartQuiz.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStartQuiz.UseVisualStyleBackColor = true;
            // 
            // QuizSessionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(554, 326);
            Controls.Add(scMainLayout);
            Name = "QuizSessionView";
            Text = "QuizSessionView";
            scMainLayout.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMainLayout).EndInit();
            scMainLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer scMainLayout;
        private Button btnStartQuiz;
        private Button btnFinishQuiz;
    }
}