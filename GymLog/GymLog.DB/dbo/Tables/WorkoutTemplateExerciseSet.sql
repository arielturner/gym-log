﻿CREATE TABLE [dbo].[WorkoutTemplateExerciseSet] (
    [WorkoutTemplateExerciseSetId] INT IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateExerciseId]    INT NOT NULL,
    [Set]                          INT NOT NULL,
    [Reps]                         INT NOT NULL,
    [Intensity]                    INT NOT NULL,
    CONSTRAINT [PK_WorkoutTemplateExerciseSet] PRIMARY KEY CLUSTERED ([WorkoutTemplateExerciseSetId] ASC),
    CONSTRAINT [FK_WorkoutTemplateExerciseSet_WorkoutTemplateExercise] FOREIGN KEY ([WorkoutTemplateExerciseId]) REFERENCES [dbo].[WorkoutTemplateExercise] ([WorkoutTemplateExerciseId])
);

