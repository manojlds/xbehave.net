﻿// <copyright file="StringExtensions.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Xbehave.Fluent;
    using Xbehave.Internal;

    /// <summary>
    /// Extensions for declaring Given, When, Then scenario steps.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Deprecated in version 0.4.0.
        /// </summary>
        /// <param name="message">A message describing the arrangment.</param>
        /// <param name="arrange">The function that will perform and return the arrangement.</param>
        /// <returns>An instance of <see cref="ISpecificationPrimitive"/>.</returns>
        [Obsolete("Use Given(Func<IDisposable>) instead.")]
        public static IStep GivenDisposable(this string message, ContextDelegate arrange)
        {
            return message.ContextFixture(arrange);
        }
    }
}