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
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// ENodeTypes enum
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora syntax node types enum</note>
    public enum ENodeTypes {

        ENT_EOF,
        ENT_UNKNOW,
        ENT_IDENTIFIER,
        ENT_TYPE,
        ENT_LITERAL,
        ENT_EXPRESSION,
        ENT_SEMICOLON,
        ENT_DECLARATION,
        ENT_STATEMENT,
        ENT_HUGS,
        ENT_BOOLEAN,
        ENT_CONTROL_FLOW,

    }

    /// <summary>
    /// SyntaxNode class 
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora syntax node core class</note>
    public class SyntaxNode {

        public ENodeTypes Type { get; }
        public Token Token { get; }

        public ETokenTypes TokenType => this.Token.Type;
        public string TokenText => this.Token.Text;

        public virtual IEnumerable<Token> Tokens {
            get { yield return this.Token; }
        }

        public virtual IEnumerable<SyntaxNode> Childs {
            get { return Enumerable.Empty<SyntaxNode>( ); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="type" >Type of the new syntax node</param>
        /// <param name="token" >Token that generate the node</param>
        public SyntaxNode( ENodeTypes type, Token token ) {
            this.Type = type;
            this.Token = token;
        }

    }

}
