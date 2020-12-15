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
using System.Linq;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// ElseStatementNode class [ StatementNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora else statement core class</note>
    public class ConditionStatementNode : StatementNode {

        public IEnumerable<Token> Operators { get; }
        public IEnumerable<SyntaxNode> Body { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;

                if ( this.Operators != null ) {
                    foreach ( var _operator in this.Operators )
                        yield return _operator;
                }
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                if ( this.Body != null ) {
                    foreach ( var content in this.Body )
                        yield return content;
                } else
                    yield return null;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="operators" >List of all condition operators.</param>
        /// <param name="body" >List of all condition expressions.</param>
        public ConditionStatementNode( IEnumerable<Token> operators, IEnumerable<SyntaxNode> body )
            : base( null ) 
        {
            this.Operators = operators;
            this.Body = body;
        }

    }

}
