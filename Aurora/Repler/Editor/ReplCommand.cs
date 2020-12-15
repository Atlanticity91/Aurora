/**
 * 
 *       /\                             
 *      /  \  _   _ _ __ ___  _ __ __ _ 
 *     / /\ \| | | | '__/ _ \| '__/ _` |
 *    / ____ \ |_| | | | (_) | | | (_| |
 *   /_/    \_\__,_|_|  \___/|_|  \__,_|
 *   
 * Licensed under the MIT License <http://opensource.org/licenses/MIT>.
 * SPDX-License-Identifier : MIT
 * Project source : https://github.com/Atlanticity91/Aurora
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
    /// ReplCommand sealed class [ Attribute ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Repler command core code</note>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false )]
    public sealed class ReplCommand : Attribute {

        public string Name { get; }
        public string Description { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="name" >Name of the command</param>
        /// <param name="description" >Description of the command</param>
        public ReplCommand( string name, string description ) {
            this.Name = name;
            this.Description = description;
        }

    }

    /// <summary>
    /// ReplCommandMeta sealed class [ AttributeMeta<ReplCommand> ] 
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Repler command meta core code</note>
    internal sealed class ReplCommandMeta : AttributeMeta<ReplCommand> {

        public string Name => this.Attribute.Name;
        public string Description => this.Attribute.Description;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public ReplCommandMeta( ) : base( ) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="command" >Current command</param>
        /// <param name="action" >Current action</param>
        public ReplCommandMeta( ReplCommand command, MethodInfo action ) 
            : base( command, action )
        {
        }

    }

}
