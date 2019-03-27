CREATE TABLE [dbo].[Results] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]     INT            NOT NULL,
    [Question_Id] INT            NOT NULL,
    [Answer_Id]   INT            NULL,
    [Result]      INT            NULL,
    [Date]        NVARCHAR (50)  NULL,
    [Name]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Results_Answer] FOREIGN KEY ([Answer_Id]) REFERENCES [dbo].[Answers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Results_Question] FOREIGN KEY ([Question_Id]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Results_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);

