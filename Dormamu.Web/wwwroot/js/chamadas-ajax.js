

function adicionarItemCarrinho(id_produto, quantidade) {
    $.ajax({
        url: "~/Carrinho/AdicionarItemCarrinho",
        method: "GET",
        dataType: "json"
        params: {
            produtoID: id_produto,
            quantidade: quantidade
        },
        success: aviso(response.mensagem),
        error: aviso(response.mensagem)
    });
}