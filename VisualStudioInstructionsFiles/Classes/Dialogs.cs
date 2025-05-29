namespace VisualStudioInstructionsFiles.Classes;
internal class Dialogs
{
    /// <summary>
    /// Displays an informational dialog with a specified heading and button text.
    /// </summary>
    /// <param name="owner">
    /// The parent form that owns the dialog.
    /// </param>
    /// <param name="heading">
    /// The heading text to be displayed in the dialog.
    /// </param>
    /// <param name="buttonText">
    /// The text to be displayed on the button. Defaults to "Ok".
    /// </param>
    public static void Information(Form owner, string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.blueInformation_32),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(owner, page);

    }
    /// <summary>
    /// Displays an error dialog with a specified heading and button text.
    /// </summary>
    /// <param name="heading">
    /// The heading text to be displayed in the dialog.
    /// </param>
    /// <param name="buttonText">
    /// The text to be displayed on the button. Defaults to "Ok".
    /// </param>
    public static void Error(string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Error",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.Explaination),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(page);

    }
}
