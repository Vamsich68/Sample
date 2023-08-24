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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821085353_AddCompaniesToDb')
BEGIN
    CREATE TABLE [Employees] (
        [EmployeeId] nvarchar(450) NOT NULL,
        [EmployeeName] nvarchar(max) NOT NULL,
        [EmployeeAge] int NOT NULL,
        [EmployeeDesignation] nvarchar(max) NOT NULL,
        [EmployeeDepartment] nvarchar(max) NOT NULL,
        [EmployeeAddress] nvarchar(max) NOT NULL,
        [EmployeeDescription] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230821085353_AddCompaniesToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230821085353_AddCompaniesToDb', N'7.0.10');
END;
GO

COMMIT;
GO

