CREATE DATABASE AluguelVeiculos
GO

USE AluguelVeiculos
GO

CREATE TABLE Veiculo(
VeiculoId int PRIMARY KEY IDENTITY (1,1),
Placa varchar(7) NOT NULL,
AnoFabricacao int NOT NULL,
TipoVeiculoId int NOT NULL,
Estado CHAR(2) NOT NULL,
MontadoraId int NOT NULL,
Alugado bit DEFAULT 0
)
