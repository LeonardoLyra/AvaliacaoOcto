// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery(document).ready(function ($) {
    $('#masc-data').mask('00/00/0000');
    $('#masc-cep').mask('00000-000');
    $('#masc-telefone').mask('(00) 0000-0000');
    $('#masc-celular').mask('(00) 0 0000-0000');
    $('#masc-cpf').mask('000.000.000-00', { reverse: true });
    $('#masc-cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('#masc-dinheiro').mask('000.000.000.000.000,00', { reverse: true });
 });