CREATE TABLE [dbo].[IdentityUserLogin] (
    [UserId]             NVARCHAR (128) NOT NULL,
    [LoginProvider]      NVARCHAR (MAX) NULL,
    [ProviderKey]        NVARCHAR (MAX) NULL,
    [ApplicationUser_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.IdentityUserLogin] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_dbo.IdentityUserLogin_dbo.ApplicationUser_ApplicationUser_Id] FOREIGN KEY ([ApplicationUser_Id]) REFERENCES [dbo].[ApplicationUser] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id]
    ON [dbo].[IdentityUserLogin]([ApplicationUser_Id] ASC);

