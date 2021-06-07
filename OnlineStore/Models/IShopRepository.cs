using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public interface IShopRepository : IDisposable
    {
        List<Section> Sections { get; }
    }
}
