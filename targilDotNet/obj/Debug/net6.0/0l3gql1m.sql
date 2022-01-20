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

CREATE TABLE [Keys] (
    [KeyName] nvarchar(1) NOT NULL,
    [startTimeastamp] datetime2 NOT NULL,
    [Count] int NOT NULL,
    CONSTRAINT [PK_Keys] PRIMARY KEY ([KeyName], [startTimeastamp])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220119082723_InitialCreate', N'6.0.1');
GO

COMMIT;
GO

