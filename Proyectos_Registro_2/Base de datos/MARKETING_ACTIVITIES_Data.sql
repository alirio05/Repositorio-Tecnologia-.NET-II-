USE [MARKETING_ACTIVITIES];
GO

-- =============================================
-- DATOS DE PRUEBA - MARKETING_ACTIVITIES
-- =============================================

-- Países
IF NOT EXISTS (
    SELECT 1 FROM dbo.Addresses_Country
    WHERE Name = 'El Salvador'
)
BEGIN
    INSERT INTO dbo.Addresses_Country
        (Name, IsActive)
    VALUES
        ('El Salvador', 1);
END
GO

IF NOT EXISTS (
    SELECT 1 FROM dbo.Addresses_Country
    WHERE Name = 'Guatemala'
)
BEGIN
    INSERT INTO dbo.Addresses_Country
        (Name, IsActive)
    VALUES
        ('Guatemala', 1);
END
GO

-- Estado
IF NOT EXISTS (
    SELECT 1 FROM dbo.States
    WHERE Name = 'San Salvador'
)
BEGIN
    INSERT INTO dbo.States
        (Name, CountryId, IsActive)
    SELECT
        'San Salvador',
        Id,
        1
    FROM dbo.Addresses_Country
    WHERE Name = 'El Salvador';
END
GO

-- Ciudad
IF NOT EXISTS (
    SELECT 1 FROM dbo.Addresses_City
    WHERE Name = 'San Salvador'
)
BEGIN
    INSERT INTO dbo.Addresses_City
        (Name, CountryId, StateId, IsActive)
    SELECT
        'San Salvador',
        c.Id,
        s.Id,
        1
    FROM dbo.Addresses_Country c
    INNER JOIN dbo.States s
        ON s.CountryId = c.Id
    WHERE c.Name = 'El Salvador'
      AND s.Name = 'San Salvador';
END
GO

-- Tipo de cliente
IF NOT EXISTS (
    SELECT 1 FROM dbo.Business_CustomerType
    WHERE Name = 'Cliente Regular'
)
BEGIN
    INSERT INTO dbo.Business_CustomerType
        (Name, IsActive)
    VALUES
        ('Cliente Regular', 1);
END
GO

-- Empresa
IF NOT EXISTS (
    SELECT 1 FROM dbo.Business_Company
    WHERE Name = 'Empresa Demo'
)
BEGIN
    INSERT INTO dbo.Business_Company
        (Name, Sigla, MainEmail, IsActive)
    VALUES
        ('Empresa Demo', 'ED', 'demo@empresa.com', 1);
END
GO

-- Clientes
IF NOT EXISTS (
    SELECT 1 FROM dbo.Business_Customer
    WHERE Code = 'CLI001'
)
BEGIN
    INSERT INTO dbo.Business_Customer
        (Code, Name, Email, CustomerTypeId, CompanyId, IsActive)
    SELECT
        'CLI001',
        'Cliente Uno',
        'cliente1@empresa.com',
        ct.Id,
        co.Id,
        1
    FROM dbo.Business_CustomerType ct
    CROSS JOIN dbo.Business_Company co
    WHERE ct.Name = 'Cliente Regular'
      AND co.Name = 'Empresa Demo';
END
GO

IF NOT EXISTS (
    SELECT 1 FROM dbo.Business_Customer
    WHERE Code = 'CLI002'
)
BEGIN
    INSERT INTO dbo.Business_Customer
        (Code, Name, Email, CustomerTypeId, CompanyId, IsActive)
    SELECT
        'CLI002',
        'Cliente Dos',
        'cliente2@empresa.com',
        ct.Id,
        co.Id,
        1
    FROM dbo.Business_CustomerType ct
    CROSS JOIN dbo.Business_Company co
    WHERE ct.Name = 'Cliente Regular'
      AND co.Name = 'Empresa Demo';
END
GO

-- Direcciones de los clientes
IF NOT EXISTS (
    SELECT 1 FROM dbo.Addresses_Position
    WHERE CustomerId = 1
)
BEGIN
    INSERT INTO dbo.Addresses_Position
        (Address, ZipCode, CityId, Latitude, Longitude, CustomerId, IsActive)
    SELECT
        'Calle Principal #1',
        '1101',
        Id,
        13.692899703979492,
        -89.21820068359375,
        1,
        1
    FROM dbo.Addresses_City
    WHERE Name = 'San Salvador';
END
GO

IF NOT EXISTS (
    SELECT 1 FROM dbo.Addresses_Position
    WHERE CustomerId = 2
)
BEGIN
    INSERT INTO dbo.Addresses_Position
        (Address, ZipCode, CityId, Latitude, Longitude, CustomerId, IsActive)
    SELECT
        'Avenida Central #2',
        '1102',
        Id,
        13.699999809265137,
        -89.209999084472656,
        2,
        1
    FROM dbo.Addresses_City
    WHERE Name = 'San Salvador';
END
GO