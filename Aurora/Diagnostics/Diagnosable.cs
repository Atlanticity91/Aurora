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

namespace Aurora.Diagnostics {

    /// <summary>
    /// Diagnosable class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Diagnosable core code</note>
    public class Diagnosable {

        public DiagnosticReport Report { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Diagnosable( string emitter ) => this.Report = new DiagnosticReport( emitter );

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Clear current disagnostic report</note>
        public void ClearDiags( ) => this.Report.Clear( );

        /// <summary>
        /// Merge method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Merge to report</note>
        /// <param name="report" >The other query report to merge</param>
        public void Merge( DiagnosticReport report ) => this.Report.Merge( report );

        /// <summary>
        /// EmitInfo method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Emit a info diagnotic</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitInfo( string message, Textmeta meta ) => this.Report.EmitInfo( message, meta );

        /// <summary>
        /// EmitWarn method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Emit a warning diagnotic</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitWarn( string message, Textmeta meta ) => this.Report.EmitWarn( message, meta );

        /// <EmitErrr>
        /// EmitInfo method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Emit an error diagnotic</note>
        /// <param name="message" >Message of the diagnostic</param>
        /// <param name="meta" >Metadata of the diagnostic</param>
        public void EmitErrr( string message, Textmeta meta ) => this.Report.EmitErrr( message, meta );

    }

}
