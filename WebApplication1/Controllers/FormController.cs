using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class FormController : ControllerBase
        {
            public readonly IFormService _employeeCreatedFormService;

            public FormController(IFormService employeeCreatedFormService)
            {
                _employeeCreatedFormService = employeeCreatedFormService;
            }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var sqlQuery = "SELECT * FROM c";
                var result = await _employeeCreatedFormService.Get(sqlQuery);
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(string id)
            {
                var result = await _employeeCreatedFormService.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Add(Form Form)
            {
                Form.Id = Guid.NewGuid().ToString();
                var result = await _employeeCreatedFormService.Add(Form);

                return Ok(result);
            }
            [HttpPut]
            public async Task<IActionResult> Update(Form Form)
            {
                var result = await _employeeCreatedFormService.Update(Form);
                return Ok(result);
            }
            [HttpDelete]
            public async Task<IActionResult> Delete(string id, string partition)
            {
                await _employeeCreatedFormService.Delete(id, partition);
                return Ok();
            }
        }
}
