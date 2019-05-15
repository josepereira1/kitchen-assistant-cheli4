USE [master]

DROP DATABASE cheli4;

GO
/****** Object:  Database [cheli4]    Script Date: 15/05/2019 16:41:38 ******/
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
/****** Object:  Table [dbo].[Agenda]    Script Date: 15/05/2019 16:41:38 ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 15/05/2019 16:41:38 ******/
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
/****** Object:  Table [dbo].[ClienteReceita]    Script Date: 15/05/2019 16:41:39 ******/
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
/****** Object:  Table [dbo].[Expressao]    Script Date: 15/05/2019 16:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expressao](
	[expressao] [varchar](512) NOT NULL,
	[descricao] [text] NOT NULL,
	[FK_id_passo] [int] NOT NULL,
 CONSTRAINT [PK_Expressao] PRIMARY KEY CLUSTERED 
(
	[expressao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 15/05/2019 16:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[id] [int] NOT NULL,
	[nome] [varchar](45) NOT NULL,
	[tipo] [varchar](45) NOT NULL,
	[calorias] [int] NOT NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passo]    Script Date: 15/05/2019 16:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passo](
	[id] [int] NOT NULL,
	[descricao] [text] NOT NULL,
	[duracao] [int] NOT NULL,
 CONSTRAINT [PK_Passo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 15/05/2019 16:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[id_pergunta] [int] NOT NULL,
	[pergunta] [text] NOT NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[id_pergunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receita]    Script Date: 15/05/2019 16:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita](
	[id] [int] NOT NULL,
	[nome] [varchar](45) NOT NULL,
	[tipo] [varchar](45) NOT NULL,
	[duracao] [int] NOT NULL,
	[gastronomia] [varchar](45) NOT NULL,
	[disponivel] [int] NOT NULL,
 CONSTRAINT [PK_Receita] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceitaIngrediente]    Script Date: 15/05/2019 16:41:39 ******/
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
/****** Object:  Table [dbo].[ReceitaPasso]    Script Date: 15/05/2019 16:41:39 ******/
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
/****** Object:  Table [dbo].[Resposta]    Script Date: 15/05/2019 16:41:39 ******/
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
INSERT [dbo].[Cliente] ([username], [password], [nome], [email], [peso], [altura], [data_nascimento], [idade], [apagado]) VALUES (N'jose', N'password', N'José Pereira', N'jose@gmail.com', 80, 1.9, CAST(N'1997-06-19' AS Date), 21, 0)
INSERT [dbo].[Cliente] ([username], [password], [nome], [email], [peso], [altura], [data_nascimento], [idade], [apagado]) VALUES (N'ricardo', N'password', N'Ricardo Petronilho', N'ricardo@gmail.com', 56, 1.73, CAST(N'1998-06-29' AS Date), 20, 0)
INSERT [dbo].[ClienteReceita] ([FK_username_cliente], [FK_id_receita], [n_realizada], [ultima_nota]) VALUES (N'jose', 0, 2, 6)
INSERT [dbo].[ClienteReceita] ([FK_username_cliente], [FK_id_receita], [n_realizada], [ultima_nota]) VALUES (N'jose', 1, 10, 9)
INSERT [dbo].[ClienteReceita] ([FK_username_cliente], [FK_id_receita], [n_realizada], [ultima_nota]) VALUES (N'ricardo', 0, 4, 8)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Pré-aquecer o forno', N'Pré-aquecer o forno consiste em colocar uma temperatura adequada ao cozinhado que está a efeutar, geralmente a 200 graus durante 10 a 15 minutos. Note-se que existem fornos com uma configuração para pre-aquecimento, verifique se o seu tem a mesma.', 0)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'refogar as cebolas, os alhos e a folha de louro', N'Coloque a cebola, alho e folha de loura, tudo picado, juntamente com azeite no fundo do tacho e deixe a lume brando durante 3 minutos ou até reparar que a cebola ou alho começe a ficar queimada.', 5)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (0, N'bacalhau', N'peixe', 200)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (1, N'batata', N'legume', 25)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (2, N'nata', N'lácteo', 75)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (3, N'arroz', N'cereal', 100)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (4, N'pato', N'carne', 150)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (0, N'pré-aquecer o forno a 220 graus', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (1, N'Corte as batatas em cubos e frite-as em azeite.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (2, N' Coloque o bacalhau num tacho e cubra-o com água. Leve-o a cozinhar em lume alto, quando levantar fervura baixe o lume e cozinhe 5 minutos.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (3, N' Retire o bacalhau da água e reserve 200 ml da água. Deixe arrefecer o bacalhau, retire-lhe a pele e as espinhas e desfie-o em lascas.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (4, N' Leve ao lume um tacho, coloque a manteiga até derreter. Junte a farinha e mexa muito bem. Aos poucos, sem parar de mexer, vá juntando a água de cozer o bacalhau reservada, as natas. Quando começar a ferver, tempere com especiarais a seu gosto. Envolva bem todos os ingredientes e retire do lume. Reserve.', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (5, N' Num outro tacho, coloque 100 ml de azeite e deixe refogar as cebolas, os alhos e a folha de louro. Adicione o bacalhau, mexa e deixe refogar um pouco.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (6, N'Junte as batatas e envolva bem. Depois, acrescente 2/3 do molho béchamel, mexa bem retire do lume e reserve.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (7, N'Junte as batatas e envolva bem. Depois, acrescente 2/3 do molho béchamel, mexa bem retire do lume e reserve.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (8, N'Pincele um tabuleiro de forno com o restante azeite e espalhe bem o preparado de bacalhau. Coloque o restante molho béchamel e polvilhe com o queijo ralado.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (9, N' Leve o bacalhau com natas com natas ao forno a gratinar entre 15 e 20 minutos.', 10)
INSERT [dbo].[Receita] ([id], [nome], [tipo], [duracao], [gastronomia], [disponivel]) VALUES (0, N'bacalhau com natas', N'peixe', 90, N'pt', 1)
INSERT [dbo].[Receita] ([id], [nome], [tipo], [duracao], [gastronomia], [disponivel]) VALUES (1, N'arroz de pato', N'carne', 90, N'pt', 1)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 0, 400)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 1, 500)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 2, 250)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 3, 1)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 4, 1)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 0, 0)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 1, 1)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 2, 2)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 3, 3)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 4, 4)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 5, 5)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 6, 6)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 7, 7)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 8, 8)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 9, 9)
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
