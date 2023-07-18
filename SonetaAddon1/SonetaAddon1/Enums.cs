using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonetaAddon1
{
    public enum CzyOplacone
    {
        // Caption można dodawać też w enumach: decyduje ono o tekście wyświetlanym np. w dropdownach
        [Caption("Opłacone")]
        Oplacone = 0,
        [Caption("Nieopłacone")]
        Nieoplacone = 1,
        [Caption("Razem")]
        Razem = 2
    }
}
