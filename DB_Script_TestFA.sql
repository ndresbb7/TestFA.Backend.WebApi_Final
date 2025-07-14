USE [TestFA]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 14/07/2025 2:35:34 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Color_ID] [int] IDENTITY(1,1) NOT NULL,
	[Color_Nombre] [nvarchar](50) NOT NULL,
	[Color_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Color_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fase]    Script Date: 14/07/2025 2:35:34 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fase](
	[Fase_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fase_Nombre] [nvarchar](50) NOT NULL,
	[Fase_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Fase] PRIMARY KEY CLUSTERED 
(
	[Fase_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 14/07/2025 2:35:34 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Marca_ID] [int] IDENTITY(1,1) NOT NULL,
	[Marca_Nombre] [nvarchar](50) NOT NULL,
	[Marca_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Marca_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 14/07/2025 2:35:34 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Vehiculo_ID] [int] IDENTITY(1,1) NOT NULL,
	[Vehiculo_Placa] [nvarchar](10) NOT NULL,
	[Vehiculo_Color] [int] NOT NULL,
	[Vehiculo_Marca] [int] NOT NULL,
	[Vehiculo_Linea] [nvarchar](50) NULL,
	[Vehiculo_Anio] [int] NOT NULL,
	[Vehiculo_KM] [int] NOT NULL,
	[Vehiculo_Valor] [money] NOT NULL,
	[Vehiculo_Observaciones] [nvarchar](500) NOT NULL,
	[Vehiculo_Fase] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Vehiculo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo_Foto]    Script Date: 14/07/2025 2:35:34 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo_Foto](
	[Vehiculo_Foto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Vehiculo_Foto_Vehiculo] [int] NOT NULL,
	[Vehiculo_Foto_Filename] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vehiculo_Foto] PRIMARY KEY CLUSTERED 
(
	[Vehiculo_Foto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Color] ON 
GO
INSERT [dbo].[Color] ([Color_ID], [Color_Nombre], [Color_Activo]) VALUES (1, N'Azul', 1)
GO
INSERT [dbo].[Color] ([Color_ID], [Color_Nombre], [Color_Activo]) VALUES (2, N'Rojo', 1)
GO
INSERT [dbo].[Color] ([Color_ID], [Color_Nombre], [Color_Activo]) VALUES (3, N'Verde', 1)
GO
INSERT [dbo].[Color] ([Color_ID], [Color_Nombre], [Color_Activo]) VALUES (4, N'Negro', 1)
GO
INSERT [dbo].[Color] ([Color_ID], [Color_Nombre], [Color_Activo]) VALUES (5, N'Blanco', 1)
GO
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Fase] ON 
GO
INSERT [dbo].[Fase] ([Fase_ID], [Fase_Nombre], [Fase_Activo]) VALUES (1, N'Disponible', 1)
GO
INSERT [dbo].[Fase] ([Fase_ID], [Fase_Nombre], [Fase_Activo]) VALUES (2, N'Reparacion', 1)
GO
INSERT [dbo].[Fase] ([Fase_ID], [Fase_Nombre], [Fase_Activo]) VALUES (3, N'Vitrina', 1)
GO
INSERT [dbo].[Fase] ([Fase_ID], [Fase_Nombre], [Fase_Activo]) VALUES (4, N'Vendido', 1)
GO
SET IDENTITY_INSERT [dbo].[Fase] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (1, N'Chevrolet', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (2, N'Mazda', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (3, N'Toyota', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (4, N'Ford', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (5, N'BMW', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (6, N'Mercedes-Benz', 1)
GO
INSERT [dbo].[Marca] ([Marca_ID], [Marca_Nombre], [Marca_Activo]) VALUES (8, N'Hyundai', 1)
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 
GO
INSERT [dbo].[Vehiculo] ([Vehiculo_ID], [Vehiculo_Placa], [Vehiculo_Color], [Vehiculo_Marca], [Vehiculo_Linea], [Vehiculo_Anio], [Vehiculo_KM], [Vehiculo_Valor], [Vehiculo_Observaciones], [Vehiculo_Fase]) VALUES (2, N'ABC123', 4, 1, N'Spark', 2022, 12300, 34524268.0000, N' ', 1)
GO
INSERT [dbo].[Vehiculo] ([Vehiculo_ID], [Vehiculo_Placa], [Vehiculo_Color], [Vehiculo_Marca], [Vehiculo_Linea], [Vehiculo_Anio], [Vehiculo_KM], [Vehiculo_Valor], [Vehiculo_Observaciones], [Vehiculo_Fase]) VALUES (3, N'XYZ334', 2, 3, N'Picanto', 2022, 25000, 25000000.0000, N'Cojineria nueva', 1)
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Vehiculo__Placa]    Script Date: 14/07/2025 2:35:34 p.m. ******/
ALTER TABLE [dbo].[Vehiculo] ADD  CONSTRAINT [UQ__Vehiculo__Placa] UNIQUE NONCLUSTERED 
(
	[Vehiculo_Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Color] FOREIGN KEY([Vehiculo_Color])
REFERENCES [dbo].[Color] ([Color_ID])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Color]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Fase] FOREIGN KEY([Vehiculo_Fase])
REFERENCES [dbo].[Fase] ([Fase_ID])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Fase]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Marca] FOREIGN KEY([Vehiculo_Marca])
REFERENCES [dbo].[Marca] ([Marca_ID])
GO
ALTER TABLE [dbo].[Vehiculo] CHECK CONSTRAINT [FK_Vehiculo_Marca]
GO
ALTER TABLE [dbo].[Vehiculo_Foto]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculo_Foto_Vehiculo] FOREIGN KEY([Vehiculo_Foto_Vehiculo])
REFERENCES [dbo].[Vehiculo] ([Vehiculo_ID])
GO
ALTER TABLE [dbo].[Vehiculo_Foto] CHECK CONSTRAINT [FK_Vehiculo_Foto_Vehiculo]
GO
