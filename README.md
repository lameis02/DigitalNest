# Die Idee

<p>Wir wollen in C# ein Programm entwickeln, dass mithilfe einer gegebenen Bilderkennung Vögel erkennen kann und in Verbindung mit einem weiteren Programm 
auch Vogelarten voneinander unterscheiden kann. Die Bilderkennungssoftware möchten wir mit Bildern, welche wir hochladen, trainieren, um bestmögliche Ergebnisse zu erzielen. 
Die Bilder werden vom User erstmal selber hochgeladen. Die hochgeladenen Bilder werden dann wie vorherig beschrieben von dem Programm verarbeitet. 
Die Software soll auf den Bildern die Vogelarten und die Anzahl dieser identifizieren. Nach dem Abschließen der Erkennung soll der Benutzer die Möglichkeit haben 
das Bild zu speichern, wobei er dann zusätzlich Datum und Ort des Fotos angeben kann. Die gespeicherten Bilder können dann nach den darauf erkennbaren Vogelarten 
gruppiert werden. Zudem soll sich der Benutzer auch eine Statistik ausgeben lassen können, die die Anzahl der fotografierten Vögel innerhalb einer Woche bzw. eines Monats darstellt. 
<p/>

> Wenn wir bis zu diesem Punkt im Projekt gekommen sind, haben wir unsere grundlegende Software fertig. Sollte noch Zeit zur Verfügung stehen, haben wir uns vorgenommen 
eine Kamera und einen Lautsprecher zu integrieren. Die Kamera soll automatisch ein Bild machen, wenn sie ein Vogel erkennt. 
Dieses Foto wird dann an das Programm weitergeleitet. Der Lautsprecher soll bei der Sichtung von bestimmten Vogelarten ein Geräusch machen, welches die Vögel verschrecken soll.

# Das Ergebnis

Die Anwendung lässt den User ein Bild eines Vogels hochladen. Dann kann die Vogelart durch eine KI bestimmt werden und der Nutzer kann Datum und Ort setzen. Außerdem kann das Bild als Favorit markiert werden. Nach dem Hochladen des Bildes in die Datenbank können alle Bilder in der Galerie angezeigt werden. In dieser Ansicht können einzelne Bilder angezeigt und gelöscht werden und auch der gesamte Inhalt der Galerie kann gelöscht werden. Die Favoriten können über eine zusätzliche Ansicht angezeigt werden. Ebenfalls gibt es Statistiken, welche eine Gesamtübersicht der Daten  geben oder nur eine Übersicht über die Daten der letzen sieben Tage geben. 

# How to connect to the Database

After cloning our repository, open the SQL SERVER folder and then open a new Terminal in that folder.

```bash 
docker build -t vogelsammlung . 
```

``` bash
docker run -d --name vogelsammlung -p 1433:1433 vogelsammlung 
```

# How to access the Bird Recognition AI

Open the Terminal

```bash
docker run -d --name bird-recognition -p 5000:5000 fiob9220/bird_ai:v1.0 
```

> **Accessing the given [Localhost](http://localhost:5000/) a small API can be used as a standalone**

## Code for Bird Recognition AI

The code of the AI can be found [here](https://github.com/fyo21103/Bird-Recognition-AI/tree/master).

> As of 01/02/2024 the most recent changes are in [this](https://github.com/fyo21103/Bird-Recognition-AI/tree/api-update) branch.
