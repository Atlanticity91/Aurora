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

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aurora.Utils {

    /// <summary>
    /// File internal class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Define text metadata</note>
    internal class File {

        /// <summary>
        /// Load static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="path" >Path to the file to load</param>
        /// <returns>bool</returns>
        public static bool Load( ref List<string> lines, string path ) {
            if ( !string.IsNullOrEmpty( path ) ) {
                using ( StreamReader reader = new StreamReader( path, Encoding.UTF8 ) ) {
                    lines.Clear( );

                    while ( !reader.EndOfStream )
                        lines.Add( reader.ReadLine( ) );

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Write static method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <typeparam name="T" >Type of the data to write</typeparam>
        /// <param name="path" >Path to the file to write</param>
        /// <param name="lines" >Collection of string thats corespond to lines to write</param>
        public static void Write<T>( string path, IEnumerable<T> lines ) {
            using ( StreamWriter writer = new StreamWriter( path, true, Encoding.UTF8 ) ) {
                foreach ( var line in lines )
                    writer.Write( line );
            }
        }

    }

}
