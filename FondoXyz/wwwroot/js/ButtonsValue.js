//capturamos los valores de los inputs:
document.addEventListener("DOMContentLoaded", function() {
    const Tecladobtn = document.querySelectorAll('.teclado-boton'); // valor de los botones
const Documento =document.querySelectorAll('.numeroDocumento');  //valor del documento
const clave = document.querySelectorAll('clave'); //valor clave // Recordar función o usar Notaciones de datos para el requerimiento de 4 digitos

//funcion para validar los digitos
Tecladobtn.forEach(button => {
    button.addEventListener('click', fucntion () {
        const value = this.getAttribute('data-value'),
        if(value ){
            if(Documento.value === '')
            {
                Documento.value += value;
            } else {
                clave.value += value;
            }
        }
    });
});
//Limpiamos los datos 
document.getElementById('limpiar').addEventListener('click', fucntion (){
    Documento.value = '';
    clave.value = '';
});

 
}