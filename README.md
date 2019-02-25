# Nash
A simple project implementing .Net Core 2.1 + Angular 7 + SignalR

Pasos para correr la aplicación

1- Ejecute el proyecto Nash-Backend
   la aplicación se ejecutara en el puerto http://localhost:5001/ 
   
2- Probar los endpoints
   Se recomienda el uso de la herramienta postman para consultar los endpoints
   http://localhost:5001/cotizacion/euro
   http://localhost:5001/cotizacion/real
   http://localhost:5001/cotizacion/dolar
   
   las peticiones son de tipo get
   
3- dashboard en angular
   1er paso - Ejecutar el backend
   2do paso - Ejecutar el frontend usando ng serve --open en una cmd dentro de la carpeta Nash-FrontEnd
   la pantalla se refresca cada 5 segundos, para ver las llamadas simplemente presione f12 y seleccione la pestana consola.
   Cabe destacar que los montos expresados en la gráfica y en las respuesta son en pesos Argentinos, por ejemplo la cotización del dolar es 35.5 ARS... 

Saludos!!
