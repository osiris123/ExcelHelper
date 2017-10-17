﻿/*
 * Copyright (C) 2004-2017 AMain.com, Inc.
 * Copyright 2009-2013 Josh Close
 * All Rights Reserved
 * 
 * See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
 * See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
 */

using System;
using System.Globalization;

namespace ExcelHelper.TypeConversion
{
    /// <summary>
    /// Converts a SByte to and from an Excel value.
    /// </summary>
    public class SByteConverter : DefaultTypeConverter
    {
        /// <summary>
        /// Constructor for the type converter
        /// </summary>
        public SByteConverter()
            : base(true, typeof(sbyte))
        {
        }

        /// <summary>
        /// Converts an Excel value to an object.
        /// </summary>
        /// <param name="options">The options to use when converting.</param>
        /// <param name="excelValue">The Excel value to convert to an object.</param>
        /// <returns>The object created from the Excel value.</returns>
        public override object ConvertFromExcel(
            TypeConverterOptions options,
            object excelValue)
        {
            var text = excelValue as string;
            if (text != null) {
                var numberStyle = options.NumberStyle ?? NumberStyles.Integer;

                sbyte sb;
                if (sbyte.TryParse(text, numberStyle, options.CultureInfo, out sb)) {
                    return sb;
                }
            }
            try {
                return Convert.ToSByte(excelValue);
            } catch (Exception e) {
                throw new ExcelTypeConverterException(InvalidConversionMessage, e);
            }
        }
    }
}