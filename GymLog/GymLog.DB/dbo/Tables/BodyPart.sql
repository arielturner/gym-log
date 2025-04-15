CREATE TABLE [dbo].[BodyPart] (
    [BodyPartId]   INT          IDENTITY (1, 1) NOT NULL,
    [BodyPartName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_BodyPart] PRIMARY KEY CLUSTERED ([BodyPartId] ASC),
    CONSTRAINT [UQ_BodyPart_BodyPartName] UNIQUE NONCLUSTERED ([BodyPartName] ASC)
);

