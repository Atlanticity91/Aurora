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

using Aurora.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Analysis.Lexem {

    /// <summary>
    /// Lexer class [ Parser ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora lexer core class</note>
    public class Lexer : Parser<string> {

        protected List<Token> tokens;
        private Dictionary<string, ETokenTypes> token_table;

        public IEnumerable<Token> Tokens => this.tokens;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Lexer( ) 
            : base( "Lexer" ) 
        {
            this.tokens = new List<Token>( );
            this.token_table = new Dictionary<string, ETokenTypes>( );

            this.Initialize( );
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Register a token to token table</note>
        /// <param name="span" >Token span</param>
        /// <param name="type" >Token type</param>
        protected void Register( string span, ETokenTypes type ) {
            if ( this.token_table != null && !this.token_table.ContainsKey( span ) )
                this.token_table.Add( span, type );
        }

        /// <summary>
        /// Initialize method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Initialize current lexer</note>
        protected override void Initialize( ) {
            this.Register( "var", ETokenTypes.ETT_KEYWORD_VAR );
            this.Register( "define", ETokenTypes.ETT_KEYWORD_DEFINE );
            this.Register( "if", ETokenTypes.ETT_KEYWORD_IF );
            this.Register( "else", ETokenTypes.ETT_KEYWORD_ELSE );
            this.Register( "for", ETokenTypes.ETT_KEYWORD_FOR );
            this.Register( "foreach", ETokenTypes.ETT_KEYWORD_FOREACH );
            this.Register( "while", ETokenTypes.ETT_KEYWORD_WHILE );
            this.Register( "end", ETokenTypes.ETT_KEYWORD_END );
            this.Register( "then", ETokenTypes.ETT_KEYWORD_THEN );
            this.Register( "true", ETokenTypes.ETT_KEYWORD_TRUE );
            this.Register( "false", ETokenTypes.ETT_KEYWORD_FALSE );
            this.Register( "function", ETokenTypes.ETT_KEYWORD_FUNCTION );
            this.Register( "return", ETokenTypes.ETT_KEYWORD_RETURN );
            this.Register( "continue", ETokenTypes.ETT_KEYWORD_CONTINUE );
            this.Register( "break", ETokenTypes.ETT_KEYWORD_BREAK );
            this.Register( "import", ETokenTypes.ETT_KEYWORD_IMPORT );
            this.Register( "as", ETokenTypes.ETT_KEYWORD_AS );
            this.Register( "in", ETokenTypes.ETT_KEYWORD_IN );
            this.Register( "from", ETokenTypes.ETT_KEYWORD_FROM );
            this.Register( "to", ETokenTypes.ETT_KEYWORD_TO );
            this.Register( "do", ETokenTypes.ETT_KEYWORD_DO );

            this.Register( "=", ETokenTypes.ETT_OP_ASIGN );
            this.Register( "+", ETokenTypes.ETT_OP_ADD );
            this.Register( "+=", ETokenTypes.ETT_OP_AEQU );
            this.Register( "-", ETokenTypes.ETT_OP_SUB );
            this.Register( "-=", ETokenTypes.ETT_OP_SBEQU );
            this.Register( "*", ETokenTypes.ETT_OP_MUL );
            this.Register( "*=", ETokenTypes.ETT_OP_MEQU );
            this.Register( "/", ETokenTypes.ETT_OP_DIV );
            this.Register( "/=", ETokenTypes.ETT_OP_DEQU );
            this.Register( "%", ETokenTypes.ETT_OP_MOD );
            this.Register( "%=", ETokenTypes.ETT_OP_MDEQU );
            this.Register( "not", ETokenTypes.ETT_OP_NOT );
            this.Register( "!", ETokenTypes.ETT_OP_NOT );
            this.Register( "==", ETokenTypes.ETT_OP_EQU );
            this.Register( "!=", ETokenTypes.ETT_OP_NEQU );
            this.Register( "<", ETokenTypes.ETT_OP_INF );
            this.Register( "<=", ETokenTypes.ETT_OP_IEQU );
            this.Register( ">", ETokenTypes.ETT_OP_SUP );
            this.Register( ">=", ETokenTypes.ETT_OP_SEQU );
            this.Register( "++", ETokenTypes.ETT_OP_INC );
            this.Register( "--", ETokenTypes.ETT_OP_DEC );
            this.Register( ":", ETokenTypes.ETT_OP_ASIGN_TYPE );
            this.Register( ".", ETokenTypes.ETT_OP_MEMBER );
            this.Register( "::", ETokenTypes.ETT_OP_NAME_MEMBER );
            this.Register( "?", ETokenTypes.ETT_OP_TERNARY );
            this.Register( "&", ETokenTypes.ETT_OP_UADD );
            this.Register( "|", ETokenTypes.ETT_OP_UXOR );
            this.Register( "^", ETokenTypes.ETT_OP_UOR );
            this.Register( "~", ETokenTypes.ETT_OP_UCOMP );

            this.Register( "and", ETokenTypes.ETT_COND_AND );
            this.Register( "&&", ETokenTypes.ETT_COND_AND );
            this.Register( "or", ETokenTypes.ETT_COND_OR );
            this.Register( "||", ETokenTypes.ETT_COND_OR );

            this.Register( "bool", ETokenTypes.ETT_TYPE_BOOL );
            this.Register( "byte", ETokenTypes.ETT_TYPE_INT8 );
            this.Register( "short", ETokenTypes.ETT_TYPE_INT16 );
            this.Register( "int", ETokenTypes.ETT_TYPE_INT32 );
            this.Register( "long", ETokenTypes.ETT_TYPE_INT64 );
            this.Register( "float", ETokenTypes.ETT_TYPE_FLOAT32 );
            this.Register( "double", ETokenTypes.ETT_TYPE_FLOAT64 );
            this.Register( "mat2", ETokenTypes.ETT_TYPE_MATRIX2 );
            this.Register( "mat3", ETokenTypes.ETT_TYPE_MATRIX3 );
            this.Register( "mat4", ETokenTypes.ETT_TYPE_MATRIX4 );
            this.Register( "imat2", ETokenTypes.ETT_TYPE_IMATRIX2 );
            this.Register( "imat3", ETokenTypes.ETT_TYPE_IMATRIX3 );
            this.Register( "imat4", ETokenTypes.ETT_TYPE_IMATRIX4 );
            this.Register( "string", ETokenTypes.ETT_TYPE_STRING );

            this.Register( "(", ETokenTypes.ETT_SEP_OPEN_PARANTHESIS );
            this.Register( "[", ETokenTypes.ETT_SEP_OPEN_BRACKETS );
            this.Register( "{", ETokenTypes.ETT_SEP_OPEN_HUG );
            this.Register( "}", ETokenTypes.ETT_SEP_CLOSE_HUG );
            this.Register( "]", ETokenTypes.ETT_SEP_CLOSE_BRACKETS );
            this.Register( ")", ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS );
            this.Register( ",", ETokenTypes.ETT_SEP_COMA );
            this.Register( ";", ETokenTypes.ETT_SEP_SEMICOLON );
        }

        /// <summary>
        /// Prepare virtual method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare the lexer for compilation</note>
        /// <param name="lines" >Source lines to parse</param>
        protected override void Prepare( IEnumerable<string> elements ) {
            this.ClearDiags( );
            this.tokens.Clear( );
        }

        /// <summary>
        /// ParseToken virtual function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse a span to Token</note>
        /// <param name="line" >Current line index</param>
        /// <param name="position" >Position from the start of the line</param>
        /// <param name="span" >Current substring of the line</param>
        /// <returns>Token</returns>
        protected virtual Token ParseToken( int line, int position, string span ) {
            if ( this.token_table.ContainsKey( span ) )
                return new Token( this.token_table[ span ], line, position, span );
            else if ( span.IsBlank( ) )
                return new Token( ETokenTypes.ETT_BLANK, line, position, span );
            else if ( span.IsLitteral( ) )
                return new Token( ETokenTypes.ETT_LITERAL, line, position, span );
            else if ( span == "\"" )
                return new Token( ETokenTypes.ETT_STRING, line, position, span );

            return new Token( ETokenTypes.ETT_IDENTIFIER, line, position, span );
        }

        /// <summary>
        /// ParseText virtual method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse line to tokens</note>
        /// <param name="text" >Query text of the line</param>
        /// <param name="line" >Current line index</param>
        protected virtual void ParseText( string text, ref int line ) {
            var chars = text.ToCharArray( );
            var char_id = 0;
            var start = 0;
            var old = ' ';

            while ( char_id < chars.Length ) {
                do 
                    old = chars[ char_id++ ];
                while ( char_id < chars.Length && !chars[ char_id ].GetSubmissionEnd( old, char_id ) );

                var span = text.Substring( start, char_id - start );

                if ( !span.IsBlank( ) ) {
                    var token = this.ParseToken( line, char_id, span );

                    this.tokens.Add( token );
                } else if ( span.Contains( "\n" ) )
                    line += 1;

                start = char_id;
            }
        }

        /// <summary>
        /// InternalParse method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse syntax nodes for type checking</note>
        /// <param name="nodes" >Current syntax node list</param>
        protected override void InternalParse( IEnumerable<string> lines ) {
            if ( lines != null ) {
                var line_id = 0;

                foreach ( var line in lines ) {
                    if ( !string.IsNullOrEmpty( line ) )
                        this.ParseText( line, ref line_id );

                    line_id += 1;
                }

                this.tokens.Add( new Token( lines.Count( ) ) );
            } else
                this.EmitErrr( "No input string for lexer.", null );
        }

        /// <summary>
        /// ParseLine internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse line to tokens</note>
        /// <param name="text" >Current line text</param>
        /// <param name="line" >Current line index</param>
        /// <returns>IEnumerable<Token></returns>
        public IEnumerable<Token> ParseLine( string text, int line ) {
            this.Prepare( null );

            if ( !string.IsNullOrEmpty( text ) )
                this.ParseText( text, ref line );

            return this.tokens;
        }

    }

}
