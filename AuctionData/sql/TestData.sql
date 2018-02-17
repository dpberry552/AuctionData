select * from dbo.AA_Auctions;
select * from dbo.AA_Locations;
select * from dbo.AA_Items;
select * from dbo.AA_AuctionMedia;
select * from dbo.AA_ItemMedia;

--------------------------------------------

delete from dbo.AA_AuctionMedia;
delete from dbo.AA_Auctions;
delete from dbo.AA_ItemMedia;
delete from dbo.AA_Items;
delete from dbo.AA_Locations;

DBCC CHECKIDENT ('[AA_Auctions]', RESEED, 0);
GO
DBCC CHECKIDENT ('[AA_Locations]', RESEED, 0);
GO
DBCC CHECKIDENT ('[AA_Items]', RESEED, 0);
GO
DBCC CHECKIDENT ('[AA_AuctionMedia]', RESEED, 0);
GO
DBCC CHECKIDENT ('[AA_ItemMedia]', RESEED, 0);
GO

--------------------------------------------

insert into dbo.AA_Locations
	(Title, StreeAddress, City, State, Zip, Phone)
	values('Smith Auction House', '123 Main St', 'Auburn', 'ME', '04210', '207-999-9999');
insert into dbo.AA_Locations 
	(Title, StreeAddress, City, State, Zip, Phone)
	values('ACME Auctions', '555 Maple Lane', 'Auburn', 'ME', '04210', '207-888-8888');


insert into dbo.AA_Auctions
	(Title, Description, AuctionDateTime, Type, IsPublic, LocationId)
	values('Jones Estate Auction', 'Estate auction at Smith Auction house', CURRENT_TIMESTAMP, 'Estate', 1, 1);
insert into dbo.AA_Auctions
	(Title, Description, AuctionDateTime, Type, IsPublic, LocationId)
	values('Used Car Auction', 'Used car auction at ACME Auctions', CURRENT_TIMESTAMP, 'Auto', 0, 2);
insert into dbo.AA_Auctions
	(Title, Description, AuctionDateTime, Type, IsPublic, LocationId)
	values('Another Auction', 'Auction at Smith Auction house', CURRENT_TIMESTAMP, 'Misc', 1, 1);


insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank, LastModfied, IsDeleted, WhenCreated)
	values('Ford Taurus', '2015 Ford Taurus', 0, 10000, 1, 2, 1, CURRENT_TIMESTAMP, 0, CURRENT_TIMESTAMP);
insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank, LastModfied, IsDeleted, WhenCreated)
	values('Nissan Altima', '2014 Nissan Altima', 0, 8000, 1, 2, 1, CURRENT_TIMESTAMP, 0, CURRENT_TIMESTAMP);
insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank)
	values('Couch', 'Black leather couch', 1, 100, 1, 1, 1);
insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank)
	values('Lamp', 'Desk lamp', 1, 25, 1, 1, 1);
insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank)
	values('Desk', 'Wooden writing desk', 1, 50, 1, 3, 1);
insert into dbo.AA_Items
	(Title, Description, OnlineBidding, MinimumBid, LotNumber, AuctionId, Rank)
	values('Office chair', 'Adjustable leather office chair', 1, 25, 1, 3, 1);


insert into dbo.AA_AuctionMedia
	(AuctionId, MediaId, Type, Description)
	values(1, 12345, 'Picture', 'Auction house picture');
insert into dbo.AA_AuctionMedia
	(AuctionId, MediaId, Type, Description)
	values(2, 12345, 'Video', 'Auto auction video');

insert into dbo.AA_ItemMedia
	(ItemId, Type, MediaId)
	values(1, 'Picture', 45678);
insert into dbo.AA_ItemMedia
	(ItemId, Type, MediaId)
	values(3, 'Picture', 56789);