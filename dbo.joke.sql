CREATE TABLE [dbo].[joke] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [jokeQustion] NVARCHAR (MAX) NULL,
    [jokeAnswer]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_joke] PRIMARY KEY CLUSTERED ([Id] ASC)
);

