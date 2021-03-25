CREATE DATABASE Bicycle_Empire;

CREATE TABLE Rental_Prices(
	price_category int IDENTITY(1, 1),
	hour_price decimal NOT NULL,
	day_price decimal NOT NULL,
	PRIMARY KEY(price_category)
);

CREATE TABLE Bicycles(
	bicycle_id int IDENTITY(1, 1),
	price_category int,
	rental_status NVARCHAR(50) NOT NULL DEFAULT('Vacant'),
	model NVARCHAR(50),
	PRIMARY KEY(bicycle_id),
	FOREIGN KEY (price_category) REFERENCES Rental_Prices(price_category)
);

CREATE TABLE Customers(
	customer_id int IDENTITY(1, 1),
	first_name NVARCHAR(25) NOT NULL,
	last_name NVARCHAR(25) NOT NULL,
	phone_number int NOT NULL,
	PRIMARY KEY(customer_id)
);

CREATE TABLE Rental_Orders(
	order_number int IDENTITY(1, 1),
	order_date datetime2 NOT NULL DEFAULT(SYSDATETIMEOFFSET()), -- Gör så att orderdatumet automatiskt blir samma som när en order skapas.
	return_date datetime2 NOT NULL CHECK(return_date > SYSDATETIMEOFFSET()), --Kollar så returdatumet är större än datum och tid då raden skapas.
	customer_id int,
	bicycle_id int,
	PRIMARY KEY(order_number),
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
	FOREIGN KEY (bicycle_id) REFERENCES Bicycles(bicycle_id)
);

CREATE TABLE Invoice_Info(
	invoice_number int IDENTITY(1, 1),
	invoice_adress NVARCHAR(50) NOT NULL,
	co_adress NVARCHAR(50),
	postal_number int NOT NULL,
	city NVARCHAR(50) NOT NULL,
	order_number int,
	customer_id int,
	PRIMARY KEY(invoice_number),
	FOREIGN KEY (order_number) REFERENCES Rental_Orders(order_number),
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
);

-- Flyller i Rental_Prices tabellen.
INSERT INTO Rental_Prices(
	hour_price,
	day_price
)
VALUES(
	100,
	2000
);

INSERT INTO Rental_Prices(
	hour_price,
	day_price
)
VALUES(
	110,
	2100
);

INSERT INTO Rental_Prices(
	hour_price,
	day_price
)
VALUES(
	120,
	2200
);

INSERT INTO Rental_Prices(
	hour_price,
	day_price
)
VALUES(
	130,
	2300
);

INSERT INTO Rental_Prices(
	hour_price,
	day_price
)
VALUES(
	140,
	2400
);

-- Flyller i Bicycles tabellen.
INSERT INTO Bicycles(
	price_category,
	rental_status,
	model		
)
VALUES(
	1,
	'Vacant',
	'Trek'
);

-- På denna fyller jag inte i rental_status för att visa att den sätts som 'Vacant' som standard.
INSERT INTO Bicycles( 
	price_category,
	model		
)
VALUES(
	2,
	'Colnago'
);

INSERT INTO Bicycles(
	price_category,
	rental_status,
	model		
)
VALUES(
	3,
	'Rented', --Här sätter jag värdet till något annat än 'Vacant'.
	'Raleigh'
);

INSERT INTO Bicycles(
	price_category,
	rental_status,
	model		
)
VALUES(
	4,
	'Vacant',
	'Cervelo'
);

INSERT INTO Bicycles(
	price_category,
	rental_status,
	model		
)
VALUES(
	5,
	'Vacant',
	'BMC'
);

-- Flyller i Customers tabellen.
INSERT INTO Customers(
	first_name,
	last_name,
	phone_number
)
VALUES(
	'Tobias',
	'Nyholm',
	0768645167
);

INSERT INTO Customers(
	first_name,
	last_name,
	phone_number
)
VALUES(
	'Oliver',
	'Stenström',
	0764334783
);

INSERT INTO Customers(
	first_name,
	last_name,
	phone_number
)
VALUES(
	'Kevin',
	'Dani',
	0733589715
);

INSERT INTO Customers(
	first_name,
	last_name,
	phone_number
)
VALUES(
	'Erik',
	'Niklasson',
	0735366796
);

INSERT INTO Customers(
	first_name,
	last_name,
	phone_number
)
VALUES(
	'Pontus',
	'Haglund',
	0768945527
);


-- Flyller i Rental_Orders tabellen.
INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-03-22 08:23:00',
	1,
	1	
);

INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-03-25 10:23:00',
	1,
	5	
);

INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-04-17 09:23:00',
	2,
	2	
);

INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-03-29 09:23:00',
	3,
	3	
);

INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-03-18 23:23:00',
	4,
	4	
);

INSERT INTO Rental_Orders(
	return_date,
	customer_id,
	bicycle_id
)
VALUES(
	'2021-03-19 18:23:00',
	5,
	5	
);

-- Flyller i Invoice_Info tabellen.
INSERT INTO Invoice_Info(
	invoice_adress,
	co_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Lärdomsgatan 9',
	'LGH 1011',
	41756,
	'Göteborg',
	1,
	1	
);

INSERT INTO Invoice_Info(
	invoice_adress,
	co_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Lärdomsgatan 9',
	'LGH 1011',
	41756,
	'Göteborg',
	6,
	1	
);

INSERT INTO Invoice_Info(
	invoice_adress,
	co_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Byshan 1',
	'Den ute på gården',
	41955,
	'Göteborg',
	2,
	2	
);

INSERT INTO Invoice_Info(
	invoice_adress,
	co_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Högsätragatan 5',
	'Lyssna efter hunden.',
	46532,
	'Högsätra',
	3,
	3	
);

-- Denna har ingen C/O adress för att påvisa att det inte behövs.
INSERT INTO Invoice_Info(
	invoice_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Bilbovägen 56',
	41889,
	'Fylke',
	4,
	4	
);

INSERT INTO Invoice_Info(
	invoice_adress,
	co_adress,
	postal_number,
	city,
	order_number,
	customer_id
)
VALUES(
	'Storgatan 6',
	'Baksidan',	
	41889,
	'Helsingborg',
	5,
	5	
);




