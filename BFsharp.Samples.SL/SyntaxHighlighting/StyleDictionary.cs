﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.
// <auto-generated />
// No style analysis for imported project.

using System.Collections.ObjectModel;

namespace System.Windows.Controls.Samples.SyntaxHighlighting
{
    /// <summary>
    /// A dictionary of <see cref="Style" /> instances, keyed by the styles' 
    /// scope name.
    /// </summary>
    public class StyleDictionary : KeyedCollection<string, Style>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the 
        /// specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(Style item)
        {
            return item.ScopeName;
        }
    }
}