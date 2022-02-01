CREATE TABLE [dbo].[CityDetails] (
    [CityId]              INT            IDENTITY (0, 1) NOT NULL,
    [Name]                NVARCHAR (100) NOT NULL,
    [Region]              NVARCHAR (100) NOT NULL,
    [Country]             NVARCHAR (100) NOT NULL,
    [TouristRating]       INT            DEFAULT ((0)) NULL,
    [EstablishedDate]     DATE           NULL,
    [EstimatedPopulation] NUMERIC            NULL
);

