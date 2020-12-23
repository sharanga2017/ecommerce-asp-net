CREATE TABLE [dbo].[bd] (
    [ref]        VARCHAR (50)    NOT NULL,
    [image]      VARBINARY (MAX) NULL,
    [heros]      NVARCHAR (50)   NULL,
    [titre]      NVARCHAR (50)   NULL,
    [prixPublic] FLOAT (53)      NULL,
    [resume]     TEXT            NULL,
    [idSerie]    INT             NULL,
    [idGenre]    INT             NULL,
    PRIMARY KEY CLUSTERED ([ref] ASC)
);

