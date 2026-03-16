using MyWebApi.Models;
using MyWebApi.Models.DTOs;
using MyWebApi.Repositories;

namespace MyWebApi.Services.Impl
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<TeacherResponse>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(MapToResponse);
        }

        public async Task<TeacherResponse?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return teacher != null ? MapToResponse(teacher) : null;
        }

        public async Task<TeacherResponse> CreateTeacherAsync(TeacherRequest request)
        {
            var teacher = new Teacher
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Subject = request.Subject,
                Qualification = request.Qualification,
                JoiningDate = request.JoiningDate,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            var createdTeacher = await _teacherRepository.AddAsync(teacher);
            return MapToResponse(createdTeacher);
        }

        public async Task<TeacherResponse?> UpdateTeacherAsync(int id, TeacherRequest request)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
                return null;

            teacher.Name = request.Name;
            teacher.Email = request.Email;
            teacher.Phone = request.Phone;
            teacher.Subject = request.Subject;
            teacher.Qualification = request.Qualification;
            teacher.JoiningDate = request.JoiningDate;
            teacher.IsActive = request.IsActive;
            teacher.UpdatedAt = DateTime.UtcNow;

            await _teacherRepository.UpdateAsync(teacher);
            return MapToResponse(teacher);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
                return false;

            await _teacherRepository.DeleteAsync(teacher);
            return true;
        }

        private TeacherResponse MapToResponse(Teacher teacher)
        {
            return new TeacherResponse
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Subject = teacher.Subject,
                Qualification = teacher.Qualification,
                JoiningDate = teacher.JoiningDate,
                IsActive = teacher.IsActive,
                CreatedAt = teacher.CreatedAt,
                UpdatedAt = teacher.UpdatedAt
            };
        }
    }
}
