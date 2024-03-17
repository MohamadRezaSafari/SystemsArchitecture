using MediatR;

namespace Application.Students.Commands;

public class CreateStudentCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Standard { get; set; }
    public int Rank { get; set; }
}
