﻿using AutoMapper;
using com.raizen.PGC.Application.Models;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<List<Address>>> GetAll()
        {
            var response = new BaseOutput<List<Address>>();

            IEnumerable<Address> addresses = await _addressRepository.GetAsync();

            response.IsSuccessful = addresses.Any();
            response.Response = addresses.ToList();

            return response;
        }

        public async Task<BaseOutput<int>> RegisterAddress(AddressDto addressDto)
        {
            var response = new BaseOutput<int>();

            var addressMapped = _mapper.Map<Address>(addressDto);
            await _addressRepository.AddAsync(addressMapped);
            await _unitOfWork.CommitAsync();

            response.Response = addressMapped.Id;
            response.IsSuccessful = true;

            return response;
        }
    }
}