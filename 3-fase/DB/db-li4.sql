USE [master]

DROP DATABASE cheli4;

GO
/****** Object:  Database [cheli4]    Script Date: 15/05/2019 00:29:26 ******/
CREATE DATABASE [cheli4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cheli4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cheli4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cheli4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\cheli4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [cheli4] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cheli4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cheli4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cheli4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cheli4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cheli4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cheli4] SET ARITHABORT OFF 
GO
ALTER DATABASE [cheli4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cheli4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cheli4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cheli4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cheli4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cheli4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cheli4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cheli4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cheli4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cheli4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cheli4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cheli4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cheli4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cheli4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cheli4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cheli4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cheli4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cheli4] SET RECOVERY FULL 
GO
ALTER DATABASE [cheli4] SET  MULTI_USER 
GO
ALTER DATABASE [cheli4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cheli4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cheli4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cheli4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cheli4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'cheli4', N'ON'
GO
ALTER DATABASE [cheli4] SET QUERY_STORE = OFF
GO
USE [cheli4]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 15/05/2019 00:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[FK_username_cliente] [varchar](45) NOT NULL,
	[FK_id_receita] [int] NOT NULL,
	[data] [datetime] NOT NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[FK_username_cliente] ASC,
	[FK_id_receita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 15/05/2019 00:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[username] [varchar](45) NOT NULL,
	[password] [varchar](45) NOT NULL,
	[nome] [varchar](45) NOT NULL,
	[email] [varchar](45) NOT NULL,
	[peso] [float] NULL,
	[altura] [float] NULL,
	[data_nascimento] [date] NULL,
	[idade] [int] NULL,
	[apagado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteReceita]    Script Date: 15/05/2019 00:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteReceita](
	[FK_username_cliente] [varchar](45) NOT NULL,
	[FK_id_receita] [int] NOT NULL,
	[n_realizada] [int] NOT NULL,
	[ultima_nota] [int] NOT NULL,
 CONSTRAINT [PK_ClienteReceita] PRIMARY KEY CLUSTERED 
(
	[FK_username_cliente] ASC,
	[FK_id_receita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expressao]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expressao](
	[expressao] [nchar](45) NOT NULL,
	[descricao] [text] NOT NULL,
	[FK_id_passo] [int] NOT NULL,
 CONSTRAINT [PK_Expressao] PRIMARY KEY CLUSTERED 
(
	[expressao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[id] [int] NOT NULL,
	[nome] [nchar](45) NOT NULL,
	[tipo] [nchar](45) NOT NULL,
	[calorias] [int] NOT NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passo]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passo](
	[id] [int] NOT NULL,
	[descricao] [nchar](45) NOT NULL,
	[duracao] [int] NOT NULL,
 CONSTRAINT [PK_Passo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[id_pergunta] [int] NOT NULL,
	[pergunta] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[id_pergunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receita]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita](
	[id] [int] NOT NULL,
	[nome] [nchar](45) NOT NULL,
	[tipo] [nchar](45) NOT NULL,
	[duracao] [int] NOT NULL,
	[gastronomia] [nchar](45) NOT NULL,
	[disponivel] [int] NOT NULL,
 CONSTRAINT [PK_Receita] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceitaIngrediente]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceitaIngrediente](
	[FK_id_receita] [int] NOT NULL,
	[FK_id_ingrediente] [int] NOT NULL,
	[quantidade] [int] NOT NULL,
 CONSTRAINT [PK_ReceitaIngrediente] PRIMARY KEY CLUSTERED 
(
	[FK_id_receita] ASC,
	[FK_id_ingrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceitaPasso]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceitaPasso](
	[FK_id_receita] [int] NOT NULL,
	[FK_id_passo] [int] NOT NULL,
	[ordem] [int] NOT NULL,
 CONSTRAINT [PK_ReceitaPasso] PRIMARY KEY CLUSTERED 
(
	[FK_id_receita] ASC,
	[FK_id_passo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resposta]    Script Date: 15/05/2019 00:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resposta](
	[FK_username_cliente] [varchar](45) NOT NULL,
	[FK_id_receita] [int] NOT NULL,
	[data] [datetime] NOT NULL,
	[FK_id_pergunta] [int] NOT NULL,
	[resposta] [int] NOT NULL,
 CONSTRAINT [PK_Resposta] PRIMARY KEY CLUSTERED 
(
	[FK_username_cliente] ASC,
	[FK_id_receita] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Cliente] FOREIGN KEY([FK_username_cliente])
REFERENCES [dbo].[Cliente] ([username])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Cliente]
GO
ALTER TABLE [dbo].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_Receita] FOREIGN KEY([FK_id_receita])
REFERENCES [dbo].[Receita] ([id])
GO
ALTER TABLE [dbo].[Agenda] CHECK CONSTRAINT [FK_Agenda_Receita]
GO
ALTER TABLE [dbo].[ClienteReceita]  WITH CHECK ADD  CONSTRAINT [FK_ClienteReceita_Cliente] FOREIGN KEY([FK_username_cliente])
REFERENCES [dbo].[Cliente] ([username])
GO
ALTER TABLE [dbo].[ClienteReceita] CHECK CONSTRAINT [FK_ClienteReceita_Cliente]
GO
ALTER TABLE [dbo].[ClienteReceita]  WITH CHECK ADD  CONSTRAINT [FK_ClienteReceita_Receita] FOREIGN KEY([FK_id_receita])
REFERENCES [dbo].[Receita] ([id])
GO
ALTER TABLE [dbo].[ClienteReceita] CHECK CONSTRAINT [FK_ClienteReceita_Receita]
GO
ALTER TABLE [dbo].[Expressao]  WITH CHECK ADD  CONSTRAINT [FK_Expressao_Passo] FOREIGN KEY([FK_id_passo])
REFERENCES [dbo].[Passo] ([id])
GO
ALTER TABLE [dbo].[Expressao] CHECK CONSTRAINT [FK_Expressao_Passo]
GO
ALTER TABLE [dbo].[ReceitaIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_ReceitaIngrediente_Ingrediente] FOREIGN KEY([FK_id_ingrediente])
REFERENCES [dbo].[Ingrediente] ([id])
GO
ALTER TABLE [dbo].[ReceitaIngrediente] CHECK CONSTRAINT [FK_ReceitaIngrediente_Ingrediente]
GO
ALTER TABLE [dbo].[ReceitaIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_ReceitaIngrediente_Receita] FOREIGN KEY([FK_id_receita])
REFERENCES [dbo].[Receita] ([id])
GO
ALTER TABLE [dbo].[ReceitaIngrediente] CHECK CONSTRAINT [FK_ReceitaIngrediente_Receita]
GO
ALTER TABLE [dbo].[ReceitaPasso]  WITH CHECK ADD  CONSTRAINT [FK_ReceitaPasso_Passo] FOREIGN KEY([FK_id_passo])
REFERENCES [dbo].[Passo] ([id])
GO
ALTER TABLE [dbo].[ReceitaPasso] CHECK CONSTRAINT [FK_ReceitaPasso_Passo]
GO
ALTER TABLE [dbo].[ReceitaPasso]  WITH CHECK ADD  CONSTRAINT [FK_ReceitaPasso_Receita] FOREIGN KEY([FK_id_receita])
REFERENCES [dbo].[Receita] ([id])
GO
ALTER TABLE [dbo].[ReceitaPasso] CHECK CONSTRAINT [FK_ReceitaPasso_Receita]
GO
ALTER TABLE [dbo].[Resposta]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Cliente] FOREIGN KEY([FK_username_cliente])
REFERENCES [dbo].[Cliente] ([username])
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_Resposta_Cliente]
GO
ALTER TABLE [dbo].[Resposta]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Quiz] FOREIGN KEY([FK_id_pergunta])
REFERENCES [dbo].[Quiz] ([id_pergunta])
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_Resposta_Quiz]
GO
ALTER TABLE [dbo].[Resposta]  WITH CHECK ADD  CONSTRAINT [FK_Resposta_Receita] FOREIGN KEY([FK_id_receita])
REFERENCES [dbo].[Receita] ([id])
GO
ALTER TABLE [dbo].[Resposta] CHECK CONSTRAINT [FK_Resposta_Receita]
GO
USE [master]
GO
ALTER DATABASE [cheli4] SET  READ_WRITE 
GO
