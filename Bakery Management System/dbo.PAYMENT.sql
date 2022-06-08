﻿CREATE TABLE [dbo].[PAYMENT] (
    [PAYMENT_ID]      DECIMAL (10) NOT NULL,
    [ORDER_NO]        DECIMAL (10) NOT NULL,
    [USERNAME]        VARCHAR (20) NOT NULL,
    [TOTAL_AMOUNT] MONEY NULL, 
    PRIMARY KEY CLUSTERED ([PAYMENT_ID] ASC),
    CONSTRAINT [FK_PAYMENT_ToTable] FOREIGN KEY ([USERNAME]) REFERENCES [dbo].[CUSTOMER] ([USERNAME])
);
