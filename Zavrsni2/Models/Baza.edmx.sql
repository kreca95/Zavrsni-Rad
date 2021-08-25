
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/25/2021 11:29:35
-- Generated from EDMX file: C:\Users\cornet1\Desktop\soče zavrsni\Zavrsni-Rad\Zavrsni2\Models\Baza.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [shop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KosaraProizvod_Kosara]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KosaraProizvod] DROP CONSTRAINT [FK_KosaraProizvod_Kosara];
GO
IF OBJECT_ID(N'[dbo].[FK_KosaraProizvod_Proizvod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KosaraProizvod] DROP CONSTRAINT [FK_KosaraProizvod_Proizvod];
GO
IF OBJECT_ID(N'[dbo].[FK_Proizvod_Kategorija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proizvod] DROP CONSTRAINT [FK_Proizvod_Kategorija];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Uloga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Uloga];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Brandovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brandovi];
GO
IF OBJECT_ID(N'[dbo].[Kategorija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategorija];
GO
IF OBJECT_ID(N'[dbo].[Kosara]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kosara];
GO
IF OBJECT_ID(N'[dbo].[KosaraProizvod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KosaraProizvod];
GO
IF OBJECT_ID(N'[dbo].[Proizvod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proizvod];
GO
IF OBJECT_ID(N'[dbo].[Slider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Slider];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Uloga]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uloga];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brandovi'
CREATE TABLE [dbo].[Brandovi] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Slika] varchar(50)  NULL,
    [Ime] varchar(50)  NULL
);
GO

-- Creating table 'Kategorija'
CREATE TABLE [dbo].[Kategorija] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Naziv] varchar(50)  NULL
);
GO

-- Creating table 'Kosara'
CREATE TABLE [dbo].[Kosara] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Datum] datetime  NULL,
    [Cookie] varchar(50)  NULL,
    [JeLiKupljeno] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [JeLiIsporuceno] bit  NULL
);
GO

-- Creating table 'KosaraProizvod'
CREATE TABLE [dbo].[KosaraProizvod] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Kosara_ID] int  NULL,
    [Proizvod_ID] int  NULL,
    [Kolicina] int  NULL
);
GO

-- Creating table 'Proizvod'
CREATE TABLE [dbo].[Proizvod] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Slika] varchar(200)  NULL,
    [Ime] varchar(50)  NULL,
    [Opis] varchar(50)  NULL,
    [DatumDodavanje] datetime  NULL,
    [Cijena] float  NULL,
    [KratakOpis] varchar(50)  NULL,
    [Kategorija_ID] int  NULL,
    [Kolicina] int  NULL,
    [ProdanaKolicina] int  NULL
);
GO

-- Creating table 'Slider'
CREATE TABLE [dbo].[Slider] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Slika] varchar(50)  NULL,
    [JeLiPrikazana] bigint  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Uloga'
CREATE TABLE [dbo].[Uloga] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Naziv] varchar(50)  NULL,
    [Opis] varchar(50)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ime] varchar(50)  NULL,
    [Prezime] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Pass] varchar(50)  NULL,
    [Broj_mobitela] varchar(50)  NULL,
    [Uloga] varchar(50)  NULL,
    [ID_Uloga] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Brandovi'
ALTER TABLE [dbo].[Brandovi]
ADD CONSTRAINT [PK_Brandovi]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Kategorija'
ALTER TABLE [dbo].[Kategorija]
ADD CONSTRAINT [PK_Kategorija]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Kosara'
ALTER TABLE [dbo].[Kosara]
ADD CONSTRAINT [PK_Kosara]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'KosaraProizvod'
ALTER TABLE [dbo].[KosaraProizvod]
ADD CONSTRAINT [PK_KosaraProizvod]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Proizvod'
ALTER TABLE [dbo].[Proizvod]
ADD CONSTRAINT [PK_Proizvod]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Slider'
ALTER TABLE [dbo].[Slider]
ADD CONSTRAINT [PK_Slider]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'Uloga'
ALTER TABLE [dbo].[Uloga]
ADD CONSTRAINT [PK_Uloga]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kategorija_ID] in table 'Proizvod'
ALTER TABLE [dbo].[Proizvod]
ADD CONSTRAINT [FK_Proizvod_Kategorija]
    FOREIGN KEY ([Kategorija_ID])
    REFERENCES [dbo].[Kategorija]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Proizvod_Kategorija'
CREATE INDEX [IX_FK_Proizvod_Kategorija]
ON [dbo].[Proizvod]
    ([Kategorija_ID]);
GO

-- Creating foreign key on [Kosara_ID] in table 'KosaraProizvod'
ALTER TABLE [dbo].[KosaraProizvod]
ADD CONSTRAINT [FK_KosaraProizvod_Kosara]
    FOREIGN KEY ([Kosara_ID])
    REFERENCES [dbo].[Kosara]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KosaraProizvod_Kosara'
CREATE INDEX [IX_FK_KosaraProizvod_Kosara]
ON [dbo].[KosaraProizvod]
    ([Kosara_ID]);
GO

-- Creating foreign key on [Proizvod_ID] in table 'KosaraProizvod'
ALTER TABLE [dbo].[KosaraProizvod]
ADD CONSTRAINT [FK_KosaraProizvod_Proizvod]
    FOREIGN KEY ([Proizvod_ID])
    REFERENCES [dbo].[Proizvod]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KosaraProizvod_Proizvod'
CREATE INDEX [IX_FK_KosaraProizvod_Proizvod]
ON [dbo].[KosaraProizvod]
    ([Proizvod_ID]);
GO

-- Creating foreign key on [ID_Uloga] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Uloga]
    FOREIGN KEY ([ID_Uloga])
    REFERENCES [dbo].[Uloga]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Uloga'
CREATE INDEX [IX_FK_User_Uloga]
ON [dbo].[User]
    ([ID_Uloga]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------