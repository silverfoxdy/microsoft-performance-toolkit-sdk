﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using Microsoft.Performance.Toolkit.PluginManager.Core.Credential;

namespace Microsoft.Performance.Toolkit.PluginManager.Core.Discovery
{
    /// <summary>
    ///     Provides a base class for implementing <see cref="IPluginDiscovererSource"/.
    /// </summary>
    /// <typeparam name="TSource">
    ///     The <see cref="Type"/> of the <see cref="IPluginSource"/> this discover discovers plugins from.
    /// </typeparam>
    public abstract class PluginDiscovererSource<TSource> : IPluginDiscovererSource<TSource>
        where TSource : class, IPluginSource
    {
        /// <inheritdoc />
        public Type PluginSourceType
        {
            get
            {
                return typeof(TSource);
            }
        }
        /// <inheritdoc />
        public abstract Lazy<ICredentialProvider<TSource>> CredentialProvider { get; }

        /// <inheritdoc />
        public abstract IPluginDiscoverer CreateDiscoverer(TSource source);

        /// <inheritdoc />
        public abstract bool IsSourceSupported(TSource source);
    }
}
