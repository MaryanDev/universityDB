USE PintingFactoryDB
GO

SET IDENTITY_INSERT EmpPositions ON
INSERT INTO EmpPositions(Id, PositionTitle, Salary)
VALUES (1, 'Junior pressman', 4000),
	   (2, 'Senior pressman', 8000),
	   (3, 'Engineer', 10000) 
SET IDENTITY_INSERT EmpPositions OFF

SET IDENTITY_INSERT TypesOfMachines ON
INSERT INTO TypesOfMachines(Id, TypeTitle)
VALUES (1, 'Cutting machine'),
	   (2, 'Printing machine'),
	   (3, 'Package machine'),
	   (4, 'Newspaper system'),
	   (5, 'Digital control system') 
SET IDENTITY_INSERT TypesOfMachines OFF

SET IDENTITY_INSERT Persons ON
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (1, 'Edward', 'Mcdonald', '57-(408)898-3259', '94351 Moulton Lane', '12/20/1999');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (2, 'Eric', 'Parker', '81-(803)483-0700', '37379 Melrose Terrace', '9/4/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (3, 'Rachel', 'Little', '57-(413)547-2251', '09620 Haas Place', '7/1/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (4, 'Scott', 'Shaw', '227-(768)636-6528', '51 Summit Avenue', '5/21/1998');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (5, 'Fred', 'Evans', '1-(628)253-4200', '1 Brown Terrace', '6/24/1986');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (6, 'Thomas', 'Ruiz', '224-(307)207-3664', '2 Hagan Circle', '2/9/1967');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (7, 'Christina', 'Martinez', '62-(382)245-6755', '795 Old Shore Street', '10/15/1998');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (8, 'Cynthia', 'Fields', '52-(354)737-1826', '33363 Pond Terrace', '4/6/1994');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (9, 'Kelly', 'Johnston', '51-(626)916-8195', '4630 Eastwood Trail', '10/8/1967');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (10, 'Brenda', 'Hanson', '94-(818)713-0382', '0 Birchwood Road', '8/23/1992');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (11, 'Martin', 'Perez', '7-(745)823-8441', '3 Northland Center', '4/24/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (12, 'Brenda', 'Lopez', '351-(222)360-1009', '59450 Barby Parkway', '8/21/1987');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (13, 'Juan', 'Reyes', '81-(901)394-8080', '09 Clove Court', '2/15/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (14, 'Heather', 'Turner', '254-(931)475-4685', '92 Little Fleur Hill', '11/4/1977');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (15, 'Edward', 'Howell', '1-(218)598-5812', '95505 Mosinee Plaza', '7/5/1984');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (16, 'Sara', 'Smith', '62-(315)906-3431', '26396 Londonderry Street', '4/27/1997');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (17, 'Joe', 'Elliott', '353-(303)682-2913', '3199 Hermina Parkway', '2/28/1994');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (18, 'Linda', 'Cruz', '64-(541)860-3346', '4 Sundown Drive', '12/3/1962');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (19, 'Richard', 'Perry', '51-(104)273-7753', '07 Mallard Crossing', '12/30/1974');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (20, 'Kathy', 'Kelley', '47-(893)257-2899', '19555 Tony Court', '7/18/1986');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (21, 'Robert', 'Rodriguez', '55-(671)943-7035', '577 Meadow Ridge Place', '4/3/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (22, 'Thomas', 'Watkins', '86-(982)661-5068', '2802 Melody Pass', '10/5/1989');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (23, 'Anne', 'Armstrong', '51-(495)217-8143', '69073 Dennis Street', '5/11/1966');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (24, 'Doris', 'Hawkins', '86-(419)565-0501', '1 Vernon Terrace', '8/13/1996');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (25, 'Amy', 'Webb', '33-(131)135-7492', '9312 Roxbury Point', '5/12/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (26, 'Matthew', 'Hunter', '507-(237)824-5678', '1736 Scoville Trail', '1/25/1961');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (27, 'Joyce', 'Mendoza', '7-(617)730-9750', '31 Crownhardt Circle', '6/13/1965');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (28, 'Julie', 'Meyer', '60-(146)249-3200', '5 Spaight Park', '4/29/1965');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (29, 'Brian', 'Franklin', '1-(361)128-0536', '1 Washington Road', '1/10/1964');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (30, 'Kathryn', 'Webb', '233-(298)893-4683', '34468 Gulseth Road', '10/17/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (31, 'Kevin', 'Day', '86-(669)497-8333', '01 Scott Road', '5/18/1996');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (32, 'Susan', 'Williamson', '56-(621)370-4759', '96636 Green Way', '3/5/1966');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (33, 'Randy', 'Hughes', '86-(545)802-7587', '8 Di Loreto Park', '3/8/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (34, 'Richard', 'Dunn', '48-(777)901-4219', '1856 Dovetail Trail', '8/4/2000');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (35, 'James', 'Harvey', '86-(797)137-6158', '9697 Esch Terrace', '10/14/1999');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (36, 'Brandon', 'Stevens', '372-(583)807-1278', '5192 Valley Edge Alley', '12/31/1960');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (37, 'Pamela', 'Moreno', '86-(680)560-9167', '99 Fulton Terrace', '9/26/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (38, 'George', 'Price', '55-(833)396-9446', '94681 Crowley Road', '9/4/1977');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (39, 'Laura', 'Payne', '86-(924)582-6964', '7678 Oxford Place', '9/24/1985');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (40, 'Michael', 'Harrison', '48-(390)671-7039', '77159 Kennedy Lane', '5/22/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (41, 'Doris', 'Wagner', '63-(997)298-9404', '1303 Saint Paul Alley', '4/14/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (42, 'Jason', 'Stevens', '7-(280)259-0667', '1196 Summit Drive', '1/12/1977');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (43, 'Matthew', 'Torres', '66-(756)683-2997', '805 Sutherland Hill', '8/4/1965');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (44, 'Lillian', 'Foster', '229-(286)664-5936', '534 Nelson Park', '11/4/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (45, 'Jerry', 'Fowler', '81-(506)140-4837', '7574 Di Loreto Crossing', '12/22/1991');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (46, 'Ruth', 'Kennedy', '62-(490)279-4697', '81628 Northport Terrace', '5/5/1972');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (47, 'Keith', 'Simmons', '63-(503)683-0767', '10123 Forster Crossing', '1/4/1968');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (48, 'Fred', 'Lawrence', '7-(393)822-5477', '0690 Tomscot Way', '2/20/1999');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (49, 'John', 'Sims', '30-(914)893-2160', '07 Grim Lane', '5/18/1995');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (50, 'Jacqueline', 'Jenkins', '62-(692)385-1783', '90850 Waxwing Park', '2/10/1998');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (51, 'Craig', 'Ortiz', '86-(532)823-7982', '99468 Menomonie Court', '5/28/2000');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (52, 'Jeremy', 'Allen', '33-(243)228-3385', '838 John Wall Court', '9/2/1988');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (53, 'Victor', 'Howard', '86-(862)149-4268', '73257 Bay Park', '2/19/1999');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (54, 'Jose', 'Scott', '86-(529)836-6072', '39959 Texas Road', '7/25/1969');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (55, 'Russell', 'Lawrence', '62-(302)425-8439', '36 Mallard Court', '7/9/1979');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (56, 'Teresa', 'George', '46-(385)788-6993', '16 Barby Plaza', '4/7/1987');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (57, 'Shirley', 'Harvey', '62-(604)925-4386', '21442 Prentice Point', '4/8/1995');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (58, 'Cheryl', 'Garrett', '48-(312)391-0845', '06 Loeprich Circle', '3/11/1981');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (59, 'Craig', 'Riley', '55-(309)478-5797', '787 Toban Circle', '1/11/1977');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (60, 'Evelyn', 'Gordon', '962-(296)495-7044', '55724 Barby Junction', '7/31/1984');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (61, 'Peter', 'Ortiz', '420-(476)209-1063', '01 Mosinee Junction', '3/22/1964');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (62, 'Cheryl', 'Coleman', '358-(579)497-5224', '46035 Buena Vista Junction', '4/5/1967');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (63, 'Shirley', 'Tucker', '351-(732)534-1171', '0292 Blue Bill Park Trail', '4/1/1989');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (64, 'Carl', 'Rodriguez', '62-(922)689-5695', '1007 John Wall Center', '10/26/1977');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (65, 'Judith', 'Anderson', '359-(326)874-4949', '8612 Waxwing Way', '5/6/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (66, 'Antonio', 'Fuller', '86-(463)719-8031', '7 Mendota Trail', '1/27/1965');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (67, 'Scott', 'Richardson', '377-(485)307-5148', '39114 Monterey Hill', '1/27/1970');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (68, 'James', 'Ramos', '55-(110)901-6375', '10 Green Ridge Center', '12/16/1986');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (69, 'Ann', 'Mcdonald', '7-(807)333-0057', '57515 Graedel Lane', '6/24/1963');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (70, 'Albert', 'Daniels', '255-(584)113-9136', '28333 Bluejay Park', '5/23/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (71, 'Helen', 'Barnes', '48-(783)183-0236', '848 Mockingbird Court', '10/29/1992');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (72, 'Marilyn', 'Sanders', '351-(584)737-0786', '055 Corben Terrace', '10/6/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (73, 'Lois', 'Hunter', '506-(633)959-5345', '6 Columbus Crossing', '3/27/1982');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (74, 'Edward', 'Diaz', '81-(965)189-1426', '60596 Sheridan Road', '2/13/1972');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (75, 'Karen', 'George', '86-(129)791-0628', '1 Larry Terrace', '5/22/1966');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (76, 'Keith', 'Thompson', '86-(483)684-0183', '4628 Westerfield Alley', '9/29/1980');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (77, 'Dennis', 'Watkins', '86-(427)713-5842', '52023 Lillian Street', '12/4/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (78, 'Diane', 'Bryant', '86-(896)270-0365', '7 Brickson Park Place', '5/13/1968');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (79, 'Paul', 'Romero', '86-(241)551-3934', '7731 Lukken Road', '1/14/1992');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (80, 'Rebecca', 'Larson', '7-(518)728-7495', '2921 Transport Road', '1/19/1982');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (81, 'Shirley', 'Jones', '86-(239)781-4385', '04 Surrey Plaza', '4/26/1964');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (82, 'Stephen', 'Spencer', '86-(122)480-4546', '2 Scofield Junction', '8/3/1997');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (83, 'Jesse', 'Martin', '62-(548)692-9012', '3 Bunting Trail', '5/14/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (84, 'Mildred', 'Cooper', '420-(303)840-5704', '3 Anderson Pass', '1/30/1978');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (85, 'Timothy', 'Sanders', '30-(720)898-6129', '8278 Jana Avenue', '9/1/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (86, 'Willie', 'Woods', '46-(143)627-2225', '4749 Knutson Alley', '11/23/1985');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (87, 'Scott', 'Edwards', '46-(594)667-9526', '9 Texas Court', '11/5/1961');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (88, 'Philip', 'Myers', '48-(523)998-9333', '2227 Rigney Park', '11/15/1993');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (89, 'Paula', 'Lewis', '81-(699)180-2716', '784 Crownhardt Street', '11/2/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (90, 'Ernest', 'Cunningham', '62-(102)604-6492', '6 Buena Vista Park', '9/13/1982');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (91, 'Lisa', 'Ortiz', '55-(248)740-0254', '8 Jackson Street', '3/8/1979');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (92, 'Nicholas', 'Hawkins', '256-(933)888-8715', '1 Heath Crossing', '7/5/1981');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (93, 'Doris', 'Harrison', '48-(329)663-8718', '3 Cottonwood Way', '10/18/1982');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (94, 'Michael', 'Powell', '55-(398)872-2516', '7 8th Hill', '1/20/1981');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (95, 'Deborah', 'Chavez', '381-(874)636-8282', '7146 Northland Point', '9/15/1967');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (96, 'Eric', 'Lopez', '420-(512)327-5976', '5893 Atwood Road', '1/3/1973');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (97, 'Shirley', 'Kennedy', '51-(432)111-8881', '63970 Veith Crossing', '6/26/1995');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (98, 'Alan', 'Carr', '86-(594)903-1807', '9 Annamark Road', '4/30/1979');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (99, 'Shirley', 'Murphy', '7-(833)886-9850', '88426 Gale Trail', '5/16/1971');
insert into Persons (id, FirstName, LastName, PhoneNumber, [Address], DateOfBirth) values (100, 'Chris', 'Kim', '373-(191)809-6528', '45 Morrow Parkway', '7/8/1991');
SET IDENTITY_INSERT Persons OFF


insert into Customers (PersonId, AccountNumber) values (1, 'AT35 7404 5295 8935 5794');
insert into Customers (PersonId, AccountNumber) values (2, 'FR14 2948 2677 40QQ NWCJ MRSX G54');
insert into Customers (PersonId, AccountNumber) values (3, 'MU49 UQPR 8771 5893 5627 3245 317U SK');
insert into Customers (PersonId, AccountNumber) values (4, 'LV34 YGFD I8JG Y72K 6ZSJ F');
insert into Customers (PersonId, AccountNumber) values (5, 'LI83 0177 9JWT 2XHC H4HL L');
insert into Customers (PersonId, AccountNumber) values (6, 'GE53 ER82 0678 1909 4689 04');
insert into Customers (PersonId, AccountNumber) values (7, 'FR85 2054 6672 00NV LSMO MR6V P14');
insert into Customers (PersonId, AccountNumber) values (8, 'SM29 W512 8034 659Y PLYZ M1AT GG3');
insert into Customers (PersonId, AccountNumber) values (9, 'CY70 5323 3672 CQKF HRXJ GBMR YGXY');
insert into Customers (PersonId, AccountNumber) values (10, 'FR16 4214 9771 34FF E6T3 OY4P W96');
insert into Customers (PersonId, AccountNumber) values (11, 'HU70 4379 4470 1639 5982 7749 3720');
insert into Customers (PersonId, AccountNumber) values (12, 'CR02 6034 2826 7159 9580 9');
insert into Customers (PersonId, AccountNumber) values (13, 'FR98 0377 5617 95EJ OTM7 V53T E36');
insert into Customers (PersonId, AccountNumber) values (14, 'DO03 JX48 8653 8901 9514 7857 9373');
insert into Customers (PersonId, AccountNumber) values (15, 'ME60 0196 1336 9861 1446 00');
insert into Customers (PersonId, AccountNumber) values (16, 'LV29 BRVA SLFX RJGB 4EBA Y');
insert into Customers (PersonId, AccountNumber) values (17, 'IT81 K430 8223 071F CCUQ VXTG LMY');
insert into Customers (PersonId, AccountNumber) values (18, 'FR16 2376 6148 15DI CWJN WPBC 078');
insert into Customers (PersonId, AccountNumber) values (19, 'FR29 6887 3512 60KW ZI2R MNAV 764');
insert into Customers (PersonId, AccountNumber) values (20, 'SA63 62QD IW4V M5KN NQUL JGWX');
insert into Customers (PersonId, AccountNumber) values (21, 'FR65 4061 6331 25I7 JHF6 4FNR E48');
insert into Customers (PersonId, AccountNumber) values (22, 'ES73 9488 6728 7933 2560 4088');
insert into Customers (PersonId, AccountNumber) values (23, 'AL64 7569 4095 BK4K YRQV CWQ5 EE3Z');
insert into Customers (PersonId, AccountNumber) values (24, 'SE86 1870 9477 5348 1234 2911');
insert into Customers (PersonId, AccountNumber) values (25, 'SM78 H131 3354 413I ZK3L FPNE RPA');
insert into Customers (PersonId, AccountNumber) values (26, 'DO89 HGUX 0875 1520 7903 5127 7889');
insert into Customers (PersonId, AccountNumber) values (27, 'EE90 7136 7722 5463 7063');
insert into Customers (PersonId, AccountNumber) values (28, 'SI83 0306 9964 6330 839');
insert into Customers (PersonId, AccountNumber) values (29, 'SE68 2910 5970 5546 3296 1327');
insert into Customers (PersonId, AccountNumber) values (30, 'RO17 KLZT AF4I SIFN YVXI NHCZ');
insert into Customers (PersonId, AccountNumber) values (31, 'SI79 3932 4639 3385 046');
insert into Customers (PersonId, AccountNumber) values (32, 'FR30 8297 9552 838B GPTU BUKQ W49');
insert into Customers (PersonId, AccountNumber) values (33, 'AT35 3911 7340 6062 1080');
insert into Customers (PersonId, AccountNumber) values (34, 'MU58 LTJP 7469 9215 9230 7491 157X SN');
insert into Customers (PersonId, AccountNumber) values (35, 'GT04 PNUJ MZEO C1AR HOZS AKJA UUBZ');
insert into Customers (PersonId, AccountNumber) values (36, 'ME96 7561 9621 2569 6238 45');
insert into Customers (PersonId, AccountNumber) values (37, 'MK67 464J VTKS 4X6T Q69');
insert into Customers (PersonId, AccountNumber) values (38, 'SA21 28FF OEPM ZHSY ABKI KCPX');
insert into Customers (PersonId, AccountNumber) values (39, 'FR87 2116 7431 85TG YGB1 LR7E F74');
insert into Customers (PersonId, AccountNumber) values (40, 'GB92 NSHC 8403 1067 1747 00');

insert into Employees (PersonId, PositionId) values (41, 3);
insert into Employees (PersonId, PositionId) values (42, 2);
insert into Employees (PersonId, PositionId) values (43, 2);
insert into Employees (PersonId, PositionId) values (44, 1);
insert into Employees (PersonId, PositionId) values (45, 3);
insert into Employees (PersonId, PositionId) values (46, 2);
insert into Employees (PersonId, PositionId) values (47, 1);
insert into Employees (PersonId, PositionId) values (48, 3);
insert into Employees (PersonId, PositionId) values (49, 1);
insert into Employees (PersonId, PositionId) values (50, 2);
insert into Employees (PersonId, PositionId) values (51, 3);
insert into Employees (PersonId, PositionId) values (52, 3);
insert into Employees (PersonId, PositionId) values (53, 2);
insert into Employees (PersonId, PositionId) values (54, 1);
insert into Employees (PersonId, PositionId) values (55, 2);
insert into Employees (PersonId, PositionId) values (56, 2);
insert into Employees (PersonId, PositionId) values (57, 1);
insert into Employees (PersonId, PositionId) values (58, 2);
insert into Employees (PersonId, PositionId) values (59, 3);
insert into Employees (PersonId, PositionId) values (60, 1);
insert into Employees (PersonId, PositionId) values (61, 2);
insert into Employees (PersonId, PositionId) values (62, 2);
insert into Employees (PersonId, PositionId) values (63, 3);
insert into Employees (PersonId, PositionId) values (64, 3);
insert into Employees (PersonId, PositionId) values (65, 1);
insert into Employees (PersonId, PositionId) values (66, 1);
insert into Employees (PersonId, PositionId) values (67, 1);
insert into Employees (PersonId, PositionId) values (68, 2);
insert into Employees (PersonId, PositionId) values (69, 2);
insert into Employees (PersonId, PositionId) values (70, 1);
insert into Employees (PersonId, PositionId) values (71, 2);
insert into Employees (PersonId, PositionId) values (72, 3);
insert into Employees (PersonId, PositionId) values (73, 1);
insert into Employees (PersonId, PositionId) values (74, 2);
insert into Employees (PersonId, PositionId) values (75, 2);
insert into Employees (PersonId, PositionId) values (76, 3);
insert into Employees (PersonId, PositionId) values (77, 1);
insert into Employees (PersonId, PositionId) values (78, 2);
insert into Employees (PersonId, PositionId) values (79, 1);
insert into Employees (PersonId, PositionId) values (80, 2);
insert into Employees (PersonId, PositionId) values (81, 3);
insert into Employees (PersonId, PositionId) values (82, 2);
insert into Employees (PersonId, PositionId) values (83, 2);
insert into Employees (PersonId, PositionId) values (84, 1);
insert into Employees (PersonId, PositionId) values (85, 1);
insert into Employees (PersonId, PositionId) values (86, 2);
insert into Employees (PersonId, PositionId) values (87, 2);
insert into Employees (PersonId, PositionId) values (88, 3);
insert into Employees (PersonId, PositionId) values (89, 1);
insert into Employees (PersonId, PositionId) values (90, 2);
insert into Employees (PersonId, PositionId) values (91, 3);
insert into Employees (PersonId, PositionId) values (92, 3);
insert into Employees (PersonId, PositionId) values (93, 3);
insert into Employees (PersonId, PositionId) values (94, 3);
insert into Employees (PersonId, PositionId) values (95, 3);
insert into Employees (PersonId, PositionId) values (96, 1);
insert into Employees (PersonId, PositionId) values (97, 3);
insert into Employees (PersonId, PositionId) values (98, 2);
insert into Employees (PersonId, PositionId) values (99, 1);
insert into Employees (PersonId, PositionId) values (100, 3);


SET IDENTITY_INSERT PrintingMachines ON
INSERT INTO PrintingMachines(Id, Model, Price, MachineTypeId, EmployeeInChargeId)
VALUES
(1, 'Ventura MC Digital', 1000000, 5, 98),
(2, 'PC-P43 Electric Paper Cutter', 140098, 1, 90),
(3, 'Speedmaster XL 106', 14396803, 2, 87),
(4, 'AlphaLiner', 14396803, 4, 56),
(5, 'CH802-1200F', 30000, 3, 42)
SET IDENTITY_INSERT PrintingMachines OFF

SET IDENTITY_INSERT MachinesForRepair ON
INSERT INTO MachinesForRepair(Id, CostOfRepair, MachineId, RepairStartDate, RepairFinishDate)
VALUES
(1, 10000, 2, '10/07/2016', null)
SET IDENTITY_INSERT MachinesForRepair OFF

SET IDENTITY_INSERT Products ON
INSERT INTO Products(Id, Title, Cost)
VALUES
(1, 'Book', 100),
(2, 'Magazine', 80),
(3, 'Newspaper', 50),
(4, 'Brochure', 35),
(5, 'Poster', 140),
(6, 'Billboard', 300),
(7, 'Blue print', 70),
(8, 'Cup print', 30),
(9, 'Notebook', 45),
(10, 'T-shirt print', 70),
(11, 'Packages XS', 20),
(12, 'Packages S', 30),
(13, 'Packages M', 40),
(14, 'Packages L', 50),
(15, 'Packages XL', 60),
(16, 'Packages XXL', 80)
SET IDENTITY_INSERT Products OFF

SET IDENTITY_INSERT Orders ON
insert into Orders (Id, Quantity, CustomerId, ProductId) values (1, 76, 4, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (2, 79, 32, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (3, 104, 20, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (4, 104, 9, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (5, 112, 10, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (6, 68, 25, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (7, 24, 29, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (8, 53, 34, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (9, 76, 33, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (10, 119, 6, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (11, 9, 21, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (12, 15, 6, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (13, 105, 37, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (14, 149, 19, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (15, 135, 7, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (16, 65, 9, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (17, 137, 16, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (18, 136, 16, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (19, 144, 38, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (20, 42, 1, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (21, 20, 8, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (22, 122, 17, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (23, 102, 21, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (24, 96, 26, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (25, 95, 2, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (26, 77, 21, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (27, 127, 23, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (28, 118, 9, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (29, 103, 24, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (30, 101, 34, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (31, 62, 5, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (32, 38, 14, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (33, 143, 10, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (34, 121, 39, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (35, 68, 24, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (36, 19, 17, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (37, 84, 20, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (38, 107, 18, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (39, 14, 20, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (40, 142, 15, 4);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (41, 119, 26, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (42, 67, 39, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (43, 48, 26, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (44, 71, 21, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (45, 48, 39, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (46, 68, 17, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (47, 123, 15, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (48, 12, 29, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (49, 83, 14, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (50, 86, 6, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (51, 55, 36, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (52, 97, 16, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (53, 62, 25, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (54, 34, 1, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (55, 123, 37, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (56, 2, 19, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (57, 92, 39, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (58, 93, 2, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (59, 119, 19, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (60, 59, 40, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (61, 15, 2, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (62, 78, 8, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (63, 86, 11, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (64, 1, 37, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (65, 121, 18, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (66, 16, 22, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (67, 109, 17, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (68, 98, 25, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (69, 143, 11, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (70, 133, 25, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (71, 51, 38, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (72, 14, 6, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (73, 54, 39, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (74, 37, 2, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (75, 2, 3, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (76, 56, 6, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (77, 43, 36, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (78, 62, 5, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (79, 9, 25, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (80, 100, 31, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (81, 11, 2, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (82, 117, 25, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (83, 131, 18, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (84, 74, 11, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (85, 65, 34, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (86, 98, 11, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (87, 113, 1, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (88, 1, 12, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (89, 108, 6, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (90, 9, 7, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (91, 131, 18, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (92, 9, 7, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (93, 145, 37, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (94, 91, 21, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (95, 134, 25, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (96, 137, 28, 16);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (97, 15, 21, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (98, 145, 28, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (99, 82, 38, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (100, 2, 21, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (101, 72, 1, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (102, 37, 19, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (103, 102, 12, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (104, 45, 33, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (105, 33, 18, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (106, 83, 35, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (107, 56, 36, 15);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (108, 30, 16, 11);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (109, 147, 22, 4);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (110, 83, 31, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (111, 28, 5, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (112, 10, 30, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (113, 58, 33, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (114, 121, 5, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (115, 16, 31, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (116, 52, 5, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (117, 86, 14, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (118, 90, 16, 4);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (119, 3, 10, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (120, 139, 22, 2);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (121, 17, 35, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (122, 18, 4, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (123, 108, 4, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (124, 44, 12, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (125, 4, 15, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (126, 109, 1, 4);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (127, 99, 28, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (128, 62, 35, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (129, 1, 4, 9);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (130, 94, 1, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (131, 53, 36, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (132, 87, 25, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (133, 17, 2, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (134, 107, 4, 12);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (135, 72, 6, 5);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (136, 83, 22, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (137, 118, 8, 7);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (138, 144, 14, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (139, 53, 37, 13);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (140, 64, 18, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (141, 92, 8, 8);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (142, 80, 10, 4);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (143, 93, 3, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (144, 147, 13, 1);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (145, 18, 21, 10);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (146, 4, 32, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (147, 144, 26, 3);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (148, 82, 4, 14);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (149, 109, 14, 6);
insert into Orders (Id, Quantity, CustomerId, ProductId) values (150, 10, 1, 6);

SET IDENTITY_INSERT Orders OFF


SET IDENTITY_INSERT ProductsToMachines ON
INSERT INTO ProductsToMachines(Id, MachineId, ProductId)
VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 2, 4),
(5, 2, 5),
(6, 2, 6),
(7, 3, 7),
(8, 3, 8),
(9, 3, 9),
(10, 4, 10),
(11, 4, 11),
(12, 4, 12),
(13, 5, 13),
(14, 5, 14),
(15, 5, 15),
(16, 5, 16)
SET IDENTITY_INSERT ProductsToMachines OFF

INSERT INTO AspNetUsers (Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
VALUES ('895a1c64-5889-4027-88c6-2931cb1a5acd', NULL, 'mr.maykher@gmail.com', 0, 'ALCpaL7HIm4MONiE0fUbUKff/lDaY4AJYGF9/xJK5g7xZyR2GUcoyoDwnBfTOsDtYw==', 'fbb7e0df-731f-498a-b7e2-5ea9a31118fe', NULL, 0, 0, null, 0, 0, 'MaryanDev')