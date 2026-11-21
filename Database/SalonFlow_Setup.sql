CREATE DATABASE IF NOT EXISTS salonflow_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE salonflow_db;

CREATE TABLE IF NOT EXISTS customers (
 id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL,
 phone VARCHAR(24) NOT NULL UNIQUE, email VARCHAR(150), notes VARCHAR(255),
 consent TINYINT NOT NULL DEFAULT 0, points INT NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS users (
 id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL,
 email VARCHAR(150) NOT NULL UNIQUE, phone VARCHAR(24) NOT NULL UNIQUE,
 role ENUM('Owner','Manager','Receptionist','Stylist','Customer') NOT NULL,
 salt CHAR(32) NOT NULL, password_hash CHAR(64) NOT NULL,
 customer_id INT UNIQUE, active TINYINT NOT NULL DEFAULT 1,
 failures INT NOT NULL DEFAULT 0, locked_until DATETIME,
 FOREIGN KEY(customer_id) REFERENCES customers(id)
);
CREATE TABLE IF NOT EXISTS branches (
 id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL UNIQUE,
 address VARCHAR(160) NOT NULL, phone VARCHAR(24) NOT NULL, tax_rate DECIMAL(5,2) NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS staff (
 id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL, phone VARCHAR(24) NOT NULL UNIQUE,
 branch_id INT NOT NULL, user_id INT UNIQUE, commission DECIMAL(5,2) NOT NULL DEFAULT 0,
 FOREIGN KEY(branch_id) REFERENCES branches(id), FOREIGN KEY(user_id) REFERENCES users(id)
);
CREATE TABLE IF NOT EXISTS services (
 id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL UNIQUE,
 category VARCHAR(80) NOT NULL, price DECIMAL(12,2) NOT NULL, minutes INT NOT NULL,
 active TINYINT NOT NULL DEFAULT 1
);
CREATE TABLE IF NOT EXISTS appointments (
 id INT AUTO_INCREMENT PRIMARY KEY, customer_id INT NOT NULL, staff_id INT NOT NULL,
 service_id INT NOT NULL, start_at DATETIME NOT NULL, end_at DATETIME NOT NULL,
 price DECIMAL(12,2) NOT NULL,
 status ENUM('Booked','Confirmed','Checked in','In service','Completed','Cancelled','No-show') NOT NULL,
 INDEX(staff_id,start_at),
 FOREIGN KEY(customer_id) REFERENCES customers(id), FOREIGN KEY(staff_id) REFERENCES staff(id),
 FOREIGN KEY(service_id) REFERENCES services(id)
);
CREATE TABLE IF NOT EXISTS queue (
 id INT AUTO_INCREMENT PRIMARY KEY, customer_id INT NOT NULL, service_id INT NOT NULL,
 staff_id INT, arrived_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
 status ENUM('Waiting','In service','Completed','Cancelled') NOT NULL DEFAULT 'Waiting',
 FOREIGN KEY(customer_id) REFERENCES customers(id), FOREIGN KEY(service_id) REFERENCES services(id),
 FOREIGN KEY(staff_id) REFERENCES staff(id)
);
CREATE TABLE IF NOT EXISTS products (
 id INT AUTO_INCREMENT PRIMARY KEY, sku VARCHAR(50) NOT NULL UNIQUE, name VARCHAR(100) NOT NULL,
 kind ENUM('Retail','Professional') NOT NULL, price DECIMAL(12,2) NOT NULL,
 quantity INT NOT NULL DEFAULT 0, reorder_level INT NOT NULL DEFAULT 0,
 CHECK(quantity >= 0)
);
CREATE TABLE IF NOT EXISTS expenses (
 id INT AUTO_INCREMENT PRIMARY KEY, branch_id INT NOT NULL, category VARCHAR(80) NOT NULL,
 description VARCHAR(160) NOT NULL, amount DECIMAL(12,2) NOT NULL, spent_on DATE NOT NULL,
 FOREIGN KEY(branch_id) REFERENCES branches(id)
);
CREATE TABLE IF NOT EXISTS promotions (
 id INT AUTO_INCREMENT PRIMARY KEY, code VARCHAR(40) NOT NULL UNIQUE,
 discount DECIMAL(5,2) NOT NULL, starts_on DATE NOT NULL, ends_on DATE NOT NULL
);
CREATE TABLE IF NOT EXISTS bills (
 id INT AUTO_INCREMENT PRIMARY KEY, customer_id INT NOT NULL, appointment_id INT UNIQUE,
 branch_id INT NOT NULL, created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
 subtotal DECIMAL(12,2) NOT NULL, discount DECIMAL(12,2) NOT NULL,
 tax DECIMAL(12,2) NOT NULL, total DECIMAL(12,2) NOT NULL,
 voided TINYINT NOT NULL DEFAULT 0,
 FOREIGN KEY(customer_id) REFERENCES customers(id), FOREIGN KEY(appointment_id) REFERENCES appointments(id),
 FOREIGN KEY(branch_id) REFERENCES branches(id)
);
CREATE TABLE IF NOT EXISTS bill_items (
 id INT AUTO_INCREMENT PRIMARY KEY, bill_id INT NOT NULL, product_id INT, service_id INT,
 item_name VARCHAR(100) NOT NULL, quantity INT NOT NULL, price DECIMAL(12,2) NOT NULL,
 FOREIGN KEY(bill_id) REFERENCES bills(id), FOREIGN KEY(product_id) REFERENCES products(id),
 FOREIGN KEY(service_id) REFERENCES services(id)
);
CREATE TABLE IF NOT EXISTS payments (
 id INT AUTO_INCREMENT PRIMARY KEY, bill_id INT NOT NULL, amount DECIMAL(12,2) NOT NULL,
 method ENUM('Cash','Mobile money','Card') NOT NULL, reference VARCHAR(100),
 paid_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
 FOREIGN KEY(bill_id) REFERENCES bills(id)
);
CREATE TABLE IF NOT EXISTS audit_log (
 id INT AUTO_INCREMENT PRIMARY KEY, user_id INT NOT NULL, action VARCHAR(90) NOT NULL,
 details TEXT NOT NULL, recorded_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
 FOREIGN KEY(user_id) REFERENCES users(id)
);

-- Sample data for the classroom. Re-running this file preserves existing records.
INSERT IGNORE INTO users (id,name,email,phone,role,salt,password_hash) VALUES
 (1,'Salon Owner','owner@salonflow.local','0780000001','Owner','b624139e10edc165fbe829f43bf4743a','47dba43174a55f3d57e63dab8515866fdfaf0d60fab5b7065d21105f3ec2aaaa');
INSERT IGNORE INTO branches (id,name,address,phone) VALUES (1,'Kigali Main Branch','Kigali','0780000002');
INSERT IGNORE INTO customers (id,name,phone,email) VALUES (1,'Aline Mukamana','0780000003','aline@example.test');
INSERT IGNORE INTO staff (id,name,phone,branch_id,commission) VALUES (1,'Claude Niyonsenga','0780000004',1,15);
INSERT IGNORE INTO services (id,name,category,price,minutes) VALUES
 (1,'Haircut','Hair',5000,30),(2,'Hair wash','Hair',3000,25),(3,'Manicure','Nails',8000,45);
INSERT IGNORE INTO products (id,sku,name,kind,price,quantity,reorder_level) VALUES
 (1,'SH-01','Shampoo','Retail',7000,10,3);
