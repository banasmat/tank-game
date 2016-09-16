MainTODO
- Minimalna siła pocisku - dostosować siły do grywalności
- Zdebugować odrzut na nietrafionym wrogu
- Klocki do składania terenu (pagórki różnego kształtu + edge collider)
- Usuwanie niepotrzebnych klocków terenu
- Dym stopniowo - zależnie od zdrowia czołgu
- Porządek w public/private variables - użyć getterów i setterów c #
- Uporządkować foldery - albo Player -> skrypty, sprajty itd., albo Sprites -> Player, Enemy itd.
- spawn enemies - na event onbecamevisible z ebooka?
- nie iterowac po wszystkich spawn pointach. znalezc ktory jest najblizszy i tylko jego sprawdzać. Po wypuszczeniu wroga sprawdzić kolejny najbliższy.
- System punktów
- Wypróbować system strzelania: lufa obraca się wokół osi z jak player przyciska
- Menu UI

Architektura:
- Zamienić managery (które nie muszą implementować MonoBehaviour) na singletony
- Użyć object pool (do poprawy)

Grafika:
- OPTYMALIZACJA (rozmiar, sprajty)
- eksplozja


Narzędzia
1. Czekać na / sprawdzić czy już jest SmartSprite  - https://unity3d.com/unity/roadmap
2. Obczaić TileMap

Teren
1. Wyczaić szerokość 'klocka' - ustawić grid w Inkscape
2. Przenosić klocki do Unity, łączyć je w gridzie, obrysowywać edge colliderem

Grywalność
- Rodzaje broni strzelające: klasycznie, poziomo, punktowo, bomby, możdzierze, rozproszone...
- Broń białą - młot
- Osłona - pole siłowe
- Wrogowie spadający z nieba
- Jazda do tyłu?
- Punkty za trafienie urwaną głową w coś? np trafienie innego wroga.
- Bonusy: ustrzel konkretnych wrogów w konkretny sposób


DONE
- Ustawić spawn wrogów (done)
- Wrogowie mają biegnąć w kirunku tanka (done)
- Zrobić strzelanie (done)
- Zrobić detekcję kolizji po trafieniu nabojem (done)
- Zrobić zmianę stanu i zniszczenie obiektu po trafieniu (done)
- WaitForSeconds zmienić na np. czekaj aż skończy się animacja (done)
- przejrzeć skrypty tower bridge defense (done)
- ustalić jak wywołać funkcję innego skryptu podłączonego pod ten sam obiekt (inaczej niż sendMessage) (done)
- Zaimplementować event manager z ebooka (podpiåç resztę eventów) (done)
- Kierunek strzelania (done)
- Zrobić detekcję kolizji po zderzeniu z czołgiem (done)
- Niszczyć (albo wrzucić do poola) bullet po trafieniu, tworzyć nowy obiekt - eksplozja (done)
- Poczytać o particle system (done)
- latające członki po eksplozji (done)
- dym po zniszczeniu czołgu (done)
- Brudny czołg po rozjechaniu wroga - kilka poziomów (done)
- Zrobić health tanka (do poprawy - health bar ma sie skracac w 1 strone) (done)
- Użyć dziedziczenia w info barach (done)
- Health tanka ma się zmieniać płynnie (bar musi znać poprzednią wartość?)
- Przeładowanie pocisków - pasek (done)
- Siła pocisku zależna od długości przyciśnięcia + pasek (done)
- czołg z kółkami osobno (done)
- obracanie kółek (done)
- enemy z nogami osobno (done)
- animacja biegu (done)
- tło niebo (done)
- tło góry (done)
- parallax animacja tła (done)
- animacja explozji - scale 1->2->0 (done)
- Event listener (done)
- słabsza moc pocisków (done)
- zmienna moc pocisków (done)
- jeżeli czołg jest do góry nogami - ustawić go z powrtotem
- poczytać o Unity GUI - dopracować info bar
- Opóźnienie strzelania (przeładunek)
- Manipulacja prędkością? - hamulec