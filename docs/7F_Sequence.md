# 7 FRAMES - Sequence

```mermaid
sequenceDiagram
    participant SPIAGGIA
    participant DUNGEON
    participant FORESTA
    participant GROTTA
    participant PALUDE
    participant TUNDRA
    participant VILLAGGIO
    participant VULCANO
    participant PONTE
    participant PORTALE

    SPIAGGIA->>DUNGEON:  
    Note right of DUNGEON: prendo OLIO, prendo DIARIO
    DUNGEON->>SPIAGGIA:  

    SPIAGGIA->>TUNDRA:  
    Note right of TUNDRA: prendo OLIO + Androide ZOT viene con noi
    TUNDRA->>SPIAGGIA:  

    SPIAGGIA->>VULCANO:  
    Note right of VULCANO: ZOT spegne fuoco, riceviamo MEDICINA
    VULCANO->>SPIAGGIA:  

    SPIAGGIA->>VILLAGGIO:  
    Note right of VILLAGGIO: diamo MEDICINA, prendo INVENZIONE
    VILLAGGIO->>SPIAGGIA:  

    SPIAGGIA->>GROTTA:  
    Note right of GROTTA: usiamo PELLICCIA, prendo INVENZIONE
    GROTTA->>SPIAGGIA:  

    SPIAGGIA->>PONTE: il ponte è rotto
    Note right of PONTE: usiamo INVENZIONE per aggiustare ponte
    PONTE->>SPIAGGIA:  f
```
