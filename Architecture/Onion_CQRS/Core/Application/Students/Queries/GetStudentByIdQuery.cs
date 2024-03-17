using Domain;
using MediatR;

namespace Application.Students.Queries;

public class GetStudentByIdQuery : IRequest<Student>
{
    public int Id { get; set; }
}
