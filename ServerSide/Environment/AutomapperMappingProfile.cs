using AutoMapper;
using ServerSide.BLL.DTO;
using ServerSide.DAL.Models;

namespace ServerSide.Environment
{
    public class AutomapperMappingProfile : Profile
    {
        public AutomapperMappingProfile()
        {
            CreateMap<Todo, TodoDto>(); 
            CreateMap<TodoDto, Todo>();

            CreateMap<Attachment, AttachmentDto>();
            CreateMap<AttachmentDto, Attachment>();
        }
    }
}
