using Catalog.API.Features.Courses.Create;
using Catalog.API.Features.Courses.Dtos;
using Catalog.API.Features.Courses.Update;

namespace Catalog.API.Features.Courses
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<UpdateCourseCommand, Course>();
        }
    }
}
