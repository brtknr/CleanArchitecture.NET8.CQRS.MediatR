using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Plans.Queries.ListPlans
{
    public record ListPlansQuery() : IRequest<List<Plan>>;
    
}
