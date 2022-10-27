using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.IO;


/// <summary>
/// Base class on top of which AUTHENTICATED SESSION requests to Cloudbeds are based
/// </summary>
class CloudbedsAuthenticatedRequestBase : CloudbedsRequestBase
{
    private readonly ICloudbedsAuthSessionId _authenticatedSesssion;
    protected CloudbedsAuthenticatedRequestBase(ICloudbedsAuthSessionId authSession, TaskStatusLogs statusLogs) : base (statusLogs)
    {
        _authenticatedSesssion = authSession;
    }

    /// <summary>
    /// Add a authorization header...
    /// </summary>
    /// <param name="httpMethod"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    protected override HttpRequestMessage Internal_CreateHttpRequest(string httpMethod, string uri)
    {
        var httpRequest = base.Internal_CreateHttpRequest(httpMethod, uri);

        httpRequest.Headers.Add(
            "Authorization",
            "Bearer " + _authenticatedSesssion.AuthSessionsId);
        return httpRequest;
    }
}
