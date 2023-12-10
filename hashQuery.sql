UPDATE userlog
SET password = CONVERT(varchar(64),
HASHBYTES('MD5',password),2)

SELECT * FROM userlog