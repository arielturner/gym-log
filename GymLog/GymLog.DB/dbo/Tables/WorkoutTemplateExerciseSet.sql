CREATE TABLE [dbo].[WorkoutTemplateExerciseSet] (
    [WorkoutTemplateExerciseSetId] INT          IDENTITY (1, 1) NOT NULL,
    [WorkoutTemplateExerciseId]    INT          NOT NULL,
    [Set]                          INT          NOT NULL,
    [Reps]                         INT          NOT NULL,
    [RPE]                          INT          NULL,
    [Intensity]                    INT          NOT NULL,
    [CreatedAt]                    DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]                    VARCHAR (50) NOT NULL,
    [UpdatedAt]                    DATETIME     DEFAULT (getutcdate()) NOT NULL,
    [UpdatedBy]                    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WorkoutTemplateExerciseSet] PRIMARY KEY CLUSTERED ([WorkoutTemplateExerciseSetId] ASC),
    CONSTRAINT [CHK_RPE] CHECK ([RPE]>=(1) AND [RPE]<=(10)),
    CONSTRAINT [FK_WorkoutTemplateExerciseSet_WorkoutTemplateExercise] FOREIGN KEY ([WorkoutTemplateExerciseId]) REFERENCES [dbo].[WorkoutTemplateExercise] ([WorkoutTemplateExerciseId])
);

