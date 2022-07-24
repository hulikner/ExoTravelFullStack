USE [ExoTravel];
GO

set identity_insert [UserType] on
insert into [UserType] ([ID], [Name]) VALUES (1, 'Admin'), (2, 'Author');
set identity_insert [UserType] off

set identity_insert [UserProfile] on
insert into UserProfile (Id, DisplayName, FirstName, LastName, Email, CreateDateTime, ImageLocation, UserTypeId, FirebaseUserId) values (1, 'Foo', 'Foo', 'Barington', 'foo@bar.com', '2020-04-23', 'https://robohash.org/numquamutut.png?size=150x150&set=set1', 1, 'tv5ex21W7PgQGZdNQPGI9uOHLBg2');
insert into UserProfile (Id, DisplayName, FirstName, LastName, Email, CreateDateTime, ImageLocation, UserTypeId, FirebaseUserId) values (2, 'aotton2', 'Arnold', 'Otton', 'aotton2@ow.lyx', '2020-01-13', 'https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1', 1, 'EkRwtoDzlaPayK8jTzdY747yumq1');
set identity_insert [UserProfile] off

set identity_insert [ExoPlanet] on
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (1, 'Earth', 1, 1, 1, 365, 0, 'Earth is the third planet from the Sun', 4.2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (2, 'Mars', 3.6, 3.6, 3.6, 400, 0, 'Mars is the fourth planet from the Sun', 4.8);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (3, 'KOI 4878.01', 2, 33, 4, 399, 20, 'KOI-4878.01 is an exoplanet that orbits the F-type main-sequence star KOI-4878.', 2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (4, 'TOI 700 d', 0.6, 0.6, 0.6, 400, 40, 'Mars is the fourth planet from the Sun', 3);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (5, 'K2 72e', 1, 1, 1, 365, 50, 'Earth is the third planet from the Sun', 1);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (6, 'Teegardens Star b', 5.6, 5, 5, 450, 60, 'Mars is the fourth planet from the Sun', 5);
set identity_insert [ExoPlanet] off

set identity_insert [Receipt] on
insert into Receipt (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, LogId, Paid, Mode) values (1, 1, 1, 1651017600, 1650240000, 1, 10, 'Ion-Drive');
insert into Receipt (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, LogId, Paid, Mode) values (2, 1, 2, 1651017600, 1650240000, 2, 10.5, 'Warp-Drive');
set identity_insert [Receipt] off

set identity_insert [Review] on
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (1, 1, 1, 1651017600, 1650240000, 'Ion-Drive', 2);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (2, 1, 1, 1651017600, 1650240000, 'Ion-Drive', 3);
set identity_insert [Review] off

set identity_insert [Log] on
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (1, 1, 1, 1651017600, 1650240000, 1, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (2, 1, 2, 1651017600, 1650240000, 2, 'Warp-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (3, 1, 3, 1651014600, 1650240000, 1, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (4, 1, 4, 1651018600, 1650290000, 2, 'Warp-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (5, 1, 1, 1651017600, 1650240000, 1, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (6, 1, 6, 1651017600, 1650290000, 2, 'Warp-Drive');
set identity_insert [Log] off

set identity_insert [HubDrive] on
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (1, 'Central InterPlanetary Hub', 'The Hub is the largest', 'Largest Artificial Structure in the Galaxy', './Images/Hub.jpg');
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (2, 'Ion Drive', 'An ion drive ionizes propellant by adding or removing electrons to produce ions.', 'The Net-Positive Dark Energy Drive', './Images/Ion Drive.jpg');
set identity_insert [HubDrive] off

set identity_insert [About] on
insert into About (Id, Name, Detail, CardDetail, Image) values (1, 'Exo-Travel', 'Exo-Travel Corporation', 'The Exo-Travel Corporation is an American space advocacy corporation', './Images/Hub.jpg');
insert into About (Id, Name, Detail, CardDetail, Image) values (2, 'Hulikner', 'The Greatest Mind of All Generations', 'This is the man who aspires to save our planet and get us a new one to inhabit', './Images/Genius.jpg');
set identity_insert [About] off