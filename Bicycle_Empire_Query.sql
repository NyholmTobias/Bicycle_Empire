
-- Lägger till kolumnen "rent_time" i Rental_Orders som visar hur många timmar en cyckel varit uthyrd på varje enskiljd order.
ALTER TABLE Rental_Orders
ADD rent_time AS DATEDIFF(HOUR, order_date, return_date);

-- Lägger till kolumnen "days_rented" i Rental_Orders som visar hur många dagar en cyckel varit uthyrd på varje enskiljd order.
ALTER TABLE Rental_Orders
ADD days_rented AS DATEDIFF(DAY, order_date, return_date);

-- Ändrar order datum och återlämningstiden och därav uthyrningstiden på order 3 och 4.
UPDATE Rental_Orders
SET order_date = '2021-03-20 19:25:00'
WHERE order_number = 3 OR order_number = 4;

UPDATE Rental_Orders
SET return_date = '2021-03-20 21:25:00'
WHERE order_number = 3 OR order_number = 4;

-- Ändrar faktura adress på order 6.
UPDATE Invoice_Info
SET invoice_adress = 'Kobergsgatan 25', co_adress = 'LGH 28', postal_number = 41671
WHERE order_number = 6;

--Lägger till first- och last name i Invoice_Info för att senare kunna använda en fråga som manipulerar raderna med namnen och fyller på automatiskt.
ALTER TABLE Invoice_Info
ADD first_name NVARCHAR(25);

ALTER TABLE Invoice_Info
ADD last_name NVARCHAR(25);

UPDATE Invoice_Info
SET first_name = Customers.first_name
FROM Customers
INNER JOIN Invoice_Info
ON Customers.customer_id=Invoice_Info.customer_id;

UPDATE Invoice_Info
SET last_name = Customers.last_name
FROM Customers
INNER JOIN Invoice_Info
ON Customers.customer_id=Invoice_Info.customer_id;
