CREATE DATABASE bd_catalogo
GO
USE bd_catalogo
GO

CREATE TABLE [Estados] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Roles](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Rol] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Usuarios](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(50) NOT NULL,
	[Correo] NVARCHAR(250) NOT NULL,
	[Contraseña] NVARCHAR(50) NOT NULL,
	[Rol] INT NOT NULL DEFAULT 1,
	CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY ([Rol]) REFERENCES [Roles] ([Id]) ON DELETE No Action ON UPDATE No Action,
);
GO

CREATE TABLE [Categorias] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Categoria] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Fabricantes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(50) NOT NULL,
	[Contacto] NVARCHAR(100) NULL
);
GO

CREATE TABLE [Productos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Codigo] NVARCHAR(50) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
	[Cantidad] INT NOT NULL,
	[Precio] FLOAT NOT NULL,
	[Costo] FLOAT NOT NULL,
	[Fabricante] INT NOT NULL,
	[Categoria] INT NOT NULL,
	CONSTRAINT [FK_Producto_Fabricante] FOREIGN KEY ([Fabricante]) REFERENCES [Fabricantes] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY ([Categoria]) REFERENCES [Categorias] ([Id]) ON DELETE No Action ON UPDATE No Action,
);
GO

CREATE TABLE [Imagenes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Producto] INT NOT NULL,
    [Archivo] NVARCHAR(255) NOT NULL,
    [Informacion] TEXT NULL,
	CONSTRAINT [FK_Imagen_Producto] FOREIGN KEY ([Producto]) REFERENCES [Productos] ([Id]) ON DELETE No Action ON UPDATE No Action
);
GO

CREATE TABLE [Publicaciones] (
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL,
	[Estado] INT NOT NULL,
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(),
	[Titulo] NVARCHAR(255) NOT NULL,
    [Descripcion] TEXT NULL,
	CONSTRAINT [FK_Publicaciones_Producto] FOREIGN KEY ([Producto]) REFERENCES [Productos] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Publicaciones_Estado] FOREIGN KEY ([Estado]) REFERENCES [Estados] ([Id]) ON DELETE No Action ON UPDATE No Action
);
GO

-- Insertar datos en la tabla Estados
INSERT INTO Estados ([Nombre]) VALUES ('Disponible');
INSERT INTO Estados ([Nombre]) VALUES ('No Disponible');
GO

-- Insertar datos en la tabla Roles
INSERT INTO Roles ([Rol]) VALUES ('Cliente');
INSERT INTO Roles ([Rol]) VALUES ('Admin');
GO

-- Insertar datos en la tabla Roles
INSERT INTO Usuarios ([Nombre], [Correo],[Contraseña],[Rol]) VALUES ('AA', 'andresalbanes@correo.com', 'programacion2024', 2);
INSERT INTO Usuarios ([Nombre], [Correo],[Contraseña],[Rol]) VALUES ('MV', 'manuelaestrada@correo.com', 'programacion2024', 2);
INSERT INTO Usuarios ([Nombre], [Correo],[Contraseña],[Rol]) VALUES ('EC', 'emanuelcardona@correo.com', 'programacion2024', 2);
GO

-- Insertar datos en la tabla Categorias
INSERT INTO Categorias ([Categoria]) VALUES ('Electrónica');
INSERT INTO Categorias ([Categoria]) VALUES ('Hogar');
GO

-- Insertar datos en la tabla Fabricantes
INSERT INTO Fabricantes ([Nombre], [Contacto]) VALUES ('Sony', 'contacto@sony.com');
INSERT INTO Fabricantes ([Nombre], [Contacto]) VALUES ('Samsung', 'contacto@samsung.com');
GO

-- Insertar datos en la tabla Productos
INSERT INTO Productos ([Codigo], [Nombre], [Fabricante], [Categoria], [Cantidad], [Precio], [Costo])
VALUES ('P001', 'Televisor LED', 1, 1, 50, 3999960.00,3500000.00);
INSERT INTO Productos ([Codigo], [Nombre], [Fabricante], [Categoria], [Cantidad], [Precio],[Costo])
VALUES ('P002', 'Refrigerador', 2, 2, 30, 3199960.00,2980000.00);
GO

-- Insertar datos en la tabla Publicaciones
INSERT INTO Publicaciones ([Producto], [Estado], [Fecha], [Titulo], [Descripcion])
VALUES (1, 1, GETDATE(), 'Venta de Televisores', 'Oferta en televisores LED Sony');
INSERT INTO Publicaciones ([Producto], [Estado], [Fecha], [Titulo], [Descripcion])
VALUES (2, 2, GETDATE(), 'Refrigeradores en stock', 'Refrigeradores Samsung a buen precio');
GO

-- Insertar datos en la tabla Imagenes
INSERT INTO Imagenes ([Producto], [Archivo], [Informacion])
VALUES (1, 'televisor_sony.jpg', 'Imagen de un televisor LED Sony');
INSERT INTO Imagenes ([Producto], [Archivo], [Informacion])
VALUES (2, 'refrigerador_samsung.jpg', 'Imagen de un refrigerador Samsung');
GO