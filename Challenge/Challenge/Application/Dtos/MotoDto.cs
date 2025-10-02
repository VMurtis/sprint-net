using Challenge.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Application.Dtos
{
    public record MotoDto(string modelo,string placa, string chassi, string StatusAtual)
    {
        public MotoEntity ToMotoEntity()
        {
            return new MotoEntity
            {
                Modelo = modelo,
                Placa = placa,
                Chassi = chassi,
                StatusAtual = StatusAtual
                
            };
        }
    }
}

