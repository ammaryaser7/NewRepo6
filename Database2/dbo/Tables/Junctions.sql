CREATE TABLE [dbo].[Junctions] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [UserID]   INT NULL,
    [CourseID] INT NULL,
    CONSTRAINT [PK_dbo.Junctions] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Junctions_dbo.Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Courses] ([ID]),
    CONSTRAINT [FK_dbo.Junctions_dbo.Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserID]
    ON [dbo].[Junctions]([UserID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CourseID]
    ON [dbo].[Junctions]([CourseID] ASC);

