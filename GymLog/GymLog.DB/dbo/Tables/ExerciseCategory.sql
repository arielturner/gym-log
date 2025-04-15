CREATE TABLE [dbo].[ExerciseCategory] (
    [ExerciseCategoryId]   INT          IDENTITY (1, 1) NOT NULL,
    [ExerciseCategoryName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ExerciseCategory] PRIMARY KEY CLUSTERED ([ExerciseCategoryId] ASC),
    CONSTRAINT [UQ_ExerciseCategory_ExerciseCategoryName] UNIQUE NONCLUSTERED ([ExerciseCategoryName] ASC)
);

