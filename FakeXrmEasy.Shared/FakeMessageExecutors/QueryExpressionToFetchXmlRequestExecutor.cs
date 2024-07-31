using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace FakeXrmEasy.FakeMessageExecutors
{
    public class QueryExpressionToFetchXmlRequestExecutor : IFakeMessageExecutor
    {
        public bool CanExecute(OrganizationRequest request)
        {
            return request is QueryExpressionToFetchXmlRequest;
        }

        public OrganizationResponse Execute(OrganizationRequest request, XrmFakedContext ctx)
        {
            var req = request as QueryExpressionToFetchXmlRequest;
            var service = ctx.GetOrganizationService();
            QueryExpressionToFetchXmlResponse response = new QueryExpressionToFetchXmlResponse();
            response["FetchXml"] = "FakeXRMEasy - Not implemented FetchXmlToQueryExpressionResponse";
            return response;
        }

        public Type GetResponsibleRequestType()
        {
            return typeof(QueryExpressionToFetchXmlRequest);
        }
    }
}
