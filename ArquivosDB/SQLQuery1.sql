USE DB_UNIINFO
CREATE TABLE [dbo].[ERP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[modulos] varchar (30) Not Null
	)

CREATE TABLE [dbo].[Funcionario](
	[idFuncionario] [int] primary key IDENTITY(1,1) NOT NULL,
	[idLogin] [int],
	FOREIGN KEY (idLogin) references Loginn(idLogin),
	[nome] [varchar] (30),
	[ramal] [int] NULL,
	[nComputador] [int] NULL,
	[email] [varchar](15) NOT NULL,
	[setor] [varchar](20) NOT NULL
	)

	

CREATE TABLE [dbo].[Hardware](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[perifericos] [varchar] (30) NOT NULL,
	)

CREATE TABLE [dbo].[Software](
	[id] [int] IDENTITY(1,1) NOT NULL,
	software varchar(20) not null
	)

CREATE TABLE [dbo].[StatusAtendimento](
	[idStatus] [int] IDENTITY(1,1) NOT NULL,
	[estadoStatus] [varchar] (30) NOT NULL
	)

CREATE TABLE [dbo].[Telefonia](
	[idTelefonia] [int] IDENTITY(1,1) NOT NULL,
	tipoLigacao varchar (20) not null
	)


CREATE TABLE [dbo].[Loginn](
	[idLogin] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[loginn] [varchar](20) NULL,
	[senha] [varchar](30) NULL
	)


CREATE TABLE [dbo].[Chamado](
[idChamado] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[idFuncionario] [int],
FOREIGN KEY (idFuncionario) references Funcionario(idFuncionario),
)