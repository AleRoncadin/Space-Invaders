# Space-Invaders

Questo progetto è un **clone di Space Invaders** sviluppato in **Unity** utilizzando **C#**.  
Include funzionalità di gioco complete: menu, gestione punteggi, effetti audio e logica dei nemici.

---

## 🛠️ Funzionalità Principali

### Giocatore (`Player.cs`)
- Movimento orizzontale con **A/D** o **Freccia sinistra/destra**
- Sparo proiettili con **Spazio** o **Click sinistro**
- Rilevamento collisioni con nemici o missili
- Gestione game over e pulsanti **Restart/Menu/Quit**

---

### Nemici (`Invaders.cs`, `Invader.cs`)
- Creazione **griglia dinamica** di nemici
- Movimento laterale e discesa dopo aver raggiunto i bordi
- Velocità che aumenta con la percentuale di nemici eliminati
- Sparo missili casuale da parte dei nemici
- Rilevamento vittoria quando tutti i nemici sono eliminati

---

### Proiettili (`Projectile.cs`)
- Movimento costante verso l’alto o verso il basso
- Distruzione al contatto con nemici o giocatore

---

### Bunker (`Bunker.cs`)
- Protezione del giocatore
- Distruzione al contatto con proiettili nemici

---

### Mystery Ship (`MysteryShip.cs`)
- Nave speciale che compare casualmente
- Movimento orizzontale avanti e indietro
- Colpirla assegna **punti bonus** al giocatore

---

### Audio e Volume (`Volume.cs`)
- Regolazione volume tramite **Slider**
- Salvataggio preferenze con **PlayerPrefs**
- Effetti sonori per spari, esplosioni, vittoria e game over

---

### Punteggi (`Punti_Nemici.cs`, `Punti_Navi.cs`)
- Punti per ogni nemico ucciso
- Punti extra per navi bonus
- Visualizzazione punteggio in **UI Text**

---

### Menu (`Options.cs`)
- **New Game** → Avvia la partita
- **Options** → Regolazione volume
- **Back** → Ritorna al menu principale
- **Quit** → Esce dal gioco
- **Restart/Menu** → Disponibili a fine partita

---

## Comandi di Gioco

| Comando        | Azione                  |
|----------------|-------------------------|
| **A / ←**      | Muovi a sinistra        |
| **D / →**      | Muovi a destra          |
| **Spazio / Click** | Spara                  |
| **ESC**        | Torna al menu (opzionale)|

---

## Condizioni di Vittoria e Sconfitta

- **Vittoria**: tutti i nemici eliminati  
- **Sconfitta**: nemico raggiunge il confine inferiore o giocatore colpito  

---
