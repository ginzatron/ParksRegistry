-- DELETE DATABASE DATA
DELETE FROM survey_result;
DELETE FROM weather;
DELETE FROM park;


-- INSERT sample park
INSERT INTO park VALUES ('TWNG','name','st',10,11,12,13,'tropical',2000,100,'look out','abraham lincoln','oh what a park',6000,1)
DECLARE @parkCode varchar(4) = ('TWNG')

-- INSERT sample survey
INSERT INTO survey_result VALUES (@parkCode,'email@email.com','PA','active')
DECLARE @surveyId int = (SELECT @@IDENTITY);

---- INSERT sample weather
INSERT INTO weather VALUES (@parkCode,1,20,25,'rain')
DECLARE @weather varchar(4) = (@parkCode);

-- Return reservation ID
SELECT @parkCode as parkCode, @surveyId as surveyId