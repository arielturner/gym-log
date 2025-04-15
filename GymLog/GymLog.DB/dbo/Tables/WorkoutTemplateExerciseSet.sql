CREATE TABLE [dbo].[WorkoutTemplateExerciseSet] (
    [WorkoutTemplateExerciseSetId] INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateExerciseId]    INT          NOT NULL,
    [Set]                          INT          NOT NULL,
    [Reps]                         INT          NOT NULL,
    [Intensity]                    INT          NOT NULL,
    [CreatedAt]                    DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]                    VARCHAR (50) NOT NULL,
    [UpdatedAt]                    DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [UpdatedBy]                    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WorkoutTemplateExerciseSet] PRIMARY KEY CLUSTERED ([WorkoutTemplateExerciseSetId] ASC),
    CONSTRAINT [FK_WorkoutTemplateExerciseSet_WorkoutTemplateExercise] FOREIGN KEY ([WorkoutTemplateExerciseId]) REFERENCES [dbo].[WorkoutTemplateExercise] ([WorkoutTemplateExerciseId])
);

