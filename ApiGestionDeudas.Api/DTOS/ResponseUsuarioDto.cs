namespace ApiGestionDeudas.Api.DTOS
{
    public class ResponseUsuarioDto
    {
        public Guid IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
