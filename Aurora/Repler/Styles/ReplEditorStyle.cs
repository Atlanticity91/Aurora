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

using Aurora.Utils;
using System;

namespace Aurora.Repler.Styles {

    /// <summary>
    /// ReplEditorStyle class [ ReplConsoleStyle ]
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Define Aurora default console repl editor style support</note>
    public class ReplEditorStyle : ReplConsoleStyle {

        public char Unsaved { get; }
        public char NewLineSingle { get; }
        public char NewLineMulti { get; }
        public char Help { get; }

        public Color CurrentDocument { get; }
        public Color UnsavedDocument { get; }
        public Color OtherDocument { get; }
        public Color DocumentSepratator { get; }
        public Color NewLine { get; }
        public Color Command { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="name" >Name of the style</param>
        public ReplEditorStyle( string name )
            : base( name ) 
        {
            this.Unsaved = '§';
            this.NewLineSingle = '»';
            this.NewLineMulti = '·';
            this.Help = '¤';

            this.CurrentDocument = new Color( ConsoleColor.DarkCyan, this.Background );
            this.UnsavedDocument = new Color( ConsoleColor.DarkYellow, this.Background );
            this.OtherDocument = new Color( ConsoleColor.DarkGray, this.Background );
            this.DocumentSepratator = new Color( ConsoleColor.Gray, this.Background );
            this.NewLine = new Color( ConsoleColor.Green, this.Background );
            this.Command = new Color( ConsoleColor.Gray, this.Background );
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        public ReplEditorStyle( ) 
            : this( "Default" ) 
        { 
        }

    }

}
