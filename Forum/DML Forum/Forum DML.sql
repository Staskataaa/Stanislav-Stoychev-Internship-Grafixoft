USE FORUM 

INSERT INTO POST (title, post_description)
VALUES ('Weather', 'QWEQWE', 123, 12);

INSERT INTO ACCOUNT (username, account_password, email, profile_pic_path, points)
VALUES ('Staskata', '123123', 'stat@gmail.com', '1123123123', '0');

INSERT INTO ROLES(rolename)
VALUES ('ADMIN');

INSERT INTO ACCOUNT_ROLE(account_id, role_id)
VALUES (1, 1);

DECLARE @topic_id uniqueidentifier;
SET @topic_id = (SELECT id FROM TOPIC WHERE topic_name = '123');
INSERT INTO POST(title, post_description, fk_topic_id)
VALUES('Weather', 'Forecast', @topic_id);

DECLARE @owner1_id uniqueidentifier;
SET @owner1_id = (SELECT id FROM POST WHERE post_description = 'Forecast');
INSERT INTO REACT(likes, dislikes)
VALUES (1, 1);

DECLARE @account_id uniqueidentifier
SET @account_id = (SELECT id FROM ACCOUNT WHERE username = 'Staskata');

DECLARE @role_id uniqueidentifier
SET @role_id = NEWID()
INSERT INTO ACCOUNT_ROLE(account_id, role_id, role_description, role_priority)
VALUES (@account_id, @role_id, '12312', 1);

INSERT INTO ACCOUNT_ROLE(account_id, role_id, role_description, role_priority)
VALUES (@account_id, @role_id, '12312', 1);

INSERT INTO TOPIC(topic_name, topic_description, topic_owner)
VALUES('123', '123', @account_id);

DELETE FROM TOPIC WHERE topic_name = '123';