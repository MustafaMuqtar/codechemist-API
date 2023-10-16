﻿using codechemist.Models;
using codechemist.Models.ViewModels;

namespace codechemist.Data.IRepository
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Lesson> GetByIdAsync(int id);

        Task AddAsync(LessonVM data);

        Task DeleteByIdAsync(int id);

        //  Task<Technology> UpdateByIdAsync(int id, Lesson data);
    }
}
