USE FORUM 

--Requires comment table to be created first--
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'POST')
BEGIN
CREATE TABLE POST(
id uniqueIdentifier DEFAULT (NEWID()) PRIMARY KEY,
title NVARCHAR(255) NOT NULL, 
post_description TEXT NOT NULL,
account_id uniqueIdentifier,
CONSTRAINT fk_post_account_id FOREIGN KEY(account_id) REFERENCES ACCOUNT(id) ON DELETE CASCADE,
topic_id uniqueIdentifier, 
CONSTRAINT fk_post_topic_id FOREIGN KEY(topic_id) REFERENCES TOPIC(id) ON UPDATE CASCADE,
react_id uniqueIdentifier UNIQUE,
CONSTRAINT fk_post_react_id FOREIGN KEY(react_id) REFERENCES REACT(id) ON UPDATE CASCADE,
comment_id uniqueIdentifier
CONSTRAINT fk_comment_id FOREIGN KEY(comment_id) REFERENCES COMMENT(id) ON UPDATE CASCADE);
END

