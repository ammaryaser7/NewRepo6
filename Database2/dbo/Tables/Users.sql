CREATE TABLE [dbo].[Users] (
    [ID]         INT              IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (50)    NOT NULL,
    [Password]   NVARCHAR (20)    NOT NULL,
    [Confirm]    NVARCHAR (20)    NOT NULL,
    [MajorID]    INT              NULL,
    [RoleRoleID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Users_dbo.Majors_MajorID] FOREIGN KEY ([MajorID]) REFERENCES [dbo].[Majors] ([ID]),
    CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleRoleID] FOREIGN KEY ([RoleRoleID]) REFERENCES [dbo].[Roles] ([RoleID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[Users]([Email] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MajorID]
    ON [dbo].[Users]([MajorID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleRoleID]
    ON [dbo].[Users]([RoleRoleID] ASC);

