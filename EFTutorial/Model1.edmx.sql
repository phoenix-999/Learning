
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2019 16:08:07
-- Generated from EDMX file: C:\Users\y.kalinichenko\Source\Repos\Learning\EFTutorial\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFTutorial];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompaniesPhones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_CompaniesPhones];
GO
IF OBJECT_ID(N'[dbo].[FK_GeographyCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK_GeographyCompany];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Phones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phones];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Geography]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Geography];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [ModelDetail] nvarchar(max)  NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [Geography_Id] int  NOT NULL
);
GO

-- Creating table 'Geography'
CREATE TABLE [dbo].[Geography] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Geography'
ALTER TABLE [dbo].[Geography]
ADD CONSTRAINT [PK_Geography]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Company_Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [FK_CompaniesPhones]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompaniesPhones'
CREATE INDEX [IX_FK_CompaniesPhones]
ON [dbo].[Phones]
    ([Company_Id]);
GO

-- Creating foreign key on [Geography_Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_GeographyCompany]
    FOREIGN KEY ([Geography_Id])
    REFERENCES [dbo].[Geography]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GeographyCompany'
CREATE INDEX [IX_FK_GeographyCompany]
ON [dbo].[Companies]
    ([Geography_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------