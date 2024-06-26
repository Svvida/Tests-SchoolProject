# Aplikacja Testująca Selenium - Instrukcja Użytkowania

## Opis

Aplikacja została stworzona do przeprowadzenia testów automatycznych interfejsu użytkownika stron internetowych z wykorzystaniem Selenium WebDriver. Projekt wykorzystuje Visual Studio 2022 oraz NUnit framework do organizacji i wykonania testów.

## Konfiguracja środowiska

- Aby uruchomić projekt, konieczne jest posiadanie Visual Studio 2022.
- Wymagana jest jedna z następujących przeglądarek: Google Chrome, Mozilla Firefox, lub Microsoft Edge.
- Przy pierwszym uruchomieniu projektu w Visual Studio, wszystkie zależności z NuGet będą automatycznie przywrócone.

## Używane zależności NuGet

- `coverlet.collector`
- `DotNetSeleniumExtras.PageObjects`
- `DotNetSeleniumExtras.WaitHelpers`
- `Microsoft.NET.Test.Sdk`
- `NUnit`
- `NUnit.Analyzers`
- `NUnit3TestAdapter`
- `Selenium.Support`
- `Selenium.WebDriver`
- `Selenium.WebDriver.ChromeDriver`
- `Selenium.WebDriver.MSEdgeDriver`

## Opis Testów

### BasicTesting

- `Test1` (Smoke testing): Test sprawdza interakcję z elementami strony Facebook, takimi jak przyciski zgody na cookies oraz interakcję z formularzem rejestracyjnym. Test zawiera logikę obsługującą dynamiczne elementy strony.
- `Test2` (Regression testing): Test wykonuje podstawową interakcję z polem tekstowym email na stronie Facebook.
- `Test3` (Smoke testing): Podobnie jak `Test2`, wykonuje interakcję z polem tekstowym, z dodatkową pauzą, symulując użytkownika.

### OrderSkipAttribute

- `ChromeTest_Ignore`: Ten test jest zignorowany i służy jako przykład pominięcia testu.
- `FirefoxTest`: Test używa przeglądarki Firefox do sprawdzenia funkcji logowania Facebook.
- `EdgeTest`: Analogicznie do `FirefoxTest`, ale z wykorzystaniem przeglądarki Edge.

### ParallelTesting

- `Parallel1`, `Parallel2`, `Parallel3` (UAT Testing, Module1): Testy te są uruchamiane równolegle i sprawdzają funkcjonalność logowania za pomocą Selenium WebDriver, wykorzystując metodę inicjalizacji przeglądarki z klasy pomocniczej `BrowserUtility`.

### DataDrivenTesting

- `TestNoPass_TakeScreenshot`: Test ten jest przykładem wywołania błędu, który celowo nie powinien przejść, demonstrując jednocześnie mechanizm tworzenia zrzutu ekranu w przypadku niepowodzenia testu.
- `TestPass`: Test weryfikujący logowanie na stronie Facebook, który powinien zakończyć się sukcesem.

## Uruchamianie Testów

- Otwórz projekt w Visual Studio.
- Skorzystaj z Test Explorera do uruchomienia wszystkich testów lub wybranych przypadków testowych.

## Informacje Dodatkowe

- W folderze `Screenshots` znajdują się zrzuty ekranu utworzone podczas testów, które zakończyły się niepowodzeniem.

---

_Autor: Krystian Świda_
