using GitLibrary;
using VisualStudioInstructionsFiles.Classes;

// ReSharper disable AsyncVoidMethod
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace VisualStudioInstructionsFiles;

public partial class Form1 : Form
{

    private CancellationTokenSource _cts;
    public Form1()
    {
        InitializeComponent();

        lblStatus.Text = "";

        CancelFindInstructionsButton.Enabled = false;
        
        if (!FileOperations.AllRequiredFilesPresent())
        {
            this.ButtonList().ForEach(button => button.Enabled = false);
            Dialogs.Error("Required files are missing. Please check the configuration.");
        }

    }

    private async void FindInstructionFilesButton_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Searching...";
        InstructionFilesListBox.DataSource = null; // Clear previous results
        try
        {
            CancelFindInstructionsButton.Enabled = true;

            if (_cts == null || _cts.IsCancellationRequested)
            {
                _cts = new CancellationTokenSource();
            }

            FileOperations fileOperations = new();
            var results = await fileOperations.FindInstructionFilesAsync(@"C:\OED\DotnetLand\VS2022", _cts.Token);
            lblStatus.Text = $"{results.Count} file(s) found.";

            if (results.Count >0)
            {
                InstructionFilesListBox.DataSource = results;
            }
        }
        catch (OperationCanceledException)
        {
            lblStatus.Text = "Search canceled....";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CancelFindInstructionsButton.Enabled = false;
            _cts?.Dispose();
            _cts = null!;
        }
    }

    private void CancelFindInstructionsButton_Click(object sender, EventArgs e)
    {
        if (_cts is not { IsCancellationRequested: false }) return;
        _cts.Cancel();
        lblStatus.Text = "Canceling...";
        CancelFindInstructionsButton.Enabled = false;
    }
}
