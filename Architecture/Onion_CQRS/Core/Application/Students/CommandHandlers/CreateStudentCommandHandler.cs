using MediatR;
using Domain;

namespace Application.Students.Commands;


public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IAppDbContext context;

    public CreateStudentCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    public async Task<int> Handle(
        CreateStudentCommand command,
        CancellationToken cancellationToken)
    {
        var student = new Student();
        student.Name = command.Name;
        student.Standard = command.Standard;
        student.Rank = command.Rank;

        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student.Id;
    }
}

