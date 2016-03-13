BlackMetalTank in Unity

MainTODO
- Ustawić spawn wrogów (done)
- Wrogowie mają biegnąć w kirunku tanka (done)
- Zrobić strzelanie (done)
- Zrobić detekcję kolizji po trafieniu nabojem (done)
- Zrobić zmianę stanu i zniszczenie obiektu po trafieniu (done)
- Kierunek strzelania (done) // Czy kierunek poziomy nie był bardziej grywalny?? Może warto dodać rodzaj broni strzelającej poziomo (np. karabin z wieżyczki)
- Porządek w public/private variables - użyć getterów i setterów c #
- WaitForSeconds zmienić na np. czekaj aż skończy się animacja
- PRZEJRZEĆ ORGANIZACJĘ SKRYPTÓW W np. TOWER BRIDGE DEFENSE - trzeba ustalić jak wywołać funkcję innego skryptu podłączonego pod ten sam obiekt (inaczej niż sendMessage) (done)
- Zaimplementować event manager z êbooka
- Zrobić detekcję kolizji po zderzeniu z czołgiem (do poprawy)
- Zrobić health tanka (do poprawy)
- Dorobić grafiki/animacje

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