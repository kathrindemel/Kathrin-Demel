
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/29/2020 21:14:07
-- Generated from EDMX file: C:\Users\I2CM Developer\Source\Repos\Schwimmbad\SchwimmbadLib\SchwimmbadModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Schwimmbad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GastBuchung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuchungSet] DROP CONSTRAINT [FK_GastBuchung];
GO
IF OBJECT_ID(N'[dbo].[FK_SchwimmbahnBuchung_Schwimmbahn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchwimmbahnBuchung] DROP CONSTRAINT [FK_SchwimmbahnBuchung_Schwimmbahn];
GO
IF OBJECT_ID(N'[dbo].[FK_SchwimmbahnBuchung_Buchung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchwimmbahnBuchung] DROP CONSTRAINT [FK_SchwimmbahnBuchung_Buchung];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SchwimmbahnSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchwimmbahnSet];
GO
IF OBJECT_ID(N'[dbo].[BuchungSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuchungSet];
GO
IF OBJECT_ID(N'[dbo].[GastSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastSet];
GO
IF OBJECT_ID(N'[dbo].[SchwimmbahnBuchung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchwimmbahnBuchung];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SchwimmbahnSet'
CREATE TABLE [dbo].[SchwimmbahnSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Schwimmbahnnummer] smallint  NOT NULL
);
GO

-- Creating table 'BuchungSet'
CREATE TABLE [dbo].[BuchungSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Wochentag] nvarchar(max)  NOT NULL,
    [Beginn] time  NOT NULL,
    [Ende] time  NOT NULL,
    [Starttermin] datetime  NOT NULL,
    [Endtermin] datetime  NOT NULL,
    [GastId] int  NULL,
    [Schwimmbahnanzahl] smallint  NOT NULL
);
GO

-- Creating table 'GastSet'
CREATE TABLE [dbo].[GastSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Verein] bit  NOT NULL,
    [Mitarbeiter] bit  NOT NULL
);
GO

-- Creating table 'SchwimmbahnBuchung'
CREATE TABLE [dbo].[SchwimmbahnBuchung] (
    [belegt_Id] int  NOT NULL,
    [WirdGebucht_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SchwimmbahnSet'
ALTER TABLE [dbo].[SchwimmbahnSet]
ADD CONSTRAINT [PK_SchwimmbahnSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BuchungSet'
ALTER TABLE [dbo].[BuchungSet]
ADD CONSTRAINT [PK_BuchungSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GastSet'
ALTER TABLE [dbo].[GastSet]
ADD CONSTRAINT [PK_GastSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [belegt_Id], [WirdGebucht_Id] in table 'SchwimmbahnBuchung'
ALTER TABLE [dbo].[SchwimmbahnBuchung]
ADD CONSTRAINT [PK_SchwimmbahnBuchung]
    PRIMARY KEY CLUSTERED ([belegt_Id], [WirdGebucht_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GastId] in table 'BuchungSet'
ALTER TABLE [dbo].[BuchungSet]
ADD CONSTRAINT [FK_GastBuchung]
    FOREIGN KEY ([GastId])
    REFERENCES [dbo].[GastSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastBuchung'
CREATE INDEX [IX_FK_GastBuchung]
ON [dbo].[BuchungSet]
    ([GastId]);
GO

-- Creating foreign key on [belegt_Id] in table 'SchwimmbahnBuchung'
ALTER TABLE [dbo].[SchwimmbahnBuchung]
ADD CONSTRAINT [FK_SchwimmbahnBuchung_Schwimmbahn]
    FOREIGN KEY ([belegt_Id])
    REFERENCES [dbo].[SchwimmbahnSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [WirdGebucht_Id] in table 'SchwimmbahnBuchung'
ALTER TABLE [dbo].[SchwimmbahnBuchung]
ADD CONSTRAINT [FK_SchwimmbahnBuchung_Buchung]
    FOREIGN KEY ([WirdGebucht_Id])
    REFERENCES [dbo].[BuchungSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchwimmbahnBuchung_Buchung'
CREATE INDEX [IX_FK_SchwimmbahnBuchung_Buchung]
ON [dbo].[SchwimmbahnBuchung]
    ([WirdGebucht_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------