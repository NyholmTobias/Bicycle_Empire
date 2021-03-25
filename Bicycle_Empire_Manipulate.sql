-- Fråga som visar alla priskattegorier sorterat från billigast och uppåt.
SELECT *
FROM Rental_Prices
ORDER BY hour_price, day_price ASC;

-- Fråga som visar ordernummer där fakturan skickats till en stad som har strängen 'borg' i sig.
SELECT order_number 
FROM Invoice_Info
WHERE city LIKE '%borg%';

--Denna frågan visar hur många orders det finns där en cykel blivit uthyrd i mer än 24 timmar. 
SELECT COUNT(order_number)
FROM Rental_Orders
WHERE days_rented>=1;

-- Visar hur länge en cykel hyrs ut i genomsnitt
SELECT AVG(rent_time)
FROM Rental_Orders;

-- Denna fråga tar fram pris per timma, pris per dag och den totala uthyrningstiden på varje order genom att ta med alla rader från Rental_Orders och Bicycles där bicycle_id matchar
-- och alla rader från Bicycles och Rental_prices där price_category matchar. Sedan lägger den till en rad i svaret som heter "total_price" som räknar ut det totala priset per order
-- beroende av hur länge cykeln varit uthyrd. Prisinformationen plockas från rätt kollumn beroende av tiden som cykeln varit uthyrd.
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