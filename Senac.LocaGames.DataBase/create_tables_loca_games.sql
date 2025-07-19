CREATE TABLE GameCategory (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Inserir os valores do enum
INSERT INTO GameCategory (Id, Name) VALUES
(1, 'BRONZE'),
(2, 'SILVER'),
(3, 'GOLD');


CREATE TABLE Game (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Available BIT NOT NULL,
    CategoryId INT NOT NULL,  -- FK para GameCategory
    Responsible NVARCHAR(255),
    WithdrawalDate DATETIME NULL,
    
    CONSTRAINT FK_Game_GameCategory FOREIGN KEY (CategoryId)
        REFERENCES GameCategory(Id)
);

INSERT INTO Game (Title, Description, Available, CategoryId, Responsible, WithdrawalDate) VALUES
('FIFA 22', 'Jogo de futebol com gráficos realistas.', 1, 2, NULL, NULL),
('Call of Duty: Modern Warfare', 'FPS militar com multiplayer online.', 1, 3, NULL, NULL),
('Minecraft', 'Jogo de construção em mundo aberto.', 1, 1, NULL, NULL),
('The Legend of Zelda: Breath of the Wild', 'Aventura épica em mundo aberto.', 1, 3, NULL, NULL),
('Among Us', 'Jogo multiplayer de dedução social.', 1, 1, NULL, NULL),
('Rocket League', 'Futebol com carros.', 1, 1, NULL, NULL),
('Cyberpunk 2077', 'RPG futurista com mundo aberto.', 1, 3, NULL, NULL),
('Fortnite', 'Battle royale com construção.', 1, 2, NULL, NULL),
('God of War', 'Ação e mitologia nórdica.', 1, 3, NULL, NULL),
('Stardew Valley', 'Simulador de fazenda e RPG.', 1, 1, NULL, NULL),
('Red Dead Redemption 2', 'Aventura no Velho Oeste.', 1, 3, NULL, NULL),
('Overwatch', 'Jogo de tiro em equipe.', 1, 2, NULL, NULL),
('The Sims 4', 'Simulador de vida real.', 1, 2, NULL, NULL),
('Grand Theft Auto V', 'Ação em mundo aberto.', 1, 3, NULL, NULL),
('Hollow Knight', 'Metroidvania desafiador.', 1, 1, NULL, NULL),
('Apex Legends', 'Battle Royale com heróis.', 1, 2, NULL, NULL),
('Forza Horizon 5', 'Corrida com carros de luxo.', 1, 2, NULL, NULL),
('Terraria', 'Aventura 2D com construção.', 1, 1, NULL, NULL),
('Resident Evil Village', 'Terror e sobrevivência.', 1, 3, NULL, NULL),
('League of Legends', 'MOBA competitivo em equipes.', 1, 2, NULL, NULL);
