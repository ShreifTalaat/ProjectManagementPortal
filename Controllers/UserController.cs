using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BLL.ModelViews;
using AutoMapper;
using DAL.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController:ControllerBase
    {
        

            private readonly IConfiguration _iconfiguration;
            private readonly IMapper _mapper;
            private readonly IUser _iUser;
            public UserController(
                 IConfiguration configuration
                , IMapper mapper
                , IUser iUser
                )
            {
                _iconfiguration = configuration;
                _mapper = mapper;
                _iUser = iUser;
            

            }


      


            [HttpGet]
            [Route("User/ListAll")]
            //[Authorize]
            public IActionResult ListAll()
            {
                ActionResult response = Unauthorized();
                var Data = _iUser.GetUsers();
                if (Data != null && Data.Count() > 0)
                {

                    response = Ok(new
                    {
                        Status = 1,
                        Data = _mapper.Map<List<UserMV>>(Data)
                    });

                }
                else
                {
                    response = Ok(new
                    {
                        Status = 0,
                        Data = _mapper.Map<List<UserMV>>(null)
                    });

                }
                return response;

            }      

            [HttpPost]
            [Route("User/Add")]
            //[Authorize]
            public IActionResult AddUpdate([FromBody] UserMV model)
            {
                ActionResult response = Unauthorized();
            
           

                  var  Result = _iUser.Add(_mapper.Map<User>(model));
              
                if (Result > 0)
                {
                    response = Ok(new
                    {
                        Status = 1,
                        Data = Result
                    });
                }
                else
                {
                    response = Ok(new
                    {
                        Status = 0,
                        Data = Result
                    });
                }
                return response;



            }
       
    }
}
