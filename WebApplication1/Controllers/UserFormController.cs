using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFormController : ControllerBase
    {
        public readonly IFormService _formService;
        public readonly IUserFormService _userFormService;

        public UserFormController(IFormService formService, IUserFormService userFormService)
        {
            _formService = formService;
            _userFormService = userFormService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFormById(string id)
        {
            UserForm userFillForm = new UserForm();

            var result = await _formService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            userFillForm.AddMetadata("id", result.Id);
            userFillForm.AddMetadata("title", result.Title);
            userFillForm.AddMetadata("description", result.Description);
            userFillForm.AddMetadata("firstName", null);
            userFillForm.AddMetadata("lastName", null);
            userFillForm.AddMetadata("email", null);

            if (result.Phone.IsHide == false)
            {
                userFillForm.AddMetadata("phone", null);
            }
            if (result.Nationality.IsHide == false)
            {
                userFillForm.AddMetadata("nationality", null);
            }
            if (result.Residence.IsHide == false)
            {
                userFillForm.AddMetadata("residence", null);
            }
            if (result.IdNumber.IsHide == false)
            {
                userFillForm.AddMetadata("IdNumber", null);
            }
            if (result.DOB.IsHide == false)
            {
                userFillForm.AddMetadata("dob", null);
            }
            if (result.Gender.IsHide == false)
            {
                userFillForm.AddMetadata("gender", null);
            }

            return Ok(userFillForm.GetAllMetadata());
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserForm userForm)
        {
            userForm.Id = Guid.NewGuid().ToString();
            var result = await _userFormService.Add(userForm);

            return Ok(result);
        }
    }
}
