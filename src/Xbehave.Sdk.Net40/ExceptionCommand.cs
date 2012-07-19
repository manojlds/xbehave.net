﻿// <copyright file="ExceptionCommand.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave.Sdk
{
    using System;

    public class ExceptionCommand : TestCommand
    {
        private readonly Exception exception;

        public ExceptionCommand(IMethodInfo method, Exception exception)
            : base(method)
        {
            this.exception = exception;
        }

        public override MethodResult Execute(object testClass)
        {
            this.exception.RethrowWithNoStackTraceLoss();
            return null;
        }
    }
}