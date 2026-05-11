namespace QuizApp.Teacher.Presentation.Main
{
    partial class AnswerTools
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
            btRemove = new Button();
            btAdd = new Button();
            SuspendLayout();
            // 
            // btRemove
            // 
            btRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btRemove.Location = new Point(291, 3);
            btRemove.Name = "btRemove";
            btRemove.Size = new Size(100, 29);
            btRemove.TabIndex = 2;
            btRemove.Text = "Usuń";
            btRemove.UseVisualStyleBackColor = true;
            btRemove.Click += btRemove_Click;
            // 
            // btAdd
            // 
            btAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btAdd.Location = new Point(186, 3);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(100, 29);
            btAdd.TabIndex = 1;
            btAdd.Text = "Dodaj";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // AnswerTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(btAdd);
            Controls.Add(btRemove);
            Name = "AnswerTools";
            Size = new Size(394, 35);
            ResumeLayout(false);
        }

        #endregion

        private Button btRemove;
        private Button btAdd;
    }
}
