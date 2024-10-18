using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;

namespace FakeXrmEasy.FakeMessageExecutors
{
    public class UpdateMultipleRequestExecutor : IFakeMessageExecutor
    {
        public bool CanExecute(OrganizationRequest request)
        {
            return request is UpdateMultipleRequest;
        }

        public OrganizationResponse Execute(OrganizationRequest request, XrmFakedContext ctx)
        {
            var updateRequest = (UpdateMultipleRequest)request;
            var service = ctx.GetOrganizationService();
            foreach(var record in updateRequest.Targets.Entities)
            {
                service.Update(record);
            }

            return new UpdateMultipleResponse()
            {
                ResponseName = "UpdateMultiple",
                Results = new ParameterCollection { }
            };
        }

        public Type GetResponsibleRequestType()
        {
            return typeof(UpdateMultipleRequest);
        }
    }
}