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

CREATE TABLE Caminhoes (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),

    Nome NVARCHAR(255)       NOT NULL,
    Marca NVARCHAR(255)      NOT NULL,
    Placa NVARCHAR(20)       NOT NULL,
    Cor   NVARCHAR(50)       NOT NULL,

    AnoFabricacao INT        NOT NULL,

    -- FK para a tabela TipoCombustivel
    TipoCombustivelId INT    NOT NULL,

    -- Campos específicos de caminhão (opcionais)
    CapacidadeCargaToneladas DECIMAL(10,2) NULL,
    QuantidadeEixos          INT           NULL,

    CONSTRAINT FK_Caminhao_TipoCombustivel 
        FOREIGN KEY (TipoCombustivelId) 
        REFERENCES TipoCombustivel(Id)

INSERT INTO Caminhoes
(Nome,                     Marca,           Placa,   Cor,     AnoFabricacao, TipoCombustivelId, CapacidadeCargaToneladas, QuantidadeEixos)
VALUES
    ('Actros 2651',            'Mercedes-Benz', 'ABC1D23', 'Branco',   2022, 1, 26.00, 6),
    ('FH 540',                 'Volvo',         'DEF2G34', 'Prata',    2021, 1, 28.00, 6),
    ('R500',                   'Scania',        'GHI3J45', 'Vermelho', 2020, 1, 27.00, 6),
    ('Hi‑Way',                 'Iveco',         'JKL4M56', 'Azul',     2019, 1, 25.00, 5),
    ('TGX 28.440',             'MAN',           'MNO5P67', 'Preto',    2023, 1, 28.50, 6),
    ('F‑4000',                 'Ford',          'PQR6S78', 'Cinza',    2018, 1, 10.00, 2),
    ('Constellation 24.280',   'Volkswagen',    'STU7V89', 'Branco',   2022, 1, 24.00, 4),
    ('XF 105',                 'DAF',           'VWX8Y90', 'Azul',     2021, 1, 29.00, 6),
    ('ProStar',                'International', 'YZA9B01', 'Preto',    2017, 1, 27.50, 5),
    ('Cascadia',               'Freightliner',  'BCD0E12', 'Branco',   2024, 1, 30.00, 6),
    ('Atego 2426',             'Mercedes-Benz', 'CDE1F23', 'Verde',    2016, 1, 17.00, 4),
    ('FM 460',                 'Volvo',         'EFG2H34', 'Prata',    2019, 1, 26.00, 5),
    ('P 360',                  'Scania',        'FGH3I45', 'Amarelo',  2018, 1, 18.00, 4),
    ('Tector 240E28',          'Iveco',         'GHI4J56', 'Branco',   2020, 1, 24.00, 4),
    ('TGS 29.440',             'MAN',           'HIJ5K67', 'Azul',     2022, 1, 29.00, 6),
    ('Cargo 2429',             'Ford',          'IJK6L78', 'Vermelho', 2017, 1, 14.00, 4),
    ('Deliver 9.170',          'Volkswagen',    'JKL7M89', 'Cinza',    2023, 1,  9.00, 2),
    ('CF 85',                  'DAF',           'KLM8N90', 'Branco',   2015, 1, 23.50, 4),
    ('HX Series',              'International', 'LMN9O01', 'Preto',    2024, 1, 31.00, 6),
    ('M2 106',                 'Freightliner',  'MNO0P12', 'Prata',    2021, 1, 12.50, 2);

);