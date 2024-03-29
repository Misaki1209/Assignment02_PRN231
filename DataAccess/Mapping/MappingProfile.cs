using Entities.Dtos;
using Entities.Entity;
using Entities.RequestModels;

namespace DataAccess.Mapping;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>();
        
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
        CreateMap<AddPublisherRequest, Publisher>();
        
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<AddUserRequest, User>();
        
        CreateMap<BookAuthor, BookAuthorDto>();
        CreateMap<BookAuthorDto, BookAuthor>();
    }
}