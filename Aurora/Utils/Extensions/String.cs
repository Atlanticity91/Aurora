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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Utils {

    /// <summary>
    /// String static class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note></note>
    public static class String {

        /// <summary>
        /// Count static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Count enumerable lines</note>
        /// <param name="query" >Current enumerable</param>
        /// <returns>int</returns>
        public static int Count( this IEnumerable<string> query ) => query.Count<string>( );

        /// <summary>
        /// IsLitteral static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if a string is a literal</note>
        /// <param name="query" >Current string</param>
        /// <returns>bool</returns>
        public static bool IsLitteral( this string query ) {
            if ( !string.IsNullOrEmpty( query ) ) 
                return query[ 0 ] == '#' || query[ 0 ] == '@'|| query[ 0 ] == '.' || char.IsDigit( query[ 0 ] );

            return false;
        }

        /// <summary>
        /// IsBlank static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get if a string is a blank</note>
        /// <param name="query" >Current string</param>
        /// <returns>bool</returns>
        public static bool IsBlank( this string query ) {
            if ( !string.IsNullOrEmpty( query ) )
                return query[ 0 ].GetCharType( ) == ECharTypes.ECT_BLANK;

            return false;
        }

        /// <summary>
        /// ToDecimal static extension function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Convert string from hex or binary to int</note>
        /// <param name="query" >Current string</param>
        /// <returns>int</returns>
        public static int ToDecimal( this string query ) {
            if ( query.StartsWith( '#' ) )
                return Convert.ToInt32( query.Substring( 1 ), 16 );
            else if ( query.StartsWith( '@' ) )
                return Convert.ToInt32( query.Substring( 1 ), 2 );

            return 0;
        }   
        
    }

}
