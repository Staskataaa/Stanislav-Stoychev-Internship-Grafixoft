/*
	Script that serves the purpose of Creating 'Reacts' Table.
	Requires FORUM dabatase to exist.
*/

USE FORUM 

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'REACTS')
BEGIN
	CREATE TABLE REACTS(
	react_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	react_likes int NOT NULL DEFAULT 0, 
	react_dislikes int NOT NULL DEFAULT 0);
END