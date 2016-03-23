BlackMetalTank in Unity

MainTODO
- Ustawić spawn wrogów (done)
- Wrogowie mają biegnąć w kirunku tanka (done)
- Zrobić strzelanie (done)
- Zrobić detekcję kolizji po trafieniu nabojem (done)
- Zrobić zmianę stanu i zniszczenie obiektu po trafieniu (done)
- Kierunek strzelania (done) // Czy kierunek poziomy nie był bardziej grywalny?? Może warto dodać rodzaj broni strzelającej poziomo (np. karabin z wieżyczki)
- Porządek w public/private variables - użyć getterów i setterów c #
- Uporządkować foldery - albo Player -> skrypty, sprajty itd., albo Sprites -> Player, Enemy itd.
- WaitForSeconds zmienić na np. czekaj aż skończy się animacja (done)
- przejrzeć skrypty tower bridge defense (done)
- ustalić jak wywołać funkcję innego skryptu podłączonego pod ten sam obiekt (inaczej niż sendMessage) (done)
- Zaimplementować event manager z ebooka (podpiåç resztę eventów)
- Zrobić detekcję kolizji po zderzeniu z czołgiem (do poprawy)
- Zrobić health tanka (do poprawy - health bar ma sie skracac w 1 strone)
- spawn enemies - na event onbecamevisible z ebooka?
- nie iterowac po wszystkich spawn pointach. znalezc ktory jest najblizszy i tylko jego sprawdzać. Po wypuszczeniu wroga sprawdzić kolejny najbliższy.
- Dorobić grafiki/animacje

Architektura:
- Użyć object pool

Grafika:
- czołg z kółkami osobno
- obracanie köłek
- eksplozja
- animacja explozji - scale 1->2->0
- enemy z nogami osobno
- animacja biegu
- tło niebo
- tło gôry
- parallax animacja tła

Narzędzia
1. Czekać na / sprawdzić czy już jest SmartSprite  - https://unity3d.com/unity/roadmap
2. Obczaić TileMap

Teren
1. Wyczaić szerokość 'klocka' - ustawić grid w Illustratorze
2. Przenosić klocki do Unity, łączyć je w gridzie, obrysowywać edge colliderem

Grywalność
- Manipulacja prędkością?
- Rodzaje broni strzelające: klasycznie, poziomo, punktowo, bomby, możdzierze, rozproszone...
- Opóźnienie strzelania (przeładunek)
- Wrogowie spadający z nieba
- Jazda do tyłu?