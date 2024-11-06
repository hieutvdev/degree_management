﻿using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.Period;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Period.Update;

public record UpdatePeriodCommand(UpdatePeriodRequest Request): ICommand<ResponseBase>;