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
    /// ImportDeclarationNode class [ DeclarationNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora import expression declaration core class</note>
    public class ImportDeclarationNode : DeclarationNode {

        public Token As { get; }
        public Token End { get; }
        public SyntaxNode ModulePath { get; }
        public SyntaxNode Identifier { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.As;
                yield return this.End;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                yield return this.ModulePath;

                if ( this.Identifier != null )
                    yield return this.Identifier;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="keyword" >Current import declaration keyword</param>
        /// <param name="path" >Current import declaration module path</param>
        /// <param name="as_" >Current import declaration as keyword</param>
        /// <param name="name" >Current import declaration name</param>
        /// <param name="end" >Current import declaration end</param>
        public ImportDeclarationNode( Token keyword, SyntaxNode path, Token as_, SyntaxNode name, Token end ) 
            : base( keyword ) 
        {
            this.ModulePath = path;
            this.As = as_;
            this.Identifier = name;
            this.End = end;
        }

    }

}
