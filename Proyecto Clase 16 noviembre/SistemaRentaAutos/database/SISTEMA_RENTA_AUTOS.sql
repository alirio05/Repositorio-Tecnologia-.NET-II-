-- BASE DE DATOS: SISTEMA_RENTA_AUTOS

CREATE DATABASE SISTEMA_RENTA_AUTOS;
GO

USE SISTEMA_RENTA_AUTOS;
GO

-- TABLA 1: CLIENTES
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    DUI VARCHAR(15),
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Direccion VARCHAR(200),
    FechaRegistro DATE
);
GO

INSERT INTO Clientes VALUES
(1, 'Carlos', 'Martinez', '01234567-8', '7890-1234', 'carlos@gmail.com', 'San Salvador', '2026-01-10'),
(2, 'Maria', 'Lopez', '02345678-9', '7890-2345', 'maria@gmail.com', 'Santa Tecla', '2026-01-12'),
(3, 'Jose', 'Hernandez', '03456789-0', '7890-3456', 'jose@gmail.com', 'Soyapango', '2026-01-15'),
(4, 'Ana', 'Garcia', '04567890-1', '7890-4567', 'ana@gmail.com', 'Antiguo Cuscatlan', '2026-02-01'),
(5, 'Pedro', 'Ramirez', '05678901-2', '7890-5678', 'pedro@gmail.com', 'San Miguel', '2026-02-05'),
(6, 'Sofia', 'Castro', '06789012-3', '7890-6789', 'sofia@gmail.com', 'Santa Ana', '2026-02-10'),
(7, 'Miguel', 'Flores', '07890123-4', '7890-7890', 'miguel@gmail.com', 'La Libertad', '2026-02-15'),
(8, 'Laura', 'Mendez', '08901234-5', '7890-8901', 'laura@gmail.com', 'Apopa', '2026-03-01'),
(9, 'Roberto', 'Diaz', '09012345-6', '7890-9012', 'roberto@gmail.com', 'Zacatecoluca', '2026-03-05'),
(10, 'Daniela', 'Rivera', '10123456-7', '7890-0123', 'daniela@gmail.com', 'Usulutan', '2026-03-10');
GO

-- TABLA 2: AUTOS
CREATE TABLE Autos (
    AutoID INT PRIMARY KEY,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    Anio INT,
    Placa VARCHAR(15),
    Color VARCHAR(30),
    TipoCombustible VARCHAR(30),
    PrecioPorDia DECIMAL(10,2),
    Estado VARCHAR(30)
);
GO

INSERT INTO Autos VALUES
(1, 'Toyota', 'Corolla', 2023, 'P123456', 'Blanco', 'Gasolina', 35.00, 'Disponible'),
(2, 'Honda', 'Civic', 2022, 'P234567', 'Negro', 'Gasolina', 40.00, 'Disponible'),
(3, 'Hyundai', 'Tucson', 2024, 'P345678', 'Gris', 'Gasolina', 55.00, 'Rentado'),
(4, 'Kia', 'Sportage', 2023, 'P456789', 'Rojo', 'Diesel', 50.00, 'Disponible'),
(5, 'Nissan', 'Sentra', 2021, 'P567890', 'Azul', 'Gasolina', 30.00, 'Mantenimiento'),
(6, 'Mazda', 'CX5', 2024, 'P678901', 'Blanco', 'Gasolina', 60.00, 'Disponible'),
(7, 'Ford', 'Escape', 2022, 'P789012', 'Plata', 'Hibrido', 65.00, 'Rentado'),
(8, 'Chevrolet', 'Spark', 2020, 'P890123', 'Amarillo', 'Gasolina', 25.00, 'Disponible'),
(9, 'Mitsubishi', 'Outlander', 2023, 'P901234', 'Negro', 'Gasolina', 58.00, 'Disponible'),
(10, 'Volkswagen', 'Jetta', 2022, 'P012345', 'Gris', 'Gasolina', 42.00, 'Mantenimiento');
GO

-- TABLA 3: EMPLEADOS
CREATE TABLE Empleados (
    EmpleadoID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Cargo VARCHAR(50),
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    FechaContratacion DATE,
    Salario DECIMAL(10,2)
);
GO

INSERT INTO Empleados VALUES
(1, 'Juan', 'Perez', 'Administrador', '7000-1111', 'juan@renta.com', '2022-01-10', 1200.00),
(2, 'Lucia', 'Gomez', 'Vendedor', '7000-2222', 'lucia@renta.com', '2022-03-15', 750.00),
(3, 'Andres', 'Torres', 'Vendedor', '7000-3333', 'andres@renta.com', '2022-05-20', 750.00),
(4, 'Patricia', 'Molina', 'Contador', '7000-4444', 'patricia@renta.com', '2023-01-05', 950.00),
(5, 'Fernando', 'Ruiz', 'Supervisor', '7000-5555', 'fernando@renta.com', '2023-02-10', 1100.00),
(6, 'Gabriela', 'Cruz', 'Vendedor', '7000-6666', 'gabriela@renta.com', '2023-04-12', 750.00),
(7, 'Ricardo', 'Vasquez', 'Mecanico', '7000-7777', 'ricardo@renta.com', '2023-06-18', 850.00),
(8, 'Monica', 'Reyes', 'Recepcionista', '7000-8888', 'monica@renta.com', '2024-01-08', 650.00),
(9, 'Oscar', 'Aguilar', 'Vendedor', '7000-9999', 'oscar@renta.com', '2024-03-11', 750.00),
(10, 'Elena', 'Morales', 'Administrador', '7000-0000', 'elena@renta.com', '2024-05-15', 1200.00);
GO

-- TABLA 4: RENTAS
CREATE TABLE Rentas (
    RentaID INT PRIMARY KEY,
    ClienteID INT,
    AutoID INT,
    EmpleadoID INT,
    FechaInicio DATE,
    FechaFin DATE,
    CantidadDias INT,
    TotalRenta DECIMAL(10,2),
    Estado VARCHAR(30)
);
GO

INSERT INTO Rentas VALUES
(1, 1, 1, 2, '2026-04-01', '2026-04-05', 4, 140.00, 'Finalizada'),
(2, 2, 3, 3, '2026-04-02', '2026-04-07', 5, 275.00, 'Finalizada'),
(3, 3, 2, 6, '2026-04-05', '2026-04-08', 3, 120.00, 'Finalizada'),
(4, 4, 4, 2, '2026-04-10', '2026-04-15', 5, 250.00, 'Finalizada'),
(5, 5, 6, 9, '2026-04-12', '2026-04-16', 4, 240.00, 'Finalizada'),
(6, 6, 7, 3, '2026-04-18', '2026-04-23', 5, 325.00, 'Activa'),
(7, 7, 8, 6, '2026-04-20', '2026-04-22', 2, 50.00, 'Activa'),
(8, 8, 9, 9, '2026-04-22', '2026-04-27', 5, 290.00, 'Activa'),
(9, 9, 10, 2, '2026-04-25', '2026-04-29', 4, 168.00, 'Cancelada'),
(10, 10, 5, 3, '2026-04-28', '2026-05-02', 4, 120.00, 'Pendiente');
GO

-- TABLA 5: PAGOS
CREATE TABLE Pagos (
    PagoID INT PRIMARY KEY,
    ClienteID INT,
    RentaID INT,
    FechaPago DATE,
    MetodoPago VARCHAR(50),
    Monto DECIMAL(10,2),
    EstadoPago VARCHAR(30),
    Referencia VARCHAR(50)
);
GO

INSERT INTO Pagos VALUES
(1, 1, 1, '2026-04-01', 'Tarjeta', 140.00, 'Pagado', 'REF001'),
(2, 2, 2, '2026-04-02', 'Efectivo', 275.00, 'Pagado', 'REF002'),
(3, 3, 3, '2026-04-05', 'Transferencia', 120.00, 'Pagado', 'REF003'),
(4, 4, 4, '2026-04-10', 'Tarjeta', 250.00, 'Pagado', 'REF004'),
(5, 5, 5, '2026-04-12', 'Efectivo', 240.00, 'Pagado', 'REF005'),
(6, 6, 6, '2026-04-18', 'Tarjeta', 200.00, 'Parcial', 'REF006'),
(7, 7, 7, '2026-04-20', 'Transferencia', 50.00, 'Pagado', 'REF007'),
(8, 8, 8, '2026-04-22', 'Tarjeta', 290.00, 'Pagado', 'REF008'),
(9, 9, 9, '2026-04-25', 'Efectivo', 0.00, 'Anulado', 'REF009'),
(10, 10, 10, '2026-04-28', 'Transferencia', 60.00, 'Parcial', 'REF010');
GO
