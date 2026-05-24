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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizSessionView));
            scMainLayout = new SplitContainer();
            pictureBox1 = new PictureBox();
            lbSessionTime = new Label();
            btnFinishQuiz = new Button();
            btnStartQuiz = new Button();
            quizQuestionView1 = new QuizQuestionView();
            tSessionTime = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)scMainLayout).BeginInit();
            scMainLayout.Panel1.SuspendLayout();
            scMainLayout.Panel2.SuspendLayout();
            scMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // scMainLayout
            // 
            scMainLayout.Dock = DockStyle.Fill;
            scMainLayout.FixedPanel = FixedPanel.Panel1;
            scMainLayout.Location = new Point(0, 0);
            scMainLayout.Name = "scMainLayout";
            // 
            // scMainLayout.Panel1
            // 
            scMainLayout.Panel1.Controls.Add(pictureBox1);
            scMainLayout.Panel1.Controls.Add(lbSessionTime);
            scMainLayout.Panel1.Controls.Add(btnFinishQuiz);
            scMainLayout.Panel1.Controls.Add(btnStartQuiz);
            // 
            // scMainLayout.Panel2
            // 
            scMainLayout.Panel2.Controls.Add(quizQuestionView1);
            scMainLayout.Size = new Size(554, 326);
            scMainLayout.SplitterDistance = 200;
            scMainLayout.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lbSessionTime
            // 
            lbSessionTime.AutoSize = true;
            lbSessionTime.Location = new Point(34, 14);
            lbSessionTime.Name = "lbSessionTime";
            lbSessionTime.Size = new Size(55, 15);
            lbSessionTime.TabIndex = 2;
            lbSessionTime.Text = "00:00.000";
            // 
            // btnFinishQuiz
            // 
            btnFinishQuiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnFinishQuiz.Location = new Point(3, 291);
            btnFinishQuiz.Name = "btnFinishQuiz";
            btnFinishQuiz.Size = new Size(194, 32);
            btnFinishQuiz.TabIndex = 1;
            btnFinishQuiz.Text = "Finish";
            btnFinishQuiz.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinishQuiz.UseVisualStyleBackColor = true;
            btnFinishQuiz.Click += btnFinishQuiz_Click;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStartQuiz.Location = new Point(3, 257);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(194, 32);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Start";
            btnStartQuiz.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // quizQuestionView1
            // 
            quizQuestionView1.Dock = DockStyle.Fill;
            quizQuestionView1.Location = new Point(0, 0);
            quizQuestionView1.Name = "quizQuestionView1";
            quizQuestionView1.Size = new Size(350, 326);
            quizQuestionView1.TabIndex = 0;
            // 
            // tSessionTime
            // 
            tSessionTime.Interval = 50;
            // 
            // QuizSessionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 326);
            Controls.Add(scMainLayout);
            Name = "QuizSessionView";
            Text = "QuizSessionView";
            Load += QuizSessionView_Load;
            scMainLayout.Panel1.ResumeLayout(false);
            scMainLayout.Panel1.PerformLayout();
            scMainLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMainLayout).EndInit();
            scMainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer scMainLayout;
        private Button btnStartQuiz;
        private Button btnFinishQuiz;
        private Label lbSessionTime;
        private System.Windows.Forms.Timer tSessionTime;
        private PictureBox pictureBox1;
        private QuizQuestionView quizQuestionView1;
    }
}