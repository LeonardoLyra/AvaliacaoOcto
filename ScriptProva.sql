create database prova_Octo

use prova_Octo

create table Cliente
(
	IdCliente int primary key identity not null,
	Nome varchar(50) not null,
	TipoCliente varchar(2) not null,
	CPF_CNPJ varchar(20) not null,

);


insert into Cliente values('Leonardo', 'PF', '46640171899')
insert into Cliente values('Tecnologia LTDA', 'PJ', '40296411000190')

create table Telefone
(
	IdTelefone int primary key identity not null,
	IdCliente int not null,
	NumeroTelefone varchar(15) not null,
	TipoTelefone varchar(15) not null,
	foreign key (IdCliente) references Cliente (IdCliente)
);



insert into Telefone values('1', '17991104196', 'Celular')
insert into Telefone values('1', '17997344196', 'Residencial')
insert into Telefone values('2', '1738082044', 'Comercial')

create table Endereco
(
	IdEndereco int primary key identity not null,
	IdCliente int not null,
	Logradouro varchar(50) not null,
	TipoEndereco varchar(20) not null,
	foreign key (IdCliente) references Cliente (IdCliente)
);

insert into Endereco values('1', 'Rua Jos� Mullati, 310', 'Entrega')
insert into Endereco values('1', 'Rua Ernani Pires, 435', 'Residencial')
insert into Endereco values('2', 'Av Alberto Andal�, 4045', 'Comercial')

select * from Cliente


