using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Soneta.Business;
using Soneta.Business.UI;
using SonetaAddon1.UI;
using System;

namespace SonetaAddon1.UI
{
    public class KatalogLotowViewInfo : ViewInfo
    {
        public KatalogLotowViewInfo()
        {
            // View wiążemy z odpowiednią definicją viewform.xml poprzez property ResourceName
            ResourceName = "KatalogLotow";

            // Inicjowanie contextu
            InitContext += KatalogLotowViewInfo_InitContext;

            // Tworzenie view zawierającego konkretne dane
            CreateView += KatalogLotowViewInfo_CreateView;
        }

        void KatalogLotowViewInfo_InitContext(object sender, ContextEventArgs args)
        {
        }

        void KatalogLotowViewInfo_CreateView(object sender, CreateViewEventArgs args)
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
