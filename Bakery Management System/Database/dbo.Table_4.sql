﻿CREATE TABLE [dbo].[DELIVERY] (
    [STAFF_ID] VARCHAR (10) NOT NULL,
    [ORDER_NO] DECIMAL (10) NOT NULL,
    [CUST_ID]  DECIMAL (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ORDER_NO] ASC, [STAFF_ID] ASC),
    CONSTRAINT [FK_DELIVERY_ToTable] FOREIGN KEY ([STAFF_ID]) REFERENCES [dbo].[STAFF] ([STAFF_ID]),
    CONSTRAINT [FK_DELIVERY_ToTable_1] FOREIGN KEY ([ORDER_NO]) REFERENCES [dbo].[ORDER_DETAILS] ([ORDER_NO]),
    CONSTRAINT [FK_DELIVERY_ToTable_2] FOREIGN KEY ([CUST_ID]) REFERENCES [dbo].[CUSTOMER] ([CUST_ID])
);

