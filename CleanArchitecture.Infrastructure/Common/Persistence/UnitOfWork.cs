using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ExerciseRepository = new ExerciseRepository(db);
            MembershipRepository = new MembershipRepository(db);
            PlanRepository = new PlanRepository(db);
            WorkoutRepository = new WorkoutRepository(db);
        }

        public IExerciseRepository ExerciseRepository { get; private set; }
        public IMembershipRepository MembershipRepository { get; private set; }
        public IPlanRepository PlanRepository { get; private set; }
        public IWorkoutRepository WorkoutRepository { get; private set; }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

       
    }
}
