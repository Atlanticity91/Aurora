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

namespace Aurora.Repler {

    /// <summary>
    /// ReplConsole class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Define Aurora default console repl style support</note>
    public class ReplConsoleStyle {

        public string Name { get; }
        public ConsoleColor Background { get; }
        public Color Text { get; protected set; }
        public Color Keyword { get; protected set; }
        public Color Literal { get; protected set; }
        public Color Operator { get; protected set; }
        public Color Separator { get; protected set; }
        public Color String { get; protected set; }
        public Color InfoDiag { get; protected set; }
        public Color WarnDiag { get; protected set; }
        public Color ErrorDiag { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <param name="name" >Name of the style</param>
        public ReplConsoleStyle( string name ) {
            this.Name = name;

            this.Background = ConsoleColor.White;
            this.Text = new Color( ConsoleColor.Gray, this.Background );
            this.Keyword = new Color( ConsoleColor.Blue, this.Background );
            this.Literal = new Color( ConsoleColor.DarkGray, this.Background );
            this.Operator = new Color( ConsoleColor.DarkYellow, this.Background );
            this.Separator = new Color( ConsoleColor.DarkGray, this.Background );
            this.String = new Color( ConsoleColor.DarkCyan, this.Background );
            this.InfoDiag = new Color( ConsoleColor.DarkGreen, this.Background );
            this.WarnDiag = new Color( ConsoleColor.DarkYellow, this.Background );
            this.ErrorDiag = new Color( ConsoleColor.DarkRed, this.Background );

            Console.BackgroundColor = this.Background;
        }

    }

}
