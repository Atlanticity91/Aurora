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
using Aurora.Repler.Editor;
using Aurora.Repler.Styles;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aurora.Repler {

    /// <summary>
    /// ReplEditor class [ ReplConsole ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined Aurora Repler editor core code</note>
    public class ReplEditor : ReplConsole {

        private IEnumerable<ReplControlMeta> controls;
        private IEnumerable<ReplCommandMeta> commands;
        private LocationMeta cursor;
        private Lexer lexer;
        protected bool is_running;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public ReplEditor( )
            : base( ) 
        {
            Console.Title = "Aurora Repl Editor.";

            this.SetStyle<ReplEditorStyle>( );

            this.controls = new List<ReplControlMeta>( );
            this.commands = new List<ReplCommandMeta>( );
            this.cursor = new LocationMeta( 0, 0 );
            this.lexer = new Lexer( );
            this.is_running = true;

            this.Initialize( );
        }

        /// <summary>
        /// RegisterControl generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Run current Aurora repler editor instance</note>
        /// <typeparam name="T" >Type that store control code</typeparam>
        /// <param name="flags" >Flags that defined the visibility of control</param>
        public void RegisterControl<T>( BindingFlags flags ) =>
            this.controls.Concat( AttributeHelper.ExtractAttributeMetaOf<T, ReplControl, ReplControlMeta>( flags ) );

        /// <summary>
        /// RegisterCommand generic method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Run current Aurora repler editor instance</note>
        /// <typeparam name="T" >Type that store command code</typeparam>
        /// <param name="flags" >Flags that defined the visibility of command</param>
        public void RegisterCommand<T>( BindingFlags flags ) =>
            this.commands.Concat( AttributeHelper.ExtractAttributeMetaOf<T, ReplCommand, ReplCommandMeta>( flags ) );

        /// <summary>
        /// Initialize virtual method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Initialize current Aurora repler editor instance</note>
        protected virtual void Initialize( ) {
            this.RegisterControl<ReplEditor>( AttributeHelper.DEFAULT_FLAGS );
            this.RegisterCommand<ReplEditor>( AttributeHelper.DEFAULT_FLAGS );
        }

        /// <summary>
        /// Run method
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Run current Aurora repler editor instance</note>
        public void Run( ) {
            while ( this.is_running ) {
            }
        }

    }

}
