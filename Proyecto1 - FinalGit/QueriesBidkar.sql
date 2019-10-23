CREATE TABLE Products
(
    Product_ID int NOT NULL Identity,
    ProducCategory varchar(255),
    ProductName varchar(255) NOT NULL,
    ProductDescription varchar(255),
    Price int NOT NULL,
    PRIMARY KEY (Produc_ID)
);

Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Sonido', 'Radio Sankey 4568', 'Radio para vehiculos Sankey Modl-4568', 75000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Video', 'Pantalla LCD 5"', 'Pantalla LCD para vehiculos', 25000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Energia', 'Bateria de vehiculo Rayobac', 'Bataria de vehiculo', 69500);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Seguridad', 'Alarma vehiculo', 'Alarma para vehiculos', 125000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Seguridad', 'GPS SecureTronic', 'GPS para vehiculo', 85000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Exterior', 'Rack CycleFast', 'Rack tipo canasta para bicicletas', 250000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Interior', 'Tapete CarBeauty', 'Tapete para vehiculos', 25000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Partes', 'LLantas 17"', 'LLantas para vehiculos', 125000);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Partes', 'Aros 17" Racing', 'Aros 17" marca RAcing', 65500);
Insert INTO dbo.Products
    (ProductCategory,ProductName,ProductDescription,price)
values
    ('Sonido', 'Radio Paywood 56', 'Radio para vehiculos Paywood model 56', 95000);