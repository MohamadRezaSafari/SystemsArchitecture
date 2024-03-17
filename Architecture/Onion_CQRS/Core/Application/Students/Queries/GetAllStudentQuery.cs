using Domain;
using MediatR;

namespace Application.Students.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {

    }
}
