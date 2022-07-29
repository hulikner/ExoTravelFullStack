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
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (2, 'Mars', 0.6, 0.5, 0.6, 687, 0, 'Mars is the fourth planet from the Sun', 4.8);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (3, 'KOI-4878.01', 0.9, 1.1, 1.1, 449, 1075, 'KOI-4878.01 is an exoplanet that orbits the F-type main-sequence star KOI-4878.', 2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (4, 'TOI-700-d', 0.6, 0.6, 0.6, 400, 101, 'Mars is the fourth planet from the Sun', 3);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (5, 'K2-72e', 2.2, 1.3, 1.1, 24, 217, 'Earth is the third planet from the Sun', 1);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (6, 'Teegardens-Star-b', 5.6, 5, 5, 450, 60, 'Mars is the fourth planet from the Sun', 5);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (7, 'TRAPPIST-1d', 0.3, 0.8, 1, 4, 12, 'Earth is the third planet from the Sun', 4.2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (8, 'Kepler-1649c', 0.4, 0.8, 1.1, 400, 12, 'Mars is the fourth planet from the Sun', 4.8);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (9, 'Proxima-Centauri-b', 0.3, 0.8, 1, 4, 301, 'KOI-4878.01 is an exoplanet that orbits the F-type main-sequence star KOI-4878.', 2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (10, 'Gliese-1061-d', 0.6, 0.6, 0.6, 400, 12, 'Mars is the fourth planet from the Sun', 3);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (11, 'Gliese-1061-c', 2.2, 1.3, 1.1, 24, 12, 'Earth is the third planet from the Sun', 1);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (12, 'TRAPPIST-1e', 0.3, 0.8, 1, 4, 39, 'Mars is the fourth planet from the Sun', 5);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (13, 'Wolf-1061c', 0.9, 1.1, 1.1, 449, 13, 'Earth is the third planet from the Sun', 4.2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (14, 'Kepler-442b', 3.6, 3.6, 3.6, 400, 1193, 'Mars is the fourth planet from the Sun', 4.8);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (15, 'Kepler-1229b', 2, 1.1, 4, 399, 865, 'KOI-4878.01 is an exoplanet that orbits the F-type main-sequence star KOI-4878.', 2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (16, 'Kepler-1606b', 0.6, 0.6, 0.6, 400, 2710, 'Mars is the fourth planet from the Sun', 3);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (17, 'Kepler-1090b', 2.2, 1.3, 1.1, 24, 2800, 'Earth is the third planet from the Sun', 1);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (18, 'Kepler-452b', 0.3, 0.8, 1, 4, 1799, 'Mars is the fourth planet from the Sun', 5);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (19, 'Kepler-1638b', 2.2, 1.3, 1.1, 24, 4973, 'Earth is the third planet from the Sun', 4.2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (20, 'Tau-Ceti-f', 3.6, 3.6, 3.6, 400, 12, 'Mars is the fourth planet from the Sun', 4.8);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (21, 'LHS-1140-b', 0.3, 0.8, 1, 4, 49, 'KOI-4878.01 is an exoplanet that orbits the F-type main-sequence star KOI-4878.', 2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (22, 'HD-40307-g', 0.6, 0.6, 0.6, 400, 42, 'Mars is the fourth planet from the Sun', 3);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (23, 'Gliese-832-c', 2.2, 1.3, 1.1, 24, 16, 'Earth is the third planet from the Sun', 1);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (24, 'K2-288Bb', 5.6, 5, 5, 450, 214, 'Mars is the fourth planet from the Sun', 5);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (25, 'Luyten-98-59-f', 2.2, 1.3, 1.1, 24, 34, 'Earth is the third planet from the Sun', 4.2);
insert into ExoPlanet (Id, Name, Mass, Radius, EqTemp, Orbit, LightYears, Detail, Rating) values (26, 'Kapteyn-b', 0.3, 0.8, 1, 4, 13, 'Earth is the third planet from the Sun', 4.2);


set identity_insert [ExoPlanet] off

set identity_insert [Review] on
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (1, 1, 1, 1651017600, 1650240000, 'Ion-Drive', 2);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (2, 1, 1, 1651017600, 1650240000, 'Ion-Drive', 3);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (3, 1, 1, 1651017600, 1650240000, 'Ion-Drive', 2);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (4, 1, 2, 1651017600, 1650240000, 'Ion-Drive', 3);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (5, 1, 2, 1651017600, 1650240000, 'Ion-Drive', 2);
insert into Review (Id, UserProfileId, ExoPlanetId, CreateDate, EditDate, Message, Star) values (6, 1, 2, 1651017600, 1650240000, 'Ion-Drive', 3);
set identity_insert [Review] off

set identity_insert [Log] on
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (1, 1, 1, 1651017600, 1650240000, 1, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (2, 1, 1, 1651017600, 1650240000, 2, 'Warp-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (3, 1, 1, 1651014600, 1650240000, 3, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (4, 1, 2, 1651018600, 1650290000, 4, 'Warp-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (5, 1, 2, 1651017600, 1650240000, 5, 'Ion-Drive');
insert into Log (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, ReviewId, Mode) values (6, 1, 2, 1651017600, 1650290000, 6, 'Warp-Drive');
set identity_insert [Log] off

set identity_insert [Receipt] on
insert into Receipt (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, LogId, Paid, Mode) values (1, 1, 1, 1651017600, 1650240000, 1, 10, 'Ion-Drive');
insert into Receipt (Id, UserProfileId, ExoPlanetId, DepartureDate, ReturnDate, LogId, Paid, Mode) values (2, 1, 1, 1651017600, 1650240000, 2, 10.5, 'Warp-Drive');
set identity_insert [Receipt] off

set identity_insert [HubDrive] on
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (1, 'Central InterPlanetary Hub', 'The Hub is the largest artificial structure in the galaxy, with a population of 13.2 million intelligent beings from across the Milky Way galaxy, and uses centrifugal force to create artificial gravity for its inhabitants. The Hub orbits around Jupiters moon Europa in the Milky Way Galaxy and is a great central launching point to several Exo-Planets. This is where you will leave from to travel to the Exo-Planet of your choosing. To get to The Hub there is a base cost of 5 Bitcoin for earth inhabitants.', 'The Largest Artificial Structures In the Galaxy', './Images/Hub.jpg');
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (2, 'Ion-Drive', 'An ion drive ionizes propellant by adding or removing electrons to produce ions. Most thrusters ionize propellant by electron bombardment: a high-energy electron (negative charge) collides with a propellant atom (neutral charge), releasing electrons from the propellant atom and resulting in a positively charged ion. Putting out more energy than using allows us to constantly keep increasing speed till we are past the speed of light.', 'The Largest Artificial Structures In the Galaxy', './Images/Ion-Drive.jpg');
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (3, 'Warp-Drive', 'The warp drive works by creating a bubble of flat spacetime around the spaceship and curving spacetime around that bubble to reduce distances. The warp drive requires either negative mass, a type of matter just discovered, or a ring of negative energy density to work.', 'Bends Spacetime to Its Will', './Images/Warp-Drive.jpg');
insert into HubDrive (Id, Name, Detail, CardDetail, Image) values (4, 'Wormhole-Drive', 'The wormhole drive works by connecting two distant points with an artificially created wormhole -- but without the need for transmitting or receiving gates. Instead, the ships drive itself generates a large wormhole to the target destination. The duration of travel is 2 hours to any point even though it is instant. This is due to needing to have everyone on board and away from port to start charging the drives. Then boom, youre there.', 'Instantaneous Travel With Wormholes', './Images/Wormhole-Drive.jpg');
set identity_insert [HubDrive] off

set identity_insert [About] on
insert into About (Id, Name, Detail, CardDetail, Image) values (1, 'Exo-Travel', 'The Exo-Travel Corporation is an American space advocacy corporation organized to promote the interests of increased involvement of the private sector, in collaboration with government, in the exploration and development of space. Its advocate members design and lead a collection of projects with goals that align to the organizations goals as described by its credo. Our goals include protecting the Earths fragile biosphere and creating a freer and more prosperous life for each generation by using the unlimited energy and material resources of space. Exo-Travel Corporation is an organization of people dedicated to the Space Frontier and human settlement. Our purpose is to unleash the power of free enterprise and lead a united humanity permanently into the Solar System.', 'Exo-Travel Corp.', './Images/Hub.jpg');
insert into About (Id, Name, Detail, CardDetail, Image) values (2, 'The Hub', 'The Hub is the largest artificial structure in the galaxy, with a population of 13.2 million intelligent beings from across the Milky Way galaxy, and uses centrifugal force to create artificial gravity for its inhabitants. Initially, it was discovered by the asari and the salarians, the earliest post-Prothean races to discover the megastructures scattered throughout the galaxy that facilitate FTL travel. Following this, an executive committee known as the Hub Council was created, with the station functioning as the seat of galactic government. The Hub holds great sway in the galaxy, and are recognized as an authority by most of explored space.', 'Largest Artificial Structure In the Galaxy', './Images/Hub1.jpg');
insert into About (Id, Name, Detail, CardDetail, Image) values (3, 'Hulikner', 'This is the man who aspires to save our planet and get us a new one to inhabit: clown, genius, edgelord, visionary, industrialist, showman, cad; a madcap hybrid of Thomas Edison, P.T. Barnum, Andrew Carnegie and Watchmens Doctor Manhattan, the brooding, blue-skinned man-god who invents electric cars and moves to Mars. His Exo-Travel Corporation has a defining moment in human civilization that lead us to expanding humanity throughout the universe. His car company controls two-thirds of the multibillion-dollar electric-vehicle market it pioneered and is valued at a cool $1 trillion. That has made Hulikner, with a net worth of more than $250 trillion, the richest private citizen in history, at least on paper. Hes a player in robots and solar, cryptocurrency and climate, brain-computer implants to stave off the menace of artificial intelligence and underground tunnels to move people and freight at super speeds. He dominates Wall Street', 'The Greatest Mind of All Generations', './Images/Genius.jpg');
set identity_insert [About] off