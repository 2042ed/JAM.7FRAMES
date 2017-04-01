# 7 FRAMES - Flow (Mermaid project)

```mermaid
graph TD

HOME
SPIAGGIA{SPIAGGIA}
GROTTA["GROTTA DI GHIACCIO<br>Scienziato<br>5 fluffi"]
VILLAGGIO["VILLAGGIO<br>Indigeno"]
DUNGEON["DUNGEON<br>Morte"]
FORESTA["FORESTA<br>Robot Quby"]
PALUDE["PALUDE<br>Mago Trevor"]
PIANURA["PIANURA VULCANICA<br>Elfo Linzi"]
PONTE_ROTTO
PONTE_AGGIUSTATO
TUNDRA["TUNDRA<br>Androide Zot"]
END(("ATTIVA PORTALE<br>THE END"))

HOME -->|Play| SPIAGGIA

SPIAGGIA --> |vai| TUNDRA
SPIAGGIA --> |vai| FORESTA
SPIAGGIA --> |vai| VILLAGGIO

TUNDRA -.-> |parla| ANDROIDE
ANDROIDE -.-> |forza spegne vulcano| MEDICINA
TUNDRA  -.-> |olio| CHIAVE_ITALIANA

TUNDRA --> |vai| PIANURA
TUNDRA --> |vai| PALUDE

subgraph villaggio
VILLAGGIO --> |parla| INDIGENO
INDIGENO --> |da| PELLICCIA
end

VILLAGGIO --> |vai| PONTE_ROTTO
PELLICCIA -.-> |permette ingresso| GROTTA

PIANURA  -.-> |parla| ELFO
ELFO  -.-> |da se spento vulcano| MEDICINA
MEDICINA -.-> |cura indigeno| PELLICCIA
FORESTA  --> |vai| DUNGEON
FORESTA  -.-> |parla| ROBOT_QUBY
ROBOT_QUBY --> |da con 3 olio| CHIAVE_ITALIANA

GROTTA -.-> SCIENZIATO
GROTTA --> FLUFFI
FLUFFI  -.-> |olio| CHIAVE_ITALIANA
SCIENZIATO -.-> |invenzione| PONTE_AGGIUSTATO

DUNGEON  -.-> |parla| MORTE
MORTE  -.-> |diario| CODICE
DUNGEON  -.-> |olio| CHIAVE_ITALIANA

PALUDE  -.-> |parla| MAGO
MAGO --> |da| CODICE

PONTE_ROTTO --> |vai| GROTTA
PONTE_ROTTO --> PONTE_AGGIUSTATO

PONTE_AGGIUSTATO --> |vai| PORTALE

CHIAVE_ITALIANA -.-> |aggiusta| END
CODICE -.-> |attiva| END
PORTALE -.-> END
```
