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
using Aurora.Analysis.Syntax;
using Aurora.Diagnostics;
using Aurora.Repler.Styles;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Aurora.Repler {

    /// <summary>
    /// ReplConsole class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Define Aurora default console repl code</note>
    public class ReplConsole {

        public ReplConsoleStyle Style { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public ReplConsole( ) => this.Style = new ReplConsoleStyle( "Default" );

        /// <summary>
        /// SetStyle method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set current repl console style</note>
        /// <typeparam name="T"></typeparam>
        public void SetStyle<T>( ) where T : ReplConsoleStyle, new() => this.Style = new T( );

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set current repl console style</note>
        /// <param name="color" >Color of the text</param>
        /// <param name="text" >Text to display</param>
        protected void Display( Color color, string text ) {
            if ( !string.IsNullOrEmpty( text ) ) {
                Console.ForegroundColor = color.Foreground;
                Console.BackgroundColor = color.Background;

                Console.Write( text );

                Console.ResetColor( );
                Console.BackgroundColor = this.Style.Background;
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display text on console</note>
        /// <param name="text" >Text to display</param>
        public void Display( string text ) => this.Display( this.Style.Text, text );

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display token on console</note>
        /// <param name="token" >Query token to display</param>
        public void Display( Token token ) {
            if ( token != null ) {
                var meta = "";

                if ( token.HasMeta )
                    meta = $"[ {token.Meta.Line}, {token.Meta.Position} ]";

                if ( token.Type != ETokenTypes.ETT_EOF )
                    this.Display( this.Style.Text, $"{meta}[ {token.Type} ] {token.Meta.Value}\n" );
                else
                    this.Display( this.Style.WarnDiag, $"{meta}[ EOF ]\n" );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display token list on console</note>
        /// <param name="tokens" >Query token list</param>
        public void Display( IEnumerable<Token> tokens ) {
            if ( tokens != null ) {
                foreach ( var token in tokens )
                    this.Display( token );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display a node on console</note>
        /// <param name="node" >Query syntax node to display</param>
        /// <param name="indent" >Indentation from left</param>
        /// <param name="last" >If the current node is the last to display</param>
        public void Display( SyntaxNode node, string indent = "", bool last = true ) {
            if ( node != null ) {
                if ( !node.Token.IsEOF ) {
                    var maker = ( last ) ? "└─" : "├─";

                    this.Display( this.Style.Text, $"{indent}{maker} [ {node.Type} ] " );

                    var tokens = node.Tokens;
                    if ( tokens != null ) {
                        var color = (Color)null;

                        foreach ( var token in tokens ) {
                            if ( token != null ) {
                                if ( token.IsSeparator )
                                    color = this.Style.Separator;
                                else if ( token.IsOperator )
                                    color = this.Style.Operator;
                                else if ( token.IsLiteral )
                                    color = this.Style.Literal;
                                else if ( token.IsKeyword )
                                    color = this.Style.Keyword;
                                else if ( token.IsType )
                                    color = this.Style.Type;
                                else if ( token.IsString )
                                    color = this.Style.String;
                                else
                                    color = this.Style.Text;

                                this.Display( color, $"{token.Meta.Value} " );
                            }
                        }

                        Console.Write( "\n" );
                    }

                    indent += (last) ? "   " : "│  ";

                    foreach ( var child in node.Childs )
                        this.Display( child, indent, child == node.Childs.LastOrDefault( ) );
                } else
                    this.Display( this.Style.WarnDiag, "- End Of File \n" );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display a node list on console</note>
        /// <param name="nodes" >Query node list</param>
        public void Display( IEnumerable<SyntaxNode> nodes ) {
            if ( nodes != null ) {
                foreach ( var node in nodes )
                    this.Display( node );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display a diagnostic on console</note>
        /// <param name="diagnostic" >The diagnostic to display</param>
        public void Display( Diagnostic diagnostic ) {
            if ( diagnostic != null ) {
                var diag_message = "";

                if ( diagnostic.HasMeta )
                    diag_message += $"[ {diagnostic.Meta.Line} => {diagnostic.Meta.Position}, {diagnostic.Meta.Size} ] {diagnostic.Message}";
                else
                    diag_message += $" {diagnostic.Message}";

                if ( diagnostic.Type == EDiagnosticTypes.EDT_INFO )
                    this.Display( this.Style.InfoDiag, $"   [ INFO ]{diag_message}\n" );
                else if ( diagnostic.Type == EDiagnosticTypes.EDT_WARN )
                    this.Display( this.Style.WarnDiag, $"   [ WARN ]{diag_message}\n" );
                else if ( diagnostic.Type == EDiagnosticTypes.EDT_ERRR )
                    this.Display( this.Style.ErrorDiag, $"   [ ERRR ]{diag_message}\n" );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display a diagnostic report on console</note>
        /// <param name="report" >Query diagnostic report to display</param>
        public void Display( DiagnosticReport report ) {
            if ( report != null && report.HasDiagnostics ) {
                this.Display( this.Style.Text, $"Report emitted from {report.Emitter} :\n" );

                foreach ( var diag in report.Diagnostics )
                    this.Display( diag );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display a diagnostic bag on console</note>
        /// <param name="diag_bag" >Query diagnostic bag</param>
        public void Display( DiagnosticBag diag_bag ) {
            if ( diag_bag != null && diag_bag.HasReports ) {
                foreach ( var report in diag_bag.Reports )
                    this.Display( report );
            }
        }

        /// <summary>
        /// Display method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Display output of evaluation phase on console</note>
        /// <param name="evaluations" >List of int generate by expression evaluation</param>
        public void Display( IEnumerable<int> evaluations ) {
            if ( evaluations != null ) {
                this.Display( "Evaluation result :\n" );

                foreach ( var eval in evaluations ) {
                    if ( eval > -1 )
                        this.Display( this.Style.Literal, $"  {eval}\n" );
                    else {
                        this.Display( this.Style.Operator, "  -" );
                        this.Display( this.Style.Literal, $"{-eval}\n" );
                    }
                }
            }
        }

    }

}
