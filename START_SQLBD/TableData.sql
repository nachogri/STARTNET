-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Getting data for [Logueos]')
--------------------------------------------------

DELETE FROM Logueos
SET IDENTITY_INSERT [Logueos] ON
SET IDENTITY_INSERT [Logueos] OFF
