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
using Aurora.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// Syntaxer class [ Diagnosable ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora syntaxer core class</note>
    public class Syntaxer : Diagnosable {

        private List<SyntaxNode> nodes;
        private int current;

        public IEnumerable<SyntaxNode> Nodes => this.nodes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Syntaxer( )
            : base( "Syntaxer" ) 
        {
            this.nodes = new List<SyntaxNode>( );
        }

        /// <summary>
        /// Prepare virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare the syntaxer for compilation</note>
        protected virtual void Prepare( ) {
            this.ClearDiags( );
            this.nodes.Clear( );
            this.current = 0;
        }

        /// <summary>
        /// Current function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get current token from the token list</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <returns>Token</returns>
        protected Token Current( IEnumerable<Token> tokens ) {
            if ( this.current < tokens.Count( ) )
                return tokens.ElementAt( this.current );

            return tokens.ElementAt( tokens.Count( ) - 1 );
        }

        /// <summary>
        /// Next function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get next token of the token list</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <returns>Token</returns>
        protected Token Next( IEnumerable<Token> tokens ) {
            if ( this.current < tokens.Count( ) )
                return tokens.ElementAt( this.current++ );

            return tokens.ElementAt( tokens.Count( ) - 1 );
        }

        /// <summary>
        /// Match function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Verify if the current token match a specific token type</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <param name="query" >Query token type</param>
        /// <returns>Token</returns>
        protected Token Match( IEnumerable<Token> tokens, ETokenTypes query ) {
            var current = this.Current( tokens );

            if ( current.Type != query )
                this.EmitErrr( $"Unexpected token <{current.Type}>, expected <{query}>", current.Meta );

            return this.Next( tokens );
        }

        /// <summary>
        /// ParseToken virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse current token to syntax node</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseToken( IEnumerable<Token> tokens ) {
            var token = this.Next( tokens );

            if ( token.IsLiteral )
                return new SyntaxNode( ENodeTypes.ENT_LITERAL, token );
            else if ( token.IsIdentifier )
                return new SyntaxNode( ENodeTypes.ENT_IDENTIFIER, token );
            else if ( token.Type == ETokenTypes.ETT_SEP_OPEN_PARANTHESIS ) {
                var expression = this.ParseSyntax( tokens, 0 );
                var close = this.Match( tokens, ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS );

                return new ParanthesisExpressionNode( token, close, expression );
            }

            this.EmitErrr( $"Unexpected token type {token.Type}.", token.Meta );

            return new SyntaxNode( token );
        }

        /// <summary>
        /// ParseSyntax virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse tokens to syntax tree</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <param name="precedence" >Precedence value from parent call</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseSyntax( IEnumerable<Token> tokens, int precedence ) {
            var root = this.ParseToken( tokens );

            while ( this.Current( tokens ).IsOperator ) {
                var _operator = this.Next( tokens );
                var _precedence = _operator.Precedence( );

                if ( _precedence == 0 || _precedence <= precedence )
                    break;

                var right = this.ParseSyntax( tokens, _precedence );

                root = new BinaryExpressionNode( _operator, root, right );
            }

            return root;
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse token list to syntax nodes</note>
        /// <param name="tokens" >Query current token list</param>
        /// <returns>DiagnosticReport</returns>
        public DiagnosticReport Parse( IEnumerable<Token> tokens ) {
            this.Prepare( );

            var root = (SyntaxNode)null;

            do {
                root = this.ParseSyntax( tokens, 0 );

                this.nodes.Add( root );
            } while ( root.Type != ENodeTypes.ENT_EOF );

            return this.Report;
        }

    }

}
