-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Dec 04. 12:46
-- Kiszolgáló verziója: 10.4.17-MariaDB
-- PHP verzió: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `bntet0_szop_beadando`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `results`
--

CREATE TABLE `results` (
  `RaceID` int(11) NOT NULL,
  `RaceName` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `RaceDate` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `RaceWinner` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `RaceWinnerCar` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `RaceLaps` int(11) DEFAULT NULL,
  `RaceTime` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `ModID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `results`
--

INSERT INTO `results` (`RaceID`, `RaceName`, `RaceDate`, `RaceWinner`, `RaceWinnerCar`, `RaceLaps`, `RaceTime`, `ModID`) VALUES
(1, 'Bahrain', '28 Mar 2021', 'Lewis Hamilton', 'MERCEDES', 56, '1:32:03.897', 1),
(2, 'Emilia Romagna', '18 Apr 2021', 'Max Verstappen', 'RED BULL RACING HONDA', 63, '2:02:34.598', 1),
(3, 'Portugal', '02 May 2021', 'Lewis Hamilton', 'MERCEDES', 66, '1:34:31.421', 1),
(4, 'Spain', '09 May 2021', 'Lewis Hamilton', 'MERCEDES', 66, '1:33:07.680', 2),
(5, 'Monaco', '23 May 2021', 'Max Verstappen', 'RED BULL RACING HONDA', 78, '1:38:56.820', 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Password` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Admin` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`ID`, `Name`, `Password`, `Admin`) VALUES
(1, 'admin', 'admin', 1),
(2, 'user', 'user', 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `results`
--
ALTER TABLE `results`
  ADD PRIMARY KEY (`RaceID`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `results`
--
ALTER TABLE `results`
  MODIFY `RaceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
