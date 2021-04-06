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
	order_date datetime2 NOT NULL DEFAULT(SYSDATETIMEOFFSET()), 
	return_date datetime2 NOT NULL, 
	customer_id int,
	bicycle_id int,
	rent_time AS DATEDIFF(HOUR, order_date, return_date), 
	days_rented AS DATEDIFF(DAY, order_date, return_date),
	PRIMARY KEY(order_number),
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE,
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
	first_name NVARCHAR(50),
	last_name NVARCHAR(50),
	PRIMARY KEY(invoice_number),
	FOREIGN KEY (order_number) REFERENCES Rental_Orders(order_number) ON DELETE CASCADE,
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
);

ALTER TABLE Rental_Orders
ADD CONSTRAINT CK_return_date CHECK(return_date > order_date);