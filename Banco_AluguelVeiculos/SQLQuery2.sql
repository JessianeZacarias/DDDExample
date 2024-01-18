USE AluguelVeiculos 
go

create table Clientes(
ID INT PRIMARY KEY IDENTITY (1,1),
Nome character  NOT NULL,
DataNascimento Datetime NOT NULL,
Habilitacaoo varchar (9) NOT NULL,
Estado character NOT NULL,
)

