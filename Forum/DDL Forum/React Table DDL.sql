/*
	Script that serves the purpose of Creating 'Reacts' Table.
	Requires FORUM dabatase to exist.
*/

USE FORUM 

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'REACTS')
BEGIN
	CREATE TABLE REACTS(
	react_id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
	react_value_id uniqueIdentifier NOT NULL, 
	react_account_id uniqueIdentifier NOT NULL, 
	react_post_id uniqueIdentifier,
	react_comment_id uniqueIdentifier);

	ALTER TABLE REACTS ADD CONSTRAINT FK_REACT_VALUE FOREIGN KEY(react_value) 
	REFERENCES REACT_VALUE(react_value_id) ON DELETE CASCADE;

	ALTER TABLE REACTS ADD CONSTRAINT FK_REACT_ACCOUNT_ID FOREIGN KEY(react_account_id) 
	REFERENCES ACCOUNTS(account_id);

	ALTER TABLE REACTS ADD CONSTRAINT FK_REACT_POST_ID FOREIGN KEY(react_post_id) 
	REFERENCES POSTS(post_id) ON DELETE CASCADE;

	ALTER TABLE REACTS ADD CONSTRAINT FK_REACT_COMMENT_ID FOREIGN KEY(react_comment_id) 
	REFERENCES COMMENTS(comment_id) ON DELETE CASCADE;

	ALTER TABLE REACTS ADD CONSTRAINT ONLY_ONE_REFERENCE_COLUMN CHECK
	((react_post_id IS NULL OR react_comment_id IS NULL)
	AND NOT (react_post_id IS NULL AND react_comment_id IS NULL))
END