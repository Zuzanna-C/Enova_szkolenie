using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: NewRow(typeof(SonetaAddon1.Maszyna))]

namespace SonetaAddon1
{
    public class Maszyny: Szkolenie.SzkolenieModule.MaszynaTable
    {
    }
}
