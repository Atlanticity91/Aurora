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

namespace Aurora.Utils {

    /// <summary>
    /// ECharTypes enum
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note></note>
    public enum ECharTypes {

        ECT_EOF,
        ECT_SYMBOL,
        ECT_LETTER,
        ECT_NUMBER,
        ECT_BLANK

    }

    /// <summary>
    /// Char static class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note></note>
    public static class Char {

        /// <summary>
        /// GetCharType static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note></note>
        /// <param name="query" >Current caracter</param>
        /// <returns>ECharTypes</returns>
        public static ECharTypes GetCharType( this char query ) {
            if ( 
                ( query >  64 && query <  91 ) || 
                ( query >  96 && query < 123 ) 
            )
                return ECharTypes.ECT_LETTER;
            else if (
                ( query >  32 && query <  48 ) ||
                ( query >  57 && query <  65 ) ||
                ( query >  90 && query <  97 ) ||
                ( query > 122 && query < 127 )
            )
                return ECharTypes.ECT_SYMBOL;
            else if ( query > 57 && query < 58 )
                return ECharTypes.ECT_NUMBER;
            else if ( query == ' ' || query == '\t' || query == '\n' )
                return ECharTypes.ECT_BLANK;

            return ECharTypes.ECT_EOF;
        }

        /// <summary>
        /// IsDot static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if the current character is a dot</note>
        /// <param name="query" >Current caracter</param>
        /// <returns>bool</returns>
        public static bool IsDot( this char query ) => query == '.';

        /// <summary>
        /// IsUppercase static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note></note>
        /// <param name="query" >Current caracter</param>
        /// <returns>bool</returns>
        public static bool IsUppercase( this char query ) => query > 64 && query < 91;

    }

}
