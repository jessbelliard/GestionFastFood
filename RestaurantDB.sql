

CREATE TABLE Users (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    Password NVARCHAR(100),
    Rol NVARCHAR(50)
);

CREATE TABLE Mesas (
    MesaId INT PRIMARY KEY IDENTITY(1,1),
    NumeroPosiciones INT,
    Estado NVARCHAR(50),
    NumeroMesa INT
);

CREATE TABLE Productos (
    ProductoId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Precio DECIMAL(10, 2),
    Descripcion NVARCHAR(255)
);

CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    MesaID INT,
    Posicion INT,
    Estado NVARCHAR(50),
    FOREIGN KEY (MesaID) REFERENCES Mesas(MesaId)
);

CREATE TABLE PedidoProducto (
    PedidoID INT,
    ProductoID INT,
    Cantidad INT,
    PRIMARY KEY (PedidoID, ProductoID),
    FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoId)
);

CREATE TABLE Reservas (
    ReservaId INT PRIMARY KEY IDENTITY(1,1),
    MesaId INT,
    ClienteNombre NVARCHAR(100),
    FechaReserva DATETIME,
    Estado NVARCHAR(50),
    UsuarioID INT,
    FOREIGN KEY (MesaId) REFERENCES Mesas(MesaId),
    FOREIGN KEY (UsuarioID) REFERENCES Users(UsuarioID)
);

CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT,
    Total DECIMAL(10, 2),
    itbis DECIMAL(10, 2),
    Totalconimpuestos DECIMAL(10, 2),
    TipoFactura NVARCHAR(50),
    Estado NVARCHAR(50),
    FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID)
);
CREATE TABLE Pedido (
    PedidoID INT PRIMARY KEY IDENTITY,
    MesaID INT FOREIGN KEY REFERENCES Mesa(MesaID),
    Posicion INT NOT NULL,
    ProductoID INT FOREIGN KEY REFERENCES Producto(ProductoID),
    Cantidad INT NOT NULL,
    Estado NVARCHAR(20) NOT NULL
);

CREATE TABLE Factura (
    FacturaID INT PRIMARY KEY IDENTITY,
    PedidoID INT FOREIGN KEY REFERENCES Pedido(PedidoID),
    Total Decimal(10,2) NOT NULL,
	itbis decimal(10,2) NOT NULL,
	Totalconimpuestos decimal (10,2),
    TipoFactura NVARCHAR(20) NOT NULL, -- 'Individual' o 'Grupal'
    Estado NVARCHAR(20) NOT NULL
);




ALTER TABLE Reserva
ADD CONSTRAINT FK_Reserva_Usuario
FOREIGN KEY(UsuarioID) REFERENCES Users(UsuarioID);

ALTER TABLE Reserva
ADD UsuarioID INT;

ALTER TABLE Pedido
DROP COLUMN ProductoID;

ALTER TABLE Pedido
DROP CONSTRAINT FK__Pedido__Producto__44FF419A;


CREATE TABLE PedidoProducto (
PedidoID INT FOREIGN KEY REFERENCES Pedido(PedidoID),
ProductoID INT FOREIGN KEY REFERENCES Producto(ProductoID),
Cantidad INT NOT NULL,
PRIMARY KEY (PedidoID,ProductoID)
);


ALTER TABLE Mesa
ADD NumeroMesa INT NOT NULL; 
