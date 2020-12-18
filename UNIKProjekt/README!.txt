Venligst kør både API og MVC samme tid.

Der er åbenbart forskel på hvorvidt om man kører programmet fra CLI, eller iisExpress (Visual Studio IDE)
Køres projektet fra iisExpress, skal porten ændres.
Standard porten på API er 58197 (Kan være den skal ændres) => Naviger til Application->Classes->ConnectionStrings.cs og ret porten så det matcher med din port.