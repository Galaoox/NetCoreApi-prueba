CREATE DATABASE ProductosDB;
USE [ProductosDB]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 13/03/2022 09:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[disabled] [smallint] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 13/03/2022 09:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[valor_unitario] [decimal](16, 2) NOT NULL,
	[disabled] [smallint] NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 13/03/2022 09:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[valor_unitario] [decimal](16, 2) NOT NULL,
	[valor_total] [decimal](16, 2) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[disabled] [smallint] NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente] ADD  CONSTRAINT [DF_cliente_disabled]  DEFAULT ((0)) FOR [disabled]
GO
ALTER TABLE [dbo].[producto] ADD  CONSTRAINT [DF_producto_disabled]  DEFAULT ((0)) FOR [disabled]
GO
ALTER TABLE [dbo].[venta] ADD  CONSTRAINT [DF_venta_disabled]  DEFAULT ((0)) FOR [disabled]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_producto]
GO
