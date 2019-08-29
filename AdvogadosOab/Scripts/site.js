$(function () {

    $('#buscar').on('click', function () {


        $('#alerta').show();

        $.ajax({
            url: "/Home/BuscaAdvogado",
            type: "get", 
            data: {
                inscricao: $('#inscricao').val(),
                uf: $('#uf').val(),
                nome: $('#nome').val()
            },
            success: function (response) {
                console.log(response);

                var trHTML = '';
                $.each(response, function (i, item) {
                    trHTML += '<tr><td>' + item.Inscricao + '</td><td>' + item.Nome + '</td><td>' + item.Organizacao + '</td><td>'+ item.Situacao + '</td></tr>';
                });
                $('#tabela-advogados').append(trHTML);              

            },
            error: function (xhr, error, eT) {
                
                console.log(xhr);
                var text = xhr.responseText;
                var erro = text.match("<title>(.*)</title>");

                $('#alerta').show();
                $('#alerta').html("Ocorreu um erro: ".concat(erro));               
                
            }
        });
    });

});