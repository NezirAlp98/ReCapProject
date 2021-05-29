using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardPaymentsController : ControllerBase
    {
        private ICardPaymentService _cardPaymentService;

        public CardPaymentsController(ICardPaymentService cardPaymentService)
        {
            _cardPaymentService = cardPaymentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardPaymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cardPaymentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getallbycustomerid")]
        public IActionResult GetAllByCustomerId(int customerId)
        {
            var result = _cardPaymentService.GetAllByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]

        public IActionResult Add(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Add(cardPayment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Delete(cardPayment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
