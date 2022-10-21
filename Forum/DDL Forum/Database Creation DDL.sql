/*	
	Script that serves the purpose of creating the database if it does not exist.
	Requires FORUM dabatase to exist.
*/

IF DB_ID('FORUM') IS NULL 
BEGIN
	CREATE DATABASE FORUM
END
