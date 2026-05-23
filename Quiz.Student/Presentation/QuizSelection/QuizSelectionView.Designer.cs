namespace QuizApp.Student.Presentation.Main;

partial class QuizSelectionView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        ListViewItem listViewItem1 = new ListViewItem("C:\\ProgramData\\Apple Computer\\iTunes\\adi", 0);
        ListViewItem listViewItem2 = new ListViewItem("C:\\ProgramData\\Apple\\Music", 0);
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizSelectionView));
        ofdOpenLocalFileDialog = new OpenFileDialog();
        lbOpenRecent = new Label();
        btnOpenLocalFile = new Button();
        lbGetStarted = new Label();
        columnHeader1 = new ColumnHeader();
        lvRecentFiles = new ListView();
        ilImages = new ImageList(components);
        SuspendLayout();
        // 
        // ofdOpenLocalFileDialog
        // 
        ofdOpenLocalFileDialog.Filter = "Quiz files|*.qz|All files|*.*";
        // 
        // lbOpenRecent
        // 
        lbOpenRecent.AutoSize = true;
        lbOpenRecent.Location = new Point(12, 74);
        lbOpenRecent.Name = "lbOpenRecent";
        lbOpenRecent.Size = new Size(72, 15);
        lbOpenRecent.TabIndex = 2;
        lbOpenRecent.Text = "Open recent";
        // 
        // btnOpenLocalFile
        // 
        btnOpenLocalFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnOpenLocalFile.Image = Properties.Resources.OpenFile;
        btnOpenLocalFile.Location = new Point(12, 31);
        btnOpenLocalFile.Name = "btnOpenLocalFile";
        btnOpenLocalFile.Size = new Size(216, 32);
        btnOpenLocalFile.TabIndex = 1;
        btnOpenLocalFile.Text = "Open a local file";
        btnOpenLocalFile.TextAlign = ContentAlignment.MiddleRight;
        btnOpenLocalFile.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnOpenLocalFile.UseVisualStyleBackColor = true;
        btnOpenLocalFile.Click += btnOpenFile_Click;
        // 
        // lbGetStarted
        // 
        lbGetStarted.AutoSize = true;
        lbGetStarted.Location = new Point(12, 9);
        lbGetStarted.Name = "lbGetStarted";
        lbGetStarted.Size = new Size(64, 15);
        lbGetStarted.TabIndex = 0;
        lbGetStarted.Text = "Get started";
        // 
        // columnHeader1
        // 
        columnHeader1.Width = 214;
        // 
        // lvRecentFiles
        // 
        lvRecentFiles.Activation = ItemActivation.OneClick;
        lvRecentFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lvRecentFiles.BackColor = SystemColors.Window;
        lvRecentFiles.BorderStyle = BorderStyle.None;
        lvRecentFiles.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
        lvRecentFiles.FullRowSelect = true;
        lvRecentFiles.GridLines = true;
        lvRecentFiles.HeaderStyle = ColumnHeaderStyle.None;
        listViewItem1.ToolTipText = "C:\\ProgramData\\Apple Computer\\iTunes\\adi";
        lvRecentFiles.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
        lvRecentFiles.Location = new Point(10, 96);
        lvRecentFiles.MultiSelect = false;
        lvRecentFiles.Name = "lvRecentFiles";
        lvRecentFiles.Size = new Size(218, 109);
        lvRecentFiles.SmallImageList = ilImages;
        lvRecentFiles.TabIndex = 3;
        lvRecentFiles.UseCompatibleStateImageBehavior = false;
        lvRecentFiles.View = View.Details;
        lvRecentFiles.DoubleClick += lvRecentFiles_DoubleClick;
        // 
        // ilImages
        // 
        ilImages.ColorDepth = ColorDepth.Depth32Bit;
        ilImages.ImageStream = (ImageListStreamer)resources.GetObject("ilImages.ImageStream");
        ilImages.TransparentColor = Color.Transparent;
        ilImages.Images.SetKeyName(0, "Report");
        // 
        // QuizSelectionView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(240, 217);
        Controls.Add(lvRecentFiles);
        Controls.Add(lbGetStarted);
        Controls.Add(btnOpenLocalFile);
        Controls.Add(lbOpenRecent);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "QuizSelectionView";
        Text = "Quiz";
        Load += QuizSelectionView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private OpenFileDialog ofdOpenLocalFileDialog;
    private Label lbOpenRecent;
    private Button btnOpenLocalFile;
    private Label lbGetStarted;
    private ColumnHeader columnHeader1;
    private ListView lvRecentFiles;
    private ImageList ilImages;
}
