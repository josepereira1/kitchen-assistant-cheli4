USE [master]
GO

DROP DATABASE cheli4;

/****** Object:  Database [cheli4]    Script Date: 03/06/2019 11:53:36 ******/
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
/****** Object:  Table [dbo].[Agenda]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[ClienteReceita]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Codigo]    Script Date: 03/06/2019 11:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Codigo](
	[codigo] [varchar](10) NOT NULL,
	[FK_username_cliente] [varchar](45) NOT NULL,
 CONSTRAINT [PK_Codigo] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expressao]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Passo]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Quiz]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Receita]    Script Date: 03/06/2019 11:53:37 ******/
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
	[nomeFotoNormal] [varchar](50) NOT NULL,
	[nomeFotoMiniatura] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Receita] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceitaIngrediente]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[ReceitaPasso]    Script Date: 03/06/2019 11:53:37 ******/
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
/****** Object:  Table [dbo].[Resposta]    Script Date: 03/06/2019 11:53:37 ******/
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
ALTER TABLE [dbo].[Codigo]  WITH CHECK ADD  CONSTRAINT [FK_Codigo_Cliente] FOREIGN KEY([FK_username_cliente])
REFERENCES [dbo].[Cliente] ([username])
GO
ALTER TABLE [dbo].[Codigo] CHECK CONSTRAINT [FK_Codigo_Cliente]
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


USE [cheli4]
INSERT [dbo].[Cliente] ([username], [password], [nome], [email], [peso], [altura], [data_nascimento], [idade], [apagado]) VALUES (N'jose', N'5f4dcc3b5aa765d61d8327deb882cf99', N'José Pereira', N'jose@gmail.com', 80, 1.9, CAST(N'1997-06-19' AS Date), 21, 0)
INSERT [dbo].[Cliente] ([username], [password], [nome], [email], [peso], [altura], [data_nascimento], [idade], [apagado]) VALUES (N'ricardo', N'5f4dcc3b5aa765d61d8327deb882cf99', N'Ricardo Petronilho', N'ricardo@gmail.com', 56, 1.73, CAST(N'1998-06-29' AS Date), 20, 0)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (0, N'codfish', N'fish', 140)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (1, N'potato', N'vegetable', 69)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (2, N'cream', N'dairy', 19)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (3, N'rice', N'cereal', 206)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (4, N'duck', N'beef', 201)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (5, N'chorizo', N'beef', 273)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (6, N'water', N'water', 0)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (7, N'Knorr Chicken Natura', N'sauces', 50)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (8, N'milk', N'milk', 184)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (9, N'Seasoning Knorr of Garlic and Parsley', N'sauces', 50)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (10, N'olive oil', N'oil', 120)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (11, N'garlic cloves', N'vegetable', 20)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (12, N'onion', N'vegetable', 39)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (13, N'bay leaves', N'vegetable', 5)
INSERT [dbo].[Ingrediente] ([id], [nome], [tipo], [calorias]) VALUES (14, N'salt', N'salt', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (0, N'Soak the dried salted cod in cold water with the skin side up for 24 hours, changing the water about 4 times. Drain and discard the water.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (1, N'Preheat an oven to 175 degrees.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (2, N'Place the cod in a pan with enough water to cover; bring to a boil and cook for 10 minutes. Remove the cod from the pan. Remove and discard the skin and bones. Cut the cod into chunks and set aside.', 8)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (3, N'Heat 1/2 inch vegetable oil in large skillet over medium-high heat. Working in batches if necessary, fry the potatoes in the hot oil until just cooked, about 5 minutes. Transfer to a plate lined with paper towels to drain.', 4)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (4, N'Pour the olive oil into a Dutch oven or heat-proof casserole dish over medium heat. Cook the onion and garlic in the oil until the onion is translucent, about 5 minutes. Add the cod and cook another 3 minutes; stir the potatoes into the mixture and cook another 1 to 2 minutes. Reduce heat to low.', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (5, N'Melt the butter in a separate pan over medium-low heat; vigorously stir the flour into the melted butter. Slowly stream the hot milk into the mixture while stirring; cook and stir until thick. Season with the nutmeg. Pour into the casserole with 1 1/3 cups cream; stir to coat. Allow the mixture to simmer together for about 2 minutes. Season with salt and pepper. Drizzle remaining 2/3 cup cream over the mixture; sprinkle with the Parmesan cheese.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (6, N'Bake in the preheated oven until the top is browned, 30 to 40 minutes. Serve hot.', 10)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (7, N'It’s very important to desalinate the fish very well, at least 72 hours before cooking it, you must use very cold water, change it frequently, and keep the codfish in a covered glass bowl inside the refrigerator.', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (8, N'After desalinated, cut the codfish into 4 big squares, remove the dark skin and the spines, and put it into a saucepan covering it with the milk and the sliced garlic. Set aside for at least 2 hours. (maybe in the refrigerator)', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (9, N'Step 0', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (10, N'Step 1', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (11, N'Step 2', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (12, N'Step 3', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (13, N'Step 4', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (14, N'Step 5', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (15, N'Step 6', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (16, N'Step 7', 5)
INSERT [dbo].[Passo] ([id], [descricao], [duracao]) VALUES (17, N'Step 8', 5)
INSERT [dbo].[Receita] ([id], [nome], [tipo], [duracao], [gastronomia], [disponivel],[nomeFotoNormal],[nomeFotoMiniatura]) VALUES (0, N'Cod with cream', N'fish', 90, N'pt', 1, N'f0N.PNG', N'f0M.PNG')
INSERT [dbo].[Receita] ([id], [nome], [tipo], [duracao], [gastronomia], [disponivel],[nomeFotoNormal],[nomeFotoMiniatura]) VALUES (1, N'Duck rice', N'beef', 80, N'pt', 1, N'f1N.PNG', N'f1M.PNG')
INSERT [dbo].[Receita] ([id], [nome], [tipo], [duracao], [gastronomia], [disponivel],[nomeFotoNormal],[nomeFotoMiniatura]) VALUES (2, N'Lagareiro Codfish', N'fish', 120, N'pt', 1, N'f2N.PNG', N'f2M.PNG')
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 0, 400)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 1, 400)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 2, 100)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 8, 800)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 9, 50)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 10, 200)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 11, 50)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (0, 12, 100)

INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 3, 100)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 4, 500)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 5, 200)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 6, 800)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (1, 7, 50)

INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 0, 400)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 1, 300)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 3, 100)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 10, 100)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 13, 50)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 14, 500)
INSERT [dbo].[ReceitaIngrediente] ([FK_id_receita], [FK_id_ingrediente], [quantidade]) VALUES (2, 11, 100)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 0, 0)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 1, 1)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 2, 2)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 3, 3)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 4, 4)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 5, 5)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (0, 6, 6)

INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 7, 0)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 8, 1)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 9, 2)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 10, 3)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 11, 4)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 12, 5)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (2, 13, 6)

INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 9, 0)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 10, 1)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 11, 2)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 12, 3)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 13, 4)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 14, 5)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 16, 6)
INSERT [dbo].[ReceitaPasso] ([FK_id_receita], [FK_id_passo], [ordem]) VALUES (1, 17, 7)
INSERT [dbo].[ClienteReceita] ([FK_username_cliente], [FK_id_receita], [n_realizada], [ultima_nota]) VALUES (N'jose', 0,15 , 6)
INSERT [dbo].[ClienteReceita] ([FK_username_cliente], [FK_id_receita], [n_realizada], [ultima_nota]) VALUES (N'ricardo', 0, 10, 9)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Preheat an oven', N'Before putting anything to roast, the oven must be heated to a suitable temperature. Even if it takes only a few seconds to turn it on, you need to wait a few minutes to reach the desired temperature. The act of turning on the oven and letting it heat up to the right temperature is called "preheating." Since ovens are slow to heat, most recipes recommend turning them on before starting to bake. This article will show you how to preheat electric and gas ovens.', 1)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 1', N'meaning of expression', 0)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 2', N'meaning of expression', 2)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 3', N'meaning of expression', 3)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 4', N'meaning of expression', 4)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 5', N'meaning of expression', 5)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 6', N'meaning of expression', 6)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 7', N'meaning of expression', 7)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 8', N'meaning of expression', 8)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 9', N'meaning of expression', 0)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 10', N'meaning of expression', 2)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 11', N'meaning of expression', 3)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 12', N'meaning of expression', 4)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 13', N'meaning of expression', 5)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 14', N'meaning of expression', 6)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 15', N'meaning of expression', 7)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 16', N'meaning of expression', 8)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 17', N'meaning of expression', 0)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 18', N'meaning of expression', 2)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 19', N'meaning of expression', 3)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 20', N'meaning of expression', 4)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 21', N'meaning of expression', 5)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 22', N'meaning of expression', 6)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 23', N'meaning of expression', 7)
INSERT [dbo].[Expressao] ([expressao], [descricao], [FK_id_passo]) VALUES (N'Expression 24', N'meaning of expression', 8)
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H0', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H1', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H2', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H3', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H4', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H5', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H6', N'jose')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H7', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H8', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477H9', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477J0', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477J1', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477J2', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477J3', N'ricardo')
INSERT [dbo].[Codigo] ([codigo], [FK_username_cliente]) VALUES (N'44XTG477J4', N'ricardo')
GO