CREATE TABLE [dbo].[WorkoutTemplateExerciseSet] (
    [WorkoutTemplateExerciseSetId] INT IDENTITY (1, 1) NOT NULL,
    [Set]                          INT NOT NULL,
    [Reps]                         INT NOT NULL,
    [Intensity]                    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkoutTemplateExerciseSetId] ASC)
);

