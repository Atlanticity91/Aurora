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

namespace Aurora.Utils {

    /// <summary>
    /// Textmeta sealed  class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Define text metadata</note>
    public sealed class Textmeta {

        private LocationMeta location;

        public string Value { get; }

        public int Line => this.location.Line;
        public int Position => this.location.Position;
        public int Size => this.Value.Length;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="line" >Line of the source text that contain data</param>
        /// <param name="position" >Offset from line start</param>
        /// <param name="value" >Text store on the metadata</param>
        public Textmeta( int line, int position, string value ) {
            this.location = new LocationMeta( line, position );
            this.Value = value;
        }

    }

}
