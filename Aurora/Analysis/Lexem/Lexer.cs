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

using Aurora.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Analysis.Lexem {

    /// <summary>
    /// Lexer class [ Diagnosable ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora lexer core class</note>
    public class Lexer : Diagnosable {

        private List<Token> tokens;

        public IEnumerable<Token> Tokens => this.tokens;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Lexer( ) 
            : base( "Lexer" ) 
        {
            this.tokens = new List<Token>( );
        }

        /// <summary>
        /// Prepare virtual method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare the lexer for compilation</note>
        protected virtual void Prepare( ) {
            this.ClearDiags( );
            this.tokens.Clear( );
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse line to tokens</note>
        /// <param name="text" >Query text of the line</param>
        /// <param name="last" >If the line is the last</param>
        /// <returns>DiagnosticReport</returns>
        protected DiagnosticReport Parse( string text, bool last ) {
            return this.Report;
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse line to tokens</note>
        /// <param name="lines"></param>
        /// <returns>DiagnosticReport</returns>
        public DiagnosticReport Parse( IEnumerable<string> lines ) {
            this.Prepare( );

            if ( lines != null ) {
                var last = lines.Last( );

                foreach ( var line in lines )
                    this.Merge( this.Parse( line, line == last ) );
            } else
                this.EmitErrr( "No input string for lexer.", null );

            return this.Report;
        }

    }

}
