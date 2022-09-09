USE master
GO
if exists (select * from sysdatabases where name='pc')
	DROP DATABASE pc
GO

CREATE DATABASE pc
GO
USE pc
GO


CREATE TABLE laptop(
 code int NOT NULL, 
 model varchar(4) NOT NULL, 
 speed decimal(4, 0) NOT NULL,
 ram decimal(4, 0) NOT NULL, 
 hd decimal(3, 0) NOT NULL, 
 price float NOT NULL,
 screen int NOT NULL);
 
 CREATE TABLE pc(
  code int NOT NULL ,
  model varchar(4) NOT NULL ,
  speed decimal(4, 0) NOT NULL ,
  ram decimal(4, 0) NOT NULL ,
  hd decimal(3, 0) NOT NULL ,
  cd varchar(3) NOT NULL ,
  price float NOT NULL 
);

CREATE TABLE product(
  maker char(1) NOT NULL ,
  model varchar(4) NOT NULL ,
  type varchar(7) NOT NULL 
);

CREATE TABLE printer(
  code int NOT NULL ,
  model varchar(4) NOT NULL ,
  color char(1) NOT NULL ,
  type varchar(6) NOT NULL ,
  price float NOT NULL 
);

ALTER TABLE laptop ADD CONSTRAINT PK_laptop PRIMARY KEY(code); 

ALTER TABLE pc ADD CONSTRAINT PK_pc PRIMARY KEY(code);

ALTER TABLE product ADD	CONSTRAINT PK_product PRIMARY KEY (model);

ALTER TABLE printer ADD CONSTRAINT PK_printer PRIMARY KEY(code);

ALTER TABLE laptop ADD CONSTRAINT FK_laptop_product FOREIGN KEY(model) REFERENCES product(model);

ALTER TABLE pc ADD	CONSTRAINT FK_pc_product FOREIGN KEY(model) REFERENCES product(model);

ALTER TABLE printer ADD	CONSTRAINT FK_printer_product FOREIGN KEY(model) REFERENCES product(model);

----Product------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
insert into product values('B','1121','PC');
insert into product values('A','1232','PC');
insert into product values('A','1233','PC');
insert into product values('E','1260','PC');
insert into product values('A','1276','Printer');
insert into product values('D','1288','Printer');
insert into product values('A','1298','Laptop');
insert into product values('C','1321','Laptop');
insert into product values('A','1401','Printer');
insert into product values('A','1408','Printer');
insert into product values('D','1433','Printer');
insert into product values('E','1434','Printer');
insert into product values('B','1750','Laptop');
insert into product values('A','1752','Laptop');
insert into product values('E','2111','PC');
insert into product values('E','2112','PC');
----PC------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
insert into pc values(1,'1232',500,64,5,'12x',600);
insert into pc values(2,'1121',750,128,14,'40x',850);
insert into pc values(3,'1233',500,64,5,'12x',600);
insert into pc values(4,'1121',600,128,14,'40x',850);
insert into pc values(5,'1121',600,128,8,'40x',850);
insert into pc values(6,'1233',750,128,20,'50x',950);
insert into pc values(7,'1232',500,32,10,'12x',400);
insert into pc values(8,'1232',450,64,8,'24x',350);
insert into pc values(9,'1232',450,32,10,'24x',350);
insert into pc values(10,'1260',500,32,10,'12x',350);
insert into pc values(11,'1233',900,128,40,'40x',980);
----Laptop------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
insert into laptop values(1,'1298',350,32,4,700,11);
insert into laptop values(2,'1321',500,64,8,970,12);
insert into laptop values(3,'1750',750,128,12,1200,14);
insert into laptop values(4,'1298',600,64,10,1050,15);
insert into laptop values(5,'1752',750,128,10,1150,14);
insert into laptop values(6,'1298',450,64,10,950,12);
----Printer------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
insert into printer values(1,'1276','n','Laser',400);
insert into printer values(2,'1433','y','Jet',270);
insert into printer values(3,'1434','y','Jet',290);
insert into printer values(4,'1401','n','Matrix',150);
insert into printer values(5,'1408','n','Matrix',270);
insert into printer values(6,'1288','n','Laser',400);


--2.1--
INSERT INTO product VALUES('C', '1100', 'PC');
INSERT INTO pc values(12,'1100',2400,2048,500,'52x',299);

--2.2--
DELETE FROM pc WHERE pc.model = '1100';

--2.3-- 
DELETE FROM laptop WHERE laptop.model IN
(SELECT product.maker FROM product GROUP BY maker
HAVING SUM(CASE WHEN type = 'Printer' THEN 1 ELSE 0 END) = 0)

--2.4--
UPDATE product SET maker = 'A' WHERE (product.maker = 'B');

--2.5--
UPDATE pc SET hd = hd + 20, price = price / 2;

--2.6--
SELECT * FROM laptop Join product On product.model = laptop.model WHERE(product.maker = 'B' AND product.type = 'Laptop')


UPDATE laptop SET screen = screen + 1 FROM product
WHERE(product.maker = 'B' AND product.type = 'Laptop');

--SUBQUERIES--

--1--
SELECT DISTINCT product.maker FROM product 
JOIN pc ON
product.model = pc.model
WHERE (pc.speed >  500);

--2--
SELECT printer.code, printer.model, printer.price FROM printer
WHERE printer.price = (SELECT MAX(price) FROM printer );

--3--
SELECT * FROM laptop
WHERE laptop.speed < (SELECT MIN(speed) FROM pc);

--4--
SELECT TOP 1 model, MAX(price) AS maximumValue FROM
(SELECT laptop.model, laptop.price as price FROM laptop 
WHERE laptop.price IN (SELECT MAX(laptop.price) FROM laptop)
UNION ALL
SELECT printer.model, printer.price as price  FROM printer 
WHERE printer.price IN (SELECT MAX(printer.price) FROM printer)
UNION ALL
SELECT pc.model, pc.price as price  FROM pc 
WHERE pc.price IN (SELECT MAX(pc.price) FROM pc)) tableName
GROUP BY model, price
ORDER BY price DESC

--5--
SELECT product.maker FROM product
WHERE product.model IN
(SELECT MIN(printer.model) FROM printer 
WHERE printer.color = 'y');

--6--
SELECT product.maker FROM product
WHERE product.model IN(
SELECT pc.model FROM PC WHERE pc.ram IN(SELECT MIN(ram) FROM pc));

--JOINS--
--1--
SELECT product.model, product.maker, product.type FROM PRODUCT LEFT JOIN
pc ON
product.model = pc.model
WHERE (product.type = 'pc' AND pc.model is NULL)
UNION all
SELECT product.model, product.maker, product.type FROM PRODUCT LEFT JOIN
laptop ON
product.model = laptop.model
WHERE (product.type = 'laptop' AND laptop.model is NULL)
UNION all
SELECT product.model, product.maker, product.type FROM PRODUCT LEFT JOIN
printer ON
product.model = printer.model
WHERE (product.type = 'printer' AND printer.model is NULL)  


--2--
SELECT DISTINCT product.maker FROM product JOIN laptop
on product.model = laptop.model 
INTERSECT 
SELECT DISTINCT product.maker FROM product JOIN printer ON 
product.model = printer.model 

--3--
SELECT DISTINCT laptop.hd FROM laptop 
WHERE laptop.hd IN 
(SELECT laptop.hd FROM laptop GROUP BY laptop.hd HAVING COUNT(*) > 1)

--4-- 
SELECT pc.model FROM pc LEFT JOIN product ON
pc.model = product.model
WHERE(product.model IS NULL);

--SIMPLE QUERIES--

--1--
SELECT pc.model, pc.speed AS 'MHZ', pc.hd AS 'GB' FROM pc WHERE (pc.price < 1200);

--2--
SELECT DISTINCT product.maker FROM product WHERE (product.type = 'Printer');

--3--
SELECT laptop.model, laptop.ram, laptop.screen FROM laptop WHERE (laptop.price > 1000);

--4--
SELECT * FROM printer WHERE (printer.color = 'y');

--5--
SELECT pc.model, pc.speed, pc.hd FROM pc WHERE((pc.cd = '12x' OR pc.cd = '16x') AND pc.price < 2000);

--MANY TO MANY RELATIONS--

--1--
SELECT product.maker, laptop.speed FROM product
JOIN laptop ON
product.model = laptop.model
WHERE(laptop.hd > 9);

--2-- ONLY model
SELECT DISTINCT product.model, 
CONCAT(pc.price, printer.price, laptop.price) 
as price FROM product
left join pc ON 
product.model = pc.model
LEFT JOIN laptop ON 
product.model = laptop.model
LEFT JOIN printer ON
product.model = printer.model
WHERE(product.maker = 'B');

--3--
SELECT product.maker
FROM product
GROUP BY maker
HAVING SUM(CASE WHEN type = 'Laptop' THEN 1 ELSE 0 END) > 0
   AND SUM(CASE WHEN type = 'PC' THEN 1 ELSE 0 END) = 0

--4--
SELECT pc.hd ,COUNT(*) AS 'counter' 
FROM pc 
GROUP BY pc.hd
ORDER BY COUNT(*) DESC;

--5--
SELECT t1.model,t2.model,t1.speed,t1.ram 
FROM pc t1 , pc t2 
WHERE (t1.speed = t2.speed and t1.ram = t2.ram and t1.model > t2.model)

--6--
SELECT product.maker AS sequenceCount 
FROM product
JOIN pc ON pc.model = product.model
GROUP BY maker
HAVING SUM(CASE WHEN type = 'PC' THEN 1 ELSE 0 END) > 0






