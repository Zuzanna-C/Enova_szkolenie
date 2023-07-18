using Soneta.Business;
using Soneta.Business.UI;
using SonetaAddon1.UI;
using System;
using Soneta.CRM;

namespace SonetaAddon1.UI
{
    public class KlienciViewInfo : ViewInfo
    {
        public KlienciViewInfo()
        {
            // View wiążemy z odpowiednią definicją viewform.xml poprzez property ResourceName
            ResourceName = "Klienci";

            // Inicjowanie contextu
            InitContext += KlienciViewInfo_InitContext;

            // Tworzenie view zawierającego konkretne dane
            CreateView += KlienciViewInfo_CreateView;
        }

        void KlienciViewInfo_InitContext(object sender, ContextEventArgs args)
        {
        }

        void KlienciViewInfo_CreateView(object sender, CreateViewEventArgs args)
        {
            var view = args.Session.GetCRM().Kontrahenci.WgKodu.CreateView();
            view.Condition &= new FieldCondition.Equal("IsStandard", false);
            args.View = view;
        }

        public class WParams : ContextBase
        {
            public WParams(Context context) : base(context)
            {
            }
        }

    }
}
