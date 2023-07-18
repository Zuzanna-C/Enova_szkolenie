using Soneta.Business;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SonetaAddon1
{
    public class Rezerwacja: Szkolenie.SzkolenieModule.RezerwacjaRow
    {
        public object GetListCzyOplacona()
        {
            return new[]
            {
                CzyOplacone.Nieoplacone,
                CzyOplacone.Oplacone
            };
        }

        protected override void OnAdded()
        {
            base.OnAdded();
            this.Data = DateTime.Today;
            this.CzyOplacona = CzyOplacone.Nieoplacone;
        }

        [AttributeInheritance]
        [Description("Zarezerwowany lot")]
        public new Lot Lot
        {
            get => base.Lot;
            set
            {
                base.Lot = value;
                var poRabacie = Percent.Hundred;

                if(Klient != null)
                {
                    poRabacie -= Klient.RabatTowaru;
                }
                CenaLotu = Lot.Cena * poRabacie;
            }
        }

        [AttributeInheritance]
        [Description("Maszyna zarezerwowana na lot")]
        public new Maszyna Maszyna
        {
            get => base.Maszyna;
            set => base.Maszyna = value;
        }

        [AttributeInheritance]
        [Description("Cena za lot po uwzględnieniu rabatu")]
        public new Currency CenaLotu
        {
            get { return base.CenaLotu; }
            set { base.CenaLotu = value; }
        }
    }
}
