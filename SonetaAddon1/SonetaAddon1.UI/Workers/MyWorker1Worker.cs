using Mono.CSharp;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.CRM;
using Soneta.Tools;
using Soneta.Types;
using SonetaAddon1.UI.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

[assembly: Worker(typeof(MyWorker1Worker), typeof(Kontrahenci))]

namespace SonetaAddon1.UI.Workers
{
    public class MyWorker1Worker
    {

        [Context]
        public MyWorker1WorkerParams @params
        {
            get;
            set;
        }


        // TODO -> Należy podmienić podany opis akcji na bardziej czytelny dla uzytkownika
        [Action("Loty widokowe/Ustaw rabat",
            Mode = ActionMode.SingleSession | ActionMode.ConfirmSave | ActionMode.Progress,          
            Target = ActionTarget.Menu | ActionTarget.ToolbarWithText,
            Priority = 0)]
        public Object UstawRabat()
        {
            var WybraniKontrahenci = @params.Context[typeof(Kontrahent[]), false] as Kontrahent[];
            if (WybraniKontrahenci.Length == 0)
                return "Nie wybrano żadnego kontrahenta.";

            var doZmiany = new List<Kontrahent>();
            foreach (var kth in WybraniKontrahenci)
            {
                var nowyRabat = @params.DodawacRabaty ? kth.RabatTowaru + @params.Rabat : @params.Rabat;
                if (!@params.ObnizacRabaty && nowyRabat < kth.RabatTowaru)
                    continue;

                doZmiany.Add(kth);
            }

            if (doZmiany.Count == 0)
                return "Dla wybranych kontrahentów nie ma nic do zrobienia.".Translate();


            return new MessageBoxInformation("Ustawienie rabatu?")
            {
                Text = "Czy ustawić rabat ({0}) wybranym kontrahentom ({1})?".TranslateFormat(doZmiany.Count, @params.Rabat),
                YesHandler = () => SetRabat(doZmiany),
                NoHandler = () => null
            };

        }

        private object SetRabat(List<Kontrahent> doZmiany)
        {
            using (var transaction = @params.Session.Logout(true))
            {
                foreach (var k in doZmiany)
                {
                    k.RabatTowaru = @params.DodawacRabaty ? k.RabatTowaru + @params.Rabat : @params.Rabat;
                }

                transaction.Commit();
            }
            return "Ustawiono nowe rabaty";
        }

        [Caption("Ustawianie rabatu dla kontrahentów")]
        public class MyWorker1WorkerParams : ContextBase
        {
            private bool _dodawacRabaty;
            public MyWorker1WorkerParams(Context context) : base(context)
            {
            }

            // TODO -> Poniższy parametr dodany dla celów poglądowych. Należy usunąć.
            [Caption("Wysokość rabatu")]
            public Percent Rabat { get; set; }

            [Caption("Czy dodawać rabaty")]
            [Description("Czy dodawać rabaty do siebie?")]
            public bool DodawacRabaty
            {
                get => _dodawacRabaty;
                set
                {
                    _dodawacRabaty = value;
                    ObnizacRabaty = !_dodawacRabaty;
                    OnChanged(EventArgs.Empty);
                }
            }

            [Caption("Czy obniżać rabaty")]
            [Description("Czy zmniejszyć przypisany rabat jeśli już przypisany jest wyższy?")]
            public bool ObnizacRabaty { get; set; } = false;

            public bool IsReadOnlyObnizacRabaty() => ObnizacRabaty;
        }
    }

    

}
