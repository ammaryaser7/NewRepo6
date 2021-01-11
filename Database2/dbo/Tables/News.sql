CREATE TABLE [dbo].[News] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NULL,
    [Details] NVARCHAR (MAX) NULL,
    [Ontime]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED ([ID] ASC)
);

