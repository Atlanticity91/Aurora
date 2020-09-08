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

namespace Aurora.Analysis.Lexem {

    /// <summary>
    /// TokenPrecedence static class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora token precedence</note>
    public static class TokenPrecedence {

        /// <summary>
        /// Precedence static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get current token precedence value</note>
        /// <param name="token" >Current token</param>
        /// <returns>int</returns>
        public static int Precedence( this Token token ) {
            if ( token != null ) {
                switch ( token.Type ) {
                    case ETokenTypes.ETT_OP_ADD :
                    case ETokenTypes.ETT_OP_SUB : return 1;

                    case ETokenTypes.ETT_OP_MUL :
                    case ETokenTypes.ETT_OP_DIV :
                    case ETokenTypes.ETT_OP_MOD : return 2;

                    default: break;
                }
            }

            return 0;
        }

    }

}
