﻿// <copyright file="Step.cs" company="Adam Ralph">
//  Copyright (c) Adam Ralph. All rights reserved.
// </copyright>

namespace Xbehave.Internal
{
    using System;
    using Xbehave.Infra;

    internal class Step
    {
        private readonly string message;
        private readonly Func<IDisposable> execute;

        public Step(string message, Func<IDisposable> execute)
        {
            Require.NotNull(execute, "execute");

            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            this.message = message;
            this.execute = execute;
        }

        public string Message
        {
            get { return this.message; }
        }

        public int MillisecondsTimeout { get; set; }

        public IDisposable Execute()
        {
            if (this.MillisecondsTimeout > 0)
            {
                var result = this.execute.BeginInvoke(null, null);

                // NOTE: we do not call the WaitOne(int) overload because it wasn't introduced until .NET 3.5 SP1 and we want to support pre-SP1
                if (!result.AsyncWaitHandle.WaitOne(this.MillisecondsTimeout, false))
                {
                    throw new Xunit.Sdk.TimeoutException(this.MillisecondsTimeout);
                }

                return this.execute.EndInvoke(result);
            }

            return this.execute();
        }
    }
}