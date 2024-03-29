USE [AtividadeDS]
GO
/****** Object:  User [DESKTOP-6LUQRDL\Gabriel]    Script Date: 10/21/2019 1:08:19 AM ******/
CREATE USER [DESKTOP-6LUQRDL\Gabriel] FOR LOGIN [DESKTOP-6LUQRDL\Gabriel] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/21/2019 1:08:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](100) NOT NULL,
	[cargo] [nvarchar](50) NOT NULL,
	[datanasc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
