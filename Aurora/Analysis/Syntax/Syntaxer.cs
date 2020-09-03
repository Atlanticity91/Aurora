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

using Aurora.Analysis.Lexem;
using Aurora.Diagnostics;
using System.Collections.Generic;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// Syntaxer class [ Diagnosable ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora syntaxer core class</note>
    public class Syntaxer : Diagnosable {

        public List<SyntaxNode> nodes;

        public IEnumerable<SyntaxNode> Nodes => this.nodes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Syntaxer( )
            : base( "Syntaxer" ) 
        {
            this.nodes = new List<SyntaxNode>( );
        }

        /// <summary>
        /// Prepare virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare the syntaxer for compilation</note>
        protected virtual void Prepare( ) {
            this.ClearDiags( );
            this.nodes.Clear( );
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse token list to syntax nodes</note>
        /// <param name="tokens" >Query current token list</param>
        /// <returns>DiagnosticReport</returns>
        public DiagnosticReport Parse( IEnumerable<Token> tokens ) {
            this.Prepare( );

            return this.Report;
        }

    }

}
