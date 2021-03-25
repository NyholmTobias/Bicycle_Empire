-- Fr�ga som visar alla priskattegorier sorterat fr�n billigast och upp�t.
SELECT *
FROM Rental_Prices
ORDER BY hour_price, day_price ASC;

-- Fr�ga som visar ordernummer d�r fakturan skickats till en stad som har str�ngen 'borg' i sig.
SELECT order_number 
FROM Invoice_Info
WHERE city LIKE '%borg%';

--Denna fr�gan visar hur m�nga orders det finns d�r en cykel blivit uthyrd i mer �n 24 timmar. 
SELECT COUNT(order_number)
FROM Rental_Orders
WHERE days_rented>=1;

-- Visar hur l�nge en cykel hyrs ut i genomsnitt
SELECT AVG(rent_time)
FROM Rental_Orders;

-- Denna fr�ga tar fram pris per timma, pris per dag och den totala uthyrningstiden p� varje order genom att ta med alla rader fr�n Rental_Orders och Bicycles d�r bicycle_id matchar
-- och alla rader fr�n Bicycles och Rental_prices d�r price_category matchar. Sedan l�gger den till en rad i svaret som heter "total_price" som r�knar ut det totala priset per order
-- beroende av hur l�nge cykeln varit uthyrd. Prisinformationen plockas fr�n r�tt kollumn beroende av tiden som cykeln varit uthyrd.
SELECT hour_price, day_price, rent_time AS hours_rented, days_rented, 
CASE 
	WHEN rent_time < 24 THEN rent_time*hour_price
	WHEN rent_time > 24 THEN days_rented*day_price
END AS total_price
FROM Rental_Prices
INNER JOIN Rental_Orders
INNER JOIN Bicycles
ON Rental_Orders.bicycle_id=Bicycles.bicycle_id
ON Bicycles.price_category=Rental_Prices.price_category;