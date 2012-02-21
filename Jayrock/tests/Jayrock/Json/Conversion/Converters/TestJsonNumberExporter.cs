#region License, Terms and Conditions
//
// Jayrock - A JSON-RPC implementation for the Microsoft .NET Framework
// Written by Atif Aziz (www.raboof.com)
// Copyright (c) Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jayrock.Json.Conversion.Converters
{
    #region Imports

    using NUnit.Framework;

    #endregion

    [ TestFixture ]
    public class TestJsonNumberExporter
    {
        [ Test ]
        public void Superclass()
        {
            Assert.IsInstanceOfType(typeof(ExporterBase), new JsonNumberExporter());
        }

        [ Test ]
        public void InputTypeIsJsonNumber()
        {
            Assert.AreSame(typeof(JsonNumber), (new JsonNumberExporter()).InputType);
        }

        [ Test ]
        public void ExportDefault()
        {
            Assert.AreEqual(0, (int) Export(new JsonNumber()).ReadNumber());
        }

        [ Test ]
        public void ExportNonZero()
        {
            Assert.AreEqual(42, (int) Export(new JsonNumber("42")).ReadNumber());
        }

        private static JsonReader Export(JsonNumber value)
        {
            JsonRecorder writer = new JsonRecorder();
            JsonConvert.Export(value, writer);
            return writer.CreatePlayer();
        }
    }
}