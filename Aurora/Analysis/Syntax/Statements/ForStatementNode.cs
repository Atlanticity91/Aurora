﻿/**
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

using Aurora.Analysis.Lexem;
using System.Collections.Generic;

namespace Aurora.Analysis.Syntax {

    /// <summary>
    /// ForStatementNode class [ DeclarationNode ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora for statement core class</note>
    public class ForStatementNode : StatementNode {

        public Token From { get; }
        public Token To { get; }
        public Token Do { get; }
        public Token End { get; }
        public SyntaxNode Identifier { get; }
        public SyntaxNode Lower { get; }
        public SyntaxNode Upper { get; }
        public IEnumerable<SyntaxNode> Body { get; }

        public override IEnumerable<Token> Tokens {
            get {
                yield return this.Token;
                yield return this.From;
                yield return this.To;
                yield return this.Do;
                yield return this.End;
            }
        }

        public override IEnumerable<SyntaxNode> Childs {
            get {
                yield return this.Identifier;
                yield return this.Lower;
                yield return this.Upper;

                foreach ( var content in this.Body )
                    yield return content;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="keyword" >Current for statement keyword</param>
        /// <param name="identifier" >Current for statement counter name</param>
        /// <param name="from" >Current for statement from keyword</param>
        /// <param name="lower" >Current for statement lower bound</param>
        /// <param name="to" >Current for statement to keyword</param>
        /// <param name="upper" >Current for statement upper bound</param>
        /// <param name="do_" >Current for statement do keyword</param>
        /// <param name="body" >Current for statement body</param>
        /// <param name="end" >Current for statement end keyword</param>
        public ForStatementNode( Token keyword, SyntaxNode identifier, Token from, SyntaxNode lower, Token to, SyntaxNode upper, Token do_, IEnumerable<SyntaxNode> body, Token end ) 
            : base( keyword ) 
        {
            this.Identifier = identifier;
            this.From = from;
            this.Lower = lower;
            this.To = to;
            this.Upper = upper;
            this.Do = do_;
            this.Body = body;
            this.End = end;
        }

    }

}
