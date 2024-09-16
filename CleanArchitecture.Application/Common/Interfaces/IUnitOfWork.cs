using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IExerciseRepository ExerciseRepository { get; }
        IMembershipRepository MembershipRepository { get; }
        IPlanRepository PlanRepository { get; }
        IWorkoutRepository WorkoutRepository { get; }
        void SaveAsync();
    }
}
