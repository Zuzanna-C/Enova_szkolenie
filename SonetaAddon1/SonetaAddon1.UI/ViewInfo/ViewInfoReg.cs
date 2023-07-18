using Soneta.Business.UI;
using Soneta.Zadania.Zasoby;
using SonetaAddon1.UI;

[assembly: FolderView("LotyWidokowe", //wymagane: sciezka folderu
    Caption = "Loty Widokowe",
    Priority = 0,
    Description = "Szkolenie techniczne - przykłąd dopdatku",
    BrickColor = FolderViewAttribute.BlueBrick
)]

[assembly: FolderView("LotyWidokowe/Klienci",
    Caption = "Klienci",
    Priority = 0,
    Description = "Klienci firmy",
    TableName = "Kontrahenci",
    ViewType = typeof(KlienciViewInfo),
    BrickColor = FolderViewAttribute.YellowBrick
)]

[assembly: FolderView("LotyWidokowe/KatalogLotow",
    Caption = "Katalog lotów",
    Priority = 100,
    Description = "Katalog oferowanych lotów",
    TableName = "Loty",
    ViewType = typeof(KatalogLotowViewInfo),
    BrickColor = FolderViewAttribute.GreenBrick
)]

[assembly: FolderView("LotyWidokowe/KatalogMaszyn",
    Caption = "Katalog Maszyn",
    Priority = 200,
    Description = "Katalog maszyn",
    TableName = "Maszyny",
    ViewType = typeof(KatalogMaszynViewInfo)
)]

[assembly: FolderView("LotyWidokowe/Rezerwacje",
    Priority = 300,
    Description = "Lista rezerwacji",
    TableName = "Rezerwacje",
    ViewType = typeof(RezerwacjeViewInfo),
    BrickColor = FolderViewAttribute.BlackBrick
)]