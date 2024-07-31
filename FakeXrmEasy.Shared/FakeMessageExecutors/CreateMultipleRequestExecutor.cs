using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;

namespace FakeXrmEasy.FakeMessageExecutors
{
    public class CreateMultipleRequestExecutor : IFakeMessageExecutor
    {
        public bool CanExecute(OrganizationRequest request)
        {
            return request is CreateMultipleRequest;
        }

        public OrganizationResponse Execute(OrganizationRequest request, XrmFakedContext ctx)
        {
            var createRequest = (CreateMultipleRequest)request;
            var guids = new List<Guid>();
            var service = ctx.GetOrganizationService();
            foreach(var record in createRequest.Targets.Entities)
            {
                guids.Add(service.Create(record));
            }

            return new CreateMultipleResponse()
            {
                ResponseName = "CreateMultiple",
                Results = new ParameterCollection { { "ids", guids.ToArray() } }
            };
        }

        public Type GetResponsibleRequestType()
        {
            return typeof(CreateMultipleRequest);
        }
    }
}