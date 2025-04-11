CREATE TABLE [dbo].[ExerciseCategory] (
    [ExerciseCategoryId]   INT          IDENTITY (1, 1) NOT NULL,
    [ExerciseCategoryName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ExerciseCategoryId] ASC),
    UNIQUE NONCLUSTERED ([ExerciseCategoryName] ASC)
);

