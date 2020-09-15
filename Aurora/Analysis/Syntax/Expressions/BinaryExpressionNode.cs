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
    /// ExpressionNode class [ SyntaxNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora binary expression node core class</note>
    public class BinaryExpressionNode : ExpressionNode {

        public SyntaxNode Left { get; }
        public SyntaxNode Right { get; }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                yield return this.Left;
                yield return this.Right;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="operator_" >Current expression operator</param>
        /// <param name="left" >Current expression left operand</param>
        /// <param name="right" >Current expression right operand</param>
        public BinaryExpressionNode( Token operator_, SyntaxNode left, SyntaxNode right )
            : base( operator_ ) 
        {
            this.Left = left;
            this.Right = right;
        }

    }

}
