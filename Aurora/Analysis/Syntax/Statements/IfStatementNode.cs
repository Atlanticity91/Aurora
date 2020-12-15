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
    /// IfStatementNode class [ DeclarationNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora if statement core class</note>
    public class IfStatementNode : StatementNode {

        public Token Then { get; }
        public Token End { get; }
        public SyntaxNode Conditions { get; }
        public IEnumerable<SyntaxNode> Body { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.Then;
                yield return this.End;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                if ( this.Conditions.Childs != null ) {
                    foreach ( var condition in this.Conditions.Childs )
                        yield return condition;
                }

                foreach ( var content in this.Body )
                    yield return content;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="keyword" >Current if statement keyword</param>
        /// <param name="conditions" >Current if statement conditions expression</param>
        /// <param name="then" >Current if statement then keyword</param>
        /// <param name="body" >Current function declaration body</param>
        /// <param name="end" >Current if statement end keyword</param>
        public IfStatementNode( Token keyword, SyntaxNode conditions, Token then, IEnumerable<SyntaxNode> body, Token end ) 
            : base( keyword ) 
        {
            this.Conditions = conditions;
            this.Then = then;
            this.Body = body;
            this.End = end;
        }
    }

}
