USE Unip

CREATE TABLE [dbo].[Chamado](
	[idChamado] [int] IDENTITY(1,1) NOT NULL primary key,
	[idFuncionario] [int] NOT NULL,
	[idProblema] [int] NOT NULL,
	[descricao] [nvarchar](350) NOT NULL,
	[dataChamado] [date] NOT NULL,
	[statusAtendimento] [nvarchar](30) NOT NULL,
	foreign key (idFuncionario) references Funcionario(idFuncionario),
	foreign key (idProblema) references Problema(idProblema),
)

CREATE TABLE [dbo].[chamadoAtendimento](
	[idAtendimento] [int] IDENTITY(1,1) NOT NULL primary key,
	[idFuncionario] [int] NOT NULL,
	[idChamado] [int] NOT NULL,
	[dataAtendimento] [date] not NULL,
	foreign key (idFuncionario) references Funcionario(idFuncionario),
	foreign key (idChamado) references Chamado(idChamado)
)

CREATE TABLE [dbo].[Funcionario](
	[idFuncionario] [int] IDENTITY(1,1) NOT NULL primary key,
	[nome] [nvarchar](50) not null,
	[ramal] [int] NULL,
	[nComputador] [int] NULL,
	[email] [nvarchar](50) NOT NULL,
	[setor] [nvarchar](30) NOT NULL,
	[idNivelAcesso] [int] NOT NULL,
	foreign key(idNivelAcesso) references nivelAcesso(idNivelAcesso)
)

CREATE TABLE [dbo].[Loginn](
	[idLogin] [int] IDENTITY(1,1) NOT NULL primary key,
	idFuncionario int not null,
	[login] [varchar](50) not NULL,
	[senha] [varchar](50) not NULL,
	foreign key(idFuncionario) references Funcionario(idFuncionario)
)


CREATE TABLE [dbo].[Problema](
	[idProblema] [int] IDENTITY(1,1) NOT NULL primary key,
	[tipoProblema] [nvarchar](30) NOT NULL,
)

create table nivelAcesso(
idNivelAcesso int identity(1,1) primary key not null,
tipoAcesso nvarchar(20) not null
)


