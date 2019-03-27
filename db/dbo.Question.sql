CREATE TABLE [dbo].[Question] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (500) NULL,
    [Text]    NVARCHAR (MAX) NULL,
    [Test_Id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_ToTest] FOREIGN KEY ([Test_Id]) REFERENCES [dbo].[Test] ([Id]) ON DELETE CASCADE
);

