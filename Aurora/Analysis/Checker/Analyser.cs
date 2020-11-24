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

using Aurora.Analysis.Checker.Symbols;
using Aurora.Analysis.Checker.Types;
using Aurora.Analysis.Syntax;
using Aurora.Utils;
using System.Collections.Generic;

namespace Aurora.Analysis.Checker {

    /// <summary>
    /// Analyser class [ Parser ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora analyser core class</note>
    public class Analyser : Parser<SyntaxNode> {

        protected SymbolChecker symbol_checker;
        protected TypeChecker type_checker;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public Analyser( )
            : base( "Analyser" ) 
        { 
        }

        /// <summary>
        /// SetSymbolChecker generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set current symbol checker of analyser</note>
        /// <typeparam name="T" >Query symbol checker</typeparam>
        public void SetSymbolChecker<T>( ) where T : SymbolChecker, new( ) => this.symbol_checker = new T( );

        /// <summary>
        /// SetTypeChecker generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Set current type checker of analyser</note>
        /// <typeparam name="T" >Query type checker</typeparam>
        public void SetTypeChecker<T>( ) where T : TypeChecker, new( ) => this.type_checker = new T( );

        /// <summary>
        /// Initialize method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Initialize current analyser instance</note>
        protected override void Initialize( ) {
            this.SetSymbolChecker<SymbolChecker>( );
            this.SetTypeChecker<TypeChecker>( );
        }

        /// <summary>
        /// Prepare method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Prepare the analyser for compilation</note>
        protected override void Prepare( IEnumerable<SyntaxNode> nodes ) => this.ClearDiags( );

        /// <summary>
        /// InternalParse method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Parse syntax nodes for type checking</note>
        /// <param name="nodes" >Current syntax node list</param>
        /// <returns>DiagnosticReport</returns>
        protected override void InternalParse( IEnumerable<SyntaxNode> nodes ) {
            this.Merge( this.symbol_checker.Parse( nodes ) );

            if ( this.Report.ErrrCount == 0 )
                this.Merge( this.type_checker.Parse( null ) );
        }

    }

}
