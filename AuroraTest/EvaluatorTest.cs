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

using Aurora.Analysis;
using Aurora.Runtime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AuroraTest {

    /// <summary>
    /// LexerTest class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora lexer core test</note>
    public class EvaluatorTest {

        /// <summary>
        /// Compute internal function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Compile and evaluate an expression based on source text</note>
        /// <param name="text" ></param>
        /// <returns>IEnumerable<int></returns>
        internal IEnumerable<int> Compute( string text ) {
            var compiler = new Compiler( );
            var evaluator = new Evaluator( );

            compiler.Compile( text );

            return evaluator.Evaluate( compiler.Nodes );
        }

        /// <summary>
        /// Evaluator_Expression method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Defined test for expression result evaluation</note>
        [Theory]
        [InlineData( "10", 10 )]
        [InlineData( "-10", -10 )]
        [InlineData( "1 * 2", 2 )]
        [InlineData( "-1 * 2", -2 )]
        [InlineData( "1 * 2 + 4", 6 )]
        [InlineData( "1 * ( 2 + 4 )", 6 )]
        [InlineData( "2 * ( 2 + 4 )", 12 )]
        public void Evaluator_Expression( string text, int result ) {
            var evaluation = this.Compute( text );

            Assert.Single( evaluation );
            Assert.Equal( result, evaluation.Single( ) );
        }

    }

}
