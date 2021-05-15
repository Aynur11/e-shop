using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public interface IShopRepository
    {
        List<Section> Sections { get; }
    }
}
