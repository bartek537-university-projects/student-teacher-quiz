namespace QuizApp.Student.Presentation.QuizSelection
{
    partial class PasswordInputView
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            tbPassword = new TextBox();
            btnUnlock = new Button();
            lbError = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(50, 12);
            label1.Name = "label1";
            label1.Size = new Size(198, 32);
            label1.TabIndex = 0;
            label1.Text = "This file is password-protected. Enter password to unlock it.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PageLock;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new Point(50, 51);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(198, 23);
            tbPassword.TabIndex = 2;
            // 
            // btnUnlock
            // 
            btnUnlock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUnlock.Location = new Point(173, 80);
            btnUnlock.Name = "btnUnlock";
            btnUnlock.Size = new Size(75, 23);
            btnUnlock.TabIndex = 3;
            btnUnlock.Text = "Unlock";
            btnUnlock.UseVisualStyleBackColor = true;
            btnUnlock.Click += btnUnlock_Click;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(50, 84);
            lbError.Name = "lbError";
            lbError.Size = new Size(95, 15);
            lbError.TabIndex = 4;
            lbError.Text = "Invalid password";
            // 
            // PasswordInputView
            // 
            AcceptButton = btnUnlock;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 111);
            Controls.Add(lbError);
            Controls.Add(btnUnlock);
            Controls.Add(tbPassword);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordInputView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter password";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private TextBox tbPassword;
        private Button btnUnlock;
        private Label lbError;
    }
}