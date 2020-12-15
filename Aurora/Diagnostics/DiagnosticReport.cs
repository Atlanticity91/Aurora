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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Aurora.Diagnostics {

    /// <summary>
    /// DiagnosticReport sealed class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora core code for diagnostic report support</note>
    public sealed class DiagnosticReport {

        private List<Diagnostic> diags;

        public string Emitter { get; }
        public bool HasDiagnostics => this.diags.Count > 0;
        public IEnumerable< Diagnostic > Diagnostics => this.diags.ToImmutableArray( );
        public int Size => this.diags.Count;
        public int InfoCount => this.diags.Count( diag => diag.Type == EDiagnosticTypes.EDT_INFO );
        public int WarnCount => this.diags.Count( diag => diag.Type == EDiagnosticTypes.EDT_INFO );
        public int ErrrCount => this.diags.Count( diag => diag.Type == EDiagnosticTypes.EDT_INFO );

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="emitter" >Diagnostic emitter</param>
        public DiagnosticReport( string emitter ) {
            this.Emitter = emitter;
            this.diags = new List<Diagnostic>( );
        }

        /// <summary>
        /// Clear method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Clear the current report</note>
        public void Clear( ) => this.diags.Clear( );

        /// <summary>
        /// Merge method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Merge to report</note>
        /// <param name="report" >The other query report to merge</param>
        public void Merge( DiagnosticReport report ) {
            if ( report.HasDiagnostics )
                this.diags.AddRange( report.Diagnostics );
        }

        /// <summary>
        /// Emit method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Add a line to the report</note>
        /// <param name="type" >Type of diagnostic</param>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        private void Emit( EDiagnosticTypes type, string message, Textmeta meta ) {
            var diag = new Diagnostic( type, message, meta );

            this.diags.Add( diag );
        }

        /// <summary>
        /// EmitInfo method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Add an info line to the report</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitInfo( string message, Textmeta meta ) => this.Emit( EDiagnosticTypes.EDT_INFO, message, meta );

        /// <summary>
        /// EmitWarn method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Add a warning line to the report</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitWarn( string message, Textmeta meta ) => this.Emit( EDiagnosticTypes.EDT_WARN, message, meta );

        /// <summary>
        /// EmitErrr method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Add an error line to the report</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitErrr( string message, Textmeta meta ) => this.Emit( EDiagnosticTypes.EDT_ERRR, message, meta );

    }

}
