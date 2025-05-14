go
use GymFlashDB
go


create table [User]
(
ID UNIQUEIDENTIFIER primary key default NEWID(),
Username nvarchar (50) unique not null,
[Password] nvarchar (100) not null,
[Name]nvarchar (50) not null,
LastName nvarchar (50) not null,
Email nvarchar (100) unique not null,
Edad int,
Peso float (5),
Altura float(4),
IMC nvarchar(5),
ID_TipoMembresia int not null,
FOREIGN KEY (ID_TipoMembresia) REFERENCES TipoMembresia(ID_TipoMembresia)
)

-- Insertar tipos de membresía
INSERT INTO TipoMembresia (Descripcion) VALUES ('Gratuita');
INSERT INTO TipoMembresia (Descripcion) VALUES ('Básica');
INSERT INTO TipoMembresia (Descripcion) VALUES ('Premium');

-- Insertar usuarios de ejemplo
INSERT INTO [User] (
    Username, [Password], [Name], LastName, Email, Edad, Peso, Altura, IMC, ID_TipoMembresia
) VALUES
('admin', '1234', 'Carlos', 'Hernández', 'admin@example.com', 28, 75.5, 1.75, '25', 1),

('jdoe', 'qwerty', 'Juan', 'Doe', 'jdoe@example.com', 32, 80.0, 1.80, '24', 2),

('maria123', 'pass123', 'María', 'López', 'mlopez@example.com', 26, 65.0, 1.68, '23', 3);