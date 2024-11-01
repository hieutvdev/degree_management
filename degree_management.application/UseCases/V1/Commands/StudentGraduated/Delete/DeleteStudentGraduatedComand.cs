﻿using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.StudentGraduated;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StudentGraduated.Delete;

public record DeleteStudentGraduatedComand(DeleteStudentGraduatedRequest Request) : ICommand<ResponseBase>;