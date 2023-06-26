using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF_NET_Angular_RCD_Bibliotheque.BLL.Services;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerFormDTO customer)
        {
            try
            {
                return Ok(_customerService.Add(customer));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetMany()
        {
            return Ok(_customerService.GetMany());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            try
            {
                return Ok(_customerService.GetOne(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CustomerFormDTO customer)
        {
            try
            {
                if(_customerService.Update(id, customer))
                {
                    return Ok();
                }
                return BadRequest("La MAJ a echoué");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (_customerService.Delete(id))
                {
                    return Ok();
                }
                return BadRequest("La suppresion a echoué");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
