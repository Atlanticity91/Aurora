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

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// HugsNode class [ SyntaxNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora hugs node core class</note>
    public class HugsNode : SyntaxNode {

        public Token Close { get; }
        public IEnumerable<SyntaxNode> Content { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.Close;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                foreach ( var node in this.Content )
                    yield return node;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="open" >Open hug</param>
        /// <param name="close" >Close hug</param>
        /// <param name="content" >Hugs content</param>
        public HugsNode( Token open, Token close, IEnumerable<SyntaxNode> content )
            : base( ENodeTypes.ENT_HUGS, open ) 
        {
            this.Close = close;
            this.Content = content;
        }

    }

}
