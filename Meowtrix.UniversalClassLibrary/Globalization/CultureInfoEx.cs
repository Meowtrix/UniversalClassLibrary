using System;
using System.Globalization;

namespace Meowtrix.Globalization
{
    /// <summary>
    /// Provides extension methods for <see cref="CultureInfo"/>.
    /// </summary>
    public static class CultureInfoEx
    {
        /// <summary>
        /// Tests if a <see cref="CultureInfo"/> is an ancestor of another.
        /// </summary>
        /// <param name="ancestor">The ancestor to test.</param>
        /// <param name="descendant">The descendant to test.</param>
        /// <returns>If <paramref name="ancestor"/> is an ancestor of <paramref name="descendant"/>.</returns>
        public static bool IsAncestorOf(this CultureInfo ancestor, CultureInfo descendant)
        {
            if (ancestor == null) throw new ArgumentNullException(nameof(ancestor));
            if (descendant == null) throw new ArgumentNullException(nameof(descendant));
            CultureInfo current = descendant;
            do
            {
                if (current.Name == ancestor.Name) return true;
                current = current.Parent;
            }
            while (current != current.Parent);
            return false;
        }
    }
}
