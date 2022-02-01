CREATE PROCEDURE [dbo].[procedure_SaveCityDetails]
	@cityid INT,
	@name NVARCHAR(100),
	@region NVARCHAR(100),
	@country NVARCHAR(100),
	@touristrating INT,
	@establisheddate DATE,
	@estimatedpopulation NUMERIC(18,0)
AS
	IF EXISTS(SELECT COUNT(1) FROM CityDetails WHERE CityId = @cityid)
	BEGIN
		UPDATE CityDetails SET [Name]=@name, Region = @region, Country = @country , TouristRating = @touristrating, EstablishedDate = @establisheddate,EstimatedPopulation = @estimatedpopulation
	END
	ELSE
	BEGIN
		INSERT INTO CityDetails VALUES(@name,@region,@country,@touristrating,@establisheddate,@estimatedpopulation)
	END

