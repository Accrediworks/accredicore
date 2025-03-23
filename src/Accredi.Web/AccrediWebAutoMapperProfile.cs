using AutoMapper;
using Accredi.Books;

namespace Accredi.Web;

public class AccrediWebAutoMapperProfile : Profile
{
    public AccrediWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        
        //Define your AutoMapper configuration here for the Web project.
    }
}
