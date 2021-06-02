// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Requests.Diaries;
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
        public async Task<IActionResult> GetAllDiaries()
        {
            var diaries = await _mediator.Send(new GetAllDiariesRequest());
            return Ok(diaries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiary(Guid? id)
        {
            var diary = await _mediator.Send(new GetDiaryRequest(id));
            return Ok(diary);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDiary(DiaryDto diaryToAdd)
        {
            var addedDiary = await _mediator.Send(new AddDiaryRequest(diaryToAdd.Title, diaryToAdd.Description));
            return CreatedAtAction(nameof(GetDiary), new { id = addedDiary.Id }, addedDiary);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDiary(Guid? id, DiaryDto diaryToUpdate)
        {
            var (_, title, description) = diaryToUpdate;
            var updatedDiary = await _mediator.Send(new UpdateDiaryRequest(id, title, description));
            return Ok(updatedDiary);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveDiary(Guid? id)
        {
            await _mediator.Send(new RemoveDiaryRequest(id));
            return Ok();
        }

        #endregion
    }
}
