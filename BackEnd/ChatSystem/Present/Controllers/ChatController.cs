using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Present.Common;
using Present.Data;
using Present.Models;
using Present.Repository.Implement;
using Present.Repository.Interface;
using System;
using System.Data;

namespace Present.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController : ControllerBase
    {
        private readonly IChatRepository chatRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public ChatController(IChatRepository chatRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            this.chatRepository = chatRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }


        //[HttpPost("SendMessage")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> SendMessage(ChatModel chatModel)
        //{
        //    var chat = _mapper.Map<Chat>(chatModel);

        //    var result = await chatRepository.CreateAsync(chat);

        //    if (result.Succeeded)
        //    {
        //        return Ok(result);

        //    }
        //    var error = result.Errors.FirstOrDefault();
        //    return new BadRequestObjectResult(new { errorMessage = error.Description });
        [Authorize]

        [HttpGet("GetMessage")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMessage(string userId)
        {

          
            try
            {
               
                
                var chats = await chatRepository.GetMessageOfUser(userId);
                var chatmodels = await chats.ToListAsync();
                var result= _mapper.Map<List<ChatModel>>(chatmodels);
                ;
            
                return Ok(result);

             
            }catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [Authorize]
        [HttpGet("MyProtectedResource")]
        public IActionResult MyProtectedResource()
        {
            return Ok("ok login");
        }
    }
}
