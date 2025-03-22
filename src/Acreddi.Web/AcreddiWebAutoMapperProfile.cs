using AutoMapper;
using Acreddi.Books;

namespace Acreddi.Web;

public class AcreddiWebAutoMapperProfile : Profile
{
    public AcreddiWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        
        //Define your AutoMapper configuration here for the Web project.
    }
}
