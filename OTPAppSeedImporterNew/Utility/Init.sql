-- Creates the table for the token spec
CREATE TABLE IF NOT EXISTS ft_tokeninfo (
	serialNumber INTEGER PRIMARY KEY,
	seed VARCHAR(64) NOT NULL,
	specId VARCHAR(6) NOT NULL,
	importTime DATETIME DEFAULT (datetime('now', 'localtime')),
	FOREIGN KEY (specID) REFERENCES tokenSpec(specID) ON DELETE CASCADE ON UPDATE CASCADE
 );

 -- Creates the table for the token info
 CREATE TABLE IF NOT EXISTS ft_tokenspec (
	specId VARCHAR(6) PRIMARY KEY,
	intervalLength INTEGER
 );

 -- Insert the 3 required token spec types
 INSERT OR IGNORE INTO ft_tokenspec(specId, intervalLength) VALUES 
	("TOTP30", 30),
	("TOTP60", 60),
	("HOTP", 0);