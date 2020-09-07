﻿/**
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

using Aurora.Analysis;
using Aurora.Repler;

namespace Aurora {

    /// <summary>
    /// Program sealed class
    /// </summary>
    /// <author>ALVES Quentin</author>
    public sealed class Program {

        /// <summary>
        /// Main static method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Program main entry point</note>
        /// <param name="args" >Arguments pass to the program.</param>
        public static void Main( string[] args ) {
            var console = new ReplConsole( );
            var compiler = new Compiler( );

            var result = compiler.Compile( "10 + 5 * 2;\n( 2 + 5 ) * 20" );

            // Display all compilation error
            console.Display( compiler );

            // Display current compilation token list
            console.Display( compiler.Tokens );

            // Display current compilation syntax node list
            console.Display( compiler.Nodes );
        }

    }

}
