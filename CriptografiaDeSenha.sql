/*Criação da chave mestra, certificado e chave simétrica*/
CREATE MASTER KEY ENCRYPTION
BY PASSWORD = 'uniinfo'

CREATE CERTIFICATE Certificado
WITH SUBJECT = 'Certificado Uniinfo DESK'

CREATE SYMMETRIC KEY SyKeyUniDesk
WITH ALGORITHM = AES_256
ENCRYPTION BY CERTIFICATE Certificado



/*CRIPTOGRAFAR SENHA*/
OPEN SYMMETRIC KEY SyKeyUniDesk DECRYPTION BY CERTIFICATE Certificado  
DECLARE @GUID UNIQUEIDENTIFIER = (SELECT KEY_GUID ('SyKeyUniDesk'))
INSERT INTO [dbo].[Loginn] VALUES ('1','admin', ENCRYPTBYKEY (@GUID, 'admin'))
SELECT * FROM [dbo].[Loginn]
CLOSE SYMMETRIC KEY SyKeyUniDesk

/*DESCRIPTOGRAFAR SENHA*/
OPEN SYMMETRIC KEY SyKeyUniDesk DECRYPTION BY CERTIFICATE Certificado
select *, senhaDescriptografada = CAST (DECRYPTBYKEY(senha) AS varchar(50)) FROM [dbo].[Loginn]
CLOSE SYMMETRIC KEY SyKeyUniDesk


