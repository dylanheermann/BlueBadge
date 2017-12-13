CREATE TABLE [dbo].[SongEntity] (
    [SongId]      INT                IDENTITY (1, 1) NOT NULL,
    [OwnerId]     UNIQUEIDENTIFIER   NULL,
    [Title]       NVARCHAR (MAX)     NOT NULL,
    [Description] NVARCHAR (MAX)     NULL,
    [SongName]    NVARCHAR (MAX)     NULL,
    [Content]     NVARCHAR (MAX)     NULL,
    [Link]        NVARCHAR (MAX)     NULL,
    [CreatedUtc]  DATETIMEOFFSET (7) NOT NULL,
    [ModifiedUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_dbo.SongEntity] PRIMARY KEY CLUSTERED ([SongId] ASC)
);

