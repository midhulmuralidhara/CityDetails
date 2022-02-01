CREATE PROCEDURE [dbo].[procedure_DeleteCityDetails]
	@CityId INT
AS
	DELETE FROM CityDetails where CityId = @CityId

