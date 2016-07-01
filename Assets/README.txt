MainTODO
- Ustawić spawn wrogów (done)
- Wrogowie mają biegnąć w kirunku tanka (done)
- Zrobić strzelanie (done)
- Zrobić detekcję kolizji po trafieniu nabojem (done)
- Zrobić zmianę stanu i zniszczenie obiektu po trafieniu (done)
- Kierunek strzelania (done) // Czy kierunek poziomy nie był bardziej grywalny?? Może warto dodać rodzaj broni strzelającej poziomo (np. karabin z wieżyczki)
- WaitForSeconds zmienić na np. czekaj aż skończy się animacja (done)
- przejrzeć skrypty tower bridge defense (done)
- ustalić jak wywołać funkcję innego skryptu podłączonego pod ten sam obiekt (inaczej niż sendMessage) (done)
- Zaimplementować event manager z ebooka (podpiåç resztę eventów) (done)
- Zrobić detekcję kolizji po zderzeniu z czołgiem (done)
- Niszczyć (albo wrzucić do poola) bullet po trafieniu, tworzyć nowy obiekt - eksplozja (done)
- Poczytać o particle system (done)
- latające członki po eksplozji (done)
- dym za czołgiem (albo po zniszczeniu czołgu)
- Zrobić health tanka (do poprawy - health bar ma sie skracac w 1 strone)
- Porządek w public/private variables - użyć getterów i setterów c #
- Uporządkować foldery - albo Player -> skrypty, sprajty itd., albo Sprites -> Player, Enemy itd.
- spawn enemies - na event onbecamevisible z ebooka?
- nie iterowac po wszystkich spawn pointach. znalezc ktory jest najblizszy i tylko jego sprawdzać. Po wypuszczeniu wroga sprawdzić kolejny najbliższy.
- Dorobić grafiki/animacje

Architektura:
- Event listener (done)
- Użyć object pool (do poprawy)

Grafika:
- czołg z kółkami osobno (done)
- obracanie kółek (done)
- enemy z nogami osobno (done)
- animacja biegu (done)
- tło niebo (done)
- tło góry (done)
- parallax animacja tła (done)
- animacja explozji - scale 1->2->0 (done)
- OPTYMALIZACJA (rozmiar, sprajty)
- eksplozja



Narzędzia
1. Czekać na / sprawdzić czy już jest SmartSprite  - https://unity3d.com/unity/roadmap
2. Obczaić TileMap

Teren
1. Wyczaić szerokość 'klocka' - ustawić grid w Inkscape
2. Przenosić klocki do Unity, łączyć je w gridzie, obrysowywać edge colliderem

Grywalność
- słabsza moc pocisków (done)
- zmienna moc pocisków
- Manipulacja prędkością?
- Rodzaje broni strzelające: klasycznie, poziomo, punktowo, bomby, możdzierze, rozproszone...
- Broń białą - młot
- Osłona - pole siłowe
- Opóźnienie strzelania (przeładunek)
- Wrogowie spadający z nieba
- Jazda do tyłu?
- Punkty za trafienie urwaną głową w coś? np trafienie innego wroga.
