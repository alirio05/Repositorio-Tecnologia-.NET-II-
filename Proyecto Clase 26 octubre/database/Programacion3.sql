-- ============================================
-- 1. CREACIÓN DE LA BASE DE DATOS
-- ============================================
CREATE DATABASE Programacion3;
GO

USE Programacion3;
GO

-- ============================================
-- 2. TABLA ESTUDIANTES
-- ============================================
CREATE TABLE Estudiantes (
    IdEstudiante INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Carnet VARCHAR(20) NOT NULL,
    Edad INT NOT NULL,
    Correo VARCHAR(150),
    FechaIngreso DATE NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- INSERCIÓN DE 10 ESTUDIANTES
INSERT INTO Estudiantes
    (Nombres, Apellidos, Carnet, Edad, Correo, FechaIngreso, Estado)
VALUES
    ('Carlos', 'Martinez', 'EST001', 20, 'carlos@gmail.com', '2024-01-15', 1),
    ('Maria', 'Lopez', 'EST002', 22, 'maria@gmail.com', '2023-02-10', 1),
    ('Jose', 'Hernandez', 'EST003', 21, 'jose@gmail.com', '2024-01-20', 1),
    ('Ana', 'Rodriguez', 'EST004', 19, 'ana@gmail.com', '2025-01-12', 1),
    ('Luis', 'Garcia', 'EST005', 23, 'luis@gmail.com', '2022-02-05', 1),
    ('Sofia', 'Ramirez', 'EST006', 20, 'sofia@gmail.com', '2024-07-10', 1),
    ('Diego', 'Torres', 'EST007', 24, 'diego@gmail.com', '2021-01-18', 0),
    ('Valeria', 'Flores', 'EST008', 21, 'valeria@gmail.com', '2023-07-15', 1),
    ('Fernando', 'Castro', 'EST009', 22, 'fernando@gmail.com', '2023-01-25', 1),
    ('Gabriela', 'Mendoza', 'EST010', 19, 'gabriela@gmail.com', '2025-01-10', 1);
GO

-- ============================================
-- 3. TABLA DOCENTES
-- ============================================
CREATE TABLE Docentes (
    IdDocente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Correo VARCHAR(150),
    Telefono VARCHAR(20),
    FechaContratacion DATE NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- INSERCIÓN DE 10 DOCENTES
INSERT INTO Docentes
    (Nombres, Apellidos, Especialidad, Correo, Telefono, FechaContratacion, Estado)
VALUES
    ('Roberto', 'Perez', 'Programacion', 'roberto@universidad.edu', '7000-1001', '2020-01-15', 1),
    ('Patricia', 'Gomez', 'Base de Datos', 'patricia@universidad.edu', '7000-1002', '2019-02-10', 1),
    ('Miguel', 'Sanchez', 'Redes', 'miguel@universidad.edu', '7000-1003', '2021-01-20', 1),
    ('Claudia', 'Morales', 'Matematicas', 'claudia@universidad.edu', '7000-1004', '2018-03-12', 1),
    ('Jorge', 'Vasquez', 'Ingenieria de Software', 'jorge@universidad.edu', '7000-1005', '2022-02-05', 1),
    ('Daniela', 'Rivas', 'Seguridad Informatica', 'daniela@universidad.edu', '7000-1006', '2020-07-10', 1),
    ('Ricardo', 'Aguilar', 'Sistemas Operativos', 'ricardo@universidad.edu', '7000-1007', '2017-01-18', 0),
    ('Andrea', 'Campos', 'Desarrollo Web', 'andrea@universidad.edu', '7000-1008', '2023-07-15', 1),
    ('Oscar', 'Reyes', 'Inteligencia Artificial', 'oscar@universidad.edu', '7000-1009', '2022-01-25', 1),
    ('Elena', 'Herrera', 'Arquitectura de Software', 'elena@universidad.edu', '7000-1010', '2024-01-10', 1);
GO

-- ============================================
-- 4. TABLA MATERIAS
-- ============================================
CREATE TABLE Materias (
    IdMateria INT IDENTITY(1,1) PRIMARY KEY,
    CodigoMateria VARCHAR(20) NOT NULL,
    NombreMateria VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(250),
    UnidadesValorativas INT NOT NULL,
    Ciclo INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- INSERCIÓN DE 10 MATERIAS
INSERT INTO Materias
    (CodigoMateria, NombreMateria, Descripcion, UnidadesValorativas, Ciclo, Estado)
VALUES
    ('MAT001', 'Programacion I', 'Fundamentos de programacion', 4, 1, 1),
    ('MAT002', 'Programacion II', 'Programacion orientada a objetos', 4, 2, 1),
    ('MAT003', 'Programacion III', 'Desarrollo de aplicaciones web', 4, 3, 1),
    ('MAT004', 'Base de Datos I', 'Fundamentos de bases de datos', 4, 2, 1),
    ('MAT005', 'Base de Datos II', 'Administracion de bases de datos', 4, 3, 1),
    ('MAT006', 'Redes I', 'Fundamentos de redes de computadoras', 4, 4, 1),
    ('MAT007', 'Ingenieria de Software', 'Analisis y diseno de sistemas', 4, 5, 1),
    ('MAT008', 'Desarrollo Web', 'Tecnologias para aplicaciones web', 4, 5, 1),
    ('MAT009', 'Seguridad Informatica', 'Proteccion de sistemas informaticos', 4, 7, 1),
    ('MAT010', 'Inteligencia Artificial', 'Introduccion a sistemas inteligentes', 4, 8, 1);
GO

-- ============================================
-- 5. CONSULTAS DE VERIFICACIÓN
-- ============================================
SELECT * FROM Estudiantes;
SELECT * FROM Docentes;
SELECT * FROM Materias;

-- ============================================
-- 6. CONTEO DE REGISTROS
-- ============================================
SELECT 'Estudiantes' AS Tabla, COUNT(*) AS Total
FROM Estudiantes
UNION ALL
SELECT 'Docentes', COUNT(*)
FROM Docentes
UNION ALL
SELECT 'Materias', COUNT(*)
FROM Materias;
GO
