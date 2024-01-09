# Die Idee

<p>Wir wollen in C# ein Programm entwickeln, dass mithilfe einer gegebenen Bilderkennung Vögel erkennen kann und in Verbindung mit einem weiteren Programm 
auch Vogelarten voneinander unterscheiden kann. Die Bilderkennungssoftware möchten wir mit Bildern, welche wir hochladen, trainieren, um bestmögliche Ergebnisse zu erzielen. 
Die Bilder werden vom User erstmal selber hochgeladen. Die hochgeladenen Bilder werden dann wie vorherig beschrieben von dem Programm verarbeitet. 
Die Software soll auf den Bildern die Vogelarten und die Anzahl dieser identifizieren. Nach dem Abschließen der Erkennung soll der Benutzer die Möglichkeit haben 
das Bild zu speichern, wobei er dann zusätzlich Datum und Ort des Fotos angeben kann. Die gespeicherten Bilder können dann nach den darauf erkennbaren Vogelarten 
gruppiert werden. Zudem soll sich der Benutzer auch eine Statistik ausgeben lassen können, die die Anzahl der fotografierten Vögel innerhalb einer Woche bzw. eines Monats darstellt. 
<p/>

Wenn wir bis zu diesem Punkt im Projekt gekommen sind, haben wir unsere grundlegende Software fertig. Sollte noch Zeit zur Verfügung stehen, haben wir uns vorgenommen 
eine Kamera und einen Lautsprecher zu integrieren. Die Kamera soll automatisch ein Bild machen, wenn sie ein Vogel erkennt. 
Dieses Foto wird dann an das Programm weitergeleitet. Der Lautsprecher soll bei der Sichtung von bestimmten Vogelarten ein Geräusch machen, welches die Vögel verschrecken soll.

# How to connect to the Database

- After cloning our repository, open the SQL SERVER folder
- Open a new Terminal in that folder

    ``` docker build -t mymssql . ```

    ``` docker run -d --name mymssql -p 1433:1433 mymssql ```

# How to access the Bird Recognition AI

- After cloning our repository, open the Bird_Recognition folder
- Open a new Terminal in that folder

    ```docker run --name bird-recognition -p 5000:5000 aaronzi/bird-recognition ```

    Accessing the given http://localhost:5000/ a small API can be used as a standalone
