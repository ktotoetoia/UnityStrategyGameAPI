﻿namespace TDS.Economy
{
    public interface INumerableResource<out TResource> : ICappedValue<int> 
    {
        TResource Resource { get; }
    }
}