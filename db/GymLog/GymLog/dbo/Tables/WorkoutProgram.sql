CREATE TABLE [dbo].[WorkoutProgram] (
    [WorkoutProgramId]   INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutProgramName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkoutProgramId] ASC),
    UNIQUE NONCLUSTERED ([WorkoutProgramName] ASC)
);

