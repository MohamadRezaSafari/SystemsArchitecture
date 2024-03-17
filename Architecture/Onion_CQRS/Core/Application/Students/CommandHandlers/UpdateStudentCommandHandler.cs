using Application.Students.Commands;
using MediatR;

namespace Application.Students.CommandHandlers;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IAppDbContext context;

    public UpdateStudentCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

        if (student == null)
            return default;

        student.Name = command.Name;
        student.Standard = command.Standard;
        student.Rank = command.Rank;
        await context.SaveChangesAsync();
        return student.Id;
    }
}
