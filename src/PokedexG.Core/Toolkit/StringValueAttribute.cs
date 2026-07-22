// RECONSTRUCTION 2026-07-23 — shim minimal de l'attribut StringValue du Windows Community
// Toolkit 1.2.0 (mort avec UWP), dans son namespace d'origine pour garder Ailment.cs verbatim.
using System;

namespace Microsoft.Toolkit.Uwp.Services.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
