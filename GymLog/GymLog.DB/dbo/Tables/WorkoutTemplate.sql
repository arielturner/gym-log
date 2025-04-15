CREATE TABLE [dbo].[WorkoutTemplate] (
    [WorkoutTemplateId]   INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateName] VARCHAR (50) NOT NULL,
    [WorkoutProgramId]    INT          NOT NULL,
    [Week]                INT          NOT NULL,
    [Day]                 INT          NOT NULL,
    [CreatedAt]           DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]           VARCHAR (50) NOT NULL,
    [UpdatedAt]           DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [UpdatedBy]           VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WorkoutTemplate] PRIMARY KEY CLUSTERED ([WorkoutTemplateId] ASC),
    CONSTRAINT [FK_WorkoutTemplate_WorkoutProgram] FOREIGN KEY ([WorkoutProgramId]) REFERENCES [dbo].[WorkoutProgram] ([WorkoutProgramId]),
    CONSTRAINT [UQ_WorkoutTemplate_WorkoutTemplateName] UNIQUE NONCLUSTERED ([WorkoutTemplateName] ASC)
);

