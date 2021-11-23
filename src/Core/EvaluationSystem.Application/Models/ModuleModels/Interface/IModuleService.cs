using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Application.Models.ModuleModels.Interface
{
    public interface IModuleService
    {
        List<ModuleGetDto> GetAll();
        ModuleGetDto GetById(int id);
        void Delete(int id);
        ModuleGetDto Create(ModuleCreateDto model);
        ModuleGetDto Update(int id, ModuleCreateDto model);
        void AddQuestionToModule(int modulelId, int questionId, int position);
        void DeleteQuestionFromModule(int moduleId, int questionId);
        ModuleWithQuestionsDto GetModuleWithQuestions(int moduleId);
        void IsModuleExist(int moduleId);
    }
}
