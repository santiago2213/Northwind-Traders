Alter table Products
add ProdImage nvarchar(20)

GO
ALTER proc [dbo].[spGetProductsByCategoryID]
( @categoryID int )
as

begin
	select * from Products
	where CategoryID = @categoryID

end
go


alter proc [dbo].[spGetProductDetails]
(@prodID int)
as 
begin
	Select * from Products
	where ProductID = @prodID 

end
go

alter proc [dbo].[spShoppingCartGetItems]
(@cartID char(36))
As
Begin
	Select * from ShoppingCart 
	where CartID = @cartID
End
go

alter proc [dbo].[spShoppingCartGetTotalAmmount]
(@cartID char(36))
As
Begin
	Select CartID, sum(ListPrice * QuantityToOrder) 

	from Products inner join ShoppingCart
	on Products.ProductID = ShoppingCart.ProductID

	where CartID = @cartID 
	group by CartID
End
go

alter   PROCEDURE [dbo].[spShoppingCartRemoveItem]
(@CartID char(36),
@ProductID int)
AS
DELETE FROM ShoppingCart
WHERE CartID = @CartID and ProductID = @ProductID
go

alter   Procedure [dbo].[spShoppingCartUpdateItem]
(@cartID char(36),
@prodID int,
@qty int)
AS
	IF @qty > 0
		UPDATE ShoppingCart
		SET QuantityToOrder = @qty
		WHERE ProductID = @prodID AND CartID = @cartID
	Else
		EXEC spShoppingCartRemoveItem @cartID, @prodID
go

Update Products
set ProdImage = 'fruits.jpg'
go

alter proc spShoppingCartGetTotalAmmount
(@CartID char(36))
as
	select ISNULL(Sum(Subtotal),0)
	from ShoppingCart
	where CartID = @CartID
go

ALTER PROCEDURE [dbo].[spCreatePurchaseOrder]

(@CartID char(36), @EmpID char(36), @PurchaseOrderID int output)

AS
BEGIN
	/* Insert a new record into Orders */
	INSERT INTO PurchaseOrders (EmpID) VALUES (@EmpID)
	
	/* Save the new Order ID */
	SET @PurchaseOrderID = @@IDENTITY
	
	/* Add the order details to OrderDetail */
	INSERT INTO PurchaseOrderDetails
	(PurchaseOrderID, ProductID, ProductName, Quantity, UnitCost)
	
	SELECT
	@PurchaseOrderID, ProductID, ProductName, QuantityToOrder, StandardCost
	FROM ShoppingCart
	WHERE CartID = @CartID

	/* Clear the shopping cart */
	DELETE FROM ShoppingCart
	WHERE CartID = @CartID

	

END
go


alter proc [dbo].[spShoppingCartAdditem]
(@cartid char(36),
@prodid int
)
AS

BEGIN

	if Not exists
	(Select Cartid from shoppingcart 
	where cartid=@cartid and productid=@prodid)
	
	begin
			declare @productname nvarchar(100)
			declare @standardcost money
			declare @quantitytoorder int

			Select @productname = productname, @standardcost = standardcost,
			@quantitytoorder = targetlevel - availableqty
			from products 
			where productid = @prodid

			insert into shoppingcart (cartID, ProductID, ProductName, StandardCost, QuantityToOrder)
			values(@cartID, @prodID, @productname, @standardcost, @quantitytoorder)

			Update Products
			set Reordered = 1
			where productid = @prodid
	end



alter table ShoppingCart
add Subtotal as QuantityToOrder * ListPrice
go

alter proc [dbo].[spAddProduct]
(@categoryid int,
@prodcode nvarchar(100),
@prodname nvarchar(100),
@proddesc nvarchar(100),
@prodprice money,
@prodimage nvarchar(100))
as 
begin
	declare @productID int

	insert into Products(CategoryID, ProductCode, ProductName, Description, ListPrice, ProdImage)
	values (@categoryid, @prodcode, @prodname, @proddesc, @prodprice, @prodimage);

	set @productID = @@IDENTITY ;

	--insert into ProductCategory
	--values(@productID, @categoryid)
end
GO

alter proc [dbo].[spDeleteProduct]
(@prodID int)
as
begin

Delete from Products
where ProductID=@prodID

end
GO