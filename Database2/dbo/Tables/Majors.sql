CREATE TABLE [dbo].[Majors] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Majors] PRIMARY KEY CLUSTERED ([ID] ASC)
);

