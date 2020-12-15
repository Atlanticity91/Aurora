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

namespace Aurora.Diagnostics {

    /// <summary>
    /// EDiagnosticTypes enum
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined all diagnostic types</note>
    public enum EDiagnosticTypes {

        EDT_INFO,
        EDT_WARN,
        EDT_ERRR,

    }

    /// <summary>
    /// Diagnostic sealed class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Diagnostic code support</note>
    public sealed class Diagnostic {

        public EDiagnosticTypes Type { get; }
        public string Message { get; }
        public Textmeta Meta { get; }

        public bool HasMeta => this.Meta != null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="type" >Type of diagnostic</param>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public Diagnostic( EDiagnosticTypes type, string message, Textmeta meta ) {
            this.Type = type;
            this.Message = message;
            this.Meta = meta;
        }

    }

}
