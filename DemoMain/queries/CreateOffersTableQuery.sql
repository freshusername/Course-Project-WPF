CREATE TABLE [Offers] (
    [Owner]       NCHAR (40) NOT NULL,
    [Email]       NCHAR (40) NOT NULL,
    [PhoneNumber] NCHAR (13) NOT NULL,
    [Price]       REAL       NOT NULL,
    [Discount]    INT        DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Owner] ASC)
);

