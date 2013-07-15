-- Change the database here
USE [START_SQLBD]
GO

--------------------------------------------------
PRINT ('Getting data for [Monedas]')
--------------------------------------------------

DELETE FROM Monedas
SET IDENTITY_INSERT [Monedas] ON
INSERT INTO [Monedas]
(
[mon_id],
[mon_nombre],
[mon_simbolo],
[mon_cambio_dolar]
)
VALUES
(
1,
'Pesos',
'$',
4.20
)
INSERT INTO [Monedas]
(
[mon_id],
[mon_nombre],
[mon_simbolo],
[mon_cambio_dolar]
)
VALUES
(
2,
'Dolares',
'US$',
1.00
)
SET IDENTITY_INSERT [Monedas] OFF
