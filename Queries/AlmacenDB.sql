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

insert into Imagenes
    (Imagen, NameImagen)
values
    ('zapatillas_running_switch_run_negro_standard.jpg', 'zapatillas running switch run'),
    ('zapatillas_pureboost_23_Blanco_01_standard.jpg', 'zapatillas pureboots 23'),
    ('zapatillas_duramo_azul_01_standard.jpg', 'zapatillas duramo sl');



insert into Productos
    (Nombre, Descripcion, Precio, CategoriaID, ImagenID, Stars)
values
    ('zapatillas de running supernova rise', 'Para pies delgados recomendamos comprar el talle inferior', 169999.00, 1, 1, 3),
    ('zapatillas de running 4dfwd x strung 4d', 'Para pies delgados recomendamos comprar el talle inferior', 378999.00, 1, 2, 4);


insert into Productos
    (Nombre, Descripcion, Precio, CategoriaID, ImagenID, Stars)
values
    ('zapatillas running switch run', 'ZAPATILLAS DE RUNNING LIVIANAS CON EXTERIOR DE MALLA Y AMARRE CON CORDONES.
Fusionando estilo con detalles que evitan las distracciones, la última colección de prendas básicas de running adidas te mantendrá luciendo tan bien como te sientes mientras corres. Para que puedas concentrarte en lo que más importa: divertirte con cada paso.

Amarrate las zapatillas de running Switch Run y disfrutá de una pisada con ritmo. Estas zapatillas están diseñadas para ofrecer un ajuste ligero y cuentan con la suela Adiwear y un refuerzo 3D en el talón para mayor estabilidad. El exterior de malla y el acolchado te garantizan máxima comodidad para tus pasos. Su exterior contiene al menos un 50% de materiales', 114999.00, 1, 3, 5),

('zapatillas pureboots 23', 'ZAPATILLAS DE RUNNING DE ALTO RENDIMIENTO HECHAS PARCIALMENTE CON MATERIALES RECICLADOS
No importa si vas a correr o a hacer mandados por la ciudad, estas zapatillas Pureboost 23 te dan la amortiguación receptiva y la comodidad necesaria para enfrentarte a tu día. Su exterior de malla técnica optimiza el flujo de aire, mientras que la mediasuela BOOST completa proporciona comodidad al instante y un recorrido lleno de energía. Inspiradas en el diseño de las Ultraboost, estas zapatillas estilizadas brindan un retorno de energía que potencia tus pasos. La suela Stretchweb proporciona agarre en cualquier superficie, para que puedas ir de la carretera a la acera con facilidad. Ponete estas Pureboost y preparate para un recorrido inolvidable.

Este producto contiene al menos un 20% de material reciclado. Utilizando materiales reciclados reducimos los residuos, nuestra dependencia de los recursos finitos y la huella que generan los productos que fabricamos.', 189999.00, 1, 4, 4);

insert into Productos(Nombre,Descripcion,Precio,CategoriaID,ImagenID,Stars)
values('zapatillas duramo sl', 'ZAPATILLAS DE RUNNING VELOCES HECHAS PARCIALMENTE CON MATERIALES RECICLADOS
Sentí la ligereza y velocidad. Si estás listo para subir el ritmo y entrenar para distancias de hasta 10 kilómetros, estas zapatillas para correr de adidas te ayudarán en tus carreras con la máxima comodidad. Presentan una parte superior de monomalla ligera y una mediasuela LIGHTMOTION que te proporciona una gran estabilidad. En la pista o en asfalto, la suela Adiwear proporciona durabilidad y agarre.

Hecho con una serie de materiales reciclados, este exterior incorpora al menos un 50 % de contenido reciclado. Este producto representa solo una de nuestras soluciones para ayudar a poner fin a los residuos plásticos.',97999.00,1,5,4);


select * from dbo.Categorias;
select * from Productos WHERE CategoriaID = 1;


select C.Nombre, P.Nombre, P.Descripcion, I.Imagen, P.Precio
from Productos as P
    join Imagenes as I on P.ImagenID = I.ImagenID
    join Categorias as C on P.CategoriaID = C.CategoriaID
where C.CategoriaID = 1;
