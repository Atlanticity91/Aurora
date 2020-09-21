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

namespace Aurora.Analysis.Lexem {

    /// <summary>
    /// ETokenTypes enum
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora token types enum</note>
    public enum ETokenTypes {

        ETT_EOF,
        ETT_UNKNOW,
        ETT_BLANK,
        ETT_IDENTIFIER,

        ETT_KEYWORD_VAR,
        ETT_KEYWORD_DEFINE,
        ETT_KEYWORD_IF,
        ETT_KEYWORD_ELSE,
        ETT_KEYWORD_FOR,
        ETT_KEYWORD_FOREACH,
        ETT_KEYWORD_WHILE,
        ETT_KEYWORD_END,
        ETT_KEYWORD_THEN,
        ETT_KEYWORD_TRUE,
        ETT_KEYWORD_FALSE,
        ETT_KEYWORD_FUNCTION,
        ETT_KEYWORD_RETURN,
        ETT_KEYWORD_CONTINUE,
        ETT_KEYWORD_BREAK,
        ETT_KEYWORD_IMPORT,
        ETT_KEYWORD_AS,
        ETT_KEYWORD_IN,
        ETT_KEYWORD_FROM,
        ETT_KEYWORD_TO,
        ETT_KEYWORD_DO,

        ETT_LITERAL,
        ETT_HEX_LITERAL,
        ETT_BIN_LITERAL,

        ETT_OP_ASIGN,
        ETT_OP_ADD,
        ETT_OP_AEQU,
        ETT_OP_SUB,
        ETT_OP_SBEQU,
        ETT_OP_MUL,
        ETT_OP_MEQU,
        ETT_OP_DIV,
        ETT_OP_DEQU,
        ETT_OP_MOD,
        ETT_OP_MDEQU,
        ETT_OP_NOT,
        ETT_OP_EQU,
        ETT_OP_NEQU,
        ETT_OP_INF,
        ETT_OP_IEQU,
        ETT_OP_SUP,
        ETT_OP_SEQU,
        ETT_OP_INC,
        ETT_OP_DEC,
        ETT_OP_ASIGN_TYPE,
        ETT_OP_MEMBER,
        ETT_OP_NAME_MEMBER,
        ETT_OP_TERNARY,
        ETT_OP_UADD,
        ETT_OP_UXOR,
        ETT_OP_UOR,
        ETT_OP_UCOMP,

        ETT_TYPE,
        ETT_TYPE_BOOL,
        ETT_TYPE_INT8,
        ETT_TYPE_INT16,
        ETT_TYPE_INT32,
        ETT_TYPE_INT64,
        ETT_TYPE_FLOAT32,
        ETT_TYPE_FLOAT64,
        ETT_TYPE_MATRIX2,
        ETT_TYPE_MATRIX3,
        ETT_TYPE_MATRIX4,
        ETT_TYPE_IMATRIX2,
        ETT_TYPE_IMATRIX3,
        ETT_TYPE_IMATRIX4,

        ETT_SEP_OPEN_PARANTHESIS,
        ETT_SEP_OPEN_BRACKETS,
        ETT_SEP_OPEN_HUG,
        ETT_SEP_CLOSE_PARANTHESIS,
        ETT_SEP_CLOSE_BRACKETS,
        ETT_SEP_CLOSE_HUG,
        ETT_SEP_COMA,
        ETT_SEP_SEMICOLON,

    }

    /// <summary>
    /// Token class 
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora token core class</note>
    public class Token {

        public ETokenTypes Type { get; }
        public Textmeta Meta { get; }

        public bool HasMeta => this.Meta != null;
        public string Text => this.Meta.Value;
        public bool IsEOF => this.Type == ETokenTypes.ETT_EOF;
        public bool IsSemicolon => this.Type == ETokenTypes.ETT_SEP_SEMICOLON;
        public bool IsOperator => this.interal_IsOperator( );
        public bool IsUnaryOperator => this.interal_IsUnaryOperator( );
        public bool IsSeparator => this.interal_IsSeparator( );
        public bool IsType => this.interal_IsType( );
        public bool IsLiteral => this.interal_IsLiteral( );
        public bool IsUnsigned => this.IsType && this.Meta.Value.StartsWith( 'u' );
        public bool IsIdentifier => this.Type == ETokenTypes.ETT_IDENTIFIER;
        public bool IsKeyword => this.interal_IsKeyword( );
        public bool IsBoolean => this.Type == ETokenTypes.ETT_KEYWORD_TRUE || this.Type == ETokenTypes.ETT_KEYWORD_FALSE;
        public bool IsControlFlow => this.Type == ETokenTypes.ETT_KEYWORD_CONTINUE || this.Type == ETokenTypes.ETT_KEYWORD_BREAK;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="line" >Line ID of the end of file token</param>
        public Token( int line ) {
            this.Type = ETokenTypes.ETT_EOF;
            this.Meta = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="type" >Type of the new token</param>
        /// <param name="line" >Line of the new token from file start</param>
        /// <param name="position" >Position of the token from current line start</param>
        /// <param name="text" >Text that represent the token on the source text</param>
        public Token( ETokenTypes type, int line, int position, string text ) {
            this.Type = type;
            this.Meta = new Textmeta( line, position, text );
        }

        /// <summary>
        /// interal_IsOperator internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is an operator</note>
        /// <returns>bool</returns>
        internal bool interal_IsOperator( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_OP_ASIGN :
                case ETokenTypes.ETT_OP_ADD :
                case ETokenTypes.ETT_OP_AEQU :
                case ETokenTypes.ETT_OP_SUB :
                case ETokenTypes.ETT_OP_SBEQU :
                case ETokenTypes.ETT_OP_MUL :
                case ETokenTypes.ETT_OP_MEQU :
                case ETokenTypes.ETT_OP_DIV :
                case ETokenTypes.ETT_OP_DEQU :
                case ETokenTypes.ETT_OP_MOD :
                case ETokenTypes.ETT_OP_MDEQU :
                case ETokenTypes.ETT_OP_NOT :
                case ETokenTypes.ETT_OP_EQU :
                case ETokenTypes.ETT_OP_NEQU :
                case ETokenTypes.ETT_OP_INF :
                case ETokenTypes.ETT_OP_IEQU :
                case ETokenTypes.ETT_OP_SUP :
                case ETokenTypes.ETT_OP_SEQU :
                case ETokenTypes.ETT_OP_INC :
                case ETokenTypes.ETT_OP_DEC :
                case ETokenTypes.ETT_OP_ASIGN_TYPE :
                case ETokenTypes.ETT_OP_MEMBER :
                case ETokenTypes.ETT_OP_NAME_MEMBER :
                case ETokenTypes.ETT_OP_UADD :
                case ETokenTypes.ETT_OP_UXOR :
                case ETokenTypes.ETT_OP_UOR :
                case ETokenTypes.ETT_OP_UCOMP :
                    return true;
            }

            return false;
        }

        /// <summary>
        /// interal_IsUnaryOperator internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a unary operator</note>
        /// <returns>bool</returns>
        internal bool interal_IsUnaryOperator( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_OP_MUL :
                case ETokenTypes.ETT_OP_DIV :
                case ETokenTypes.ETT_OP_MOD :
                case ETokenTypes.ETT_OP_UADD :
                case ETokenTypes.ETT_OP_UXOR :
                case ETokenTypes.ETT_OP_UOR :
                case ETokenTypes.ETT_OP_UCOMP:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// interal_IsSeparator internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a separator</note>
        /// <returns>bool</returns>
        internal bool interal_IsSeparator( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_SEP_OPEN_PARANTHESIS :
                case ETokenTypes.ETT_SEP_OPEN_BRACKETS :
                case ETokenTypes.ETT_SEP_OPEN_HUG :
                case ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS :
                case ETokenTypes.ETT_SEP_CLOSE_BRACKETS :
                case ETokenTypes.ETT_SEP_CLOSE_HUG :
                case ETokenTypes.ETT_SEP_COMA :
                case ETokenTypes.ETT_SEP_SEMICOLON :
                    return true;
            }

            return false;
        }

        /// <summary>
        /// interal_IsType internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a type</note>
        /// <returns>bool</returns>
        internal bool interal_IsType( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_TYPE :
                case ETokenTypes.ETT_TYPE_INT8 :
                case ETokenTypes.ETT_TYPE_INT16 :
                case ETokenTypes.ETT_TYPE_INT32 :
                case ETokenTypes.ETT_TYPE_INT64 :
                case ETokenTypes.ETT_TYPE_FLOAT32 :
                case ETokenTypes.ETT_TYPE_FLOAT64 :
                case ETokenTypes.ETT_TYPE_MATRIX2 :
                case ETokenTypes.ETT_TYPE_MATRIX3 :
                case ETokenTypes.ETT_TYPE_MATRIX4 :
                case ETokenTypes.ETT_TYPE_IMATRIX2 :
                case ETokenTypes.ETT_TYPE_IMATRIX3 :
                case ETokenTypes.ETT_TYPE_IMATRIX4 :
                    return true;
            }

            return false;
        }

        /// <summary>
        /// interal_IsLiteral internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a literal</note>
        /// <returns>bool</returns>
        internal bool interal_IsLiteral( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_LITERAL:
                case ETokenTypes.ETT_BIN_LITERAL:
                case ETokenTypes.ETT_HEX_LITERAL:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// interal_IsKeyword internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a keyword</note>
        /// <returns>bool</returns>
        internal bool interal_IsKeyword( ) {
            switch ( this.Type ) {
                case ETokenTypes.ETT_KEYWORD_VAR :
                case ETokenTypes.ETT_KEYWORD_DEFINE :
                case ETokenTypes.ETT_KEYWORD_IF :
                case ETokenTypes.ETT_KEYWORD_ELSE :
                case ETokenTypes.ETT_KEYWORD_FOR :
                case ETokenTypes.ETT_KEYWORD_FOREACH :
                case ETokenTypes.ETT_KEYWORD_WHILE :
                case ETokenTypes.ETT_KEYWORD_END :
                case ETokenTypes.ETT_KEYWORD_THEN :
                case ETokenTypes.ETT_KEYWORD_TRUE :
                case ETokenTypes.ETT_KEYWORD_FALSE :
                case ETokenTypes.ETT_KEYWORD_FUNCTION :
                case ETokenTypes.ETT_KEYWORD_RETURN :
                case ETokenTypes.ETT_KEYWORD_CONTINUE :
                case ETokenTypes.ETT_KEYWORD_BREAK :
                case ETokenTypes.ETT_KEYWORD_IMPORT :
                case ETokenTypes.ETT_KEYWORD_AS :
                case ETokenTypes.ETT_KEYWORD_IN :
                case ETokenTypes.ETT_KEYWORD_FROM :
                case ETokenTypes.ETT_KEYWORD_TO :
                case ETokenTypes.ETT_KEYWORD_DO :
                    return true;
            }

            return false;
        }

    }

}
