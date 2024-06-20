-- Tabla de Categorías
CREATE TABLE Categorias
(
    CategoriaID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX)
);

-- Tabla de Imagenes
CREATE TABLE Imagenes
(
    ImagenID INT PRIMARY KEY IDENTITY,
    Imagen VARCHAR(2083) NOT NULL,
    NameImagen VARCHAR(255) NOT NULL
);

-- Tabla de Productos
CREATE TABLE Productos
(
    ProductoID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio > 0),
    CategoriaID INT NOT NULL,
    ImagenID INT NOT NULL,
    Stars INT NOT NULL CHECK (Stars >= 0 AND Stars <= 5),
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID),
    FOREIGN KEY (ImagenID) REFERENCES Imagenes(ImagenID)
);

-- Tabla de Inventario
CREATE TABLE Inventario
(
    InventarioID INT PRIMARY KEY IDENTITY,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Insertar datos

insert into Categorias
    (Nombre, Descripcion)
values
    ('Running', 'Zapatos deportivos para correr'),
    ('Shorts', 'Pantalones cortos');

insert into Imagenes
    (Imagen, NameImagen)
values
    ('zapatillas_running_supernova_rise_rojo.jpg', 'zapatillas de running supernova rise'),
    ('zapatillas_running_blanco_standard.jpg', 'zapatillas de running 4dfwd x strung 4d');


insert into Productos
    (Nombre, Descripcion, Precio, CategoriaID, ImagenID, Stars)
values
    ('zapatillas de running supernova rise', 'Para pies delgados recomendamos comprar el talle inferior', 169999.00, 1, 1, 3),
    ('zapatillas de running 4dfwd x strung 4d', 'Para pies delgados recomendamos comprar el talle inferior',378999.00, 1, 2, 4);


