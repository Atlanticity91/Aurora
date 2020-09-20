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
using Aurora.Analysis.Syntax;
using Aurora.Diagnostics;
using System.Collections.Generic;

namespace Aurora.Runtime {

    /// <summary>
    /// Evaluator class [ Diagnosable ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora syntaxer core class</note>
    public class Evaluator : Diagnosable {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Evaluator( )
            : base( "Evaluator" ) 
        { 
        }

        /// <summary>
        /// Evaluation function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Evaluate a node</note>
        /// <param name="node" >Query node to evaluate</param>
        /// <returns>int</returns>
        private int Evaluation( SyntaxNode node ) {
            if ( node.Type == ENodeTypes.ENT_LITERAL )
                return int.Parse( node.Token.Meta.Value );
            else if ( node.Type == ENodeTypes.ENT_EXPRESSION ) {
                if ( node is BinaryExpressionNode ) {
                    var expression = (BinaryExpressionNode)node;

                    switch ( node.Token.Type ) {
                        case ETokenTypes.ETT_OP_ADD : return this.Evaluation( expression.Left ) + this.Evaluation( expression.Right );
                        case ETokenTypes.ETT_OP_SUB : return this.Evaluation( expression.Left ) - this.Evaluation( expression.Right );
                        case ETokenTypes.ETT_OP_MUL : return this.Evaluation( expression.Left ) * this.Evaluation( expression.Right );
                        case ETokenTypes.ETT_OP_DIV : return this.Evaluation( expression.Left ) / this.Evaluation( expression.Right );
                        case ETokenTypes.ETT_OP_MOD : return this.Evaluation( expression.Left ) % this.Evaluation( expression.Right );
                        default : break;
                    }
                } else if ( node is UnaryExpressionNode ) {
                    var expression = (UnaryExpressionNode)node;

                    switch ( node.Token.Type ) {
                        case ETokenTypes.ETT_OP_ADD : return this.Evaluation( expression.Operand );
                        case ETokenTypes.ETT_OP_SUB : return -( this.Evaluation( expression.Operand ) );
                        default : break;
                    }
                } else if ( node is ParanthesisExpressionNode )
                    return this.Evaluation( ((ParanthesisExpressionNode)node).Expression );
            }

            return 0;
        }

        /// <summary>
        /// Evaluate function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Evaluate a sample of nodes aka trees</note>
        /// <param name="nodes" >Current node trees to evaluate</param>
        /// <returns>IEnumerable<int></returns>
        public IEnumerable<int> Evaluate( IEnumerable<SyntaxNode> nodes ) {
            if ( nodes != null ) {
                foreach ( var node in nodes ) {
                    if ( node.Type == ENodeTypes.ENT_EXPRESSION || node.Type == ENodeTypes.ENT_LITERAL )
                        yield return this.Evaluation( node );
                    else
                        this.EmitErrr( $"Node <{node.Type}> can't be evaluate, there is no expression.", null );
                }
            }
        }

    }

}
