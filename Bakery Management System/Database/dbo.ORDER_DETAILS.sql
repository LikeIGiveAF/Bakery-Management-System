CREATE TABLE [dbo].[ORDER_DETAILS] (
    [ORDER_NO]     DECIMAL (10)  IDENTITY (1, 1) NOT NULL,
    [ITEM_NAMES]   VARCHAR (MAX) NULL,
    [USERNAME]     VARCHAR (20)  NOT NULL,
    [TOTAL_AMOUNT] MONEY         DEFAULT ((0)) NULL,
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
GO

CREATE TRIGGER DEL_TRIG
	ON ORDER_DETAILS
	FOR INSERT
	AS
	BEGIN
		declare @ORDER_NO DECIMAL(10,0)
		declare @USERNAME VARCHAR(20)

		select @ORDER_NO = ORDER_NO FROM inserted
		select @USERNAME = USERNAME FROM inserted

		INSERT INTO DELIVERY(ORDER_NO,USERNAME) VALUES(@ORDER_NO,@USERNAME)
     END