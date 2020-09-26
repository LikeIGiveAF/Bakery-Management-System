CREATE TABLE [dbo].[ORDER_DETAILS] (
    [ORDER_NO]     DECIMAL (10) NOT NULL IDENTITY,
    [ITEM_NAMES]   VARCHAR (20) NULL,
    [USERNAME]     VARCHAR (20) NOT NULL,
    [TOTAL_AMOUNT] MONEY        NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([ORDER_NO] ASC),
    CONSTRAINT [FK_ORDER_DETAILS_ToTable_2] FOREIGN KEY ([USERNAME]) REFERENCES [dbo].[CUSTOMER] ([USERNAME])
);


GO
CREATE TRIGGER pay
	ON ORDER_DETAILS
	FOR INSERT
	AS
	BEGIN
		declare @order decimal(10,0)
		declare @money money
		declare @user varchar(20)

		select @order = ORDER_NO from inserted
		select @money = TOTAL_AMOUNT from inserted
		select @user = USERNAME from inserted

		INSERT INTO PAYMENT (ORDER_NO,TOTAL_AMOUNT,USERNAME)
		VALUES (@order,@money,@user)
	END