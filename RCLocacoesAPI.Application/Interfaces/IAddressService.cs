using com.raizen.PGC.Application.Models;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Interfaces
{
    public interface IAddressService
    {
        Task<BaseOutput<List<Address>>> GetAll();
        Task<BaseOutput<int>> RegisterAddress(AddressDto addressDto);
    }
}