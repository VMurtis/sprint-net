using Challenge.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Challenge.Doc.Samples
{
    public class MotoResponseListSample : IExamplesProvider<IEnumerable<MotoEntity>>
    {
        public IEnumerable<MotoEntity> GetExamples()
        {
            return new List<MotoEntity>
            {
                new MotoEntity
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
                },
                new MotoEntity
                {
                    IdMoto = 2,
                    Modelo = "Yamaha Fazer 250",
                    Placa = "XYZ-5678",
                    Chassi = "4K8AB34E56FGH012",
                    IotInfo = "Inativo",
                    RfidTag = "RFID67890",
                    Localizacao = "Rio de Janeiro - RJ",
                    StatusAtual = "Em Manutenção",
                    IdFilial = "Filial02",
                    UsuarioId = 2,
                    //MotoLogId = 1002,
                    FilialId = 2
                }
            };
        }
    }
}
