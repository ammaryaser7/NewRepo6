CREATE TABLE [dbo].[Courses] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NULL,
    [Price] FLOAT (53)     NOT NULL,
    [Hours] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED ([ID] ASC)
);

