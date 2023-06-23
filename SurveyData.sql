CREATE DATABASE Survey

CREATE TABLE Details
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ST_Name NVARCHAR(250) NOT NULL,
	Surname NVARCHAR(250) NOT NULL,
	Contact_Number INT NOT NULL,
	T_Date Date NOT NULL,
	Age INT NOT NULL,	
	Pizza BIT NOT NULL,
	Pasta INT NOT NULL,
	Pap_Wors INT NOT NULL,
	Chicken_stir_fry INT NOT NULL,
	Beef_stir_fry INT NOT NULL,
	Other INT NOT NULL,
	I_like_to_eat_out INT NOT NULL,
	I_like_to_watch_movies INT NOT NULL,
	I_like_to_watch_TV INT NOT NULL,
	I_like_to_listen_to_the_radio INT NOT NULL
)

CREATE PROCEDURE SurveyData
@ST_Name VARCHAR(250),
@Surname VARCHAR(250),
@Contact_Number INT,
@T_Date DATE,
@Age INT,
@Pizza INT,
@Pasta INT,
@Pap_Wors INT,
@Chicken_stir_fry INT,
@Beef_stir_fry INT,
@Other INT,
@I_like_to_eat_out INT,
@I_like_to_watch_movies INT,
@I_like_to_watch_TV INT,
@I_like_to_listen_to_the_radio INT
AS
BEGIN
INSERT INTO Details (ST_Name, Surname, Contact_Number, T_Date, Age, Pizza, Pasta, Pap_Wors,Chicken_stir_fry, Beef_stir_fry, Other,
I_like_to_eat_out, I_like_to_watch_movies, I_like_to_watch_TV, I_like_to_listen_to_the_radio)
VALUES (@ST_Name, @Surname, @Contact_Number, @T_Date, @Age, @Pizza, @Pasta, @Pap_Wors, @Chicken_stir_fry, @Beef_stir_fry, @Other,
@I_like_to_eat_out, @I_like_to_watch_movies, @I_like_to_watch_TV, @I_like_to_listen_to_the_radio)
END