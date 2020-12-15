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

using Aurora.Analysis.Lexem;
using System.Collections.Generic;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// ElseStatementNode class [ StatementNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora else statement core class</note>
    public class ElseStatementNode : StatementNode {

        public Token End { get; }
        public SyntaxNode Sub_if { get; }
        public IEnumerable<SyntaxNode> Body { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.End;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                if ( this.Sub_if != null )
                    yield return this.Sub_if;
                else {
                    foreach ( var content in this.Body )
                        yield return content;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="keyword" >Current else statement keyword</param>
        /// <param name="sub_if" >Current else statement sub if statement</param>
        /// <param name="body" >Current else statement body</param>
        /// <param name="end" >Current else statement end keyword</param>
        public ElseStatementNode( Token keyword, SyntaxNode sub_if, IEnumerable<SyntaxNode> body, Token end ) 
            : base( keyword ) 
        {
            this.Sub_if = sub_if;
            this.Body = body;
            this.End = end;
        }

    }

}
