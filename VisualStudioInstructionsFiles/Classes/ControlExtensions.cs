using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioInstructionsFiles.Classes;
public static class ControlExtensions
{
    /// <summary>
    /// Retrieves all descendant controls of the specified type <typeparamref name="T"/> 
    /// within the control hierarchy of the given <paramref name="control"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of controls to search for. Must be a reference type.
    /// </typeparam>
    /// <param name="control">
    /// The root control from which to begin the search for descendant controls.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing all descendant controls of type <typeparamref name="T"/>.
    /// </returns>
    public static IEnumerable<T> Descendants<T>(this Control control) where T : class
    {
        foreach (Control child in control.Controls)
        {
            if (child is T thisControl)
            {
                yield return (T)thisControl;
            }

            if (child.HasChildren)
            {
                foreach (T descendant in Descendants<T>(child))
                {
                    yield return descendant;
                }
            }
        }
    }
    public static List<Button> ButtonList(this Control control)
        => control.Descendants<Button>().ToList();
}
