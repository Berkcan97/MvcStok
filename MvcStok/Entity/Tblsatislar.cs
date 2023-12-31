﻿using System;
using System.Collections.Generic;

namespace MvcStok.Entity;

public partial class Tblsatislar
{
    public int Satisid { get; set; }

    public int? Urun { get; set; }

    public int? Musteri { get; set; }

    public byte? Adet { get; set; }

    public decimal? Fİyat { get; set; }

    public virtual Tblmusteriler? MusteriNavigation { get; set; }

    public virtual Tblurunler? UrunNavigation { get; set; }
}
