# ZTP_MVC - Projekt ASP.NET MVC

## Opis Projektu

Projekt ZTP_MVC to aplikacja webowa napisana w technologii ASP.NET MVC, kt�ra umo�liwia zarz�dzanie produktami. Skupia si� na trzech g��wnych funkcjonalno�ciach: przegl�daniu produkt�w, dodawaniu nowych produkt�w oraz zarz�dzaniu szczeg�ami produkt�w.

## Funkcje

1. **ProductsController**
    - `Index`: Wy�wietla list� wszystkich produkt�w.
    - `Create`: Przekierowuje do akcji "ProductCreate/Index" w celu dodania nowego produktu.
    - `Details`: Przekierowuje do akcji "ProductDetails/Index" w celu wy�wietlenia szczeg��w produktu o okre�lonym identyfikatorze.
    - `Delete`: Przyjmuje identyfikator produktu i usuwa go, a nast�pnie przekierowuje do akcji "Products/Index".

2. **ProductDetailsController**
    - `Index`: Wy�wietla szczeg�y produktu na podstawie identyfikatora.
    - `NavigateToProducts`: Przekierowuje do akcji "Products/Index".
    - `IncrementQuantity`: Zwi�ksza ilo�� produktu o 1, a nast�pnie wy�wietla szczeg�y produktu.
    - `SubtractQuantity`: Zmniejsza ilo�� produktu o 1, a nast�pnie wy�wietla szczeg�y produktu.
    - `Update`: Aktualizuje szczeg�y produktu na podstawie danych przekazanych z formularza, a nast�pnie przekierowuje do akcji "Products/Index".

3. **ProductCreateController**
    - `Index`: Wy�wietla formularz do dodawania nowego produktu.
    - `Create`: Dodaje nowy produkt na podstawie danych przekazanych z formularza, a nast�pnie przekierowuje do akcji "Products/Index".
    - `NavigateToProducts`: Przekierowuje do akcji "Products/Index".

## Testy Jednostkowe

Projekt zawiera testy jednostkowe dla kontroler�w. Aby uruchomi� testy, u�yj komendy: `dotnet test`
