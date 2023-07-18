using Soneta.Business;
using Soneta.Business.UI;
using SonetaAddon1.UI;
using System;

namespace SonetaAddon1.UI
{
    public class KatalogMaszynViewInfo : ViewInfo
    {
        public KatalogMaszynViewInfo()
        {
            // View wiążemy z odpowiednią definicją viewform.xml poprzez property ResourceName
            ResourceName = "KatalogMaszyn";

            // Inicjowanie contextu
            InitContext += KatalogMaszynViewInfo_InitContext;

            // Tworzenie view zawierającego konkretne dane
            CreateView += KatalogMaszynViewInfo_CreateView;
        }

        void KatalogMaszynViewInfo_InitContext(object sender, ContextEventArgs args)
        {
        }

        void KatalogMaszynViewInfo_CreateView(object sender, CreateViewEventArgs args)
        {
            WParams parameters;
            if (!args.Context.Get(out parameters))
                return;
            args.View = ViewCreate(parameters);
        }

        public class WParams : ContextBase
        {
            public WParams(Context context) : base(context)
            {
            }
        }

        protected View ViewCreate(WParams pars)
        {
            View view = null;
            return view;
        }

    }
}
