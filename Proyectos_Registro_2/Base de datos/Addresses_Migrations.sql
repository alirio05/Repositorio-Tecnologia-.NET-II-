IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE TABLE [Addresses_Country] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Addresses_Country] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE TABLE [States] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [CountryId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_States] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_States_Addresses_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Addresses_Country] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE TABLE [Addresses_City] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [CountryId] int NOT NULL,
        [StateId] int NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Addresses_City] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Addresses_City_Addresses_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Addresses_Country] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Addresses_City_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE TABLE [Addresses_Position] (
        [Id] int NOT NULL IDENTITY,
        [Address] nvarchar(max) NULL,
        [ZipCode] nvarchar(max) NULL,
        [CityId] int NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        [CustomerId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Addresses_Position] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Addresses_Position_Addresses_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [Addresses_City] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE INDEX [IX_Addresses_City_CountryId] ON [Addresses_City] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE INDEX [IX_Addresses_City_StateId] ON [Addresses_City] ([StateId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE INDEX [IX_Addresses_Position_CityId] ON [Addresses_Position] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    CREATE INDEX [IX_States_CountryId] ON [States] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203210743_AddressesV1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230203210743_AddressesV1', N'6.0.16');
END;
GO

COMMIT;
GO

