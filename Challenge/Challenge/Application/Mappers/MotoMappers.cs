using Challenge.Application.Dtos;
using Challenge.Domain.Models;

namespace Challenge.Application.Mappers
{
    public static class MotoMappers
    {
        public static MotoEntity ToMotoEntity(this MotoDto obj)
        {
            return new MotoEntity
            {
                Modelo = obj.modelo,
                Placa = obj.placa,
                Chassi = obj.chassi,
                StatusAtual = obj.StatusAtual


            };
        }
    }
}
