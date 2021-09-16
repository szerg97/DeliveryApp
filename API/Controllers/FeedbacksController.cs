using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Hubs;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FeedbacksController : BaseApiController
    {
        private  ApplicationDbContext _context;
        private readonly IFeedbackRepository _feedbackRepository;
        private IHubContext<FeedbackHub> _hub;

        public FeedbacksController(ApplicationDbContext context,
            UserManager<AppUser> userManager,
            IFeedbackRepository feedbackRepository,
            IHubContext<FeedbackHub> hub)
        {
            _context = context;
            _feedbackRepository = feedbackRepository;
            _hub = hub;
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedbacksToReturn = await _feedbackRepository.GetFeedbacksAsync();
            return Ok(feedbacksToReturn);
        }


        [Authorize(Roles = "Member")]
        [HttpPost("add-feedback")]
        public async Task<ActionResult<FeedbackDto>> AddFeedback(FeedbackDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Problem adding a feedback.");
            }

            Feedback feedback = new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Text = dto.Text,
                Value = dto.Value,
                CreatorId = dto.CreatorId,
                Solution = dto.Solution
            };

            //await _context.Feedbacks.AddAsync(feedback);
            //await _context.SaveChangesAsync();

            _feedbackRepository.AddFeedback(feedback);
            await _feedbackRepository.SaveAllAsync();

            await _hub.Clients.All.SendAsync("NewFeedback", feedback);

            return new FeedbackDto(){CreatorId = feedback.CreatorId, Text = feedback.Text, Value = feedback.Value, Solution = feedback.Solution};
        }
    }
}