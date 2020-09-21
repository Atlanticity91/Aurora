/**
 * 
 * MIT License
 *
 * Copyright( c ) 2020 ALVES Quentin
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 **/

using Aurora.Utils;
using System;
using System.Reflection;

namespace Aurora.Repler.Editor {

    /// <summary>
    /// ReplControl sealed class [ Attribute ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Repler command core code</note>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false )]
    public sealed class ReplControl : Attribute {

        public ConsoleModifiers? Modifier { get; }
        public ConsoleKey Key { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="key" >Key use by the control</param>
        public ReplControl( ConsoleKey key ) {
            this.Modifier = null;
            this.Key = key;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="modifier" >Modifier use to invoke the control</param>
        /// <param name="key" >Key use by the control</param>
        public ReplControl( ConsoleModifiers modifier, ConsoleKey key ) {
            this.Modifier = modifier;
            this.Key = key;
        }

    }

    /// <summary>
    /// ReplControlMeta sealed class [ AttributeMeta<ReplControl> ] 
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Repler control meta core code</note>
    internal sealed class ReplControlMeta : AttributeMeta<ReplControl> {

        public bool HasModifier => this.Attribute.Modifier != null;
        public ConsoleModifiers? Modifier => this.Attribute.Modifier;
        public ConsoleKey Key => this.Attribute.Key;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public ReplControlMeta( ) : base( ) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="control" >Current control</param>
        /// <param name="action" >Current action</param>
        public ReplControlMeta( ReplControl control, MethodInfo action ) 
            : base( control, action )
        { 
        }

    }

}
