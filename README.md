# ZTP_MVC - Projekt ASP.NET MVC

## Opis Projektu

Projekt ZTP_MVC to aplikacja webowa napisana w technologii ASP.NET MVC, która umo¿liwia zarz¹dzanie produktami. Skupia siê na trzech g³ównych funkcjonalnoœciach: przegl¹daniu produktów, dodawaniu nowych produktów oraz zarz¹dzaniu szczegó³ami produktów.

## Funkcje

1. **ProductsController**
    - `Index`: Wyœwietla listê wszystkich produktów.
    - `Create`: Przekierowuje do akcji "ProductCreate/Index" w celu dodania nowego produktu.
    - `Details`: Przekierowuje do akcji "ProductDetails/Index" w celu wyœwietlenia szczegó³ów produktu o okreœlonym identyfikatorze.
    - `Delete`: Przyjmuje identyfikator produktu i usuwa go, a nastêpnie przekierowuje do akcji "Products/Index".

2. **ProductDetailsController**
    - `Index`: Wyœwietla szczegó³y produktu na podstawie identyfikatora.
    - `NavigateToProducts`: Przekierowuje do akcji "Products/Index".
    - `IncrementQuantity`: Zwiêksza iloœæ produktu o 1, a nastêpnie wyœwietla szczegó³y produktu.
    - `SubtractQuantity`: Zmniejsza iloœæ produktu o 1, a nastêpnie wyœwietla szczegó³y produktu.
    - `Update`: Aktualizuje szczegó³y produktu na podstawie danych przekazanych z formularza, a nastêpnie przekierowuje do akcji "Products/Index".

3. **ProductCreateController**
    - `Index`: Wyœwietla formularz do dodawania nowego produktu.
    - `Create`: Dodaje nowy produkt na podstawie danych przekazanych z formularza, a nastêpnie przekierowuje do akcji "Products/Index".
    - `NavigateToProducts`: Przekierowuje do akcji "Products/Index".

## Testy Jednostkowe

Projekt zawiera testy jednostkowe dla kontrolerów. Aby uruchomiæ testy, u¿yj komendy: `dotnet test`
