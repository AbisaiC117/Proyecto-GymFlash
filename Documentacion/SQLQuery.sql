CREATE DATABASE GymFlashDB
GO
USE GymFlashDB;
GO

CREATE TABLE TipoMembresia (
    ID_TipoMembresia INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100)
);

CREATE TABLE TipoUsuario (
    ID_TipoUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100)
);

CREATE TABLE [User] (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Edad INT,
    Peso FLOAT,
    Altura FLOAT,
    IMC NVARCHAR(5),
    ID_TipoMembresia INT NOT NULL,
    ID_TipoUsuario INT NOT NULL DEFAULT 2,
    FOREIGN KEY (ID_TipoMembresia) REFERENCES TipoMembresia(ID_TipoMembresia),
    FOREIGN KEY (ID_TipoUsuario) REFERENCES TipoUsuario(ID_TipoUsuario)
);

CREATE TABLE Entrenador (
    ID_Entrenador UNIQUEIDENTIFIER PRIMARY KEY, -- Corresponde al ID del usuario
    Especialidad NVARCHAR(100),
    AñosExperiencia INT,
    FOREIGN KEY (ID_Entrenador) REFERENCES [User](ID)
);

CREATE TABLE Rutina (
    ID_Rutina UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500),
    ImagenURL NVARCHAR(300),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    ID_Entrenador UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (ID_Entrenador) REFERENCES Entrenador(ID_Entrenador)
);

CREATE TABLE UsuarioRutina (
    ID_Usuario UNIQUEIDENTIFIER,
    ID_Rutina UNIQUEIDENTIFIER,
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (ID_Usuario, ID_Rutina),
    FOREIGN KEY (ID_Usuario) REFERENCES [User](ID),
    FOREIGN KEY (ID_Rutina) REFERENCES Rutina(ID_Rutina)
);

CREATE TABLE Ejercicio (
    ID_Ejercicio UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Rutina UNIQUEIDENTIFIER,
    Nombre NVARCHAR(100),
    Repeticiones NVARCHAR(50),
    Duracion NVARCHAR(50),
    ImagenURL NVARCHAR(300),
    FOREIGN KEY (ID_Rutina) REFERENCES Rutina(ID_Rutina)
);

CREATE TABLE Articulos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Precio DECIMAL(10, 2),
    Cantidad INT,
    Imagen NVARCHAR(255)
);

CREATE TABLE Compra (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario UNIQUEIDENTIFIER NOT NULL,
    IdArticulo INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Compra_Usuario FOREIGN KEY (IdUsuario)
        REFERENCES [User](ID) ON DELETE CASCADE,
    CONSTRAINT FK_Compra_Articulo FOREIGN KEY (IdArticulo)
        REFERENCES Articulos(Id) ON DELETE CASCADE
);

-- Insertar datos en tablas de referencia
INSERT INTO TipoMembresia (Nombre) VALUES ('Básica'), ('Premium'), ('Pro');
INSERT INTO TipoUsuario (Nombre) VALUES ('Administrador'), ('Usuario');

-- Insertar usuarios
INSERT INTO [User] (
    Username, [Password], [Name], LastName, Email, Edad, Peso, Altura, IMC, ID_TipoMembresia, ID_TipoUsuario
) VALUES
('admin', '1234567', 'Carlos', 'Hernández', 'admin@example.com', 28, 75.5, 1.75, '25', 1, 1), -- Administrador
('jdoe', 'qwerty', 'Juan', 'Doe', 'jdoe@example.com', 32, 80.0, 1.80, '24', 2, 2),
('maria123', 'pass123', 'María', 'López', 'mlopez@example.com', 26, 65.0, 1.68, '23', 3, 2);

-- Asignar usuario como entrenador
DECLARE @AdminID UNIQUEIDENTIFIER;
SELECT @AdminID = ID FROM [User] WHERE Username = 'admin';

INSERT INTO Entrenador (ID_Entrenador, Especialidad, AñosExperiencia)
VALUES (@AdminID, 'Entrenamiento funcional', 5);

-- Obtener ID del entrenador para rutinas
DECLARE @EntrenadorID UNIQUEIDENTIFIER;
SELECT @EntrenadorID = ID_Entrenador FROM Entrenador;

-- Insertar rutinas
INSERT INTO Rutina (Nombre, Descripcion, ImagenURL, ID_Entrenador) VALUES 
('Rutina Tronco', 'Plancha (30-60 seg), Crunch abdominal, Elevación de piernas, Superman, Plancha lateral',
'https://imgs.search.brave.com/Qo3dlXVxbopXIgw1ouKYb3_9hWc_c6jmPz-MpUEHWh4/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tdW5k/b2VudHJlbmFtaWVu/dG8uY29tL3dwLWNv/bnRlbnQvdXBsb2Fk/cy8yMDI0LzA4L2hv/bWJyZS1oYWNpZW5k/by1jdXJsLWJpY2Vw/cy1iYW5jby1pbmNs/aW5hZG8uYXZpZg', 
@EntrenadorID),

('Rutina Pierna', 'Sentadillas, Zancadas (Lunges), Elevación de talones (para gemelos), Peso muerto con piernas rectas, Puente de glúteos',
'https://imgs.search.brave.com/cI7yz7HS169Onj3D94CCOWOX9lvYHdv7S3g15zkOsF4/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly93d3cu/ZGlyLmNhdC9ibG9n/L3dwLWNvbnRlbnQv/dXBsb2Fkcy8yMDE5/LzAxL2VqZXJjaWNp/b3MtdG9uaWZpY2Fy/LXBpZXJuYXMtZ2lt/bmFzaW8uanBn', 
@EntrenadorID),

('Rutina Pecho', 'Flexiones de pecho (Push-ups), Remo con bandas o mancuernas, Press militar con mancuernas, Curl de bíceps, Fondos de tríceps en banco',
'https://imgs.search.brave.com/C7_x86pO2fPWzIV-TOnUzXE-JcE0Vu3hMsBT2NrBZnc/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/Y2FtYmlhdHVmaXNp/Y28uY29tL3dwLWNv/bnRlbnQvdXBsb2Fk/cy9lamVyY2ljaW9z/LXBlY2hvMS02OTZ4/MzkyLmpwZw', 
@EntrenadorID),

('Rutina Full Body', 'Burpees, Sentadillas con salto, Flexiones, Mountain climbers, Peso muerto + remo con mancuernas',
'https://imgs.search.brave.com/_n9ML2BnVYhC8_towr-prBaoFVhNKVD2SH9t2D_6TEs/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/aG9sYS5jb20vaG9y/aXpvbi9zcXVhcmUv/ZTQ4ZTNlNzEzZDgx/LTEuanBn',
@EntrenadorID);

-- Insertar artículos en la tienda
INSERT INTO Articulos (Nombre, Precio, Cantidad, Imagen) VALUES
('Proteína Whey', 699.00, 10, 'https://gnc.com.mx/media/catalog/product/1/0/107206001-a.jpg'),
('Creatina Monohidratada', 299.00, 15, 'https://cloudinary.images-iherb.com/image/upload/f_auto,q_auto:eco/images/nrx/nrx00074/y/39.jpg'),
('Guantes Deportivos', 149.00, 20, 'https://m.media-amazon.com/images/I/61alfP2RogL._AC_UF894,1000_QL80_.jpg'),
('Cinturón para Levantamiento', 399.00, 5, 'https://i5.walmartimages.com/asr/bcad4744-b22d-47bc-ad45-5aece3e07585.e9ebc9e231c977172acbf1fe2c4ce3b8.jpeg');
