namespace EloGroupBack.Models.Dto
{
    public class ResponseDto
    {
        public string Metodo { get; set; }

        public ResultadoResponse Resutado { get; set; }

        public object Payload { get; set; }

        public ResponseDto(string metodo, ResultadoResponse resutado, object payload)
        {
            Metodo = metodo;
            Resutado = resutado;
            Payload = payload;
        }

        public ResponseDto()
        {
            
        }
    }
}