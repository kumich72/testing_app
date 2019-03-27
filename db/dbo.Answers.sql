CREATE TABLE [dbo].[Answers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [Text]        NVARCHAR (500) NULL,
    [Question_Id] INT            NOT NULL,
    [IsRight]     BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Answer_ToQuestion] FOREIGN KEY ([Question_Id]) REFERENCES [dbo].[Question] ([Id])
);

