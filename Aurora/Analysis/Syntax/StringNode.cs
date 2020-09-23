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

using Aurora.Analysis.Lexem;
using System.Collections.Generic;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// StringNode class [ SyntaxNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora string node core class</note>
    public class StringNode : SyntaxNode {

        public Token End { get; }
        public IEnumerable<Token> Text { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="start" >String start delimiter</param>
        /// <param name="text" >Text of the string</param>
        /// <param name="end" >String end delimiter</param>
        public StringNode( Token start, IEnumerable<Token> text, Token end )
            : base( ENodeTypes.ENT_STRING, start ) 
        {
            this.Text = text;
            this.End = end;
        }

        /// <summary>
        /// GetString function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get current string value</note>
        /// <returns>string</returns>
        public string GetString( ) {
            var text = "";

            foreach ( var element in this.Text )
                text += $"{element.Text} ";

            return $"\"{text.Substring( 0, text.Length - 1)}\"";
        }

    }

}
