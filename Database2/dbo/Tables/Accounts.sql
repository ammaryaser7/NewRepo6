CREATE TABLE [dbo].[Accounts] (
    [ID]       INT            NOT NULL,
    [FullName] NVARCHAR (MAX) NOT NULL,
    [Address]  NVARCHAR (MAX) NOT NULL,
    [Mobile]   NVARCHAR (MAX) NOT NULL,
    [birth]    DATETIME       NOT NULL,
    [Image]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Accounts_dbo.Users_ID] FOREIGN KEY ([ID]) REFERENCES [dbo].[Users] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ID]
    ON [dbo].[Accounts]([ID] ASC);

