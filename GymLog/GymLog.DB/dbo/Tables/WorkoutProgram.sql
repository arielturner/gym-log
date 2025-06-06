﻿CREATE TABLE [dbo].[WorkoutProgram] (
    [WorkoutProgramId]   INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutProgramName] VARCHAR (50) NOT NULL,
    [CreatedAt]          DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]          VARCHAR (50) NOT NULL,
    [UpdatedAt]          DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [UpdatedBy]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WorkoutProgram] PRIMARY KEY CLUSTERED ([WorkoutProgramId] ASC),
    CONSTRAINT [UQ_WorkoutProgram_WorkoutProgramName] UNIQUE NONCLUSTERED ([WorkoutProgramName] ASC)
);

