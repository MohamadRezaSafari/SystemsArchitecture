using Application.Students.Queries;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.QueryHandlers;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IAppDbContext context;

    public GetStudentByIdQueryHandler(IAppDbContext context)
    {
        this.context = context;
    }

    public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
    {
        var student = await context.Students.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
        if (student == null) return null;
        return student;
    }
}
