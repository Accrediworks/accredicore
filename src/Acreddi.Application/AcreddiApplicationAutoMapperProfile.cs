using AutoMapper;
using Acreddi.Books;

namespace Acreddi;

public class AcreddiApplicationAutoMapperProfile : Profile
{
    public AcreddiApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
