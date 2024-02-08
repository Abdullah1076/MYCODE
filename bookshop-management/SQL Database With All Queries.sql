--BOOKSHOP MANAGEMENT SYSTEM

CREATE TABLE SuppliersTb(
		Supplier_ID VARCHAR (55)NOT NULL,
		Supplier_name VARCHAR(55) NOT NULL,
		Supplier_City VARCHAR(55),
		Supplier_email VARCHAR(55),
		Supplier_phone VARCHAR(55) NOT NULL,
		PRIMARY KEY (Supplier_ID)
		);

insert into SuppliersTb values(1,'SN1','City1','SN1@gmail.com','44-6020450')
insert into SuppliersTb values(2,'SN2','City2','SN2@gmail.com','44-6020450')
insert into SuppliersTb values(3,'SN3','City3','SN3@gmail.com','44-6020450')
	SELECT * FROM SuppliersTb

	--1
	SELECT Supplier_name, Supplier_phone FROM SuppliersTb 
	--2
	update SuppliersTb SET Supplier_name = 'fahad' WHERE Supplier_ID = 'SUP10';
	--3
	delete FROM SuppliersTb WHERE Supplier_ID = 'SUP10';

	create table StockTb(
		StockID VARCHAR(50) PRIMARY KEY,
		SupplierID VARCHAR(55) FOREIGN KEY REFERENCES SuppliersTb(Supplier_ID),
		BookID VARCHAR(50) NOT NULL,
		AuthorName VARCHAR(50) NOT NULL,
		BookName VARCHAR(50) NOT NULL,
		PublisherName VARCHAR(50) NOT NULL,
		PublishedYear VARCHAR(50) NOT NULL,
		Price int NOT NULL
	);

INSERT INTO StockTb VALUES(1,1,'BOOK1','J.R.R Tolken','The Hobbit','Allen & Unwin','1937', 1100);
INSERT INTO StockTb VALUES(2,1,'BOOK2','Tanith Lee','The Castle of Dark','Macmilla','1930', 1200);
INSERT INTO StockTb VALUES(3,2,'BOOK3','Tanith Lee','The Winter Players','Macmilla','1977', 1300);
INSERT INTO StockTb VALUES(4,2,'BOOK4','Anne Rice','Tale of the Thief','Penguin','2016', 1400);
	SELECT * FROM StockTb

	--1
	alter table StockTb
	add Price int check(Price>=1000);
	--2
	SELECT * FROM StockTb WHERE PublishedYear = 2016
	--3
	SELECT AuthorName, COUNT(PublishedYear)
	FROM StockTb
	GROUP BY AuthorName 
	
	CREATE TABLE Employees(
		Employee_ID VARCHAR(55) PRIMARY KEY,
		Employee_Name VARCHAR(50),
		Employee_ContactNumber VARCHAR(50),
		Employee_Position VARCHAR(50),
		Employee_Salary MONEY CHECK(Employee_Salary>20000) NOT NULL,
		);

insert into Employees values (1,'Rizwan','44-4289087','Manager',30000);
insert into Employees values (2,'Aasd','44-4289087','Accountant',350);
	SELECT * FROM Employees
	
	--1
	update Employees SET Employee_Salary = 30000 WHERE Employee_ID = 'EMP3';
	delete FROM Employees WHERE Employee_ID = 'EMP6';
	--2
	SELECT Employee_Position, SUM(Employee_Salary)
	FROM Employees
	GROUP BY Employee_Position

	CREATE TABLE Customer(
		Customer_ID VARCHAR(50) NOT NULL, 
		Name VARCHAR(30) NOT NULL,
		CustomerAddress VARCHAR(max) NOT NULL,
		Phone VARCHAR(50) NOT NULL,
		Email VARCHAR(50) NOT NULL,
		Age INT NOT NULL CHECK(Age>10),
		PRIMARY KEY (Customer_ID)
	);


	INSERT INTO Customer VALUES(1,'Nouman','london','44-12345433','Customer1@gmail.com',18)
	INSERT INTO Customer VALUES(2,'Asad','birmingham','44-12145436','Customer2@gmail.com',17)
	INSERT INTO Customer VALUES(3,'Sarfaraz','uk','44-12145436','Customer3@gmail.com',22)
	INSERT INTO Customer VALUES(4,'Ali','england','44-12145436','Customer4@gmail.com',23)
	INSERT INTO Customer VALUES(5,'Usman','northwest','44-12145436','Customer5@gmail.com',24)
	SELECT * FROM Customer

	--1
	delete FROM Customer WHERE Customer_ID = 'CUS10';
	delete FROM Customer WHERE Customer_ID = 'CUS9';
	delete FROM Customer WHERE Customer_ID = 'CUS8';
	--2
	SELECT * FROM Customer
	WHERE Age BETWEEN 20 AND 25;

	CREATE TABLE Orders(
	Order_ID VARCHAR(55) NOT NULL,
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	Employee_ID VARCHAR(55) FOREIGN KEY REFERENCES Employees(Employee_ID),
	StockID	VARCHAR(50) FOREIGN KEY REFERENCES StockTb(StockID),
	Qty_sold INT,
	Order_Date VARCHAR(55),
    PRIMARY KEY (Order_ID),
    );
	INSERT INTO Orders VALUES(1,1,'Nauman'  ,1,1,1,'2-2-2022')
	INSERT INTO Orders VALUES(2,2,'Asad'    ,1,2,2,'3-2-2022')
	INSERT INTO Orders VALUES(3,1,'Nauman'  ,1,1,1,'4-2-2022')
	INSERT INTO Orders VALUES(4,3,'Sarfaraz',1,3,2,'5-2-2022')
	INSERT INTO Orders VALUES(5,3,'Sarfaraz',1,4,1,'6-2-2022')
	SELECT * FROM Orders

	--1
	Update Orders SET Qty_sold = 3 WHERE Order_ID = 'ORD1';
	SELECT * FROM Orders Order By Qty_sold Desc; 
	--2
	SELECT Customer_ID, Qty_sold FROM Orders
	GROUP BY Customer_ID, Qty_sold
	--3
	SELECT * FROM Orders
	WHERE Order_Date BETWEEN '2-2-2022'AND'5-2-2022';
	
	CREATE TABLE Bill_Generate(
	Bill_ID VARCHAR(50) PRIMARY KEY,
	Order_ID VARCHAR(55) FOREIGN KEY REFERENCES Orders(Order_ID),
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	BookID VARCHAR(50) NOT NULL,
	Bill_Date date,
	Total_Cost INT CHECK(Total_Cost>0) NOT NULL,
	);
	INSERT INTO Bill_Generate VALUES(1,1,1,1,'2-2-2022',1100)
	INSERT INTO Bill_Generate VALUES(2,2,2,2,'3-2-2022',1200)
	INSERT INTO Bill_Generate VALUES(3,3,1,1,'4-2-2022',1100)
	INSERT INTO Bill_Generate VALUES(4,4,3,3,'5-2-2022',1300)
	INSERT INTO Bill_Generate VALUES(5,5,3,4,'6-2-2022',1300)
	SELECT * FROM Bill_Generate

	--1
	SELECT Customer_ID, BooKID FROM Bill_Generate
	GROUP BY Customer_ID, BookID
	--2
	SELECT Customer_ID, COUNT(BookID)
	FROM Bill_Generate
	GROUP BY Customer_ID

	CREATE TABLE PAYMENTS(
	Payment_ID VARCHAR(50) PRIMARY KEY,
	Bill_ID VARCHAR(50) FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Customer_ID VARCHAR(50) FOREIGN KEY REFERENCES Customer(Customer_ID),
	Credit_card_numb VARCHAR(55) NOT NULL,
	Credit_card_expiry VARCHAR(55) NOT NULL,
	Total_Cost INT CHECK(Total_Cost>0) NOT NULL,
	);

	INSERT INTO PAYMENTS VALUES('PAY1','BILL1','CUS1','1717-22-233','11-17-2024',1100)
	INSERT INTO PAYMENTS VALUES('PAY2','BILL2','CUS2','1718-23-233','01-17-2025',1200)
	INSERT INTO PAYMENTS VALUES('PAY3','BILL3','CUS1','1719-24-233','03-17-2023',1100)
	INSERT INTO PAYMENTS VALUES('PAY4','BILL4','CUS3','1720-25-233','05-17-2030',1300)
	INSERT INTO PAYMENTS VALUES('PAY5','BILL5','CUS3','1721-26-233','07-17-2045',1300)
	SELECT * FROM PAYMENTS;
	--1
	SELECT Sum(Total_Cost) As 'Total Sale' FROM PAYMENTS;
	--2
	SELECT Customer_ID, Sum(Total_Cost)
	FROM Payments
	GROUP BY Customer_ID
	having Sum(Total_Cost) >= 2200

	CREATE TABLE Returns(
	Return_ID VARCHAR(55) PRIMARY KEY,
	Bill_ID VARCHAR(50) FOREIGN KEY REFERENCES Bill_Generate(Bill_ID),
	Payment_ID VARCHAR(50) FOREIGN KEY REFERENCES PAYMENTS(Payment_ID),
	Order_ID VARCHAR(55) FOREIGN KEY REFERENCES Orders(Order_ID),
    PayReturned int,
    );
    INSERT INTO Returns VALUES('RT1','BILL1','PAY1','ORD1',1100)
	INSERT INTO Returns VALUES('RT2','BILL5','PAY5','ORD5',1300)
	SELECT * FROM Returns
	--1
	SELECT Sum(PayReturned) As 'Total Returned Sales ' FROM Returns;

	--SQL JOINTS

	--INNER JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Orders	
	INNER JOIN Customer ON Orders.Customer_ID=Customer.Customer_ID;

	--LEFT JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Customer	
	LEFT JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;

	--RIGHT JOIN
	SELECT  Customer.Name, Orders.Order_ID
	FROM Customer	
	RIGHT JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;

	--FULL JOIN
	SELECT Orders.Order_ID, Customer.Name, Orders.Order_Date
	FROM Customer	
	FULL JOIN Orders ON Orders.Customer_ID=Customer.Customer_ID;