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

using Aurora.Diagnostics;
using System.Collections.Generic;

namespace Aurora.Utils {

    /// <summary>
    /// Parser abstract generic class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Parser core code</note>
    /// <typeparam name="T" >Type of element parsed</typeparam>
    public abstract class Parser<T> : Diagnosable {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="name" ></param>
        public Parser( string name )
            : base( name ) => this.Initialize( );

        /// <summary>
        /// Initialize abstract method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Initialize current parser instance</note>
        protected abstract void Initialize( );

        /// <summary>
        /// Prepare abstract method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare current parser instance</note>
        /// <param name="elements" >Enumeration of elements to parse</param>
        protected abstract void Prepare( IEnumerable<T> elements );

        /// <summary>
        /// InternalParse abstract method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse method for current parser instance</note>
        /// <param name="elements" >Enumeration of elements to parse</param>
        protected abstract void InternalParse( IEnumerable<T> elements );

        /// <summary>
        /// Parse abstract method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse api method for current parser instance</note>
        /// <param name="elements" >Enumeration of elements to parse</param>
        /// <returns>DiagnosticReport</returns>
        public DiagnosticReport Parse( IEnumerable<T> elements ) {
            this.Prepare( elements );
            this.InternalParse( elements );

            return this.Report;
        }

    }

}
