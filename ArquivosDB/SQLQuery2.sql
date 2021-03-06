USE [BDOO]
GO
/****** Object:  Table [dbo].[Chamado]    Script Date: 05/10/2018 18:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chamado](
	[idChamado] [int] IDENTITY(1,1) NOT NULL,
	[idFuncionario] [int] NOT NULL,
	[idProblema] [int] NOT NULL,
	[descricao] [varchar](50) NOT NULL,
	[dataChamado] [date] NOT NULL,
	[dataAtendimento] [date] NULL,
	[statusAtendimento] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idChamado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chamadoAtendimento]    Script Date: 05/10/2018 18:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chamadoAtendimento](
	[idAtendimento] [int] IDENTITY(1,1) NOT NULL,
	[idFuncionario] [int] NOT NULL,
	[idChamado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAtendimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 05/10/2018 18:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[idFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[idLogin] [int] NULL,
	[nome] [varchar](30) NULL,
	[ramal] [int] NULL,
	[nComputador] [int] NULL,
	[email] [varchar](20) NOT NULL,
	[setor] [varchar](20) NOT NULL,
	[nivelAcesso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loginn]    Script Date: 05/10/2018 18:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loginn](
	[idLogin] [int] IDENTITY(1,1) NOT NULL,
	[loginn] [varchar](20) NULL,
	[senha] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[idLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoProblema]    Script Date: 05/10/2018 18:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoProblema](
	[idProblema] [int] IDENTITY(1,1) NOT NULL,
	[tipoProblema] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProblema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD FOREIGN KEY([idFuncionario])
REFERENCES [dbo].[Funcionario] ([idFuncionario])
GO
ALTER TABLE [dbo].[Chamado]  WITH CHECK ADD FOREIGN KEY([idProblema])
REFERENCES [dbo].[tipoProblema] ([idProblema])
GO
ALTER TABLE [dbo].[chamadoAtendimento]  WITH CHECK ADD FOREIGN KEY([idChamado])
REFERENCES [dbo].[Chamado] ([idChamado])
GO
ALTER TABLE [dbo].[chamadoAtendimento]  WITH CHECK ADD FOREIGN KEY([idFuncionario])
REFERENCES [dbo].[Funcionario] ([idFuncionario])
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD FOREIGN KEY([idLogin])
REFERENCES [dbo].[Loginn] ([idLogin])
GO
