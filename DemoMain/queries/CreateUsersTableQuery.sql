CREATE TABLE [Accounts] (
    [Login]    NCHAR (20) NOT NULL,
    [Email]    NCHAR (40) NOT NULL,
    [Password] NCHAR (20) NOT NULL,
    [IsAdmin]   BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Login] ASC)
);


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[Accounts]([Email] ASC);

