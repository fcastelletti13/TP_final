USE [master]
GO
/****** Object:  Database [DBFutbol]    Script Date: 30/11/2022 21:02:37 ******/
CREATE DATABASE [DBFutbol]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBFutbol', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DBFutbol.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBFutbol_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DBFutbol_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBFutbol] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBFutbol].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBFutbol] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBFutbol] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBFutbol] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBFutbol] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBFutbol] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBFutbol] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBFutbol] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBFutbol] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBFutbol] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBFutbol] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBFutbol] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBFutbol] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBFutbol] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBFutbol] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBFutbol] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBFutbol] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBFutbol] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBFutbol] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBFutbol] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBFutbol] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBFutbol] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBFutbol] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBFutbol] SET RECOVERY FULL 
GO
ALTER DATABASE [DBFutbol] SET  MULTI_USER 
GO
ALTER DATABASE [DBFutbol] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBFutbol] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBFutbol] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBFutbol] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBFutbol] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBFutbol] SET QUERY_STORE = OFF
GO
USE [DBFutbol]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[IdEquipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Escudo] [varchar](50) NULL,
	[Pos] [int] NOT NULL,
	[Pts] [int] NOT NULL,
	[PJ] [int] NULL,
	[DG] [int] NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquiposxPartidos]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquiposxPartidos](
	[IdEquipoxPartido] [int] IDENTITY(1,1) NOT NULL,
	[IdEquipo] [int] NOT NULL,
	[IdPartido] [int] NOT NULL,
	[Local] [bit] NULL,
 CONSTRAINT [PK_EquiposxPartidos] PRIMARY KEY CLUSTERED 
(
	[IdEquipoxPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[IdJugador] [int] IDENTITY(1,1) NOT NULL,
	[NombreApellido] [varchar](50) NOT NULL,
	[Goles] [int] NOT NULL,
	[Asistencias] [int] NOT NULL,
	[IdEquipo] [int] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[IdPartido] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [int] NULL,
	[Horario] [datetime] NOT NULL,
	[GolesLocal] [int] NULL,
	[GolesVisitante] [int] NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[TextoPost] [varchar](500) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Foto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 30/11/2022 21:02:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Foto] [varchar](500) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Pos], [Pts], [PJ], [DG]) VALUES (1, N'Boca Juniors', N'Boca.png', 1, 12, 4, 8)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Pos], [Pts], [PJ], [DG]) VALUES (2, N'River', N'River.png', 2, 9, 4, 6)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Pos], [Pts], [PJ], [DG]) VALUES (3, N'Independiente', N'Independiente.png', 3, 6, 4, 2)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Pos], [Pts], [PJ], [DG]) VALUES (5, N'Racing', N'Racing.png', 4, 3, 4, -3)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Pos], [Pts], [PJ], [DG]) VALUES (6, N'San Lorenzo', N'San Lorenzo.png', 5, 0, 4, -7)
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[EquiposxPartidos] ON 

INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (1, 1, 1, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (2, 2, 1, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (3, 3, 2, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (4, 5, 2, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (5, 3, 3, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (6, 1, 3, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (7, 6, 5, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (8, 2, 5, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (9, 1, 6, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (10, 6, 6, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (11, 2, 7, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (12, 5, 7, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (13, 5, 8, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (14, 1, 8, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (15, 6, 9, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (16, 3, 9, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (17, 2, 10, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (18, 3, 10, 0)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (19, 5, 11, 1)
INSERT [dbo].[EquiposxPartidos] ([IdEquipoxPartido], [IdEquipo], [IdPartido], [Local]) VALUES (20, 6, 11, 0)
SET IDENTITY_INSERT [dbo].[EquiposxPartidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([IdJugador], [NombreApellido], [Goles], [Asistencias], [IdEquipo]) VALUES (1, N'Sebastian Villa', 7, 6, 1)
INSERT [dbo].[Jugadores] ([IdJugador], [NombreApellido], [Goles], [Asistencias], [IdEquipo]) VALUES (2, N'Armani', 45, 97, 2)
INSERT [dbo].[Jugadores] ([IdJugador], [NombreApellido], [Goles], [Asistencias], [IdEquipo]) VALUES (4, N'Vallejo', 7, 3, 3)
INSERT [dbo].[Jugadores] ([IdJugador], [NombreApellido], [Goles], [Asistencias], [IdEquipo]) VALUES (5, N'Muerto Copetti', 0, 0, 5)
INSERT [dbo].[Jugadores] ([IdJugador], [NombreApellido], [Goles], [Asistencias], [IdEquipo]) VALUES (6, N'El Perrito Barrios', 2, 2, 6)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Partidos] ON 

INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (1, 1, CAST(N'2022-08-27T15:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (2, 1, CAST(N'2022-08-27T18:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (3, 2, CAST(N'2022-09-03T15:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (5, 2, CAST(N'2022-09-03T18:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (6, 3, CAST(N'2022-09-11T15:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (7, 3, CAST(N'2022-09-11T18:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (8, 4, CAST(N'2022-09-18T15:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (9, 4, CAST(N'2022-09-18T18:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (10, 5, CAST(N'2022-09-25T15:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Partidos] ([IdPartido], [Fecha], [Horario], [GolesLocal], [GolesVisitante]) VALUES (11, 5, CAST(N'2022-09-25T18:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Partidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([IdPost], [TextoPost], [IdUsuario], [FechaCreacion], [Foto]) VALUES (2, N'asdasdasdasdasdasdasdasdas asdasdasdasdasdasdasdasdas asdasdasdasdasdasdasdasdas asdasdasdasdasdasdasdasdas', 1, CAST(N'2022-11-30T12:57:19.030' AS DateTime), N'FotoReact1.jpg')
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Contraseña], [Foto]) VALUES (1, N'Axel pro', N'123', N'yoBUENA.png')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [DBFutbol] SET  READ_WRITE 
GO
