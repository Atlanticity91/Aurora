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
    /// VariableDeclarationNode class [ DeclarationNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora variable declaration core class</note>
    public class VariableDeclarationNode : DeclarationNode {

        public Token End { get; }
        public SyntaxNode Identifier { get; }
        public SyntaxNode VariableType { get; }
        public SyntaxNode Expression { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.End;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                yield return this.Identifier;

                if ( this.VariableType != null )
                    yield return this.VariableType;
                else
                    yield return this.Expression;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="keyword" >Current variable declaration keyword</param>
        /// <param name="name" >Current variable declaration name</param>
        /// <param name="expression" >Current variable delcaration expression</param>
        /// <param name="type" >Current variable declaration type</param>
        /// <param name="end" >Current variable declaration end</param>
        public VariableDeclarationNode( Token keyword, SyntaxNode name, SyntaxNode expression, SyntaxNode type, Token end ) 
            : base( keyword ) 
        {
            this.Identifier = name;
            this.VariableType = type;
            this.Expression = expression;
            this.End = end;
        }

    }

}
