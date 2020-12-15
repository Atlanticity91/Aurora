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

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aurora.Utils {

    /// <summary>
    /// AttributeHelper sealed class
    /// </summary>
    /// <author>ALVES Quentin</author>
    /// <note>Defined attribute utils code</note>
    public sealed class AttributeHelper {

        public const BindingFlags DEFAULT_FLAGS = BindingFlags.Public | BindingFlags.NonPublic |  BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        /// <summary>
        /// GetAttributesOf generic static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get all attributes of type A from instance of type T</note>
        /// <typeparam name="T" >Type that contain the attributes</typeparam>
        /// <typeparam name="A" >Type of attributes</typeparam>
        /// <param name="flags" >Flags that defined the visibility of attributes</param>
        /// <returns>IEnumerable<(A, MethodInfo)></returns>
        public static IEnumerable<(A, MethodInfo)> GetAttributesOf<T,A>( BindingFlags flags ) where A : Attribute {
            var methods = typeof( T ).GetMethods( flags );

            foreach ( var method in methods ) {
                var target = method.GetCustomAttribute<A>( );

                if ( target != null )
                    yield return (target, method);
            }
        }

        /// <summary>
        /// GetAttributes generic static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Get all attributes of type A from parent object</note>
        /// <typeparam name="A" >Type of attributes</typeparam>
        /// <param name="parent" >Object use for attributes recuperation</param>
        /// <param name="flags" >Flags that defined the visibility of attributes</param>
        /// <returns>IEnumerable<(A, MethodInfo)></returns>
        public static IEnumerable<(A,MethodInfo)> GetAttributes<A>( object parent, BindingFlags flags ) where A : Attribute {
            var methods = parent.GetType( ).GetMethods( flags );

            foreach ( var method in methods ) {
                var target = method.GetCustomAttribute<A>( );

                if ( target != null )
                    yield return ( target, method );
            }
        }

        /// <summary>
        /// GenerateMeta generic static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Generate metadata from attribute A</note>
        /// <typeparam name="A" >Type of attributes</typeparam>
        /// <typeparam name="M" >Type of attribute meta for the attribute type A</typeparam>
        /// <param name="attributes" >Query attributes</param>
        /// <returns>IEnumerable<M></returns>
        public static IEnumerable<M> GenerateMeta<A, M>( IEnumerable<(A,MethodInfo)> attributes ) where A : Attribute where M : AttributeMeta<A>, new( ) {
            if ( attributes != null ) {
                foreach ( var attribute in attributes )
                    yield return (M)Activator.CreateInstance( typeof( M ), attribute.Item1, attribute.Item2 );
            }

            yield return default( M );
        }

        /// <summary>
        /// ExtractAttributeMetaOf generic static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Extract all metadata of attribute type A from instance of type T, store as type M</note>
        /// <typeparam name="T" >Type that contain the attributes</typeparam>
        /// <typeparam name="A" >Type of attributes</typeparam>
        /// <typeparam name="M" >Type of attribute meta for the attribute type A</typeparam>
        /// <param name="flags" >Flags that defined the visibility of attributes</param>
        /// <returns>IEnumerable<M></returns>
        public static IEnumerable<M> ExtractAttributeMetaOf<T, A, M>( BindingFlags flags ) where A : Attribute where M : AttributeMeta<A>, new( ) {
            var attributes = GetAttributesOf<T, A>( flags );

            return GenerateMeta<A, M>( attributes );
        }

        /// <summary>
        /// ExtractAttributeMeta generic static function
        /// </summary>
        /// <author>ALVES Quentin</author>
        /// <note>Extract all metadata of attribute type A from parent object, store as type M</note>
        /// <typeparam name="A" >Type of attributes</typeparam>
        /// <typeparam name="M" >Type of attribute meta for the attribute type A</typeparam>
        /// <param name="parent" >Object use for attributes recuperation</param>
        /// <param name="flags" >Flags that defined the visibility of attributes</param>
        /// <returns>IEnumerable<M></returns>
        public static IEnumerable<M> ExtractAttributeMeta<A, M>( object parent, BindingFlags flags ) where A : Attribute where M : AttributeMeta<A>, new() {
            var attributes = GetAttributes<A>( parent, flags );

            return GenerateMeta<A, M>( attributes );
        }

    }

}
