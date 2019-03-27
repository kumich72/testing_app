CREATE TABLE [dbo].[Users] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [Login]           NVARCHAR (20) NOT NULL,
    [Roles_Id]        INT           NOT NULL,
    [Email]           NVARCHAR (50) NULL,
    [Password]        NVARCHAR (50) DEFAULT ((123)) NOT NULL,
    [PasswordConfirm] NVARCHAR (50) DEFAULT ((123)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([Roles_Id]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
);

