using MyWebApi.Models;
using MyWebApi.Models.DTOs;

namespace MyWebApi.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherResponse>> GetAllTeachersAsync();
        Task<TeacherResponse?> GetTeacherByIdAsync(int id);
        Task<TeacherResponse> CreateTeacherAsync(TeacherRequest request);
        Task<TeacherResponse?> UpdateTeacherAsync(int id, TeacherRequest request);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
