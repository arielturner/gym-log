CREATE TABLE [dbo].[BodyPart] (
    [BodyPartId]   INT          IDENTITY (1, 1) NOT NULL,
    [BodyPartName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BodyPartId] ASC),
    UNIQUE NONCLUSTERED ([BodyPartName] ASC)
);

