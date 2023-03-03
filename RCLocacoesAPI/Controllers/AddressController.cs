﻿using com.raizen.PGC.Application.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Application.Interfaces;
using RCLocacoes.Application.Validator;
using RCLocacoes.Domain.Entities;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RCLocacoes.Api.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Address>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _addressService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Address>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterAddress([FromBody] AddressDto addressDto, [FromServices] IValidator<AddressDto> validator)
        {
            try
            {
                ValidationResult validationResult = validator.Validate(addressDto);

                if (!validationResult.IsValid)
                {
                    return ValidatorErrorResponse(validationResult.Errors);
                }

                var response = await _addressService.RegisterAddress(addressDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}