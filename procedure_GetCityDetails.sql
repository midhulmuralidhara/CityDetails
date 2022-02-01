CREATE PROCEDURE [dbo].[procedure_GetCityDetails]
	@CityId INT
AS
	SELECT * FROM CityDetails where CityId = @CityId
RETURN 0
