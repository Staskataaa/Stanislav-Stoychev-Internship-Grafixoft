 /*
	Script that serves the purpose of creating table for 'Account' entities.
	Requires Account_Role.sql to be executed first.
*/

USE FORUM

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ACCOUNTS')
BEGIN
	CREATE TABLE ACCOUNTS(
	account_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	account_username NVARCHAR(255) UNIQUE NOT NULL,
	account_password NVARCHAR(255) NOT NULL,
	account_email NVARCHAR(255) UNIQUE NOT NULL,
	account_role_id uniqueIdentifier NOT NULL,
	account_profile_pic_path TEXT DEFAULT NULL, 
	account_points int DEFAULT 0);

	ALTER TABLE ACCOUNTS ADD CONSTRAINT FK_ACCOUNT_ROLE_PRIORITY 
	FOREIGN KEY(account_role_id) REFERENCES ACCOUNT_ROLE(role_id);
END
