using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class MotoRequestSample : IExamplesProvider<MotoEntity>
    {
        public MotoEntity GetExamples()
        {
            return new MotoEntity
            {
                IdMoto = 1,
                Modelo = "Honda CG 160",
                Placa = "ABC-1234",
                Chassi = "1H9AB34E56FGH789",
                IotInfo = "Active",
                RfidTag = "RFID12345",
                Localizacao = "São Paulo - SP",
                StatusAtual = "Disponível",
                IdFilial = "Filial01",
                UsuarioId = 1,
                //MotoLogId = 1001,
                FilialId = 1
            };
        }
    }
}
