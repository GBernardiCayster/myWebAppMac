CREATE TABLE Giuliano.Agenti
(
IDAgente VARCHAR(36) NOT NULL,
`Ragione Sociale` VARCHAR(50) NOT NULL,
Indirizzo VARCHAR(50),
CAP VARCHAR(6) NULL,
Localita VARCHAR(50) NULL,
Provincia VARCHAR(4) NULL,
`Partita IVA` VARCHAR(11) NULL,
`Codice Fiscale` VARCHAR(16) NULL,
Telefono VARCHAR(30) NULL,
EMail VARCHAR(50) NULL,
PRIMARY KEY (IDAgente)
)


CREATE TABLE Giuliano.Zone
(
IDZona VARCHAR(36) NOT NULL,
Descrizione VARCHAR(50) NULL,
PRIMARY KEY (IDZona)
)

CREATE TABLE Giuliano.`Listini Testate`
(
IDListino VARCHAR(36) NOT NULL,
Descrizione VARCHAR(50) NOT NULL,
`Riferimento Listino` VARCHAR(36),
Percentuale DECIMAL(5,2),
Tipo VARCHAR(1),
PRIMARY KEY (IDListino)
)


CREATE TABLE Giuliano.`Listini`
 (
  `IDListino` varchar(36) NOT NULL,
  `IDArticolo` varchar(36) NOT NULL,
  `Scaglione` decimal(10,2) NOT NULL,
  `Prezzo` decimal(10,2) DEFAULT NULL,
  `ScL1` decimal(4,2) DEFAULT NULL,
  `ScL2` decimal(4,2) DEFAULT NULL,
  `ScL3` decimal(4,2) DEFAULT NULL,
  `ScL4` decimal(4,2) DEFAULT NULL,
  `ScL5` decimal(4,2) DEFAULT NULL,
  PRIMARY KEY (`IDListino`,`IDArticolo`,`Scaglione`)
)


CREATE TABLE Giuliano.Articoli
(
IDArticolo VARCHAR(36) NOT NULL,
Descrizione VARCHAR(100) NULL,
Aggiuntiva VARCHAR(100) NULL,
ParentID VARCHAR(36) NULL,
IDGruppo VARCHAR(36) NULL,
`Descrizione Gruppo` VARCHAR(512) NULL,
IDUm1 VARCHAR(15) NULL,
IDTipoIVA VARCHAR(15) NULL,
IDFornitore VARCHAR(36) NOT NULL,
Categoria1 VARCHAR(50) NULL,
Categoria2 VARCHAR(50) NULL,
Categoria3 VARCHAR(50) NULL,
Categoria4 VARCHAR(50) NULL,
Categoria5 VARCHAR(50) NULL,
Categoria6 VARCHAR(50) NULL,
Categoria7 VARCHAR(50) NULL,
Categoria8 VARCHAR(50) NULL,
Categoria9 VARCHAR(50) NULL,
Categoria10 VARCHAR(50) NULL,
Categoria11 VARCHAR(50) NULL,
Categoria12 VARCHAR(50) NULL,
Categoria13 VARCHAR(50) NULL,
Categoria14 VARCHAR(50) NULL,
Categoria15 VARCHAR(50) NULL,
PzConf decimal(10, 2) NOT NULL,
chkPzConf VARCHAR(1) NOT NULL,
Esaurito VARCHAR(1) NULL,
Nuovo VARCHAR(1) NULL,
Visibile VARCHAR(1) NULL,
 PRIMARY KEY (IDArticolo)
)
	