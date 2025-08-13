using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RepositoryInterfaces;
using Core.CQRS.Request;
using Core.CQRS.RequestHandler;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Domain.Entities;
using static Application.Handlers.Projects.Commands.CreateProjectCommandHandler;

namespace Application.Handlers.Projects.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandRequest, bool>
    {
        public class CreateProjectCommandRequest : IRequest<bool>
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _uow;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork uow)
        {
            _projectRepository = projectRepository;
            _uow = uow;
        }

        public async Task<bool> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken = default)
        {
            _projectRepository.Add(new Project()
            {
                Name = request.Name,
                Description = request.Description
            });
            _uow.Save();

            return true;
        }
    }
}
