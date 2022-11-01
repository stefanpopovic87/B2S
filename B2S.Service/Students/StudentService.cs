﻿using B2S.Contract.Courses;
using B2S.Contract.Students;
using B2S.Infrastructure.Domain;
using B2S.Model.Courses;
using B2S.Model.Students;
using B2S.Repository;

namespace B2S.Service.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentQuery _studentQuery;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, 
            IStudentQuery studentQuery,
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _studentQuery = studentQuery;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(StudentSearchDto studentSearch)
        {
            return await _studentQuery.GetAllAsync(studentSearch);
        }

        public async Task CreateStudentAsync(CreateStudentDto createStudent)
        {
            var student = new Student
            {
                FirstName = createStudent.FirstName,
                LastName = createStudent.LastName,
                Email = createStudent.Email             
            };

            student.Create();

            await _studentRepository.InsertAsync(student);

            await _unitOfWork.CommitAsync();
        }
    }
}
