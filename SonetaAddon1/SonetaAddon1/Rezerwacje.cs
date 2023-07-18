using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: NewRow(typeof(SonetaAddon1.Rezerwacja))]

namespace SonetaAddon1
{
    public class Rezerwacje: Szkolenie.SzkolenieModule.RezerwacjaTable
    {
    }
}
