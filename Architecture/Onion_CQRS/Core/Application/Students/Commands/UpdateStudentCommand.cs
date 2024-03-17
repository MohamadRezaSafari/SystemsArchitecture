using MediatR;

namespace Application.Students.Commands;

public class UpdateStudentCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Standard { get; set; }
    public int Rank { get; set; }
}
