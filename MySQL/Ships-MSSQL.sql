USE master
GO
if exists (select * from sysdatabases where name='ships')
	DROP DATABASE ships
GO

CREATE DATABASE ships
GO
USE ships
GO

----- Tables -----
CREATE TABLE BATTLES (
 NAME VARCHAR(20) NOT NULL ,
 DATE DATETIME NOT NULL
);

CREATE TABLE CLASSES(
 CLASS VARCHAR(50) NOT NULL ,
 TYPE VARCHAR(2) NOT NULL ,
 COUNTRY VARCHAR (20) NOT NULL ,
 NUMGUNS INT, 
 BORE REAL, 
 DISPLACEMENT INT
);

CREATE TABLE SHIPS(
 NAME VARCHAR(50) NOT NULL ,
 CLASS VARCHAR(50) NOT NULL ,
 LAUNCHED INT
);

CREATE TABLE OUTCOMES(
 SHIP VARCHAR(50) NOT NULL ,
 BATTLE VARCHAR(20) NOT NULL ,
 RESULT VARCHAR(10) NOT NULL 
);

----- Constraints -----
ALTER TABLE BATTLES ADD	CONSTRAINT PK_BATTLES PRIMARY KEY(NAME);

ALTER TABLE CLASSES ADD	CONSTRAINT PK_CLASSES PRIMARY KEY(CLASS);

ALTER TABLE SHIPS ADD CONSTRAINT PK_SHIPS PRIMARY KEY(NAME);

ALTER TABLE SHIPS ADD CONSTRAINT FK_SHIPS_CLASSES FOREIGN KEY(CLASS) REFERENCES CLASSES(CLASS);

ALTER TABLE OUTCOMES ADD CONSTRAINT PK_OUTCOMES PRIMARY KEY(SHIP,BATTLE);

ALTER TABLE OUTCOMES ADD CONSTRAINT FK_OUTCOMES_BATTLES FOREIGN KEY(BATTLE) REFERENCES BATTLES(NAME);

ALTER TABLE OUTCOMES ADD CONSTRAINT FK_OUTCOMES_SHIPS FOREIGN KEY(SHIP) REFERENCES SHIPS(NAME);

----- Classes ----- 
INSERT INTO CLASSES
  VALUES ('Bismarck', 'bb', 'Germany', 8, 15, 42000);

INSERT INTO CLASSES
  VALUES ('Iowa', 'bb', 'USA', 9, 16, 46000);

INSERT INTO CLASSES
  VALUES ('Kongo', 'bc', 'Japan', 8, 14, 32000);

INSERT INTO CLASSES
  VALUES ('North Carolina', 'bb', 'USA', 12, 16, 37000);

INSERT INTO CLASSES
  VALUES ('Renown', 'bc', 'Gt.Britain', 6, 15, 32000);

INSERT INTO CLASSES
  VALUES ('Revenge', 'bb', 'Gt.Britain', 8, 15, 29000);

INSERT INTO CLASSES
  VALUES ('Tennessee', 'bb', 'USA', 12, 14, 32000);

INSERT INTO CLASSES
  VALUES ('Yamato', 'bb', 'Japan', 9, 18, 65000);

----- Battles ----- 
INSERT INTO BATTLES
  VALUES ('Guadalcanal', '1942-11-15');

INSERT INTO BATTLES
  VALUES ('North Atlantic', '1941-05-25');

INSERT INTO BATTLES
  VALUES ('North Cape', '1943-12-26');

INSERT INTO BATTLES
  VALUES ('Surigao Strait', '1944-10-25');

----- Ships ----- 
INSERT INTO SHIPS
  VALUES ('California', 'Tennessee', 1921);

INSERT INTO SHIPS
  VALUES ('Haruna', 'Kongo', 1916);

INSERT INTO SHIPS
  VALUES ('Hiei', 'Kongo', 1914);

INSERT INTO SHIPS
  VALUES ('Iowa', 'Iowa', 1943);

INSERT INTO SHIPS
  VALUES ('Kirishima', 'Kongo', 1915);

INSERT INTO SHIPS
  VALUES ('Kongo', 'Kongo', 1913);

INSERT INTO SHIPS
  VALUES ('Missouri', 'Iowa', 1944);

INSERT INTO SHIPS
  VALUES ('Musashi', 'Yamato', 1942);

INSERT INTO SHIPS
  VALUES ('New Jersey', 'Iowa', 1943);

INSERT INTO SHIPS
  VALUES ('North Carolina', 'North Carolina', 1941);

INSERT INTO SHIPS
  VALUES ('Ramillies', 'Revenge', 1917);

INSERT INTO SHIPS
  VALUES ('Renown', 'Renown', 1916);

INSERT INTO SHIPS
  VALUES ('Repulse', 'Renown', 1916);

INSERT INTO SHIPS
  VALUES ('Resolution', 'Renown', 1916);

INSERT INTO SHIPS
  VALUES ('Revenge', 'Revenge', 1916);

INSERT INTO SHIPS
  VALUES ('Royal Oak', 'Revenge', 1916);

INSERT INTO SHIPS
  VALUES ('Royal Sovereign', 'Revenge', 1916);

INSERT INTO SHIPS
  VALUES ('Tennessee', 'Tennessee', 1920);

INSERT INTO SHIPS
  VALUES ('Washington', 'North Carolina', 1941);

INSERT INTO SHIPS
  VALUES ('Wisconsin', 'Iowa', 1944);

INSERT INTO SHIPS
  VALUES ('Yamato', 'Yamato', 1941);
  
INSERT INTO SHIPS
  VALUES ('Yamashiro', 'Yamato', 1947);
  
INSERT INTO SHIPS
  VALUES ('South Dakota', 'North Carolina', 1941);

INSERT INTO SHIPS
  VALUES ('Bismarck', 'North Carolina', 1911);
  
INSERT INTO SHIPS
  VALUES ('Duke of York', 'Renown', 1916);
  
INSERT INTO SHIPS
  VALUES ('Fuso', 'Iowa', 1940);
  
INSERT INTO SHIPS
  VALUES ('Hood', 'Iowa', 1942);
  
INSERT INTO SHIPS
  VALUES ('Rodney', 'Yamato', 1915);
  
INSERT INTO SHIPS
  VALUES ('Yanashiro', 'Yamato', 1918);
  
INSERT INTO SHIPS
  VALUES ('Schamhorst', 'North Carolina', 1917);
  
INSERT INTO SHIPS
  VALUES ('Prince of Wales', 'North Carolina', 1937);
  
INSERT INTO SHIPS
  VALUES ('King George V', 'Iowa', 1942);
  
INSERT INTO SHIPS
  VALUES ('West Virginia', 'Iowa', 1942);

----- Outcomes ----- 
INSERT INTO OUTCOMES
  VALUES ('Bismarck', 'North Atlantic', 'sunk'); 

INSERT INTO OUTCOMES
  VALUES ('California', 'Surigao Strait', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Duke of York', 'North Cape', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Fuso', 'Surigao Strait', 'sunk');

INSERT INTO OUTCOMES
  VALUES ('Hood', 'North Atlantic', 'sunk');

INSERT INTO OUTCOMES
  VALUES ('King George V', 'North Atlantic', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Kirishima', 'Guadalcanal', 'sunk');

INSERT INTO OUTCOMES
  VALUES ('Prince of Wales', 'North Atlantic', 'damaged');

INSERT INTO OUTCOMES
  VALUES ('Rodney', 'North Atlantic', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Schamhorst', 'North Cape', 'sunk');

INSERT INTO OUTCOMES
  VALUES ('South Dakota', 'Guadalcanal', 'damaged');

INSERT INTO OUTCOMES
  VALUES ('Tennessee', 'Surigao Strait', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Washington', 'Guadalcanal', 'ok');

INSERT INTO OUTCOMES
  VALUES ('West Virginia', 'Surigao Strait', 'ok');

INSERT INTO OUTCOMES
  VALUES ('Yamashiro', 'Surigao Strait', 'sunk');

INSERT INTO OUTCOMES
  VALUES ('California', 'Guadalcanal', 'damaged');

  --3.1--
INSERT INTO CLASSES (CLASS.class, class.type, class.country, class.numguns, class.bore, class.displacement)
	Values
	(
		'Nelson',
		'bb',
		'Britain',
		9,
		16,
		34000
	),
	(
		'Rodney',
		'bb',
		'Britain',
		9,
		16,
		34000
	);

INSERT INTO SHIPS
	Values('Nelson', 'Nelson', 1927);

INSERT INTO SHIPS
	Values('Rodney', 'Rodney', 1927);

--3.2--
ALTER TABLE OUTCOMES DROP CONSTRAINT FK_OUTCOMES_SHIPS;
ALTER TABLE OUTCOMES ADD CONSTRAINT FK_OUTCOMES_SHIPS FOREIGN KEY(SHIP) REFERENCES SHIPS(NAME)
ON DELETE CASCADE;
DELETE FROM SHIPS WHERE SHIPS.NAME IN (SELECT OUTCOMES.SHIP FROM OUTCOMES WHERE (OUTCOMES.RESULT = 'sunk'));

--3.3--
 UPDATE CLASSES 
 SET DISPLACEMENT = DISPLACEMENT /1.1,
 BORE = BORE * 2.5 WHERE
 CLASS IN (SELECT SHIPS.CLASS FROM SHIPS)

 --SUBQUERIES--

 --1--
 SELECT DISTINCT CLASSES.COUNTRY FROM CLASSES WHERE CLASSES.NUMGUNS IN
(SELECT MAX(NUMGUNS) FROM CLASSES);

--2--
SELECT CLASSES.CLASS FROM CLASSES WHERE CLASSES.CLASS IN 
(SELECT SHIPS.CLASS FROM SHIPS WHERE SHIPS.NAME IN 
(SELECT OUTCOMES.SHIP FROM OUTCOMES WHERE (OUTCOMES.RESULT = 'sunk')));

--3--
SELECT SHIPS.NAME, SHIPS.CLASS FROM SHIPS WHERE SHIPS.CLASS IN 
(SELECT CLASSES.CLASS FROM CLASSES WHERE (CLASSES.BORE = 16));

--4--
SELECT BATTLES.NAME FROM BATTLES WHERE BATTLES.NAME IN
(SELECT OUTCOMES.BATTLE FROM OUTCOMES WHERE OUTCOMES.SHIP IN
(SELECT SHIPS.NAME FROM SHIPS WHERE (SHIPS.CLASS = 'Kongo')));

--JOINS--

--1--
SELECT * FROM SHIPS JOIN
CLASSES ON
SHIPS.CLASS = CLASSES.CLASS

--2--
SELECT * FROM SHIPS FULL JOIN
CLASSES ON
SHIPS.CLASS = CLASSES.CLASS

--3--
SELECT CLASSES.COUNTRY, SHIPS.NAME 
FROM CLASSES LEFT JOIN 
SHIPS ON 
CLASSES.CLASS = SHIPS.CLASS LEFT JOIN  
OUTCOMES ON
SHIPS.NAME = OUTCOMES.SHIP
WHERE(OUTCOMES.RESULT = 'ok')
GROUP BY CLASSES.COUNTRY, SHIPS.NAME

--1--
SELECT SHIPS.NAME FROM CLASSES JOIN SHIPS ON
CLASSES.CLASS = SHIPS.CLASS
WHERE(CLASSES.DISPLACEMENT > 50000);

--2--
SELECT SHIPS.NAME, CLASSES.DISPLACEMENT, 
CLASSES.NUMGUNS FROM SHIPS
JOIN CLASSES ON
SHIPS.CLASS = CLASSES.CLASS
JOIN OUTCOMES ON
SHIPS.NAME = OUTCOMES.SHIP
WHERE(OUTCOMES.BATTLE = 'Guadalcanal');

--3--
SELECT CLASSES.COUNTRY FROM CLASSES 
GROUP BY COUNTRY
HAVING SUM(CASE WHEN type = 'bc' THEN 1 ELSE 0 END) > 0 AND 
SUM(CASE WHEN type = 'bb' THEN 1 ELSE 0 END) > 0

--4--
SELECT DISTINCT ship FROM Outcomes os
WHERE EXISTS (SELECT ship 
 FROM Outcomes oa
 WHERE oa.ship = os.ship AND 
 result = 'damaged'
 ) AND 
 EXISTS (SELECT SHIP
 FROM Outcomes ou
 WHERE ou.ship=os.ship
 GROUP BY ship 
 HAVING COUNT(battle)>1
 );