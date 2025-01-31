﻿using AutoMapper;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.ExamModels;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ExamsApi.Application.Interfaces.ExamModels;

namespace ExamsApi.Application.Services.ExamModels
{
    public class ExamModelService : IExamModelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExamModelService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExamModelResponseDto> GetAsync(int id)
        {
            var exam = await _context.ExamModels.FindAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam Model Not Found");
            return _mapper.Map<ExamModelResponseDto>(exam);
        }

        public async Task<IEnumerable<ExamModelResponseDto>> GetAllAsync()
        {
            var exams = await _context.ExamModels.ToListAsync();
            return _mapper.Map<IEnumerable<ExamModelResponseDto>>(exams);
        }

        public async Task<ExamModelResponseDto> CreateAsync(CreateExamModelDto dto)
        {
            var exam = await _context.Exams.FindAsync(dto.ExamId);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            var examModel = _mapper.Map<ExamModel>(dto);
            _context.ExamModels.Add(examModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamModelResponseDto>(examModel);
        }
        public async Task<ExamModelResponseDto> UpdateAsync(int id, UpdateExamModelDto dto)
        {
            var examModel = await _context.ExamModels.FindAsync(id);
            if (examModel == null) throw new KeyNotFoundException("Exam Model not found");
            _mapper.Map(dto, examModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamModelResponseDto>(examModel);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var examModel = await _context.ExamModels.FindAsync(id);
            if (examModel == null) throw new KeyNotFoundException("Exam Model not found");
            _context.ExamModels.Remove(examModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
