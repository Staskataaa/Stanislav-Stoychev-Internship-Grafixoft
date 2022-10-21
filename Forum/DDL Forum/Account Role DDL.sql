/*
	Script that serves the purpose of creating 'Account_Role' table.
	Requires FORUM dabatase to exist.
*/

USE FORUM

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ACCOUNT_ROLE')
BEGIN
	CREATE TABLE ACCOUNT_ROLE( 
	role_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	role_description TEXT NOT NULL,
	role_priority int IDENTITY(1, 1) NOT NULL);
END