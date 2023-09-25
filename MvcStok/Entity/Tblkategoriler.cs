using System;
using System.Collections.Generic;

namespace MvcStok.Entity;

public partial class Tblkategoriler
{
    public short Kategorid { get; set; }

    public string? Kategoriad { get; set; }

    public virtual ICollection<Tblurunler> Tblurunlers { get; set; } = new List<Tblurunler>();
}
