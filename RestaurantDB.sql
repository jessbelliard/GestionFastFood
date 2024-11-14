--ALTER TABLE nombre_tabla RENAME COLUMN nombre_columna_vieja to nombre_columna_nueva;

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


DELETE FROM Roles;

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
