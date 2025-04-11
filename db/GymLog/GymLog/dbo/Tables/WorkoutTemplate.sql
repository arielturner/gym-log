CREATE TABLE [dbo].[WorkoutTemplate] (
    [WorkoutTemplateId]   INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateName] VARCHAR (50) NOT NULL,
    [WorkoutProgramId]    INT          NOT NULL,
    [Week]                INT          NOT NULL,
    [Day]                 INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkoutTemplateId] ASC),
    CONSTRAINT [FK_WorkoutTemplate_WorkoutProgram] FOREIGN KEY ([WorkoutProgramId]) REFERENCES [dbo].[WorkoutProgram] ([WorkoutProgramId]),
    UNIQUE NONCLUSTERED ([WorkoutTemplateName] ASC)
);

