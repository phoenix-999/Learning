
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/26/2019 14:43:23
-- Generated from EDMX file: C:\Users\y.kalinichenko\Source\Repos\Learning\ModelFirstTutorial\EF_People_ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EF_People_ModelFirstTutorial];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Departament_DepartamentId] int  NOT NULL
);
GO

-- Creating table 'DepartamentSet'
CREATE TABLE [dbo].[DepartamentSet] (
    [DepartamentId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet_Manager'
CREATE TABLE [dbo].[UserSet_Manager] (
    [ManagerId] int IDENTITY(1,1) NOT NULL,
    [Level] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [DepartamentId] in table 'DepartamentSet'
ALTER TABLE [dbo].[DepartamentSet]
ADD CONSTRAINT [PK_DepartamentSet]
    PRIMARY KEY CLUSTERED ([DepartamentId] ASC);
GO

-- Creating primary key on [UserId] in table 'UserSet_Manager'
ALTER TABLE [dbo].[UserSet_Manager]
ADD CONSTRAINT [PK_UserSet_Manager]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Departament_DepartamentId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_DepartamentUser]
    FOREIGN KEY ([Departament_DepartamentId])
    REFERENCES [dbo].[DepartamentSet]
        ([DepartamentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentUser'
CREATE INDEX [IX_FK_DepartamentUser]
ON [dbo].[UserSet]
    ([Departament_DepartamentId]);
GO

-- Creating foreign key on [UserId] in table 'UserSet_Manager'
ALTER TABLE [dbo].[UserSet_Manager]
ADD CONSTRAINT [FK_Manager_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------