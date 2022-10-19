--Needs to be the first script to run--

IF DB_ID('FORUM') IS NULL 
BEGIN
CREATE DATABASE FORUM
END
