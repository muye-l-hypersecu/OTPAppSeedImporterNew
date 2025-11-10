-- IF DATABASE IS NOT INITIALZIED YET, RUN THE SQL BELOW!!

-- Creates the table for the token info
CREATE TABLE ft_tokeninfo (
    tknid  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    token  varchar(32) NOT NULL,
    pubkey  varchar(1024) NOT NULL DEFAULT '',
    authnum  varchar(32) DEFAULT '0',
    physicaltype  INTEGER DEFAULT 0,
    producttype  INTEGER DEFAULT 0,
    specid  varchar(32) NOT NULL,
    importtime  INTEGER DEFAULT 0,
    pubkeystate  INTEGER DEFAULT 0,
    pubkeyfactor  varchar(128),
    tknifmid  INTEGER NOT NULL,
    tknofmid  INTEGER NOT NULL,
    crust  varchar(32),
    tknexttype  varchar(128),
    tkntype  INTEGER NOT NULL,
    tknstate  INTEGER,
    tksendnumber  varchar(64),
    tknvaliddate  INTEGER,
    CONSTRAINT fk_tkninfo_tknspec_specid FOREIGN KEY (specid) REFERENCES "ft_tokenspec" (specid) ON DELETE CASCADE ON UPDATE CASCADE,
    UNIQUE (token ASC)
);

-- Creates the table for the token spec
CREATE TABLE ft_tokenspec (
  specid varchar(32) PRIMARY KEY not null,
  tokentype INTEGER(10) default 0,
  algid INTEGER(10) default 0,
  signsuite varchar(64) default '',
  cvssuite varchar(64) default '',
  crsuite varchar(64) default '',
  atid varchar(16) default '',
  otplen INTEGER(10) default 0,
  intervaltime INTEGER(10) default 0,
  begintime INTEGER(10) default 0,
  maxauthcnt INTEGER(10) default 0,
  initauthnum INTEGER(10) default 0,
  haformat INTEGER(10) default 0,
  halen INTEGER(10) default 0,
  cardrow INTEGER(10) default 0,
  cardcol INTEGER(10) default 0,
  rowstart varchar(2) default 'A',
  colstart varchar(2) default '1',
  updatemode INTEGER(10) default 0,
  updatelimit INTEGER(10) default 0,
  updateresplen INTEGER(10) default 0,
  puk1mode INTEGER(10) default 0,
  puk1len INTEGER(10) default 0,
  puk1itv INTEGER(10) default 0,
  puk2mode INTEGER(10) default 0,
  puk2len INTEGER(10) default 0,
  puk2itv INTEGER(10) default 0,
  maxcounter INTEGER(10) default 0,
  syncmode INTEGER(10) default 0,
  descp varchar(255)
);

 -- Insert the 3 required token spec types
 INSERT INTO ft_tokenspec (specid) VALUES 
    ('TOTP30'),
    ('TOTP60'),
    ('HOTP');
