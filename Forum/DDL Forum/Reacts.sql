USE FORUM 

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'REACTS')
BEGIN
CREATE TABLE REACT(
id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
likes int DEFAULT 0, 
dislikes int DEFAULT 0);
END