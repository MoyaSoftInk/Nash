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
   por los momentos no se cargan los datos de las cotizaciones, sin embargo la tecnología SignalR está implementada, si ejecuta el proyecto
   frontend (el backend debe estar levantado de lo contrario no funcionará) visualizará como interactua en tiempo real con fakedata. Solo hay que pasarle los datos
   de las tres cotizaciones y estaría listo. Por motivos agenos tuve que salir de mi estación de trabajo, al regresar puedo terminarlo, por favor si están de acuerdo
   pueden comunicarse conmigo, pido disculpas por ello.
   
Saludos!!
