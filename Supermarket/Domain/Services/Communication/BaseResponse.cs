namespace Supermarket.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        // Classe abstrata que será herdada pelos tipos de resposta da API

        // Success informa que as solicitações foram concluídas com sucesso
        public bool Success { get; set; }
        // Message informa a mensagem de erro caso a solicitação falhe
        public string Message { get; set; }

        public BaseResponse(bool success, string message) 
        {
            Success = success;
            Message = message;
        }
    }
}
