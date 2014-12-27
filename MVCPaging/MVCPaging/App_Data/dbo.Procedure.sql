CREATE PROCEDURE [dbo].[GetCustomers]
	@PageNo int,
	@NoOfRecord int,
	@TotalRecord int output
AS
	Select @TotalRecord = Count(*) from Customer

	Select * from (Select ROW_NUMBER() over (Order by CustomerID) as RowNo,
		CustomerId,
		CustomerName
		From Customer) as Tab
		where Tab.RowNo between ((@PageNo - 1) * @NoOfRecord) + 1 and (@PageNo * @NoOfRecord)
		order by CustomerID
 
RETURN