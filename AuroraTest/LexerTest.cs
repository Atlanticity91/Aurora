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
using System.Linq;
using Xunit;

namespace AuroraTest {

    /// <summary>
    /// LexerTest class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora lexer core test</note>
    public class LexerTest {

        /// <summary>
        /// Parse function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Defined aurora lexer wrapper</note>
        /// <param name="text"></param>
        /// <returns>Token[]</returns>
        private Token[] Parse( string text ) {
            var lexer = new Lexer( );

            return lexer.ParseLine( text, 0 ).ToArray( );
        }

        /// <summary>
        /// Lexer_ParseSimple method 
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Defined test for single token generation</note>
        [Theory]
        [InlineData( "var", ETokenTypes.ETT_KEYWORD_VAR )]
        [InlineData( "define", ETokenTypes.ETT_KEYWORD_DEFINE )]
        [InlineData( "if", ETokenTypes.ETT_KEYWORD_IF )]
        [InlineData( "else", ETokenTypes.ETT_KEYWORD_ELSE )]
        [InlineData( "for", ETokenTypes.ETT_KEYWORD_FOR )]
        [InlineData( "foreach", ETokenTypes.ETT_KEYWORD_FOREACH )]
        [InlineData( "while", ETokenTypes.ETT_KEYWORD_WHILE )]
        [InlineData( "end", ETokenTypes.ETT_KEYWORD_END )]
        [InlineData( "then", ETokenTypes.ETT_KEYWORD_THEN )]
        [InlineData( "true", ETokenTypes.ETT_KEYWORD_TRUE )]
        [InlineData( "false", ETokenTypes.ETT_KEYWORD_FALSE )]
        [InlineData( "function", ETokenTypes.ETT_KEYWORD_FUNCTION )]
        [InlineData( "return", ETokenTypes.ETT_KEYWORD_RETURN )]
        [InlineData( "continue", ETokenTypes.ETT_KEYWORD_CONTINUE )]
        [InlineData( "break", ETokenTypes.ETT_KEYWORD_BREAK )]
        [InlineData( "import", ETokenTypes.ETT_KEYWORD_IMPORT )]
        [InlineData( "as", ETokenTypes.ETT_KEYWORD_AS )]
        [InlineData( "in", ETokenTypes.ETT_KEYWORD_IN )]
        [InlineData( "from", ETokenTypes.ETT_KEYWORD_FROM )]
        [InlineData( "to", ETokenTypes.ETT_KEYWORD_TO )]
        [InlineData( "do", ETokenTypes.ETT_KEYWORD_DO )]
        [InlineData( "=", ETokenTypes.ETT_OP_ASIGN )]
        [InlineData( "+", ETokenTypes.ETT_OP_ADD )]
        [InlineData( "+=", ETokenTypes.ETT_OP_AEQU )]
        [InlineData( "-", ETokenTypes.ETT_OP_SUB )]
        [InlineData( "-=", ETokenTypes.ETT_OP_SBEQU )]
        [InlineData( "*", ETokenTypes.ETT_OP_MUL )]
        [InlineData( "*=", ETokenTypes.ETT_OP_MEQU )]
        [InlineData( "/", ETokenTypes.ETT_OP_DIV )]
        [InlineData( "/=", ETokenTypes.ETT_OP_DEQU )]
        [InlineData( "%", ETokenTypes.ETT_OP_MOD )]
        [InlineData( "%=", ETokenTypes.ETT_OP_MDEQU )]
        [InlineData( "!", ETokenTypes.ETT_OP_NOT )]
        [InlineData( "==", ETokenTypes.ETT_OP_EQU )]
        [InlineData( "!=", ETokenTypes.ETT_OP_NEQU )]
        [InlineData( "<", ETokenTypes.ETT_OP_INF )]
        [InlineData( "<=", ETokenTypes.ETT_OP_IEQU )]
        [InlineData( ">", ETokenTypes.ETT_OP_SUP )]
        [InlineData( ">=", ETokenTypes.ETT_OP_SEQU )]
        [InlineData( "++", ETokenTypes.ETT_OP_INC )]
        [InlineData( "--", ETokenTypes.ETT_OP_DEC )]
        [InlineData( ":", ETokenTypes.ETT_OP_ASIGN_TYPE )]
        [InlineData( ".", ETokenTypes.ETT_OP_MEMBER )]
        [InlineData( "::", ETokenTypes.ETT_OP_NAME_MEMBER )]
        [InlineData( "&", ETokenTypes.ETT_OP_UADD )]
        [InlineData( "|", ETokenTypes.ETT_OP_UXOR )]
        [InlineData( "^", ETokenTypes.ETT_OP_UOR )]
        [InlineData( "~", ETokenTypes.ETT_OP_UCOMP )]
        [InlineData( "bool", ETokenTypes.ETT_TYPE_BOOL )]
        [InlineData( "byte", ETokenTypes.ETT_TYPE_INT8 )]
        [InlineData( "short", ETokenTypes.ETT_TYPE_INT16 )]
        [InlineData( "int", ETokenTypes.ETT_TYPE_INT32 )]
        [InlineData( "long", ETokenTypes.ETT_TYPE_INT64 )]
        [InlineData( "float", ETokenTypes.ETT_TYPE_FLOAT32 )]
        [InlineData( "double", ETokenTypes.ETT_TYPE_FLOAT64 )]
        [InlineData( "mat2", ETokenTypes.ETT_TYPE_MATRIX2 )]
        [InlineData( "mat3", ETokenTypes.ETT_TYPE_MATRIX3 )]
        [InlineData( "mat4", ETokenTypes.ETT_TYPE_MATRIX4 )]
        [InlineData( "imat2", ETokenTypes.ETT_TYPE_IMATRIX2 )]
        [InlineData( "imat3", ETokenTypes.ETT_TYPE_IMATRIX3 )]
        [InlineData( "imat4", ETokenTypes.ETT_TYPE_IMATRIX4 )]
        [InlineData( "string", ETokenTypes.ETT_TYPE_STRING )]
        [InlineData( "(", ETokenTypes.ETT_SEP_OPEN_PARANTHESIS )]
        [InlineData( "[", ETokenTypes.ETT_SEP_OPEN_BRACKETS )]
        [InlineData( "{", ETokenTypes.ETT_SEP_OPEN_HUG )]
        [InlineData( "}", ETokenTypes.ETT_SEP_CLOSE_HUG )]
        [InlineData( "]", ETokenTypes.ETT_SEP_CLOSE_BRACKETS )]
        [InlineData( ")", ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS )]
        [InlineData( ",", ETokenTypes.ETT_SEP_COMA )]
        [InlineData( ";", ETokenTypes.ETT_SEP_SEMICOLON )]
        public void Lexer_ParseSimple( string text, ETokenTypes target ) {
            var tokens = this.Parse( text );

            Assert.Single( tokens );
            Assert.Equal( target, tokens[ 0 ].Type );
            Assert.Equal( text, tokens[ 0 ].Meta.Value );
        }

        /// <summary>
        /// Lexer_ParseMultiple method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Defined test for multiple token generation</note>
        [Theory]
        [InlineData( "var test : string;", 
            new[] {
                ETokenTypes.ETT_KEYWORD_VAR, ETokenTypes.ETT_IDENTIFIER, ETokenTypes.ETT_OP_ASIGN_TYPE, 
                ETokenTypes.ETT_TYPE_STRING, ETokenTypes.ETT_SEP_SEMICOLON 
            } 
        )]
        [InlineData( "var test = 10;", 
            new []{ 
                ETokenTypes.ETT_KEYWORD_VAR, ETokenTypes.ETT_IDENTIFIER, ETokenTypes.ETT_OP_ASIGN, 
                ETokenTypes.ETT_LITERAL, ETokenTypes.ETT_SEP_SEMICOLON 
            } 
        )]
        [InlineData( "for idx from 0 to 10 do end", 
            new[] { 
                ETokenTypes.ETT_KEYWORD_FOR, ETokenTypes.ETT_IDENTIFIER, ETokenTypes.ETT_KEYWORD_FROM, ETokenTypes.ETT_LITERAL, 
                ETokenTypes.ETT_KEYWORD_TO, ETokenTypes.ETT_LITERAL, ETokenTypes.ETT_KEYWORD_DO, ETokenTypes.ETT_KEYWORD_END 
            } 
        )]
        public void Lexer_ParseMultiple( string text, ETokenTypes[] targets ) {
            var tokens = this.Parse( text );

            Assert.Equal( tokens.Count( ), targets.Count( ) );

            for ( var idx = 0; idx < targets.Count( ); idx++ )
                Assert.Equal( targets[ idx ], tokens[ idx ].Type );
        }

    }

}
