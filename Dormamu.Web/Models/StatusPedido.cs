namespace Dormamu.Web.Models
{
    public enum StatusPedido
    {
        Realizado = 0,
        Analise = 1,
        Aprovado = 2,
        Processando = 3, // Em processamento
        Encaminhado = 4,
        Entregue = 5,
        Cancelado = 6,
        ReembolsoSolicitado = 7,
        ProcessandoReembolso = 8,
        ReembolsoConcedido = 9
    }
}