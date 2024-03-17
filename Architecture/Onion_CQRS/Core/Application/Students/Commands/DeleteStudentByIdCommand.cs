using MediatR;

namespace Application.Students.Commands;

public class DeleteStudentByIdCommand : IRequest<int>
{
    public int Id { get; set; }
}