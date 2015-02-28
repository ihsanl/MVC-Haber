
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2014 19:27:59
-- Generated from EDMX file: C:\Users\Lenova\Desktop\MvcEmlak\MvcEmlak\Models\ModelEmlak.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelEmlak];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ÜyeEmlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar] DROP CONSTRAINT [FK_ÜyeEmlak];
GO
IF OBJECT_ID(N'[dbo].[FK_ŞehirEmlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar] DROP CONSTRAINT [FK_ŞehirEmlak];
GO
IF OBJECT_ID(N'[dbo].[FK_TipEmlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar] DROP CONSTRAINT [FK_TipEmlak];
GO
IF OBJECT_ID(N'[dbo].[FK_Konut_inherits_Emlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar_Konut] DROP CONSTRAINT [FK_Konut_inherits_Emlak];
GO
IF OBJECT_ID(N'[dbo].[FK_Arsa_inherits_Emlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar_Arsa] DROP CONSTRAINT [FK_Arsa_inherits_Emlak];
GO
IF OBJECT_ID(N'[dbo].[FK_Dükkan_inherits_Emlak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emlaklar_Dükkan] DROP CONSTRAINT [FK_Dükkan_inherits_Emlak];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Üyeler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Üyeler];
GO
IF OBJECT_ID(N'[dbo].[Emlaklar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emlaklar];
GO
IF OBJECT_ID(N'[dbo].[Şehirler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Şehirler];
GO
IF OBJECT_ID(N'[dbo].[Tipler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipler];
GO
IF OBJECT_ID(N'[dbo].[Emlaklar_Konut]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emlaklar_Konut];
GO
IF OBJECT_ID(N'[dbo].[Emlaklar_Arsa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emlaklar_Arsa];
GO
IF OBJECT_ID(N'[dbo].[Emlaklar_Dükkan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emlaklar_Dükkan];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Üyeler'
CREATE TABLE [dbo].[Üyeler] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [İsim] nvarchar(50)  NOT NULL,
    [EPosta] nvarchar(255)  NOT NULL,
    [Şifre] nchar(32)  NOT NULL,
    [EPostaDoğrulama] bit  NOT NULL,
    [ÜyelikTarihi] datetime  NOT NULL
);
GO

-- Creating table 'Emlaklar'
CREATE TABLE [dbo].[Emlaklar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ÜyeId] int  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [Fiyat] decimal(18,4)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL,
    [ŞehirId] int  NOT NULL,
    [Durum] bit  NOT NULL,
    [TipId] int  NOT NULL,
    [Başlık] nvarchar(max)  NOT NULL,
    [Görsel] varbinary(max)  NULL
);
GO

-- Creating table 'Şehirler'
CREATE TABLE [dbo].[Şehirler] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [İsim] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Tipler'
CREATE TABLE [dbo].[Tipler] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Emlaklar_Konut'
CREATE TABLE [dbo].[Emlaklar_Konut] (
    [Metrekare] int  NOT NULL,
    [OdaBilgisi] nvarchar(50)  NOT NULL,
    [KatBilgisi] nvarchar(50)  NOT NULL,
    [IsıtmaSistemi] nvarchar(50)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Emlaklar_Arsa'
CREATE TABLE [dbo].[Emlaklar_Arsa] (
    [Metrekare] int  NOT NULL,
    [İmarlı] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Emlaklar_Dükkan'
CREATE TABLE [dbo].[Emlaklar_Dükkan] (
    [Metrekare] int  NOT NULL,
    [Depo] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Üyeler'
ALTER TABLE [dbo].[Üyeler]
ADD CONSTRAINT [PK_Üyeler]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emlaklar'
ALTER TABLE [dbo].[Emlaklar]
ADD CONSTRAINT [PK_Emlaklar]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Şehirler'
ALTER TABLE [dbo].[Şehirler]
ADD CONSTRAINT [PK_Şehirler]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tipler'
ALTER TABLE [dbo].[Tipler]
ADD CONSTRAINT [PK_Tipler]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emlaklar_Konut'
ALTER TABLE [dbo].[Emlaklar_Konut]
ADD CONSTRAINT [PK_Emlaklar_Konut]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emlaklar_Arsa'
ALTER TABLE [dbo].[Emlaklar_Arsa]
ADD CONSTRAINT [PK_Emlaklar_Arsa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emlaklar_Dükkan'
ALTER TABLE [dbo].[Emlaklar_Dükkan]
ADD CONSTRAINT [PK_Emlaklar_Dükkan]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ÜyeId] in table 'Emlaklar'
ALTER TABLE [dbo].[Emlaklar]
ADD CONSTRAINT [FK_ÜyeEmlak]
    FOREIGN KEY ([ÜyeId])
    REFERENCES [dbo].[Üyeler]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ÜyeEmlak'
CREATE INDEX [IX_FK_ÜyeEmlak]
ON [dbo].[Emlaklar]
    ([ÜyeId]);
GO

-- Creating foreign key on [ŞehirId] in table 'Emlaklar'
ALTER TABLE [dbo].[Emlaklar]
ADD CONSTRAINT [FK_ŞehirEmlak]
    FOREIGN KEY ([ŞehirId])
    REFERENCES [dbo].[Şehirler]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ŞehirEmlak'
CREATE INDEX [IX_FK_ŞehirEmlak]
ON [dbo].[Emlaklar]
    ([ŞehirId]);
GO

-- Creating foreign key on [TipId] in table 'Emlaklar'
ALTER TABLE [dbo].[Emlaklar]
ADD CONSTRAINT [FK_TipEmlak]
    FOREIGN KEY ([TipId])
    REFERENCES [dbo].[Tipler]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipEmlak'
CREATE INDEX [IX_FK_TipEmlak]
ON [dbo].[Emlaklar]
    ([TipId]);
GO

-- Creating foreign key on [Id] in table 'Emlaklar_Konut'
ALTER TABLE [dbo].[Emlaklar_Konut]
ADD CONSTRAINT [FK_Konut_inherits_Emlak]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Emlaklar]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Emlaklar_Arsa'
ALTER TABLE [dbo].[Emlaklar_Arsa]
ADD CONSTRAINT [FK_Arsa_inherits_Emlak]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Emlaklar]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Emlaklar_Dükkan'
ALTER TABLE [dbo].[Emlaklar_Dükkan]
ADD CONSTRAINT [FK_Dükkan_inherits_Emlak]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Emlaklar]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------