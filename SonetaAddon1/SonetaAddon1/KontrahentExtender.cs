using Soneta.Business;
using Soneta.Business.App;
using Soneta.CRM;
using Soneta.Types;
using SonetaAddon1.Szkolenie;
using SonetaAddon1.UI;


// Sposób w jaki należy zarejestrować extender, który później zostanie użyty w interfejsie.
[assembly: Worker(typeof(KontrahentExtender))]

namespace SonetaAddon1.UI
{
    public class KontrahentExtender
    {
        [Context]
        public Session Session { get; set; }

        [Context]
        public Login Login { get; set; }

        [Context]
        public Kontrahent Kontrahent { get; set; }

        [Context]
        public Context Context { get; set; }

        public bool IsVisible
        {
            get
            {
                var uiNav = this.Context[typeof(UILocation), false] as UILocation;
                return uiNav.FolderNormalizedPath == "LotyWidokowe/Klienci";
            }
        }

        public bool maRezerwacje => RezerwacjaLotow.Count > 0;

        public View RezerwacjaLotow
            => SzkolenieModule.GetInstance(Kontrahent).Rezerwacje.WgKlient[Kontrahent].CreateView();
    }
}
