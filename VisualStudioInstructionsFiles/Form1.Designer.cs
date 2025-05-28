namespace VisualStudioInstructionsFiles;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        FindInstructionFilesButton = new Button();
        lblStatus = new Label();
        CancelFindInstructionsButton = new Button();
        InstructionFilesListBox = new ListBox();
        SuspendLayout();
        // 
        // FindInstructionFilesButton
        // 
        FindInstructionFilesButton.Location = new Point(12, 29);
        FindInstructionFilesButton.Name = "FindInstructionFilesButton";
        FindInstructionFilesButton.Size = new Size(256, 29);
        FindInstructionFilesButton.TabIndex = 0;
        FindInstructionFilesButton.Text = "Find instruction files";
        FindInstructionFilesButton.UseVisualStyleBackColor = true;
        FindInstructionFilesButton.Click += FindInstructionFilesButton_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(285, 35);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(18, 20);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "...";
        // 
        // CancelFindInstructionsButton
        // 
        CancelFindInstructionsButton.Location = new Point(12, 64);
        CancelFindInstructionsButton.Name = "CancelFindInstructionsButton";
        CancelFindInstructionsButton.Size = new Size(256, 29);
        CancelFindInstructionsButton.TabIndex = 2;
        CancelFindInstructionsButton.Text = "Cancel";
        CancelFindInstructionsButton.UseVisualStyleBackColor = true;
        CancelFindInstructionsButton.Click += CancelFindInstructionsButton_Click;
        // 
        // InstructionFilesListBox
        // 
        InstructionFilesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        InstructionFilesListBox.FormattingEnabled = true;
        InstructionFilesListBox.Location = new Point(12, 112);
        InstructionFilesListBox.Name = "InstructionFilesListBox";
        InstructionFilesListBox.Size = new Size(710, 204);
        InstructionFilesListBox.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(733, 453);
        Controls.Add(InstructionFilesListBox);
        Controls.Add(CancelFindInstructionsButton);
        Controls.Add(lblStatus);
        Controls.Add(FindInstructionFilesButton);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GitHub Instructions";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button FindInstructionFilesButton;
    private Label lblStatus;
    private Button CancelFindInstructionsButton;
    private ListBox InstructionFilesListBox;
}
