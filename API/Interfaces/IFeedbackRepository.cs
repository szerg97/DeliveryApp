using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
        void DeleteFeedback(Feedback feedback);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
    }
}
