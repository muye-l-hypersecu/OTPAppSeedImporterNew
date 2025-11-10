-- Creates the table for the token spec
CREATE TABLE IF NOT EXISTS ft_tokeninfo (
	serialNumber VARCHAR(20) PRIMARY KEY,
	seed VARCHAR(128) NOT NULL,
	specId VARCHAR(6) NOT NULL,
	importTime DATETIME DEFAULT (datetime('now', 'localtime')),
	FOREIGN KEY (specID) REFERENCES ft_tokenspec(specID) ON DELETE CASCADE ON UPDATE CASCADE
 );

 -- Creates the table for the token info
 CREATE TABLE IF NOT EXISTS ft_tokenspec (
	specId VARCHAR(6) PRIMARY KEY,
	token_interval INTEGER NOT NULL
 );

 -- Insert the 3 required token spec types
 INSERT OR IGNORE INTO ft_tokenspec(specId, token_interval) VALUES 
	("TOTP30", 30),
	("TOTP60", 60),
	("HOTP", 0);