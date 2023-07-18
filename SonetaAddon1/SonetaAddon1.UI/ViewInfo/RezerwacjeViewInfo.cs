using Soneta.Business;
using Soneta.Business.UI;
using SonetaAddon1.UI;
using System;
using SonetaAddon1;
using Soneta.CRM;
using SonetaAddon1.Szkolenie;
using System.Reflection.Metadata;

namespace SonetaAddon1.UI
{
    public class RezerwacjeViewInfo : ViewInfo
    {
        public RezerwacjeViewInfo()
        {
            // View wiążemy z odpowiednią definicją viewform.xml poprzez property ResourceName
            ResourceName = "Rezerwacje";

            // Inicjowanie contextu
            InitContext += RezerwacjeViewInfo_InitContext;

            // Tworzenie view zawierającego konkretne dane
            CreateView += RezerwacjeViewInfo_CreateView;
        }

        void RezerwacjeViewInfo_InitContext(object sender, ContextEventArgs args)
        {
            if (!args.Context.Contains(typeof(RezerwacjeParams)))
                args.Context.Set(new RezerwacjeParams(args.Context)); // dodanie parametrów do kontekstu jeśli nie istnieją
        }

        void RezerwacjeViewInfo_CreateView(object sender, CreateViewEventArgs args)
        {
            RezerwacjeParams parameters;
            if (!args.Context.Get(out parameters))
                return;
            args.View = ViewCreate(parameters);
        }

        public class RezerwacjeParams : ContextBase
        {
            public RezerwacjeParams(Context context) : base(context)
            {
            }

            private Maszyna _maszyna = null;
            public Maszyna Maszyna
            {
                get => _maszyna;
                set
                {
                    _maszyna = value;
                    Context.Set(this);
                }
            }

            private Kontrahent _klient = null;
            public Kontrahent Klient
            {
                get => _klient;
                set
                {
                    _klient = value;
                    Context.Set(this);
                }
            }

            private CzyOplacone _czyOplacone = CzyOplacone.Razem;
            public CzyOplacone CzyOplacone
            {
                get => _czyOplacone;
                set
                {
                    _czyOplacone = value;
                    Context.Set(this);
                }
            }
        }

        protected View ViewCreate(RezerwacjeParams parameters)
        {
            View view = parameters.Session.GetSzkolenie().Rezerwacje.WgDaty.CreateView();
            var cond = RowCondition.Empty;

            if (parameters.Maszyna != null)
                cond &= new FieldCondition.Equal("Maszyna", parameters.Maszyna);
            if (parameters.Klient != null)
                cond &= new FieldCondition.Equal("Klient", parameters.Klient);
            if (parameters.CzyOplacone != SonetaAddon1.CzyOplacone.Razem)
                cond &= new FieldCondition.Equal("CzyOplacona", parameters.CzyOplacone);

            view.Condition = cond;
            return view;
        }

    }
}
