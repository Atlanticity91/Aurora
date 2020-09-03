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

using System.Collections.Generic;

namespace Aurora.Diagnostics {

    /// <summary>
    /// DiagnosticBag class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora core code for diagnostic bag support</note>
    public class DiagnosticBag {

        private List<DiagnosticReport> reports;

        public bool HasReports => this.reports.Count > 0;
        public IEnumerable<DiagnosticReport> Reports => this.reports;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public DiagnosticBag( ) => this.reports = new List<DiagnosticReport>( );

        /// <summary>
        /// ClearBag method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Clear current diagnostic bag</note>
        public void ClearBag( ) => this.reports.Clear( );

        /// <summary>
        /// Merge method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Merge diagnostic report with current diagnostic bag</note>
        /// <param name="report" >Query report to merge</param>
        public void Merge( DiagnosticReport report ) {
            if ( report != null && report.HasDiagnostics )
                this.reports.Add( report );
        }

    }

}
