USE FORUM 

INSERT INTO POST (title, post_description, likes, dislikes)
VALUES ('Weather', 'QWEQWE', 123, 12);

INSERT INTO ACCOUNT (username, account_password, email, profile_pic_path, fk_post_id)
VALUES ('Staskata', '123123', 'stat@gmail.com', '1123123123', '1');

INSERT INTO ROLES(rolename)
VALUES ('ADMIN');

INSERT INTO ACCOUNT_ROLE(account_id, role_id)
VALUES (1, 1);

CREATE TABLE ROLES(
id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
rolename VARCHAR(255) NOT NULL);

DELETE FROM ACCOUNT WHERE ( ACCOUNT.id = '1');