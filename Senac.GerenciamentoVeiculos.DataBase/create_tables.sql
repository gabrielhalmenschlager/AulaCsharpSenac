-- Criação da tabela TipoCombustivel (opcional)
CREATE TABLE TipoCombustivel
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(50) NOT NULL
);

-- Inserindo valores do enum TipoCombustivel
INSERT INTO TipoCombustivel (Nome)
VALUES
    ('GASOLINA'),
    ('DIESEL'),
    ('ETANOL'),
    ('GNV'),
    ('HIBRIDO'),
    ('ELETRICO');

-- Criação da tabela Carro
CREATE TABLE Carro
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Marca NVARCHAR(100) NOT NULL,
    Placa NVARCHAR(10) NOT NULL,
    Cor NVARCHAR(50) NOT NULL,
    AnoFabricacao INT NOT NULL,
    TipoCombustivelId INT FOREIGN KEY REFERENCES TipoCombustivel(Id)
);

-- 1
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Supra MK IV', 'Toyota', 'BRA1S94', 'Orange', 1994, 1);

-- 2
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Skyline GT‑R R34', 'Nissan', 'BRA2N99', 'Blue', 1999, 1);

-- 3
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Charger R/T', 'Dodge', 'DOM0C70', 'Black', 1970, 1);

-- 4
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('RX‑7 FD', 'Mazda', 'DOM1R93', 'Red', 1993, 1);

-- 5
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Civic EJ1', 'Honda', 'CIV2C95', 'Black', 1995, 1);

-- 6
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Eclipse GS‑T', 'Mitsubishi', 'ECL3G95', 'Green', 1995, 1);

-- 7
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Escort RS1600', 'Ford', 'ESC4B70', 'Blue', 1970, 1);

-- 8
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('HyperSport', 'Lykan', 'LYK5R14', 'Red', 2014, 1);

-- 9
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Chevelle SS', 'Chevrolet', 'CHE6R70', 'Red', 1970, 1);

-- 10
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Challenger SRT‑8', 'Dodge', 'CHL7G09', 'Grey', 2009, 1);

-- 11
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Impreza WRX STI', 'Subaru', 'IMP8B06', 'Blue', 2006, 1);

-- 12
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('AMG GT', 'Mercedes‑Benz', 'AMG9G17', 'Gold', 2017, 1);

-- 13
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Road Runner', 'Plymouth', 'PLY0O71', 'Orange', 1971, 1);

-- 14
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('350Z', 'Nissan', 'N3D0Z02', 'Purple', 2002, 1);

-- 15
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('911 GT3 RS', 'Porsche', 'POR1W12', 'White', 2012, 1);

-- 16
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Gallardo LP560‑4', 'Lamborghini', 'LAM2O10', 'Orange', 2010, 1);

-- 17
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('M5 E60', 'BMW', 'BMW3B12', 'Blue', 2012, 1);

-- 18
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('F‑TYPE R', 'Jaguar', 'JAG4R15', 'Red', 2015, 1);

-- 19  (Diesel)
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('MXT', 'Navistar', 'NAV5D08', 'Black', 2008, 2);

-- 20  (Diesel)
INSERT INTO Carro (Nome, Marca, Placa, Cor, AnoFabricacao, TipoCombustivelId)
VALUES ('Gurkha LAPV', 'Terradyne', 'GUR6B10', 'Black', 2010, 2);
