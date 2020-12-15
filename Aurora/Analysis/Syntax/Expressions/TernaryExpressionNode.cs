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

namespace Aurora.Analysis.Syntax.Expressions {

    /// <summary>
    /// TernaryExpressionNode class [ SyntaxNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora ternary expression node core class</note>
    public class TernaryExpressionNode : ExpressionNode {

        public SyntaxNode Condition { get; }
        public SyntaxNode True { get; }
        public SyntaxNode False { get; }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                yield return this.Condition;
                yield return this.True;
                yield return this.False;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="operator_" >Current ternary expression operator</param>
        /// <param name="condition" >Current ternary expression condition</param>
        /// <param name="true_" >Current ternary expression left operand</param>
        /// <param name="false_" >Current ternary expression right operand</param>
        public TernaryExpressionNode( Token operator_, SyntaxNode condition, SyntaxNode true_, SyntaxNode false_ )
            : base( operator_ ) 
        {
            this.Condition = condition;
            this.True = true_;
            this.False = false_;
        }

    }

}
