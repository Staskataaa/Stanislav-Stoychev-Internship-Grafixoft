GO
if exists (select * from sysdatabases where name='Musical Collection DB')
	DROP DATABASE [Musical Collection DB]
GO
USE master

CREATE DATABASE [Musical Collection DB]
GO
USE [Musical Collection DB]
GO

CREATE TABLE ALBUM(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
NAME VARCHAR(255) NOT NULL);

CREATE TABLE GENRES(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
GENRE VARCHAR(255) NOT NULL); 

CREATE TABLE SONGS(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
NAME VARCHAR(255) NOT NULL UNIQUE,
DURATION TIME(0) NOT NULL, 
RELEASE_DATE DATE NOT NULL,
ALBUM_ID int FOREIGN KEY(ALBUM_ID) REFERENCES ALBUM(ID) NULL);

CREATE TABLE PLAYLIST(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
NAME VARCHAR(255) NOT NULL,
CREATOR VARCHAR(255) NOT NULL);

CREATE TABLE LISTENER(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
USERNAME VARCHAR(255) NOT NULL UNIQUE, 
PASSWORD VARCHAR(255) NOT NULL,
FULLNAME VARCHAR(255) NOT NULL,
BIRTHDATE DATE NOT NULL,
ACTIVE BIT NOT NULL);

CREATE TABLE AUTHOR(
ID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
USERNAME VARCHAR(255) NOT NULL UNIQUE, 
PASSWORD VARCHAR(255) NOT NULL,
FULLNAME VARCHAR(255) NOT NULL,
BIRTHDATE DATE NOT NULL,
ACTIVE BIT NOT NULL)

CREATE TABLE SONGS_IN_PLAYLIST(
PLAYLIST_ID int,
SONG_ID int,
CONSTRAINT SONG_IN_PLAYLIST_PK PRIMARY KEY(PLAYLIST_ID, SONG_ID),
CONSTRAINT FK_PLAYLIST_ID FOREIGN KEY(PLAYLIST_ID) REFERENCES PLAYLIST(ID),
CONSTRAINT FK_SONG_ID FOREIGN KEY(SONG_ID) REFERENCES SONGS(ID));

CREATE TABLE PLAYLIST_OF_LISTENER(
PLAYLIST_ID int,
LISTENER_ID int,
CONSTRAINT LISTENER_PLAYLISTS_PK PRIMARY KEY(PLAYLIST_ID, LISTENER_ID),
CONSTRAINT FK_PLAYLIST_LISTENER_ID FOREIGN KEY(PLAYLIST_ID) REFERENCES PLAYLIST(ID) ON DELETE CASCADE,
CONSTRAINT FK_LISNERER_PLAYLYST_ID FOREIGN KEY(LISTENER_ID) REFERENCES LISTENER(ID) ON DELETE CASCADE);

CREATE TABLE ALBUMS_OF_AUTHORS(
AUTHOR_ID int,
ALBUM_ID int,
CONSTRAINT ARTIST_ALBUMS_PK PRIMARY KEY(ALBUM_ID, AUTHOR_ID),
CONSTRAINT FK_ALBUM_ID FOREIGN KEY(ALBUM_ID) REFERENCES ALBUM(ID) ON DELETE CASCADE,
CONSTRAINT FK_AUTHOR_ID FOREIGN KEY(AUTHOR_ID) REFERENCES AUTHOR(ID) ON DELETE CASCADE);

CREATE TABLE SONGS_OF_AUTHOR(
AUTHOR_ID int,
SONG_ID int,
CONSTRAINT SONGS_OF_ARTIST_PK PRIMARY KEY(SONG_ID, AUTHOR_ID),
CONSTRAINT FK_SONG_OF_ARTIST_ID FOREIGN KEY(SONG_ID) REFERENCES SONGS(ID) ON DELETE CASCADE,
CONSTRAINT FK_AUTHOR_OF_SONG_ID FOREIGN KEY(AUTHOR_ID) REFERENCES AUTHOR(ID) ON DELETE CASCADE);

CREATE TABLE LISTENER_FAVOURITE_GENRES(
LISTENER_ID int,
GENRE_ID int,
CONSTRAINT LISTENER_FAVOURITE_GENRES_PK PRIMARY KEY(LISTENER_ID, GENRE_ID),
CONSTRAINT FK_LISTENER_ID FOREIGN KEY(LISTENER_ID) REFERENCES LISTENER(ID) ON DELETE CASCADE,
CONSTRAINT FK_FAVOURITE_GENRES_ID FOREIGN KEY(GENRE_ID) REFERENCES GENRES(ID) ON DELETE CASCADE);

CREATE TABLE LISTENER_FAVOURITE_SONGS(
LISTENER_ID int,
SONG_ID int,
CONSTRAINT LISTENER_FAVOURITE_SONGS_PK PRIMARY KEY(LISTENER_ID, SONG_ID),
CONSTRAINT FK_LISTENER_FAVOURITE_SONGS_ID FOREIGN KEY(LISTENER_ID) REFERENCES LISTENER(ID) ON DELETE CASCADE,
CONSTRAINT FK_FAVOURITE_SONGS_ID FOREIGN KEY(SONG_ID) REFERENCES SONGS(ID) ON DELETE CASCADE);

CREATE TABLE SONG_GENRES(
SONG_ID int, 
GENRE_ID int,
CONSTRAINT SONG_GENRES_PK PRIMARY KEY(SONG_ID, GENRE_ID),
CONSTRAINT FK_SONG_IN_SONG_GENRE_FK FOREIGN KEY(SONG_ID) REFERENCES SONGS(ID) ON DELETE CASCADE,
CONSTRAINT FK_GENRE_IN_SONG_GENRES_FK FOREIGN KEY(GENRE_ID) REFERENCES GENRES(ID) ON DELETE CASCADE);

