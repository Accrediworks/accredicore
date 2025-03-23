using AutoMapper;
using Accredi.Books;

namespace Accredi;

public class AccrediApplicationAutoMapperProfile : Profile
{
    public AccrediApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
