IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718094200_addTotal')
BEGIN
    ALTER TABLE [OrderDetails] ADD [total] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718094200_addTotal')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:41:59.8934049+07:00'
    WHERE [ProductId] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718094200_addTotal')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:41:59.8951978+07:00'
    WHERE [ProductId] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718094200_addTotal')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:41:59.8952015+07:00'
    WHERE [ProductId] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718094200_addTotal')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200718094200_addTotal', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718095032_addFull')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderDetails]') AND [c].[name] = N'total');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [OrderDetails] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [OrderDetails] DROP COLUMN [total];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718095032_addFull')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:50:31.6352324+07:00'
    WHERE [ProductId] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718095032_addFull')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:50:31.6371489+07:00'
    WHERE [ProductId] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718095032_addFull')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T16:50:31.6371573+07:00'
    WHERE [ProductId] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718095032_addFull')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200718095032_addFull', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718132821_add')
BEGIN
    ALTER TABLE [OrderDetails] ADD [Price] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718132821_add')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T20:28:21.0371676+07:00'
    WHERE [ProductId] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718132821_add')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T20:28:21.0388317+07:00'
    WHERE [ProductId] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718132821_add')
BEGIN
    UPDATE [Products] SET [CreateDate] = '2020-07-18T20:28:21.0388350+07:00'
    WHERE [ProductId] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200718132821_add')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200718132821_add', N'3.1.5');
END;

GO

