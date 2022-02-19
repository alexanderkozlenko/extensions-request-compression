﻿// © Oleksandr Kozlenko. Licensed under the MIT license.

using Microsoft.Extensions.ObjectPool;

namespace Anemonis.Extensions.RequestCompression;

internal sealed class AcceptEncodingValueCollectionPooledObjectPolicy : PooledObjectPolicy<List<(string, double)>>
{
    public AcceptEncodingValueCollectionPooledObjectPolicy()
    {
    }

    public sealed override List<(string, double)> Create()
    {
        return new();
    }

    public sealed override bool Return(List<(string, double)> obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        if (obj.Capacity > 16)
        {
            return false;
        }

        obj.Clear();

        return true;
    }
}
