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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE TABLE [Business_Company] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Sigla] nvarchar(max) NULL,
        [MainEmail] nvarchar(max) NULL,
        CONSTRAINT [PK_Business_Company] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE TABLE [Business_CustomerType] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Business_CustomerType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE TABLE [Business_Customer] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [CustomerTypeId] int NULL,
        [CompanyId] int NULL,
        CONSTRAINT [PK_Business_Customer] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_Customer_Business_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Business_Company] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Business_Customer_Business_CustomerType_CustomerTypeId] FOREIGN KEY ([CustomerTypeId]) REFERENCES [Business_CustomerType] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE TABLE [Business_CustomerContact] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Phone1] nvarchar(max) NULL,
        [Phone2] nvarchar(max) NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_Business_CustomerContact] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_CustomerContact_Business_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Business_Customer] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE INDEX [IX_Business_Customer_CompanyId] ON [Business_Customer] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE INDEX [IX_Business_Customer_CustomerTypeId] ON [Business_Customer] ([CustomerTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    CREATE INDEX [IX_Business_CustomerContact_CustomerId] ON [Business_CustomerContact] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608192759_BusinessTablesV1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220608192759_BusinessTablesV1', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608223026_AddBrand')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220608223026_AddBrand', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608223254_AddBrandV1')
BEGIN
    CREATE TABLE [Business_Brand] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Business_Brand] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608223254_AddBrandV1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220608223254_AddBrandV1', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220727200039_ProductsFix')
BEGIN
    CREATE TABLE [Business_Product] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [BrandId] int NULL,
        CONSTRAINT [PK_Business_Product] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_Product_Business_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Business_Brand] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220727200039_ProductsFix')
BEGIN
    CREATE INDEX [IX_Business_Product_BrandId] ON [Business_Product] ([BrandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220727200039_ProductsFix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220727200039_ProductsFix', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230121165423_NuevaMigracionF')
BEGIN
    ALTER TABLE [Business_CustomerContact] DROP CONSTRAINT [FK_Business_CustomerContact_Business_Customer_CustomerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230121165423_NuevaMigracionF')
BEGIN
    DROP INDEX [IX_Business_CustomerContact_CustomerId] ON [Business_CustomerContact];
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Business_CustomerContact]') AND [c].[name] = N'CustomerId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Business_CustomerContact] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Business_CustomerContact] ALTER COLUMN [CustomerId] int NOT NULL;
    ALTER TABLE [Business_CustomerContact] ADD DEFAULT 0 FOR [CustomerId];
    CREATE INDEX [IX_Business_CustomerContact_CustomerId] ON [Business_CustomerContact] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230121165423_NuevaMigracionF')
BEGIN
    ALTER TABLE [Business_CustomerContact] ADD CONSTRAINT [FK_Business_CustomerContact_Business_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Business_Customer] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230121165423_NuevaMigracionF')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230121165423_NuevaMigracionF', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126143143_CustomersTypeV2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126143143_CustomersTypeV2', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126143842_CustomersTypeV3')
BEGIN
    ALTER TABLE [Business_CustomerType] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126143842_CustomersTypeV3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126143842_CustomersTypeV3', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126150657_CustomerContacstV2')
BEGIN
    ALTER TABLE [Business_CustomerContact] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126150657_CustomerContacstV2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126150657_CustomerContacstV2', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126160722_CompanytV2')
BEGIN
    ALTER TABLE [Business_Company] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230126160722_CompanytV2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230126160722_CompanytV2', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127202259_CustomersV2')
BEGIN
    ALTER TABLE [Business_Customer] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230127202259_CustomersV2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230127202259_CustomersV2', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_CustomerType] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_CustomerType] ADD [InternalId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_CustomerType] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_Company] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_Company] ADD [InternalId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    ALTER TABLE [Business_Company] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130160146_CompanyTableV3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230130160146_CompanyTableV3', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130170108_CustomerContactTableV3')
BEGIN
    ALTER TABLE [Business_CustomerContact] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130170108_CustomerContactTableV3')
BEGIN
    ALTER TABLE [Business_CustomerContact] ADD [InternalId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130170108_CustomerContactTableV3')
BEGIN
    ALTER TABLE [Business_CustomerContact] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130170108_CustomerContactTableV3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230130170108_CustomerContactTableV3', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130172413_CustomerTableV4')
BEGIN
    ALTER TABLE [Business_Customer] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130172413_CustomerTableV4')
BEGIN
    ALTER TABLE [Business_Customer] ADD [InternalId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130172413_CustomerTableV4')
BEGIN
    ALTER TABLE [Business_Customer] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230130172413_CustomerTableV4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230130172413_CustomerTableV4', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE TABLE [Business_Company] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Sigla] nvarchar(max) NULL,
        [MainEmail] nvarchar(max) NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_Company] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE TABLE [Business_CustomerType] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_CustomerType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE TABLE [Business_Customer] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [CustomerTypeId] int NOT NULL,
        [CompanyId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_Customer] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_Customer_Business_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Business_Company] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Business_Customer_Business_CustomerType_CustomerTypeId] FOREIGN KEY ([CustomerTypeId]) REFERENCES [Business_CustomerType] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE TABLE [Business_CustomerContact] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Phone1] nvarchar(max) NULL,
        [Phone2] nvarchar(max) NULL,
        [CustomerId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_CustomerContact] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_CustomerContact_Business_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Business_Customer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE INDEX [IX_Business_Customer_CompanyId] ON [Business_Customer] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE INDEX [IX_Business_Customer_CustomerTypeId] ON [Business_Customer] ([CustomerTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    CREATE INDEX [IX_Business_CustomerContact_CustomerId] ON [Business_CustomerContact] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203151045_Businesss')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230203151045_Businesss', N'6.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE TABLE [Business_Company] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Sigla] nvarchar(max) NULL,
        [MainEmail] nvarchar(max) NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_Company] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE TABLE [Business_CustomerType] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_CustomerType] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE TABLE [Business_Customer] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [CustomerTypeId] int NOT NULL,
        [CompanyId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_Customer] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_Customer_Business_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Business_Company] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Business_Customer_Business_CustomerType_CustomerTypeId] FOREIGN KEY ([CustomerTypeId]) REFERENCES [Business_CustomerType] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE TABLE [Business_CustomerContact] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Phone1] nvarchar(max) NULL,
        [Phone2] nvarchar(max) NULL,
        [CustomerId] int NOT NULL,
        [InternalId] uniqueidentifier NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Business_CustomerContact] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Business_CustomerContact_Business_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Business_Customer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE INDEX [IX_Business_Customer_CompanyId] ON [Business_Customer] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE INDEX [IX_Business_Customer_CustomerTypeId] ON [Business_Customer] ([CustomerTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    CREATE INDEX [IX_Business_CustomerContact_CustomerId] ON [Business_CustomerContact] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207031628_Bussines_v1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207031628_Bussines_v1', N'6.0.16');
END;
GO

COMMIT;
GO

