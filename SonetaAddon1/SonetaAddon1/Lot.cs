using System;
using System.Collections.Generic;
using System.Text;

namespace SonetaAddon1
{
    public class Lot: Szkolenie.SzkolenieModule.LotRow
    {
        public override string ToString()
        {
            return Nazwa + " z " + LokalizacjaMiejscowosc;
        }
    }
}
