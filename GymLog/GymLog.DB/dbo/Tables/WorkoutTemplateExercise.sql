CREATE TABLE [dbo].[WorkoutTemplateExercise] (
    [WorkoutTemplateExerciseId] INT IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateId]         INT NOT NULL,
    [ExerciseId]                INT NOT NULL,
    [Sequence]                  INT NOT NULL,
    CONSTRAINT [PK_WorkoutTemplateExercise] PRIMARY KEY CLUSTERED ([WorkoutTemplateExerciseId] ASC),
    CONSTRAINT [FK_WorkoutTemplateExercise_Exercise] FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([ExerciseId]),
    CONSTRAINT [FK_WorkoutTemplateExercise_WorkoutTemplate] FOREIGN KEY ([WorkoutTemplateId]) REFERENCES [dbo].[WorkoutTemplate] ([WorkoutTemplateId])
);

