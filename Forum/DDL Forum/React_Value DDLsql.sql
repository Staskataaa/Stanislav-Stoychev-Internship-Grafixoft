/*
	Script that serves the purpose of creating 'Account_Role' table.
	Requires FORUM dabatase to exist.
*/

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'REACT_VALUE')
BEGIN 
	CREATE TABLE REACT_VALUE(
	react_value_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	react_description nvarchar(64) NOT NULL CHECK(react_description IN('like', 'dislike')));
END
