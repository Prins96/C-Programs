CREATE USER 'dkatlonusr'@'localhost' IDENTIFIED BY 'dkatlonpsw';
CREATE DATABASE dkatlondb
  DEFAULT CHARACTER SET utf8
  DEFAULT COLLATE utf8_general_ci;
GRANT SELECT, INSERT, DELETE, UPDATE ON dkatlondb.* TO 'dkatlonusr'@'localhost';
USE dkatlondb;

CREATE TABLE Clients (
    idClient INT PRIMARY KEY AUTO_INCREMENT,
    clientName VARCHAR(150) NOT NULL,
    address VARCHAR(200) NOT NULL,
    city VARCHAR(200) NOT NULL,
    phone VARCHAR(50) NOT NULL UNIQUE,
    contactEmail VARCHAR(150) NOT NULL UNIQUE
);

CREATE TABLE Orders (
    idOrder INT PRIMARY KEY AUTO_INCREMENT,
    idClient INT NOT NULL,
    orderDate DATETIME NOT NULL,
    paymentMethod ENUM('cash', 'card') NOT NULL,
    discount INT NOT NULL DEFAULT 0,
    status ENUM('pending', 'completed') NOT NULL,
    FOREIGN KEY (idClient) REFERENCES Clients(idClient) ON DELETE CASCADE
);

CREATE TABLE Articles (
    idArticle INT PRIMARY KEY AUTO_INCREMENT,
    articleName VARCHAR(100) NOT NULL,
    unitPrice FLOAT NOT NULL,
    availability INT NOT NULL
);

CREATE TABLE OrderDetails (
    idOrder INT NOT NULL,
    idArticle INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY (idOrder, idArticle),
    FOREIGN KEY (idOrder) REFERENCES Orders(idOrder) ON DELETE CASCADE,
    FOREIGN KEY (idArticle) REFERENCES Articles(idArticle) ON DELETE CASCADE
);

CREATE TABLE Users (
    username VARCHAR(255) NOT NULL UNIQUE,
    userpass VARCHAR(255) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    role ENUM('staff', 'admin') NOT NULL
);


-- Datos de ejemplo para la tabla Clients
INSERT INTO Clients (clientName, address, city, phone, contactEmail) VALUES
('John Doe', '123 Main St', 'Anytown', '555-1234', 'john.doe@proven.com'),
('Jane Smith', '456 Oak Ave', 'Othertown', '555-5678', 'jane.smith@proven.com'),
('Acme Corporation', '789 Elm St', 'Bigcity', '555-9012', 'info@acme.com'),
('Michael Johnson', '321 Elm St', 'Smalltown', '555-6789', 'michael.johnson@proven.com'),
('Sarah Brown', '789 Maple Ave', 'Villagetown', '555-3456', 'sarah.brown@proven.com'),
('XYZ Enterprises', '456 Pine St', 'Metrocity', '555-7890', 'info@xyz.com'),
('Emily Taylor', '101 Oak St', 'Hometown', '555-2345', 'emily.taylor@proven.com'),
('ABC Company', '222 Cedar St', 'Suburbia', '555-4567', 'info@abc.com');
-- Datos de ejemplo para la tabla Orders
INSERT INTO Orders (idClient, orderDate, paymentMethod, discount, status) VALUES
(1, '2024-02-15 10:00:00', 'cash', 0, 'pending'),
(2, '2024-02-15 11:00:00', 'card', 10, 'completed'),
(3, '2024-02-15 12:00:00', 'cash', 5, 'pending'),
(4, '2024-02-15 13:00:00', 'card', 15, 'completed'),
(5, '2024-02-15 14:00:00', 'cash', 0, 'pending'),
(1, '2024-02-15 15:00:00', 'card', 5, 'completed'),
(3, '2024-02-15 16:00:00', 'cash', 0, 'pending'),
(2, '2024-02-15 17:00:00', 'card', 10, 'completed');

-- Datos de ejemplo para la tabla Articles
INSERT INTO Articles (articleName, unitPrice, availability) VALUES
('Widget', 10.99, 100),
('Gadget', 19.99, 50),
('Thingamajig', 5.99, 200),
('Doodad', 8.99, 150),
('Whatchamacallit', 12.49, 75),
('Thingummy', 4.49, 250),
('Gizmo', 29.99, 30),
('Doohickey', 6.99, 100);

-- Datos de ejemplo para la tabla OrderDetails
INSERT INTO OrderDetails (idOrder, idArticle, quantity) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 5),
(3, 4, 3),
(4, 5, 2),
(5, 2, 4),
(2, 1, 1),
(1, 3, 3);

-- Datos de ejemplo para la tabla Users
INSERT INTO Users (username, userpass, email, role) VALUES
('john_doe', 'password123', 'john.doe@proven.com', 'staff'),
('jane_smith', 'letmein', 'jane.smith@proven.com', 'admin'),
('michael_j', 'abc123', 'michael.johnson@proven.com', 'staff'),
('sarah_b', 'password456', 'sarah.brown@proven.com', 'admin'),
('xyz_admin', 'xyzpass', 'admin@xyz.com', 'admin'),
('emily_t', 'letmeinagain', 'emily.taylor@proven.com', 'staff'),
('alejandro', 'alejo', 'ale96@proven.com', 'admin'),
('abc_staff', 'staffpass', 'staff@abc.com', 'staff');

