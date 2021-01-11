# PracticeXUnit.UITest
Practica #1

> Validar el envio de un formulario
* ingresar a la pagina https://demoqa.com/automation-practice-form
* ingresar valores para nombre, apellido, email, telefono y subject
* Presentar el formulario
* Validar los valores insertados en el formulario
> Para evaluar:
- Aplicacion del framework
- Inicializacion de los atributos propios de un framework
- limpiza de cookies
- validacion de errores
- tomar screenshots
- validacion por screenshots
- aplicar wait dinamico
- Aplicar POM
- aplicar el uso de un solo driver para todos los test cases
- implementar POM
- implementar manejo de errores

Practica #2
> Validar un producto en el carro de compras
- ingresar a https://www.theteastory.co/
- Seleccionar Classic Blends Assoted Tea Box collection
- agregar al carrito de compras 3 productos
- Presionar en el boton View Cart
- Validar que el producto y la cantidad selecciona es la correcta

Practica #3
> Validar que el usuario creado se muestre en la lista de empleados
  * ingresar a https://orangehrm-demo-6x.orangehrmlive.com/client/#/dashboard Utilizar (Use: user: admin passw: admin123)
  * Click on PIM option
  * Click on Add employee
  * Fill the form with valid values and click on Next button (only required fields)
  * Complete Wizard Personal Details with valid values (only required fields) and click on Next button
  * Fill Wizard job with valid values (only required fields) and click on Save button
  * Click on Employee list
  * Verify that the created employee is displayed on employee list.

> Validar que el dropdown de status contiene la opcion divorciado al agregar un empleado
* ingresar a https://orangehrm-demo-6x.orangehrmlive.com/client/#/dashboard Utilizar (Use: user: admin passw: admin123)
  * Click on PIM option
  * Click on Add employee
  * Fill the form with valid values and click on Next button (only required fields)
  * Verify that Marital Status dropdown contains Divorced option.
	
> Validar que el boton Save es mostrado
* ingresar a https://orangehrm-demo-6x.orangehrmlive.com/client/#/dashboard Utilizar (Use: user: admin passw: admin123)
  * Click on PIM option
  * Click on Add employee
  * Verify if Save button is displayed.
  
Practica #4
> Create tables to store data for customer entity with the following fields
* Crear tablas con la siguiente estructura:
Table: Client,  table preferences
firstName, lastName, email, programme, courses
"firstName" : "Silver"
"latName" : "white"
"email" : "whitestripes@gmail.com"
"programme" : "Modern music"
preferences: "butter", "peanut"

* crear metodos para realizar las siguiente operaciones
- GET all clients
- GET a client by Id
- Delete a client by Id
- Update a client by ID
- Insert a client

Practica #5
> Crear un test case que verifique si dado un numero, este tiene mas de dos factores primos (incluido el numero 1)

> Crear test method para verificar los siguientes valores desde el webAPI
- Obtener el primer estudiante
- Crear un nuevo estudiante
- Actualizar el correo del primer estudiante
* Metodos soportados por el API
- GET /Student/list
- GET /student/{id}
- POST /student
- PUT /student/{id}
> Validar que el formulario de contacto se envio
* ingresar a https://www.theteastory.co/
* llenar el formualrio de Contact Us
* Verificar que el mensaje "We'll get back to you shortly" es mostrado
