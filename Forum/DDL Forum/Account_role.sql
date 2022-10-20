USE FORUM

--requires role and account table to be created first--
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'ACCOUNT_ROLE')
BEGIN
CREATE TABLE ACCOUNT_ROLE(
account_id uniqueIdentifier UNIQUE, 
role_id uniqueIdentifier DEFAULT (NEWID()), 
PRIMARY KEY(account_id, role_id),
role_description TEXT NOT NULL,
role_priority tinyint NOT NULL
CONSTRAINT FK_ROLE_OF_ACCOUNT_ACCOUNT_ID FOREIGN KEY(account_id)
REFERENCES ACCOUNT(id) ON DELETE CASCADE)
END
