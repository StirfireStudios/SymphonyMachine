using System.Collections.Generic;
using UnityEngine;

namespace Jam.Symbols.Layout
{
    /// A generic interface for generating a layout for a set of objects
    public interface ILayout
    {
        /// Yield a set of locations and orientations for each target
        IEnumerable<LayoutObject> Layout(IEnumerable<GameObject> target);
    }
}
