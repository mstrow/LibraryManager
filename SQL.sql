DROP DATABASE IF EXISTS LibraryDB;
CREATE DATABASE LibraryDB;
USE LibraryDB;

DELIMITER //
DROP PROCEDURE IF EXISTS createSchema//

CREATE PROCEDURE createSchema()
BEGIN

	CREATE TABLE tbl_Book (
	    ID int NOT NULL AUTO_INCREMENT,
	    LibraryID int NOT NULL,
	    ISBN varchar(13) NOT NULL,
	    Title varchar(255) NOT NULL,
	    Author varchar(128) NOT NULL,
	    `Year` int NOT NULL,
	    BookType int NOT NULL,
	    `Description` varchar(512) NOT NULL,
	    Cost decimal(15,2) DEFAULT 0.00 NOT NULL,
	    ImageURL varchar(255),
	    LastModified DATETIME NOT NULL,
	    IssueDate DATETIME,
	    Pages int,
	    Size varchar(10),
	    PRIMARY KEY (ID)
	);
	CREATE TABLE tbl_Library (
	    ID int NOT NULL AUTO_INCREMENT,
	    `Name` varchar(128) NOT NULL,
	    `Location` varchar(128) NOT NULL,
	    PRIMARY KEY (ID)
	);
	CREATE TABLE tbl_Customer (
	  ID int NOT NULL AUTO_INCREMENT,
	  LibraryID int NOT NULL,
	 `Name` varchar(255) NOT NULL,
	 `Address` varchar(128) NOT NULL,
	 `Phone` varchar(25) NOT NULL,
	  PRIMARY KEY (ID)
	);
	CREATE TABLE tbl_Reservation (
	  ID int NOT NULL AUTO_INCREMENT,
	  BookID int NOT NULL,
	  LibraryID int NOT NULL,
	  CustomerID int NOT NULL,
	  `Date` DATETIME NOT NULL,
	  PRIMARY KEY (ID)
    );
	ALTER TABLE
	  tbl_Book
	ADD
	  CONSTRAINT FK_Book_Library FOREIGN KEY (LibraryID) REFERENCES tbl_Library (ID) ON UPDATE CASCADE;

	ALTER TABLE
	  tbl_Customer
	ADD
	  CONSTRAINT FK_Customer_Library FOREIGN KEY (LibraryID) REFERENCES tbl_Library (ID) ON UPDATE CASCADE;

	ALTER TABLE
	  tbl_Reservation
	ADD
	  CONSTRAINT FK_Reservation_Book FOREIGN KEY (BookID) REFERENCES tbl_Book (ID) ON DELETE CASCADE ON UPDATE CASCADE;

	ALTER TABLE
	  tbl_Reservation
	ADD
	  CONSTRAINT FK_Reservation_Customer FOREIGN KEY (CustomerID) REFERENCES tbl_Customer (ID) ON UPDATE CASCADE;

	ALTER TABLE
	  tbl_Reservation
	ADD
	  CONSTRAINT FK_Reservation_Library FOREIGN KEY (LibraryID) REFERENCES tbl_Library (ID) ON UPDATE CASCADE;


END //
DELIMITER ;

CALL createSchema();


DELIMITER /!
DROP PROCEDURE IF EXISTS insertSchema/!

CREATE PROCEDURE insertSchema()
BEGIN
    insert into tbl_Library (Name, Location) values ('Doxazosin', 'Neuville');
    insert into tbl_Library (Name, Location) values ('MISSHA M VITA BB', 'Rzewnie');
    insert into tbl_Library (Name, Location) values ('Hydroxyzine Hydrochloride', 'Malasiqui');
    insert into tbl_Library (Name, Location) values ('Retavase', 'Boli');
    insert into tbl_Library (Name, Location) values ('Body Pure', 'Laoag');
    insert into tbl_Library (Name, Location) values ('Minocycline hydrochloride', 'Wenfu');
    insert into tbl_Library (Name, Location) values ('XtraCare Instant Hand Sanitizer', 'Sainte-Adèle');
    insert into tbl_Library (Name, Location) values ('DIANEAL Low Calcium with Dextrose', 'Colcabamba');
    insert into tbl_Library (Name, Location) values ('LANEIGE SATIN FINISH TWIN PACT NO. 23', 'Ocucaje');
    insert into tbl_Library (Name, Location) values ('Potassium Chloride in Dextrose and Sodium Chloride', 'Radom');
    insert into tbl_Library (Name, Location) values ('Zolvit', 'Maputsoe');

    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (8, 'Mirilla Insole', '330 Hallows Alley', '(633) 1186399');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (9, 'Talbert Hains', '5269 Crowley Place', '(951) 2354608');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (2, 'Petronella Elwell', '0398 Orin Court', '(141) 1152327');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (5, 'Thalia MacPeake', '31 Vahlen Hill', '(609) 9094040');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (5, 'Korney Ricardo', '935 Mccormick Avenue', '(337) 9669533');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (8, 'Felicio Deble', '897 Kennedy Parkway', '(161) 9723492');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (1, 'Rose Layman', '3040 Melvin Circle', '(630) 5256294');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (2, 'Barnaby Jahndel', '93134 Springs Alley', '(877) 3829540');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (3, 'Corbie Domingues', '4 Hanson Plaza', '(565) 1099898');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (1, 'Everett Kidsley', '44 Sugar Avenue', '(922) 8763440');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (1, 'Bryant Bier', '51920 Jenna Way', '(128) 5214402');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (5, 'Rowe Vasilkov', '9 Armistice Junction', '(364) 4412826');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (9, 'Amble Hammerberg', '14527 Messerschmidt Parkway', '(348) 4163820');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (2, 'Jaclyn Pickrill', '480 Lakewood Gardens Parkway', '(115) 5242561');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (8, 'Samson Caisley', '1 Mcbride Place', '(660) 7858264');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (9, 'Reade Kalkofer', '958 Lakewood Park', '(822) 6208003');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (6, 'Nicolis Bellam', '170 Ridgeview Street', '(119) 8664858');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (7, 'Culver Woolf', '98012 Hollow Ridge Avenue', '(342) 7965824');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (3, 'Ronni Mangon', '99550 Petterle Pass', '(321) 9492960');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (10, 'Ivett Worwood', '255 Clemons Terrace', '(117) 4411514');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (1, 'Gal Taphouse', '40 Sunfield Plaza', '(767) 2317429');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (10, 'Ernaline Wingeatt', '66283 Tomscot Terrace', '(366) 5364153');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (8, 'Garry Fodden', '78244 Union Alley', '(281) 5594688');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (4, 'Imogen Burghill', '7892 Sauthoff Drive', '(441) 2776743');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (5, 'Marwin Densell', '53726 Lakewood Hill', '(422) 4299215');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (9, 'Ryon Bernaldez', '47613 Maywood Drive', '(694) 1944181');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (6, 'Dominica Boag', '2 Sundown Crossing', '(866) 4773108');
    insert into tbl_Customer (LibraryID, Name, Address, Phone) values (9, 'Ronica Dolton', '47986 Pepper Wood Crossing', '(489) 5587928');

    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (1, 7, '378986704-7', 'Brother''s Keeper', 'Patricio Jeffes', 2008, 3, 'Congenital fistula of rectum and anus', 6.32, 'http://dummyimage.com/175x100.png/dddddd/000000', '2021-05-18 07:55:39');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (2, 3, '226467623-X', 'Child''s Play 2', 'Minny Screaton', 2006, 2, 'Oth injury of vein at forearm level, unspecified arm', 9.62, 'http://dummyimage.com/199x100.png/dddddd/000000', '2020-10-21 11:38:15');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (3, 1, '020073208-0', 'Capital (Le capital)', 'Kathye Quibell', 2009, 1, 'Subluxation of tarsometatarsal joint of unsp foot, subs', 7.92, 'http://dummyimage.com/143x100.png/cc0000/ffffff', '2021-08-25 00:56:37');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (4, 7, '422584530-3', 'My Soul to Take', 'Sergei Jersch', 2012, 2, 'Unsp open wound of l mid finger w/o damage to nail, init', 4.18, null, '2021-01-26 16:57:31');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (5, 7, '254219437-8', 'Prisoner, The (Island of Fire) (Huo shao dao)', 'Sax Lembcke', 2008, 3, 'Injury of trochlear nerve, left side, initial encounter', 1.11, null, '2022-01-29 02:32:57');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (6, 8, '632445876-8', 'Dead Zone, The', 'Marianna Papaminas', 2001, 3, 'Unspecified sprain of right wrist, subsequent encounter', 3.04, 'http://dummyimage.com/242x100.png/5fa2dd/ffffff', '2020-06-17 19:39:40');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (7, 2, '692857575-1', 'Rigor Mortis (Geung si)', 'Letitia Dawidowicz', 1997, 1, 'Unsp fx the low end l rad, 7thJ', 7.4, 'http://dummyimage.com/206x100.png/cc0000/ffffff', '2021-08-08 18:13:33');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (8, 7, '723762890-9', 'Johnny English', 'Ode Mulbery', 1996, 2, 'Partial traumatic amputation of penis, subsequent encounter', 3.81, 'http://dummyimage.com/250x100.png/cc0000/ffffff', '2020-10-15 18:20:18');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (9, 2, '325073929-4', 'Pawnbroker, The', 'Jarvis Swan', 2013, 3, 'Other superficial bite of lower back and pelvis', 1.95, null, '2020-04-30 22:13:05');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (10, 2, '298167836-1', 'Robe, The', 'Dian Croxon', 2011, 2, 'Type 2 diabetes mellitus with hyperosmolarity', 6.72, 'http://dummyimage.com/247x100.png/cc0000/ffffff', '2021-01-17 16:24:07');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (11, 8, '881552320-0', 'Baby Doll', 'Fanechka Simonsen', 1985, 1, 'Abrasion of breast, right breast, subsequent encounter', 8.76, 'http://dummyimage.com/202x100.png/ff4444/ffffff', '2021-10-05 16:19:18');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (12, 6,'693475685-1', 'Frenchmen (Le coeur des hommes)', 'Hally Temperley', 1995, 2, 'Brown''s sheath syndrome', 5.24, 'http://dummyimage.com/229x100.png/ff4444/ffffff', '2021-04-09 08:29:21');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (13, 2, '101704326-4', 'How to Eat Your Watermelon in White Company (and Enjoy It)', 'Ivett Livingston', 2002, 3, 'Maternal care for oth fetal abnormality and damage, fetus 4', 3.88, 'http://dummyimage.com/223x100.png/5fa2dd/ffffff', '2021-09-20 00:13:59');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (14, 5, '058670516-3', 'Fanboys', 'Kennett Cirlos', 2008, 2, 'Oth bacterial foodborne intoxications, NEC', 4.46, 'http://dummyimage.com/243x100.png/cc0000/ffffff', '2021-11-30 22:53:05');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (15, 7, '107293414-0', 'American Pie Presents: Band Camp (American Pie 4: Band Camp)', 'Igor Lalevee', 2001, 2, 'Unsp dislocation of left sternoclavicular joint, init encntr', 4.74, 'http://dummyimage.com/159x100.png/dddddd/000000', '2020-07-21 01:42:59');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (16, 3, '688667914-7', 'From the Orient with Fury', 'Berk Cotterill', 1999, 1, 'Poisoning by oral contraceptives, undetermined, subs encntr', 8.42, 'http://dummyimage.com/100x100.png/5fa2dd/ffffff', '2020-12-26 01:28:51');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (17, 2, '918415869-7', 'Man on a Ledge', 'Francklyn Brennen', 1984, 3, 'Perf due to fb acc left in body fol remov cath/pack, subs', 3.34, 'http://dummyimage.com/169x100.png/cc0000/ffffff', '2020-07-05 00:37:23');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (18, 1, '885784764-0', 'Look of Love, The', 'Keeley Burnall', 2006, 1, 'Fx unsp prt of nk of unsp femr, 7thH', 8.25, 'http://dummyimage.com/149x100.png/dddddd/000000', '2022-03-27 01:29:30');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (19, 5, '148235384-9', 'Dr. Jack', 'Hope O''Shields', 2003, 3, 'Obstructed labor due to shoulder presentation, fetus 1', 3.07, 'http://dummyimage.com/121x100.png/5fa2dd/ffffff', '2020-05-01 15:54:34');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (20, 6, '182221278-2', 'Sleuth', 'Raleigh Restieaux', 2012, 2, 'Salter-Harris Type III physeal fracture of right calcaneus', 2.03, 'http://dummyimage.com/146x100.png/cc0000/ffffff', '2020-07-18 03:51:55');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (21, 10, '927227837-6', 'The African', 'Broddy Pahlsson', 1996, 3, 'Other sprain of left thumb, sequela', 2.73, 'http://dummyimage.com/113x100.png/ff4444/ffffff', '2020-10-31 19:26:02');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (22, 2, '383075402-7', 'Woman''s Face, A', 'Ina Redmayne', 1994, 3, 'Unspecified injury of popliteal artery, unspecified leg', 8.27, 'http://dummyimage.com/171x100.png/cc0000/ffffff', '2020-08-03 18:33:44');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (23, 4, '966707928-7', 'Alien Nation: Dark Horizon', 'Suzanne Bradnum', 1998, 1, 'Oth stimulant dependence w stim-induce anxiety disorder', 2.29, 'http://dummyimage.com/222x100.png/dddddd/000000', '2021-07-02 23:09:13');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (24, 1, '684583795-3', 'Cheeky (Trasgredire)', 'Saudra Chastand', 2009, 3, 'Extravasation of vesicant antineoplastic chemotherapy, subs', 6.43, 'http://dummyimage.com/200x100.png/cc0000/ffffff', '2021-10-13 20:47:39');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (25, 2, '698524038-0', 'Giant Gila Monster, The', 'Staffard Agius', 2003, 1, 'Displ transverse fx shaft of unsp femr, 7thE', 4.84, 'http://dummyimage.com/216x100.png/cc0000/ffffff', '2020-08-10 12:12:11');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (26, 2, '706926468-2', 'Making Love', 'Loleta Lisciardelli', 1987, 1, 'Unspecified injury of right ankle, sequela', 4.81, 'http://dummyimage.com/153x100.png/dddddd/000000', '2021-03-27 07:35:16');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (27, 3, '346011306-5', 'Red Eye', 'Frederick Giovannetti', 1989, 1, 'Crushing injury of right knee, subsequent encounter', 7.59, 'http://dummyimage.com/226x100.png/dddddd/000000', '2021-04-05 05:19:47');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (28, 8, '363624775-1', 'J.C. Chávez (a.k.a. Chavez)', 'Hilda Dimmock', 2004, 3, 'War operations involving gasoline bomb, civilian, subs', 7.24, 'http://dummyimage.com/208x100.png/dddddd/000000', '2021-09-24 07:19:29');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (29, 7, '148599024-6', 'Super', 'Myrtle Hixson', 2010, 2, 'Drug-induced chronic gout, unspecified elbow, with tophus', 7.54, 'http://dummyimage.com/176x100.png/5fa2dd/ffffff', '2021-11-01 00:43:29');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (30, 9, '679145508-X', 'Watercolors', 'Nesta Pusill', 2004, 2, 'Other injury of bronchus, bilateral', 1.97, 'http://dummyimage.com/208x100.png/dddddd/000000', '2020-07-24 16:34:55');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (31, 3, '230262361-4', 'Straits of Love and Hate, The (Aien kyo)', 'Magdalene Barkway', 1995, 3, 'Perst migraine aura w/o cereb infrc, not ntrct, w stat migr', 6.64, 'http://dummyimage.com/166x100.png/dddddd/000000', '2021-03-18 16:23:29');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (32, 3, '388133472-6', 'Keep Your Right Up', 'Langsdon Kennermann', 2001, 3, 'Nondisp avuls fx (chip fracture) of unsp talus, 7thB', 5.87, 'http://dummyimage.com/216x100.png/dddddd/000000', '2021-06-15 21:38:29');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (33, 5, '898231573-X', 'Trances', 'Wildon Tiuit', 1997, 3, 'Oth fracture of upper and lower end of left fibula, init', 7.14, 'http://dummyimage.com/185x100.png/ff4444/ffffff', '2020-12-26 17:10:31');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (34, 9, '691796806-4', 'Woman in The Septic Tank, The (Ang Babae sa septic tank)', 'Catlaina Panner', 1993, 1, 'Fracture of unspecified part of right clavicle', 6.46, 'http://dummyimage.com/204x100.png/dddddd/000000', '2020-05-25 04:56:59');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (35, 1, '320301414-9', 'Klitschko', 'Saxe Gammie', 2006, 3, 'Conjunctival hemorrhage, unspecified eye', 5.72, 'http://dummyimage.com/171x100.png/ff4444/ffffff', '2021-08-13 12:52:06');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (36, 3, '295216060-0', 'Contraband', 'Moses Hackforth', 1995, 3, 'Unsp fracture of shaft of right tibia, init for clos fx', 9.84, 'http://dummyimage.com/131x100.png/5fa2dd/ffffff', '2022-05-08 13:03:22');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (37, 8, '370960740-X', 'Anthropophagus: The Grim Reaper (Antropophagus) (Man Beast) (Savage Island, The) (Zombie''s Rage, The)', 'Emmy Kulic', 2002, 2, 'Encounter for suprvsn of normal pregnancy, second trimester', 5.25, 'http://dummyimage.com/109x100.png/dddddd/000000', '2020-12-11 20:25:53');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (38, 1, '713707589-4', 'American Pie', 'Iggie Paternoster', 2012, 3, 'Underdosing of other antidepressants, subsequent encounter', 8.63, 'http://dummyimage.com/224x100.png/5fa2dd/ffffff', '2020-09-18 02:18:49');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (39, 8, '262553562-8', 'In the Name of the King: A Dungeon Siege Tale', 'Melloney Kilcoyne', 2004, 1, 'Other secondary chronic gout, left elbow, without tophus', 8.52, 'http://dummyimage.com/199x100.png/5fa2dd/ffffff', '2021-03-08 04:53:05');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (40, 1, '113839767-9', 'Wild America', 'Dorolisa Macek', 1998, 1, 'Nondisp spiral fx shaft of r tibia, 7thH', 9.85, 'http://dummyimage.com/106x100.png/cc0000/ffffff', '2021-03-22 17:05:30');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (41, 7, '770945272-8', 'French Kiss', 'Rafaelita Slipper', 1992, 3, 'Injury of l int carotid, intcr w LOC of 1-5 hrs 59 min', 3.94, null, '2022-04-15 01:06:15');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (42, 3, '854177477-5', 'Thin Blue Line, The', 'Elysee Enoch', 2012, 2, 'Milt op involving biological weapons, civilian, sequela', 9.4, 'http://dummyimage.com/178x100.png/cc0000/ffffff', '2022-03-30 13:03:19');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (43, 7, '574436470-6', 'Plainsman, The', 'Shellysheldon Druery', 1996, 2, 'Cerebral infarction due to embolism of left vertebral artery', 4.98, null, '2020-12-20 05:14:12');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (44, 4, '309157804-6', 'Indian Summer (a.k.a. Alive & Kicking)', 'Martino Willmott', 2002, 3, 'Partial traumatic trnsphal amputation of r idx fngr, subs', 3.99, 'http://dummyimage.com/221x100.png/cc0000/ffffff', '2022-03-18 23:05:58');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (45, 10, '613406178-6', 'Pulse', 'Jill Licciardi', 2011, 3, 'Coma scale, best motor response, localizes pain', 9.98, 'http://dummyimage.com/232x100.png/dddddd/000000', '2020-05-31 18:17:05');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (46, 4, '880767693-1', 'Where the Truth Lies', 'Melamie Dwyr', 1993, 3, 'Superficial foreign body of lip, initial encounter', 4.57, 'http://dummyimage.com/228x100.png/5fa2dd/ffffff', '2021-03-31 16:18:58');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (47, 10, '949120030-5', 'Ernest Goes to Africa', 'Monty Tyrrell', 1993, 3, 'External constriction, left great toe, subsequent encounter', 8.22, 'http://dummyimage.com/112x100.png/dddddd/000000', '2021-04-30 01:22:26');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (48, 10, '038691816-3', 'Waiting Room (Bekleme odasi)', 'Tabbatha Reschke', 1991, 3, 'Other benign mammary dysplasias of right breast', 4.62, 'http://dummyimage.com/122x100.png/dddddd/000000', '2021-05-05 11:15:40');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (49, 5, '487417716-6', 'Torrente 3: El protector', 'Abbey Dohr', 1999, 2, 'Poisoning by insulin and oral hypoglycemic drugs, undet', 0.83, 'http://dummyimage.com/163x100.png/cc0000/ffffff', '2021-03-30 21:42:11');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (50, 1, '784881919-1', 'True Story', 'Lew Tailby', 1995, 3, 'Complete loss of teeth', 3.54, 'http://dummyimage.com/249x100.png/dddddd/000000', '2021-10-25 06:35:11');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (51, 8, '031630284-8', '27 Missing Kisses', 'Olivero Leward', 1989, 1, 'Disp fx of body of scapula, left shoulder, init for clos fx', 8.34, 'http://dummyimage.com/190x100.png/cc0000/ffffff', '2021-04-18 08:50:01');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (52, 3, '967423846-8', '2013 Rock and Roll Hall of Fame Induction Ceremony, The', 'Charmion Renac', 1996, 2, 'Superficial foreign body of unsp part of neck, subs encntr', 9.87, 'http://dummyimage.com/205x100.png/dddddd/000000', '2020-06-05 16:51:39');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (53, 5, '375387524-4', 'Thief and the Cobbler, The (a.k.a. Arabian Knight)', 'Emmalynne Hartil', 1995, 2, 'Toxic effect of carb monx from unsp source, acc, subs', 5.61, 'http://dummyimage.com/243x100.png/5fa2dd/ffffff', '2020-10-14 03:19:42');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (54, 4, '217563851-0', 'Mabel at the Wheel', 'Felix Brabyn', 2004, 2, 'Acute infct fol tranfs,infusn,inject blood/products, subs', 5.39, 'http://dummyimage.com/101x100.png/5fa2dd/ffffff', '2021-11-12 23:22:11');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (55, 5, '720335415-6', 'Snow Cake', 'Genevra Donati', 2012, 2, 'Primary blast injury of lung, unspecified, initial encounter', 4.09, null, '2020-07-07 11:24:41');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (56, 7, '999450195-X', 'Company You Keep, The', 'Parke Collington', 2009, 2, 'Nondisp transverse fx unsp patella, 7thH', 8.16, null, '2021-11-09 14:08:22');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (57, 1, '992038187-X', 'State of the Union', 'Matthieu McOmish', 2000, 3, 'Pilar and trichodermal cyst', 5.2, 'http://dummyimage.com/114x100.png/cc0000/ffffff', '2020-11-09 07:35:33');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (58, 5, '641404220-X', 'Last Kiss, The (Ultimo bacio, L'')', 'Billie Blunsum', 2009, 3, 'Partial traumatic amputation at left hip joint, sequela', 3.67, 'http://dummyimage.com/173x100.png/dddddd/000000', '2020-10-27 05:00:46');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (59, 1, '860347063-4', 'Red Dawn', 'Richard Kremer', 1969, 3, 'Nondisp unsp fx left great toe, subs for fx w nonunion', 2.41, 'http://dummyimage.com/219x100.png/dddddd/000000', '2022-04-10 11:05:59');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (60, 9, '649699268-1', 'Bigamist, The', 'Adelind Stuehmeyer', 2011, 1, 'Swimming-pool of nursing home as place', 4.13, 'http://dummyimage.com/134x100.png/5fa2dd/ffffff', '2020-10-08 11:56:50');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (61, 10, '119654301-1', 'Buying the Cow', 'Cris Sellack', 1999, 1, 'Unsp fx low end l ulna, subs for opn fx type I/2 w malunion', 6.03, 'http://dummyimage.com/217x100.png/dddddd/000000', '2020-11-02 08:41:08');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (62, 8, '171970411-2', 'Angel''s Leap', 'Cornie Norris', 1992, 1, 'Adverse effect of other psychodysleptics [hallucinogens]', 5.84, null, '2022-02-22 15:37:10');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (63, 9, '427951336-8', 'Les Feux Arctiques (Arktiset tulet)', 'Louise Dawe', 1996, 3, 'Unsp open wound of left thumb w damage to nail, subs encntr', 0.46, 'http://dummyimage.com/113x100.png/cc0000/ffffff', '2021-03-11 17:38:36');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (64, 2, '469294482-X', 'In My Skin (Dans ma Peau)', 'Ofella Daftor', 2008, 1, 'Corrosion of unspecified degree of thumb (nail)', 7.45, 'http://dummyimage.com/212x100.png/cc0000/ffffff', '2020-10-23 11:35:51');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (65, 5, '747230505-7', 'Jails, Hospitals & Hip-Hop', 'Myron Talby', 1994, 3, 'Type 1 diabetes w oth diabetic neurological complication', 9.08, 'http://dummyimage.com/135x100.png/cc0000/ffffff', '2022-04-14 00:26:00');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (66, 7, '116841952-2', 'Two Thousand Maniacs!', 'Elva Edy', 2012, 2, 'Diabetes with mild nonp rtnop with macular edema, bilateral', 4.62, null, '2021-01-28 14:27:26');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (67, 9, '842177924-9', 'All Dogs Go to Heaven 2', 'Julianna Sukbhans', 2008, 2, 'Unspecified injury of right foot', 5.27, null, '2020-11-27 19:56:41');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (68, 6, '283192370-0', 'Prowler, The', 'Tracey Harmstone', 1997, 2, 'Sprain of posterior cruciate ligament of unsp knee, init', 1.72, 'http://dummyimage.com/234x100.png/cc0000/ffffff', '2022-01-31 12:04:23');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (69, 8, '084705753-4', 'Blind Fury', 'Blondelle Zuenelli', 1995, 2, 'Osteochondritis dissecans, right hip', 0.57, 'http://dummyimage.com/116x100.png/ff4444/ffffff', '2020-07-13 21:27:00');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (70, 2, '505741812-2', 'From the Terrace', 'Merle Issard', 1992, 1, 'Antihyperlipidemic and antiarteriosclerotic drugs', 3.01, 'http://dummyimage.com/147x100.png/cc0000/ffffff', '2020-05-18 07:02:23');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (71, 1, '484600463-5', 'Wooden Man''s Bride, The (Yan shen)', 'Mariam O''Regan', 2010, 1, 'Occupant of streetcar injured in oth transport acc, sequela', 5.01, 'http://dummyimage.com/128x100.png/5fa2dd/ffffff', '2022-04-14 17:13:25');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (72, 4, '791108216-2', 'Silence (Chinmoku)', 'Corabella Smees', 2009, 2, 'Laceration w fb of l idx fngr w damage to nail, sequela', 0.56, 'http://dummyimage.com/215x100.png/5fa2dd/ffffff', '2021-06-13 00:13:07');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (73, 1, '250758765-2', 'Veronica Guerin', 'Lyn Goves', 2009, 1, 'Other contact with parrot', 6.53, null, '2021-07-17 13:29:34');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (74, 6, '928119795-2', 'Offence, The', 'Berkeley Dugdale', 1993, 2, 'Partial traumatic amp of female external genital organs', 7.98, 'http://dummyimage.com/117x100.png/cc0000/ffffff', '2020-07-02 14:38:41');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (75, 4, '422330948-X', 'Carry on Cruising', 'Thalia Ayrton', 1986, 2, 'Effusion, right hand', 8.78, 'http://dummyimage.com/112x100.png/dddddd/000000', '2021-11-02 11:57:01');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (76, 8, '946320779-1', 'Cold Fever (Á köldum klaka)', 'Mame Saiz', 1993, 1, 'Arthritis due to other bacteria, hand', 4.46, 'http://dummyimage.com/212x100.png/5fa2dd/ffffff', '2021-01-24 12:21:40');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (77, 1, '032153155-8', 'Eegah', 'Annamarie Haycraft', 2003, 3, 'Occup of special agricultural vehicle injured nontraf, init', 7.58, 'http://dummyimage.com/166x100.png/5fa2dd/ffffff', '2021-09-27 09:36:54');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (78, 1, '937877499-7', 'All In This Tea', 'Alisha Robe', 1999, 2, 'Other vascular disorders of intestine', 1.11, 'http://dummyimage.com/184x100.png/cc0000/ffffff', '2021-01-22 22:53:54');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (79, 8, '213531100-6', 'House Party', 'Mair Cutts', 1989, 3, 'Unspecified injury of left innominate or subclavian artery', 6.19, 'http://dummyimage.com/174x100.png/cc0000/ffffff', '2022-01-21 05:03:34');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (80, 2, '231475487-5', 'Under the Bombs', 'Gherardo Kiggel', 2002, 3, 'Toxic effect of ethanol', 6.85, null, '2022-02-13 02:01:11');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (81, 4, '592671738-8', 'Men of Respect', 'Toddy Barff', 2009, 3, 'Displ spiral fx shaft of l fibula, 7thQ', 4.2, 'http://dummyimage.com/151x100.png/dddddd/000000', '2021-07-07 01:05:15');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (82, 1, '783945520-4', 'MR 73 (a.k.a. The Last Deadly Mission)', 'Pierre Larenson', 2011, 3, 'Contusion of other part of colon, initial encounter', 9.96, null, '2022-01-16 08:49:03');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (83, 9, '298091902-0', 'Unforgiven', 'Cicily Klee', 2001, 2, 'Explosion of blasting material, subsequent encounter', 2.84, 'http://dummyimage.com/109x100.png/dddddd/000000', '2020-12-09 14:47:54');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (84, 1, '998886629-1', 'Eye, The', 'Ede Stile', 1994, 3, 'Puncture wound without foreign body, right knee, sequela', 1.77, 'http://dummyimage.com/140x100.png/dddddd/000000', '2021-03-16 20:49:12');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (85, 5, '865685203-5', 'Trigger Effect, The', 'Manda Steven', 1998, 1, 'Pedl cyc driver injured in collision w oth pedl cyc nontraf', 5.24, 'http://dummyimage.com/200x100.png/dddddd/000000', '2022-01-26 22:38:06');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (86, 3, '776967047-0', 'Love, Money, Love', 'Valerye Haeslier', 2002, 2, 'Age-rel osteopor w current path fracture, unsp humerus, init', 0.57, null, '2022-05-06 17:28:04');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (87, 9, '099710240-3', 'American Ninja 3: Blood Hunt', 'Hersh Dybbe', 2004, 2, 'Adult neglect or abandonment, confirmed, sequela', 0.97, null, '2020-11-25 15:46:13');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (88, 7, '283764844-2', 'Now You See Him, Now You Don''t', 'Evita Matuszak', 1998, 1, 'Corrosion of first degree of buttock', 8.87, 'http://dummyimage.com/198x100.png/dddddd/000000', '2022-05-09 00:07:26');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (89, 4, '759597791-6', 'Anderson Tapes, The', 'Jareb Camplen', 1990, 2, 'Anterior corneal pigmentations, right eye', 0.1, null, '2020-06-03 09:17:36');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (90, 3, '757613769-X', 'Meet Monica Velour', 'Ellwood Blannin', 1998, 2, 'Physeal arrest, lower leg, unspecified', 1.15, 'http://dummyimage.com/155x100.png/ff4444/ffffff', '2021-09-12 07:45:07');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (91, 2, '854776290-6', 'Temp, The', 'Emalia Rabbage', 1994, 2, 'Other displaced fracture of seventh cervical vertebra', 3.47, 'http://dummyimage.com/194x100.png/5fa2dd/ffffff', '2020-05-10 07:28:18');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (92, 3, '744294646-1', 'Parasite', 'Mateo Sebire', 1996, 3, 'Unspecified retinoschisis, bilateral', 6.87, 'http://dummyimage.com/126x100.png/cc0000/ffffff', '2021-03-18 09:04:58');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (93, 8, '050038054-6', 'Project Nim', 'Bria Kares', 2011, 2, 'Laceration without foreign body of left wrist', 6.43, 'http://dummyimage.com/222x100.png/cc0000/ffffff', '2021-02-14 19:37:02');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (94, 5, '643462917-6', 'Late Autumn (Man-choo)', 'Bradley Tailour', 1992, 3, 'Contusion of right index finger with damage to nail, sequela', 5.16, 'http://dummyimage.com/120x100.png/cc0000/ffffff', '2021-11-02 01:35:27');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (95, 8, '853579334-8', 'Officer Down', 'Gannon Earry', 2008, 1, 'Oth comp of fb acc left in body following endo exam, subs', 4.48, null, '2021-06-16 12:32:44');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (96, 7, '566178801-0', 'Voices of a Distant Star (Hoshi no koe)', 'Agace Jefferson', 1994, 2, 'Gestational proteinuria, complicating the puerperium', 3.41, 'http://dummyimage.com/131x100.png/cc0000/ffffff', '2020-06-24 23:19:28');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (97, 8, '973892242-9', 'Black Legion', 'Morgun Vickress', 2011, 1, 'Anal fistula', 4.37, 'http://dummyimage.com/191x100.png/dddddd/000000', '2022-02-18 06:58:54');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (98, 10, '550507838-9', 'Diary of a Country Priest (Journal d''un curé de campagne)', 'Julieta Darben', 2008, 3, 'Adverse effect of tricyclic antidepressants, init encntr', 4.86, 'http://dummyimage.com/142x100.png/cc0000/ffffff', '2021-10-10 10:58:58');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (99, 4, '947928265-8', 'All the King''s Men', 'Cosimo Anslow', 1995, 1, 'Nondisp segmental fracture of shaft of humerus, unsp arm', 7.53, 'http://dummyimage.com/156x100.png/5fa2dd/ffffff', '2020-11-26 00:24:37');
    insert into tbl_Book (id, LibraryID, ISBN, Title, Author, Year, BookType, Description, Cost, ImageURL, LastModified) values (100, 5, '983378973-0', 'The Hour of the Lynx', 'Leticia Warwick', 2008, 3, 'Insect bite (nonvenomous), right ankle', 0.66, 'http://dummyimage.com/119x100.png/cc0000/ffffff', '2021-11-09 13:35:19');

    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (19, 51, 4, '2021-02-09 13:42:10');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (8, 54, 6, '2022-03-30 08:43:14');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (12, 6, 6, '2021-05-07 09:42:55');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (27, 100, 3, '2021-04-03 22:19:52');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (7, 5, 7, '2021-09-13 19:05:41');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 97, 8, '2021-10-11 17:30:42');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (10, 99, 9, '2021-06-25 23:14:24');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (8, 84, 4, '2022-02-20 03:45:16');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (7, 100, 6, '2022-03-23 09:02:54');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 52, 1, '2020-09-14 03:39:15');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 34, 8, '2021-07-12 04:03:02');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (21, 40, 10, '2021-08-26 23:52:55');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 12, 7, '2022-01-03 09:27:00');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 45, 10, '2022-04-06 07:27:01');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (11, 9, 2, '2021-07-17 08:13:48');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (14, 43, 6, '2021-12-21 12:25:21');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (27, 26, 8, '2021-01-28 00:20:33');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (2, 64, 1, '2020-11-04 07:50:38');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (3, 82, 8, '2020-11-09 07:35:59');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (11, 29, 6, '2020-12-18 01:54:57');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (7, 77, 3, '2021-10-21 23:52:35');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (27, 5, 8, '2021-08-20 15:42:21');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (16, 35, 7, '2022-02-20 07:42:26');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (24, 89, 7, '2020-07-24 13:58:38');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (19, 96, 7, '2021-02-17 02:29:53');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 48, 4, '2022-02-17 01:37:02');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 74, 8, '2022-02-23 14:04:36');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (1, 34, 9, '2022-03-15 01:17:46');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (2, 89, 9, '2022-02-15 09:42:33');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (1, 84, 6, '2021-02-14 20:19:27');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 40, 6, '2021-11-15 19:27:50');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (2, 51, 3, '2021-01-09 16:16:37');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (6, 79, 2, '2020-09-30 14:04:25');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (20, 34, 2, '2021-09-03 06:27:09');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 19, 4, '2021-12-05 00:59:44');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (24, 43, 4, '2020-07-30 12:57:13');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (7, 98, 5, '2021-11-08 13:38:16');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (27, 8, 10, '2021-11-23 08:35:18');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (11, 76, 7, '2020-08-06 04:54:07');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 100, 2, '2021-11-12 10:34:45');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (24, 10, 6, '2021-06-10 06:03:14');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (12, 69, 1, '2021-06-21 06:06:07');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 66, 2, '2020-10-14 14:42:00');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (24, 75, 8, '2021-12-27 19:36:26');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (3, 15, 10, '2022-04-24 17:59:31');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (19, 23, 10, '2021-04-05 09:35:07');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (6, 61, 1, '2021-12-08 08:53:24');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (9, 37, 3, '2021-08-08 07:34:41');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 2, 4, '2020-09-03 03:39:37');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (14, 26, 3, '2021-05-02 18:29:46');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (1, 44, 5, '2022-04-30 00:03:26');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 100, 5, '2020-08-05 05:47:59');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 85, 6, '2021-05-20 16:00:31');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (23, 37, 10, '2022-04-11 07:27:15');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (6, 52, 4, '2021-08-16 14:00:41');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (26, 7, 2, '2022-05-05 09:12:18');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 6, 4, '2020-08-20 01:59:08');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (14, 95, 9, '2021-07-15 05:07:19');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (2, 63, 9, '2021-12-24 20:32:25');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (26, 16, 4, '2021-04-20 12:10:39');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (15, 78, 4, '2020-11-03 22:27:38');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (27, 6, 1, '2021-06-12 04:46:27');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (8, 100, 9, '2020-12-02 23:37:53');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (1, 38, 7, '2021-09-15 10:59:46');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 50, 1, '2021-05-29 21:45:09');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 76, 9, '2020-12-09 00:37:53');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (12, 90, 3, '2020-12-09 10:34:32');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (19, 92, 9, '2021-08-14 19:04:56');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 41, 7, '2021-06-28 18:11:29');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (12, 68, 10, '2021-07-08 13:50:13');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (2, 11, 7, '2020-09-13 23:58:15');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 64, 4, '2020-09-08 04:08:05');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (26, 33, 6, '2021-10-19 08:29:18');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 73, 9, '2021-10-28 12:13:25');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (6, 57, 5, '2020-10-03 16:56:04');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 43, 9, '2021-06-19 06:29:08');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (11, 45, 5, '2022-04-24 01:32:53');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (12, 65, 4, '2020-09-18 08:18:05');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 95, 6, '2020-12-16 23:05:42');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (10, 97, 5, '2022-02-12 13:15:59');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (15, 92, 5, '2021-08-21 23:47:38');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (5, 71, 7, '2021-05-03 12:18:20');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (4, 93, 4, '2021-05-28 16:16:13');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (22, 10, 4, '2022-01-09 15:19:18');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 53, 10, '2021-05-08 20:53:11');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (25, 28, 5, '2020-09-17 21:46:21');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (18, 14, 6, '2020-08-02 23:26:04');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (21, 3, 8, '2021-03-21 16:05:16');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 26, 5, '2021-08-20 13:52:08');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (15, 34, 6, '2021-05-18 09:51:51');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (20, 44, 3, '2022-02-28 09:24:30');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 97, 1, '2020-08-16 17:44:39');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (20, 68, 7, '2020-09-18 14:50:05');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (13, 80, 5, '2021-02-25 05:58:13');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (8, 60, 3, '2021-03-26 06:04:43');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (14, 26, 5, '2020-12-03 19:39:14');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (3, 48, 2, '2021-07-28 01:55:33');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 22, 4, '2020-10-13 06:00:43');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (17, 79, 5, '2022-03-18 13:01:17');
    insert into tbl_Reservation (CustomerID, BookID, LibraryID, Date) values (19, 52, 4, '2020-10-26 13:29:27');

END /!

DELIMITER ;

CALL insertSchema();
