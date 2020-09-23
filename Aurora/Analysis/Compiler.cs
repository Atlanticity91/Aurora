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

using Aurora.Analysis.Assembly;
using Aurora.Analysis.Checker;
using Aurora.Analysis.Lexem;
using Aurora.Analysis.Syntax;
using Aurora.Diagnostics;
using Aurora.Utils;
using System.Collections.Generic;

namespace Aurora.Analysis {

    /// <summary>
    /// Compiler sealed class [ DiagnosticBag ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora compiler core support</note>
    public sealed class Compiler : DiagnosticBag {

        private List<string> loader;

        public Lexer Lexer { get; private set; }
        public Syntaxer Syntaxer { get; private set; }
        public Analyser Analyser { get; private set; }
        public Assembler Assembler { get; private set; }

        public IEnumerable<string> Source => this.loader;
        public IEnumerable<Token> Tokens => this.Lexer.Tokens;
        public IEnumerable<SyntaxNode> Nodes => this.Syntaxer.Nodes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Compiler( ) {
            this.loader = new List<string>( );

            this.Lexer = new Lexer( );
            this.Syntaxer = new Syntaxer( );
            this.Analyser = new Analyser( );
            this.Assembler = new Assembler( );
        }


        /// <summary>
        /// SetLexer generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set the current compiler lexer to a custom one</note>
        /// <generic name="T" >Type of the new lexer</generic>
        public void SetLexer<T>( ) where T : Lexer, new() => this.Lexer = new T( );

        /// <summary>
        /// SetSyntaxer generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set the current compiler syntaxer to a custom one</note>
        /// <generic name="T" >Type of the new syntaxer</generic>
        public void SetSyntaxer<T>( ) where T : Syntaxer, new() => this.Syntaxer = new T( );

        /// <summary>
        /// SetAnalyser generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set the current compiler analyser to a custom one</note>
        /// <generic name="T" >Type of the new syntaxer</generic>
        public void SetAnalyser<T>( ) where T : Analyser, new() => this.Analyser = new T( );

        /// <summary>
        /// SetAssembler generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set the current compiler assembler to a custom one</note>
        /// <generic name="T" >Type of the new assembler</generic>
        public void SetAssembler<T>( ) where T : Assembler, new() => this.Assembler = new T( );

        /// <summary>
        /// Prepare method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare compiler for a new compilation</note>
        private void Prepare( ) {
            this.ClearBag( );
            this.loader.Clear( );
        }

        /// <summary>
        /// Process function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Process compilation</note>
        /// <returns>object</returns>
        private object Process( ) {
            this.Merge( this.Lexer.Parse( this.loader ) );
            this.Merge( this.Syntaxer.Parse( this.Tokens ) );

            if ( !this.HasError )
                this.Merge( this.Analyser.Parse( this.Nodes ) );

            if ( !this.HasError )
                this.Merge( this.Assembler.Parse( this.Nodes ) );

            return this.Assembler.Script;
        }

        /// <summary>
        /// Compile function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Compile text to aurora binary</note>
        /// <param name="text" >Text to compile</param>
        /// <returns>object</returns>
        public object Compile( string text ) {
            this.Prepare( );

            if ( !string.IsNullOrEmpty( text ) ) {
                this.loader.Add( text );

                return this.Process( );
            }

            return null;
        }

        /// <summary>
        /// CompileFile function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Compile a text file to aurora binary</note>
        /// <param name="path" >Path to the text file to compile</param>
        /// <returns>AuroraBin</returns>
        public object CompileFile( string path ) {
            this.Prepare( );

            if ( File.Load( ref this.loader, path ) ) 
                return this.Process( );

            return null;
        }

    }

}
