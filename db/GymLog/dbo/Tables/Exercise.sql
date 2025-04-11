CREATE TABLE [dbo].[Exercise] (
    [ExerciseId]         INT          IDENTITY (1, 1) NOT NULL,
    [ExerciseName]       VARCHAR (50) NOT NULL,
    [ExerciseCategoryId] INT          NOT NULL,
    [BodyPartId]         INT          NOT NULL,
    [EstimatedOneRepMax] INT          NULL,
    PRIMARY KEY CLUSTERED ([ExerciseId] ASC),
    CONSTRAINT [FK_Exercise_BodyPart] FOREIGN KEY ([BodyPartId]) REFERENCES [dbo].[BodyPart] ([BodyPartId]),
    CONSTRAINT [FK_Exercise_ExerciseCategory] FOREIGN KEY ([ExerciseCategoryId]) REFERENCES [dbo].[ExerciseCategory] ([ExerciseCategoryId]),
    UNIQUE NONCLUSTERED ([ExerciseName] ASC)
);

