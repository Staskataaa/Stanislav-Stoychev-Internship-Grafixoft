/*
	Script that serves the purpose of creating table for 'Post' entities.
	Requires Accounts Table DDL.sql, Topics Table DDL.sql and React Table DDL.sql to be executed first.
*/

USE FORUM 

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'POSTS')
BEGIN
	CREATE TABLE POSTS(
	post_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	post_title NVARCHAR(255) NOT NULL UNIQUE, 
	post_description TEXT NOT NULL,
	post_account_id uniqueIdentifier NOT NULL,
	post_topic_id uniqueIdentifier DEFAULT NULL, 
	post_react_id uniqueIdentifier NOT NULL UNIQUE);

	ALTER TABLE POSTS ADD CONSTRAINT FK_POSTS_ACCOUNT_ID 
	FOREIGN KEY(post_account_id) REFERENCES ACCOUNTS(account_id) ON DELETE CASCADE;

	ALTER TABLE POSTS ADD CONSTRAINT FK_POSTS_TOPIC_ID 
	FOREIGN KEY(post_topic_id) REFERENCES TOPICS(topic_id) ON UPDATE CASCADE;

	ALTER TABLE POSTS ADD CONSTRAINT FK_POSTS_REACT_ID 
	FOREIGN KEY(post_react_id) REFERENCES REACTS(react_id);
END

