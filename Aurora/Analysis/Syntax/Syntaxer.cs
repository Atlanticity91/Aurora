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

        private Token[] tokens;
        private List<SyntaxNode> nodes;
        private int node_id;

        public IEnumerable<SyntaxNode> Nodes => this.nodes;

        private Token Current => this.Peek( 0 );

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
        /// <param name="tokens" >Current token enumerable</param>
        protected virtual void Prepare( IEnumerable<Token> tokens ) {
            this.ClearDiags( );
            this.tokens = tokens.ToArray( );
            this.nodes.Clear( );
            this.node_id = 0;
        }

        /// <summary>
        /// Peek function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Peek a token from current token</note>
        /// <param name="offset"></param>
        /// <returns>Token</returns>
        protected Token Peek( int offset ) {
            var query_id = this.node_id + offset;
            
            if ( query_id < this.tokens.Length )
                return this.tokens[ query_id] ;
            
            return this.tokens[ this.tokens.Length - 1 ];
        }

        /// <summary>
        /// Next function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get current token and increase token index for next iteration</note>
        /// <returns>Token</returns>
        protected Token Next( ) {
            var current = this.Current;

            this.node_id += 1;

            return current;
        }

        /// <summary>
        /// Match function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Verify if the node_id token match a specific token type</note>
        /// <param name="query" >Query token type</param>
        /// <returns>Token</returns>
        protected Token Match( ETokenTypes query ) {
            if ( this.Current.Type != query )
                this.EmitErrr( $"Unexpected token <{this.Current.Type}>, expected <{query}>", this.Current.Meta );

            return this.Next( );
        }

        /// <summary>
        /// ParseExpression virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse expression syntax</note>
        /// <param name="precedence" >Current expression precedence value</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseExpression( ) {
            switch ( this.Peek( 1 ).Type ) {
                case ETokenTypes.ETT_OP_AEQU :
                case ETokenTypes.ETT_OP_SEQU :
                case ETokenTypes.ETT_OP_MEQU :
                case ETokenTypes.ETT_OP_DEQU :
                case ETokenTypes.ETT_OP_MDEQU :
                case ETokenTypes.ETT_OP_ASIGN :
                    return this.ParseAssignmentExpression( );
            }

            return this.ParseBinaryExpression( 0 );
        }

        /// <summary>
        /// ParseUnaryExpression virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse unary expression syntax</note>
        /// <param name="precedence" >Current expression precedence value</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseUnaryExpression( int precedence ) {
            var op = this.Next( );
            var operand = this.ParseBinaryExpression( precedence );

            return new UnaryExpressionNode( op, operand );
        }

        /// <summary>
        /// ParseBinaryExpression virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse binary expression syntax</note>
        /// <param name="precedence" >Current expression precedence value</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseBinaryExpression( int precedence ) {
            var expression = (SyntaxNode)null;
            var unary = this.Current.UnaryPrecedence( );

            if ( unary != 0 && unary >= precedence )
                expression = this.ParseUnaryExpression( unary );
            else
                expression = this.ParseToken( );

            while ( true ) {
                var _precedence = this.Current.Precedence( );

                if ( _precedence == 0 || _precedence <= precedence )
                    break;

                var op = this.Next( );
                var right = this.ParseBinaryExpression( _precedence );

                expression = new BinaryExpressionNode( op, expression, right );
            }

            return expression;
        }

        /// <summary>
        /// ParseAssignmentExpression virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse assignment expression syntax</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseAssignmentExpression( ) {
            var identifier = this.ParseToken( );
            var op = this.Next( );
            var expression = this.ParseBinaryExpression( 0 );
            
            return new AssignExpressionNode( op, identifier, expression );
        }

        /// <summary>
        /// ParseParanthesisExpression virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse paranthesis expression syntax</note>
        /// <param name="open" >Current open paranthesis token</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseParanthesisExpression( Token open ) {
            var expression = this.ParseBinaryExpression( 0 );
            var close = this.Match( ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS );

            return new ParanthesisExpressionNode( open, close, expression );
        }

        /// <summary>
        /// ParseToken virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse node_id token to syntax node</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseToken( ) {
            var token = this.Next( );

            if ( token.IsEOF )
                return new SyntaxNode( ENodeTypes.ENT_EOF, token );
            else if ( token.IsSemicolon )
                return new SyntaxNode( ENodeTypes.ENT_SEMICOLON, token );
            else if ( token.IsLiteral )
                return new SyntaxNode( ENodeTypes.ENT_LITERAL, token );
            else if ( token.IsIdentifier )
                return new SyntaxNode( ENodeTypes.ENT_IDENTIFIER, token );
            else if ( token.IsType )
                return new SyntaxNode( ENodeTypes.ENT_TYPE, token );
            else if ( token.Type == ETokenTypes.ETT_SEP_OPEN_PARANTHESIS )
                return this.ParseParanthesisExpression( token );

            this.EmitErrr( $"Unexpected token type <{token.Type}>.", token.Meta );

            return new SyntaxNode( ENodeTypes.ENT_UNKNOW, token );
        }

        /// <summary>
        /// ParseHugs virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse hugs node</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseHugs( ) {
            var open = this.Next( );
            var content = new List<SyntaxNode>( );

            while ( this.Current.Type != ETokenTypes.ETT_SEP_CLOSE_HUG )
                content.Append( this.ParseSyntax( ) );

            var close = this.Match( ETokenTypes.ETT_SEP_CLOSE_HUG );

            return new HugsNode( open, close, content );
        }

        /// <summary>
        /// ParseType virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse type node</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseType( ) {
            var type = (SyntaxNode)null;

            if ( this.Current.Type == ETokenTypes.ETT_OP_ASIGN_TYPE ) {
                this.Next( );
                type = this.ParseToken( );
            }

            return type;
        } 

        /// <summary>
        /// ParseVariableDeclaration virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse variable declaration</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseVariableDeclaration( ) {
            var keyword = this.Next( );
            var name = this.Match( ETokenTypes.ETT_IDENTIFIER );
            var type = this.ParseType( );
            var end = this.Match( ETokenTypes.ETT_SEP_SEMICOLON );

            return new VariableDeclarationNode( keyword, name, type, end );
        }

        /// <summary>
        /// ParseFunctionParameters virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse function parameters declaration</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseFunctionParameters( ) {
            var open = this.Match( ETokenTypes.ETT_SEP_OPEN_PARANTHESIS );
            var parameters = new List<SyntaxNode>( );

            while ( this.Current.Type != ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS ) {
                var name = this.Next( );
                var type = this.ParseType( );

                parameters.Add( new ParameterDeclarationNode( name, type ) );

                if ( this.Current.Type == ETokenTypes.ETT_SEP_COMA )
                    this.Next( );
            }

            var close = this.Match( ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS );

            return new ParametersNode( open, close, parameters );
        }

        /// <summary>
        /// ParseReturnStatement virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse function return statement</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseReturnStatement( ) {
            var keyword = this.Match( ETokenTypes.ETT_KEYWORD );
            
            var value = (SyntaxNode)null; // TODO : Parse return statement value

            var end = this.Match( ETokenTypes.ETT_SEP_SEMICOLON );

            return new ReturnStatementNode( keyword, value, end );
        }

        /// <summary>
        /// ParseFunctionBody virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse function parameters declaration</note>
        /// <returns>IEnumerable<SyntaxNode></returns>
        protected virtual IEnumerable<SyntaxNode> ParseFunctionBody( ) {
            while ( this.Current.Text != "end" )
                this.Next( ); // TODO : Parse Function body

            return null;
        }

        /// <summary>
        /// ParseFunctionDeclaration virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse function declaration</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseFunctionDeclaration( ) {
            var keyword = this.Next( );
            var name = this.Match( ETokenTypes.ETT_IDENTIFIER );
            var parameters = this.ParseFunctionParameters( );
            var type = this.ParseType( );
            var body = this.ParseFunctionBody( );
            var end = this.Match( ETokenTypes.ETT_KEYWORD );

            return new FunctionDeclarationNode( keyword, name, parameters, type, body, end );
        }

        /// <summary>
        /// ParseImportDeclaration virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse import declaration</note>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseImportDeclaration( ) {
            var keyword = this.Next( );
            var path = this.Match( ETokenTypes.ETT_IDENTIFIER );
            var name = (Token)null;

            if ( this.Current.IsKeyword && this.Current.Text == "as" ) {
                this.Next( );
                name = this.Match( ETokenTypes.ETT_IDENTIFIER );
            }

            var end = this.Match( ETokenTypes.ETT_SEP_SEMICOLON );

            return new ImportDeclarationNode( keyword, path, name, end );
        }

        /// <summary>
        /// ParseSyntax virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse tokens to syntax tree</note>
        /// <param name="tokens" >Current token enumerable</param>
        /// <returns>SyntaxNode</returns>
        protected virtual SyntaxNode ParseSyntax( ) {
            switch ( this.Current.Type ) {
                case ETokenTypes.ETT_IDENTIFIER : return this.ParseExpression( );
                case ETokenTypes.ETT_SEP_OPEN_HUG : return this.ParseHugs( );

                case ETokenTypes.ETT_KEYWORD :
                    if ( this.Current.Text == "var" || this.Current.Text == "define" )
                        return this.ParseVariableDeclaration( );
                    else if ( this.Current.Text == "function" )
                        return this.ParseFunctionDeclaration( );
                    else if ( this.Current.Text == "import" )
                        return this.ParseImportDeclaration( );

                    break;

                default : break;
            }

            return this.ParseToken( );
        }

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse token list to syntax nodes</note>
        /// <param name="tokens" >Query node_id token list</param>
        /// <returns>DiagnosticReport</returns>
        public DiagnosticReport Parse( IEnumerable<Token> tokens ) {
            this.Prepare( tokens );

            while ( !this.Current.IsEOF ) {
                var tree = this.ParseSyntax( );

                this.nodes.Add( tree );
            }

            this.tokens = null;

            return this.Report;
        }

    }

}
