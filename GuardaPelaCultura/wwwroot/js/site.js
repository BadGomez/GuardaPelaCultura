// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DataMin(elemento) {
    var hoje = new Date();
    var dia = hoje.getDate();
    var mes = hoje.getMonth() + 1;
    var ano = hoje.getFullYear();
    var diaerro;

    if (dia < 10) {
        dia = '0' + dia
    }
    if (mes < 10) {
        mes = '0' + mes
    }

    hoje = ano + '-' + mes + '-' + dia;
    diaerro = dia + "/" + mes + "/" + ano;
    elemento.setAttribute("min", hoje);
    elemento.setAttribute("title", "Introduza uma data igual ou superior a " + diaerro);
}
