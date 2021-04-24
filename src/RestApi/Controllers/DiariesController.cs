// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Requests.Diaries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("diaries")]
    public class DiariesController : ControllerBase
    {
        #region Dependencies

        private readonly IMediator _mediator;

        #endregion

        #region Constructors

        public DiariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<DiaryEntryDto>> GetAll()
        {
            return _mediator.Send(new GetAllDiariesRequest());
        }

        #endregion
    }
}
