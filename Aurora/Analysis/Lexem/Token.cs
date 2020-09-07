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
        ETT_KEYWORD,

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
        public bool IsEOF => this.Type == ETokenTypes.ETT_EOF;
        public bool IsOperator => this.interal_IsOperator( );
        public bool IsSeparator => this.interal_IsSeparator( );
        public bool IsType => this.interal_IsType( );
        public bool IsLiteral => this.interal_IsLiteral( );
        public bool IsUnsigned => this.IsType && this.Meta.Value.StartsWith( 'u' );
        public bool IsKeyword => this.Type == ETokenTypes.ETT_KEYWORD || this.IsType;

        public bool IsTermOperator => this.Type == ETokenTypes.ETT_OP_ADD || this.Type == ETokenTypes.ETT_OP_SUB;
        public bool IsFactorOperator => this.Type == ETokenTypes.ETT_OP_MUL || this.Type == ETokenTypes.ETT_OP_DIV || this.Type == ETokenTypes.ETT_OP_MOD;

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
            return  this.Type == ETokenTypes.ETT_OP_ASIGN ||
                    this.Type == ETokenTypes.ETT_OP_ADD ||
                    this.Type == ETokenTypes.ETT_OP_AEQU ||
                    this.Type == ETokenTypes.ETT_OP_SUB ||
                    this.Type == ETokenTypes.ETT_OP_SBEQU ||
                    this.Type == ETokenTypes.ETT_OP_MUL ||
                    this.Type == ETokenTypes.ETT_OP_MEQU ||
                    this.Type == ETokenTypes.ETT_OP_DIV ||
                    this.Type == ETokenTypes.ETT_OP_DEQU ||
                    this.Type == ETokenTypes.ETT_OP_MOD ||
                    this.Type == ETokenTypes.ETT_OP_MDEQU ||
                    this.Type == ETokenTypes.ETT_OP_NOT ||
                    this.Type == ETokenTypes.ETT_OP_EQU ||
                    this.Type == ETokenTypes.ETT_OP_NEQU ||
                    this.Type == ETokenTypes.ETT_OP_INF ||
                    this.Type == ETokenTypes.ETT_OP_IEQU ||
                    this.Type == ETokenTypes.ETT_OP_SUP ||
                    this.Type == ETokenTypes.ETT_OP_SEQU ||
                    this.Type == ETokenTypes.ETT_OP_INC ||
                    this.Type == ETokenTypes.ETT_OP_DEC ||
                    this.Type == ETokenTypes.ETT_OP_ASIGN_TYPE ||
                    this.Type == ETokenTypes.ETT_OP_MEMBER ||
                    this.Type == ETokenTypes.ETT_OP_NAME_MEMBER ||
                    this.Type == ETokenTypes.ETT_OP_UADD ||
                    this.Type == ETokenTypes.ETT_OP_UXOR ||
                    this.Type == ETokenTypes.ETT_OP_UOR ||
                    this.Type == ETokenTypes.ETT_OP_UCOMP;
        }

        /// <summary>
        /// interal_IsSeparator internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a separator</note>
        /// <returns>bool</returns>
        internal bool interal_IsSeparator( ) {
            return  this.Type == ETokenTypes.ETT_SEP_OPEN_PARANTHESIS ||
                    this.Type == ETokenTypes.ETT_SEP_OPEN_BRACKETS ||
                    this.Type == ETokenTypes.ETT_SEP_OPEN_HUG ||
                    this.Type == ETokenTypes.ETT_SEP_CLOSE_PARANTHESIS ||
                    this.Type == ETokenTypes.ETT_SEP_CLOSE_BRACKETS ||
                    this.Type ==  ETokenTypes.ETT_SEP_CLOSE_HUG ||
                    this.Type == ETokenTypes.ETT_SEP_COMA ||
                    this.Type == ETokenTypes.ETT_SEP_SEMICOLON;
        }

        /// <summary>
        /// interal_IsType internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a type</note>
        /// <returns>bool</returns>
        internal bool interal_IsType( ) {
            return  this.Type == ETokenTypes.ETT_TYPE ||
                    this.Type == ETokenTypes.ETT_TYPE_INT8 ||
                    this.Type == ETokenTypes.ETT_TYPE_INT16 ||
                    this.Type == ETokenTypes.ETT_TYPE_INT32 ||
                    this.Type == ETokenTypes.ETT_TYPE_INT64 ||
                    this.Type == ETokenTypes.ETT_TYPE_FLOAT32 ||
                    this.Type == ETokenTypes.ETT_TYPE_FLOAT64;
        }

        /// <summary>
        /// interal_IsLiteral internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current token is a literal</note>
        /// <returns>bool</returns>
        internal bool interal_IsLiteral( ) {
            return  this.Type == ETokenTypes.ETT_LITERAL ||
                    this.Type == ETokenTypes.ETT_BIN_LITERAL ||
                    this.Type == ETokenTypes.ETT_HEX_LITERAL;
        }

    }

}
