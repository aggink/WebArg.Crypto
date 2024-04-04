﻿using Aggink.Crypto.Logic.DtoModels;
using Aggink.Crypto.Logic.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aggink.Crypto.Web.Features.Queries;

public sealed class GetMessageWithCertificateQuery : IRequest<CertificateMessageDto>
{
    [Required]
    [FromBody]
    public string Key { get; set; }
}

public sealed class GetMessageWithCertificateQueryHandler : IRequestHandler<GetMessageWithCertificateQuery, CertificateMessageDto>
{
    private readonly IMemoryRepository _memoryRepository;

    public GetMessageWithCertificateQueryHandler(IMemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }

    public Task<CertificateMessageDto> Handle(GetMessageWithCertificateQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_memoryRepository.GetMessageWithCertificate(request.Key));
    }
}